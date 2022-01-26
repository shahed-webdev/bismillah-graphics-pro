﻿using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;

namespace BismillahGraphicsPro.BusinessLogic;

public interface ISellingCore
{
    Task<DbResponse<int>> AddAsync(string userName, SellingAddModel model);
    Task<DbResponse<SellingReceiptViewModel>> GetAsync(int id);
    Task<DbResponse<int>> EditAsync(SellingEditModel model);
    Task<DataResult<SellingRecordViewModel>> ListAsync(string userName, DataRequest request);
    Task<DbResponse<int>> DueCollectionAsync(string userName, SellingDuePayModel model);
    Task<DbResponse<SellingDueViewModel>> GetVendorWiseDueAsync(int vendorId, DateTime? sDate, DateTime? eDate);
    Task<DbResponse<decimal>> GetTotalDueAsync(int vendorId, DateTime? sDate, DateTime? eDate);
}