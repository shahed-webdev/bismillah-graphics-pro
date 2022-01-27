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

        //Update Vendor
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

    public DbResponse<decimal> UpdateDiscountAndPaid(List<SellingDuePayRecord> bills)
    {
        var sellings = Db.Sellings.Where(s => bills.Select(i => i.SellingId).Contains(s.SellingId)).ToList();

        if (!sellings.Any()) return new DbResponse<decimal>(false, $"Data not found");
        decimal previousDiscount = 0;
        decimal newDiscount = 0;
        foreach (var bill in bills)
        {
            var selling = sellings.FirstOrDefault(s => s.SellingId == bill.SellingId);
            if (selling == null) return new DbResponse<decimal>(false, $"Bill not found");

            previousDiscount += selling.SellingDiscountAmount;
            newDiscount += bill.SellingDiscountAmount;

            selling.SellingDiscountAmount = bill.SellingDiscountAmount;
            var due = Math.Round(
                selling.SellingTotalPrice - (selling.SellingDiscountAmount + selling.SellingPaidAmount), 2);
            if (due < bill.SellingPaidAmount)
                return new DbResponse<decimal>(false, $"{bill.SellingPaidAmount} Paid amount is greater than due");
            selling.SellingPaidAmount += bill.SellingPaidAmount;
        }

        Db.Sellings.UpdateRange(sellings);
        Db.SaveChanges();
        var netDiscount = newDiscount - previousDiscount;
        return new DbResponse<decimal>(true, $"Selling record update successfully", netDiscount);
    }

    public DataResult<SellingRecordViewModel> List(int branchId, DataRequest request)
    {
        return Db.Sellings.Where(m => m.BranchId == branchId)
            .ProjectTo<SellingRecordViewModel>(_mapper.ConfigurationProvider)
            .OrderByDescending(a => a.SellingSn)
            .ToDataResult(request);
    }
    public DataResult<SellingPaymentViewModel> PaymentList(int branchId, DataRequest request)
    {
        return Db.SellingPaymentReceipts.Where(m => m.BranchId == branchId)
            .ProjectTo<SellingPaymentViewModel>(_mapper.ConfigurationProvider)
            .OrderByDescending(a => a.PaidDate)
            .ToDataResult(request);
    }

    public DbResponse<SellingPaymentReceiptViewModel> GetPaymentDetails(int branchId, int SellingReceiptId)
    {
        var Selling = Db.SellingPaymentReceipts.Where(r => r.BranchId == branchId && r.SellingReceiptId == SellingReceiptId)
            .ProjectTo<SellingPaymentReceiptViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();

        return Selling == null
            ? new DbResponse<SellingPaymentReceiptViewModel>(false, "data Not Found")
            : new DbResponse<SellingPaymentReceiptViewModel>(true, $"{Selling!.ReceiptSn} Get Successfully",
                Selling);
    }

    public DbResponse<SellingPaymentReceipt> DueCollection(int branchId, int registrationId, int receiptSn, SellingDuePayModel model)
    {
        var paymentReceipt = _mapper.Map<SellingPaymentReceipt>(model);
        paymentReceipt.ReceiptSn = receiptSn;
        paymentReceipt.BranchId = branchId;
        paymentReceipt.RegistrationId = registrationId;

        paymentReceipt.SellingPaymentRecords = model.Bills.Select(b =>
            new SellingPaymentRecord
            {
                BranchId = branchId,
                SellingId = b.SellingId,
                AccountId = model.AccountId,
                Description = model.Description,
                SellingPaidAmount = b.SellingPaidAmount,
                SellingPaidDate = model.PaidDate
            }).ToList();

        Db.SellingPaymentReceipts.Add(paymentReceipt);
        Db.SaveChanges();
        return new DbResponse<SellingPaymentReceipt>(true, "Due collected successfully", paymentReceipt);
    }

    public DbResponse<SellingDueViewModel> GetVendorWiseDue(int VendorId, DateTime? sDate, DateTime? eDate)
    {
        var startDate = sDate ?? new DateTime(1000, 1, 1);
        var endDate = eDate ?? new DateTime(3000, 1, 1);

        var vendor = Db.Vendors
            .Include(v =>
                v.Sellings.Where(p => p.SellingDate <= endDate && p.SellingDate >= startDate))
            //.ProjectTo<SellingDueViewModel>(_mapper.ConfigurationProvider) // not working for include filtering
            .FirstOrDefault(v => v.VendorId == VendorId);

        var vendorModel = _mapper.Map<SellingDueViewModel>(vendor);

        if (vendorModel == null) return new DbResponse<SellingDueViewModel>(false, $"data not found");

        vendorModel.Amount = Math.Round(vendorModel.Sellings.Sum(s => s.SellingTotalPrice), 2);
        vendorModel.Due = Math.Round(vendorModel.Sellings.Sum(s => s.SellingDueAmount), 2);
        vendorModel.Paid = Math.Round(vendorModel.Sellings.Sum(s => s.SellingPaidAmount), 2);
        vendorModel.Discount = Math.Round(vendorModel.Sellings.Sum(s => s.SellingDiscountAmount), 2);

        return new DbResponse<SellingDueViewModel>(true, $"{vendorModel.VendorCompanyName} get successfully", vendorModel);

    }

    public decimal TotalDue(int branchId, DateTime? sDate, DateTime? eDate)
    {
        var startDate = sDate ?? new DateTime(1000, 1, 1);
        var endDate = eDate ?? new DateTime(3000, 1, 1);
        return Db.Sellings
            .Where(p => p.BranchId == branchId && p.SellingDate <= endDate && p.SellingDate >= startDate)
            .Sum(s => s.SellingDueAmount);
    }

    public decimal TotalPaid(int branchId, DateTime? sDate, DateTime? eDate)
    {
        var startDate = sDate ?? new DateTime(1000, 1, 1);
        var endDate = eDate ?? new DateTime(3000, 1, 1);
        return Db.SellingPaymentReceipts
            .Where(p => p.BranchId == branchId && p.PaidDate <= endDate && p.PaidDate >= startDate)
            .Sum(s => s.PaidAmount);
    }

    public decimal TotalSale(int branchId, DateTime? sDate, DateTime? eDate)
    {
        var startDate = sDate ?? new DateTime(1000, 1, 1);
        var endDate = eDate ?? new DateTime(3000, 1, 1);
        return Db.Sellings
            .Where(p => p.BranchId == branchId && p.SellingDate <= endDate && p.SellingDate >= startDate)
            .Sum(s => s.SellingTotalPrice);
    }
}