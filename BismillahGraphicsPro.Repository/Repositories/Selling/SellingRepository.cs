using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.EntityFrameworkCore;

namespace BismillahGraphicsPro.Repository;

public class SellingRepository : Repository, ISellingRepository
{
    public SellingRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }


    public int GetSellingSn(int branchId)
    {
        var sn = 0;
        if (Db.Sellings.Any(p => p.BranchId == branchId))
        {
            sn = Db.Sellings
                .Where(p => p.BranchId == branchId)
                .Max(s => s == null ? 0 : s.SellingSn);
        }

        return sn + 1;
    }

    public int GetReceiptSn(int branchId)
    {
        var sn = 0;
        if (Db.SellingPaymentReceipts.Any(p => p.BranchId == branchId))
        {
            sn = Db.SellingPaymentReceipts
                .Where(p => p.BranchId == branchId)
                .Max(s => s == null ? 0 : s.ReceiptSn);
        }

        return sn + 1;
    }

    public DbResponse<int> Add(int branchId, int registrationId, int sellingSn, int receiptSn, SellingAddModel model)
    {
        var selling = _mapper.Map<Selling>(model);

        selling.BranchId = branchId;
        selling.SellingLists.Select(c => { c.BranchId = branchId; return c; }).ToList();
        selling.RegistrationId = registrationId;
        selling.SellingSn = sellingSn;
        if (selling.SellingPaidAmount > 0)
        {
            selling.SellingPaymentRecords = new List<SellingPaymentRecord>
            {
                new SellingPaymentRecord
                {
                    BranchId = branchId,
                    AccountId = model.AccountId,
                    Description = model.Description,
                    SellingPaidAmount = model.SellingPaidAmount,
                    SellingPaidDate = model.SellingDate,
                    SellingReceipt = new SellingPaymentReceipt
                    {
                        BranchId = branchId,
                        RegistrationId = registrationId,
                        VendorId = model.VendorId,
                        AccountId = model.AccountId,
                        ReceiptSn = receiptSn,
                        PaidAmount = model.SellingPaidAmount,
                        PaidDate = model.SellingDate,
                        Description = model.Description
                    }
                }
            };
        }

        Db.Sellings.Add(selling);
        Db.SaveChanges();

        return new DbResponse<int>(true, $"Selling Successfully", selling.SellingId);
    }

    public DbResponse<SellingReceiptViewModel> Get(int id)
    {
        var Selling = Db.Sellings.Where(r => r.SellingId == id)
            .ProjectTo<SellingReceiptViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();

        return Selling == null
            ? new DbResponse<SellingReceiptViewModel>(false, "data Not Found")
            : new DbResponse<SellingReceiptViewModel>(true, $"{Selling!.SellingSn} Get Successfully",
                Selling);
    }

    public DbResponse<int> Edit(SellingEditModel model)
    {
        var selling = Db.Sellings
            .Include(s => s.SellingLists)
            .Include(s => s.Vendor)
            .FirstOrDefault(s => s.SellingId == model.SellingId);

        if (selling == null) return new DbResponse<int>(false, "data Not Found");
        var due = (model.SellingTotalPrice - model.SellingDiscountAmount) - selling.SellingPaidAmount;

        if (due < 0) return new DbResponse<int>(false, "Due amount cannot be less than zero");

        //Update Supplier
        var oldDiscount = selling.SellingDiscountAmount;
        var newDiscount = model.SellingDiscountAmount;
        var oldTotalPrice = selling.SellingTotalPrice;
        var newTotalPrice = model.SellingTotalPrice;

        selling.Vendor.TotalAmount += newDiscount - oldDiscount;
        selling.Vendor.TotalDiscount += newTotalPrice - oldTotalPrice;


        selling.SellingDiscountAmount = model.SellingDiscountAmount;
        selling.SellingTotalPrice = model.SellingTotalPrice;
        selling.Description = model.Description;


        var newSellingList = model.SellingLists.Select(p => _mapper.Map<SellingList>(p)).ToList();
        newSellingList.Select(c =>
        {
            c.BranchId = selling.BranchId;
            return c;
        }).ToList();

        var oldSellingList = selling.SellingLists;
        selling.SellingLists = newSellingList;


        //product stock update
        foreach (var list in oldSellingList)
        {
            var product = Db.Products.Find(list.ProductId);
            if (product == null) continue;
            product.Stock -= list.SellingQuantity;
            Db.Products.Update(product);
        }

        foreach (var list in newSellingList)
        {
            var product = Db.Products.Find(list.ProductId);
            if (product == null) continue;
            product.Stock += list.SellingQuantity;
            Db.Products.Update(product);
        }

        Db.Sellings.Update(selling);
        Db.SaveChanges();
        return new DbResponse<int>(true, $"{selling.SellingSn} Updated Successfully", selling.SellingId);
    }

    public DataResult<SellingRecordViewModel> List(int branchId, DataRequest request)
    {
        return Db.Sellings.Where(m => m.BranchId == branchId)
            .ProjectTo<SellingRecordViewModel>(_mapper.ConfigurationProvider)
            .OrderByDescending(a => a.SellingSn)
            .ToDataResult(request);
    }
}