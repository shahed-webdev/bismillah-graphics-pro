using AutoMapper;
using BismillahGraphicsPro.Repository;
using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.BusinessLogic
{
    internal class MeasurementUnitCore:Core, IMeasurementUnitCore
    {
        public MeasurementUnitCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {

        }

        public DbResponse<MeasurementUnitCrudModel> Add(string measurementUnitName, string userName)
        {
            try
            {
               
                if (string.IsNullOrEmpty(measurementUnitName))
                    return new DbResponse<MeasurementUnitCrudModel>(false, "Invalid Data");
                
                var model = new MeasurementUnitCrudModel
                {
                    BranchId = _db.Registration.BranchIdByUserName(userName),
                    MeasurementUnitName = measurementUnitName
                };

                if (_db.MeasurementUnit.IsExistName(model.BranchId ,model.MeasurementUnitName))
                    return new DbResponse<MeasurementUnitCrudModel>(false, $" {model.MeasurementUnitName} already Exist");

                return _db.MeasurementUnit.Add(model);

            }
            catch (Exception e)
            {
                return new DbResponse<MeasurementUnitCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse Edit(MeasurementUnitCrudModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.MeasurementUnitName))
                    return new DbResponse(false, "Invalid Data");

                if (!_db.MeasurementUnit.IsNull(model.MeasurementUnitId))
                    return new DbResponse(false, "No Data Found");

                if (_db.MeasurementUnit.IsExistName(model.BranchId,model.MeasurementUnitName, model.MeasurementUnitId))
                    return new DbResponse(false, $" {model.MeasurementUnitName} already Exist");


                return _db.MeasurementUnit.Edit(model);

            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse Delete(int id)
        {
            try
            {
                if (!_db.MeasurementUnit.IsNull(id))
                    return new DbResponse(false, "No data Found");

                if (_db.MeasurementUnit.IsRelatedDataExist(id))
                    return new DbResponse(false, "Failed, already exist in products");

                return _db.MeasurementUnit.Delete(id);

            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse<MeasurementUnitCrudModel> Get(int id)
        {
            try
            {
                if (_db.MeasurementUnit.IsNull(id))
                    return new DbResponse<MeasurementUnitCrudModel>(false, "No data Found");

                return _db.MeasurementUnit.Get(id);

            }
            catch (Exception e)
            {
                return new DbResponse<MeasurementUnitCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public List<MeasurementUnitCrudModel> List(string userName)
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return _db.MeasurementUnit.List(branchId);
        }

        public List<DDL> ListDdl(string userName)
        {
            var branchId = _db.Registration.BranchIdByUserName(userName);
            return _db.MeasurementUnit.ListDdl(branchId);
        }
    }
}
