using BismillahGraphicsPro.ViewModel;

namespace BismillahGraphicsPro.BusinessLogic;

public interface IMeasurementUnitCore
{
    DbResponse<MeasurementUnitCrudModel> Add(MeasurementUnitCrudModel model);
    DbResponse Edit(MeasurementUnitCrudModel model);
    DbResponse Delete(int id);
    DbResponse<MeasurementUnitCrudModel> Get(int id);
    List<MeasurementUnitCrudModel> List(string userName);
    List<DDL> ListDdl(string userName);
}