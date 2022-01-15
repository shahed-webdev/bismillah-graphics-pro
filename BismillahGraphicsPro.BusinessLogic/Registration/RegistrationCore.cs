using AutoMapper;
using BismillahGraphicsPro.BusinessLogic;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace BismillahGraphicsPro.BusinessLogic.Registration
{
    public class RegistrationCore : Core, IRegistrationCore
    {
        private readonly UserManager<IdentityUser> _userManager;
        public RegistrationCore(IUnitOfWork db, IMapper mapper, UserManager<IdentityUser> userManager) : base(db, mapper)
        {
            _userManager = userManager;
        }

        public UserType UserTypeByUserName(string userName)
        {
            return _db.Registration.UserTypeByUserName(userName);
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

                if (!result.Succeeded) return new DbResponse<IdentityUser>(false, result.Errors.FirstOrDefault()?.Description, null, "CustomError");

                await _userManager.AddToRoleAsync(user, UserType.Admin.ToString()).ConfigureAwait(false);

                _db.Branch.AddWithRegistration(model);

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
    }
}