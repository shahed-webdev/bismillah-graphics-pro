﻿using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.Repository;

public interface IVendorRepository
{
    DbResponse<VendorViewModel> Add(int branchId, VendorAddModel model);
    DbResponse Edit(VendorEditModel model);
    DbResponse Delete(int id);
    DbResponse<VendorViewModel> Get(int id);
    bool IsExistName(int branchId, string smsNumber);
    bool IsExistName(int branchId, string smsNumber, int updateId);
    bool IsNull(int id);
    bool IsRelatedDataExist(int id);
    DataResult<VendorViewModel> List(int branchId, DataRequest request);
}