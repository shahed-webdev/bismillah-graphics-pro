using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.Repository;

public interface IMeasurementUnitRepository
{
    DbResponse<MeasurementUnitCrudModel> Add(MeasurementUnitCrudModel model);
    DbResponse Edit(MeasurementUnitCrudModel model);
    DbResponse Delete(int id);
    DbResponse<MeasurementUnitCrudModel> Get(int id);
    bool IsExistName(int branchId ,string name);
    bool IsExistName(int branchId, string name, int updateId);
    bool IsNull(int id);
    bool IsRelatedDataExist(int id);
    List<MeasurementUnitCrudModel> List(int branchId);
    List<DDL> ListDdl(int branchId);
}