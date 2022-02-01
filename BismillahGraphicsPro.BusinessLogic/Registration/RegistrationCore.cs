using AutoMapper;
using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BismillahGraphicsPro.BusinessLogic.Registration
{
    public class RegistrationCore : Core, IRegistrationCore
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegistrationCore(IUnitOfWork db, IMapper mapper, UserManager<IdentityUser> userManager) : base(db,
            mapper)
        {
            _userManager = userManager;
        }

        public UserType UserTypeByUserName(string userName)
        {
            return _db.Registration.UserTypeByUserName(userName);
        }

        public bool IsBranchActive(string userName)
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return _db.Branch.IsBranchActive(branchId);
        }

        public DbResponse ToggleBranchActivation(int branchId)
        {
            try
            {
                var branchResponse = _db.Branch.Get(branchId);
                if (!branchResponse.IsSuccess) return new DbResponse(false, "Branch not found");
                if (branchResponse.Data.IsActive)
                {
                    _db.Branch.Deactivate(branchId);
                    return new DbResponse(true, $"{branchResponse.Data.BranchName} is deactivated");
                }
                else
                {
                    _db.Branch.Activate(branchId);
                    return new DbResponse(true, $"{branchResponse.Data.BranchName} is Activated");
                }
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public Task<DbResponse<BranchDetailsModel>> GetAsync(string userName)
        {
            try
            {
                var branchId = _db.Registration.BranchIdByUserName(userName);
                return Task.FromResult(_db.Branch.Get(branchId));
            }
            catch (Exception e)
            {
                return Task.FromResult(
                    new DbResponse<BranchDetailsModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
            }
        }

        public async Task<DbResponse<IdentityUser>> BranchSignUpAsync(BranchCreateModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.UserName))
                    return new DbResponse<IdentityUser>(false, "UserName or mobile number empty", null, "UserName");

                //Identity Create
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                var password = model.Password;

                var result = await _userManager.CreateAsync(user, password).ConfigureAwait(false);

                if (!result.Succeeded)
                    return new DbResponse<IdentityUser>(false, result.Errors.FirstOrDefault()?.Description, null,
                        "CustomError");

                await _userManager.AddToRoleAsync(user, UserType.Admin.ToString()).ConfigureAwait(false);

                _db.Branch.AddWithRegistration(model);

                return new DbResponse<IdentityUser>(true, "Success", user);
            }
            catch (Exception e)
            {
                return new DbResponse<IdentityUser>(false, e.Message);
            }
        }

        public Task<DbResponse> ResetAsync(string userName)
        {
            try
            {
                var branchId = _db.Registration.BranchIdByUserName(userName);
                return Task.FromResult(_db.Branch.Reset(branchId));
            }
            catch (Exception e)
            {
                return Task.FromResult(
                    new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}"));
            }
           
        }

        public async Task<DbResponse<IdentityUser>> SubAdminSignUpAsync(string userName, SubAdminCreateModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.UserName))
                    return new DbResponse<IdentityUser>(false, "Username or mobile number empty", null, "UserName");

                //Identity Create
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                var password = model.Password;

                var result = await _userManager.CreateAsync(user, password).ConfigureAwait(false);

                if (!result.Succeeded)
                    return new DbResponse<IdentityUser>(false, result.Errors.FirstOrDefault()?.Description, null,
                        "CustomError");

                await _userManager.AddToRoleAsync(user, UserType.SubAdmin.ToString()).ConfigureAwait(false);
                var branchId = _db.Registration.BranchIdByUserName(userName);

                _db.Branch.AddSubAdmin(model, branchId);

                return new DbResponse<IdentityUser>(true, "Success", user);
            }
            catch (Exception e)
            {
                return new DbResponse<IdentityUser>(false, e.Message);
            }
        }

        public List<BranchListModel> BranchList()
        {
            return _db.Branch.BranchList();
        }

        public List<SubAdminListModel> SubAdminList(string userName)
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return _db.Branch.SubAdminList(branchId);
        }

        public List<DDL> SubAdminDdl(string userName)
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return _db.Branch.SubAdminDdl(branchId);
        }

        public List<PageCategoryWithPageModel> SubAdminPageLinks(int registrationId)
        {
            return _db.Branch.SubAdminPageLinks(registrationId);
        }

        public async Task<DbResponse> SubAdminAssignLinks(int registrationId,List<PageLinkAssignModel> links)
        {
            try
            {
                if (registrationId == 0 || !links.Any())
                    return new DbResponse(false, "Data not found");

                var userNameResponse = _db.Branch.SubAdminAssignLinks(registrationId, links);
                if (!userNameResponse.IsSuccess) return new DbResponse(false, userNameResponse.Message);

                var user = await _userManager.FindByNameAsync(userNameResponse.Data);
                var roleList = links.Select(l => l.RoleName).ToList();

                roleList.Add("Sub-Admin");

                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles.ToArray());
                await _userManager.AddToRolesAsync(user, roleList.ToArray());

                return new DbResponse(true, "Success");
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public DbResponse SubAdminToggleActivation(int registrationId)
        {
            try
            {
                var branchResponse = _db.Branch.SubAdminGet(registrationId);
                if (!branchResponse.IsSuccess) return new DbResponse(false, "Branch not found");
                if (branchResponse.Data.Validation)
                {
                    _db.Branch.SubAdminDeactivate(registrationId);
                    return new DbResponse(true, $"{branchResponse.Data.UserName} is deactivated");
                }
                else
                {
                    _db.Branch.SubAdminActivate(registrationId);
                    return new DbResponse(true, $"{branchResponse.Data.UserName} is Activated");
                }
            }
            catch (Exception e)
            {
                return new DbResponse(false, e.Message);
            }
        }

        public bool IsSubAdminActive(string userName)
        {
            var registrationId = _db.Registration.RegistrationIdByUserName(userName);
            return _db.Branch.IsSubAdminActive(registrationId);
        }
    }
}