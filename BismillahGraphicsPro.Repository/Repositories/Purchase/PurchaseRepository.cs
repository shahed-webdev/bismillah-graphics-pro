using AutoMapper;
using AutoMapper.QueryableExtensions;
using BismillahGraphicsPro.Data;
using BismillahGraphicsPro.ViewModel;
using JqueryDataTables;
using Microsoft.EntityFrameworkCore;

namespace BismillahGraphicsPro.Repository;

public class PurchaseRepository : Repository, IPurchaseRepository
{
    public PurchaseRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }


    public int GetPurchaseSn(int branchId)
    {
        var sn = 0;
        if (Db.Purchases.Any(p => p.BranchId == branchId))
        {
            sn = Db.Purchases
                .Where(p => p.BranchId == branchId)
                .Max(s => s == null ? 0 : s.PurchaseSn);
        }

        return sn + 1;
    }

    public int GetReceiptSn(int branchId)
    {
        var sn = 0;
        if (Db.PurchasePaymentReceipts.Any(p => p.BranchId == branchId))
        {
            sn = Db.PurchasePaymentReceipts
                .Where(p => p.BranchId == branchId)
                .Max(s => s == null ? 0 : s.ReceiptSn);
        }

        return sn + 1;
    }

    public DbResponse<int> Add(int branchId, int registrationId, int purchaseSn, int receiptSn, PurchaseAddModel model)
    {
        var purchase = _mapper.Map<Purchase>(model);

        purchase.BranchId = branchId;
        purchase.PurchaseLists.Select(c =>
        {
            c.BranchId = branchId;
            return c;
        }).ToList();
        purchase.RegistrationId = registrationId;
        purchase.PurchaseSn = purchaseSn;
        if (purchase.PurchasePaidAmount > 0)
        {
            purchase.PurchasePaymentRecords = new List<PurchasePaymentRecord>
            {
                new PurchasePaymentRecord
                {
                    BranchId = branchId,
                    AccountId = model.AccountId,
                    Description = model.Description,
                    PurchasePaidAmount = model.PurchasePaidAmount,
                    PurchasePaidDate = model.PurchaseDate,
                    PurchaseReceipt = new PurchasePaymentReceipt
                    {
                        BranchId = branchId,
                        RegistrationId = registrationId,
                        SupplierId = model.SupplierId,
                        AccountId = model.AccountId,
                        ReceiptSn = receiptSn,
                        PaidAmount = model.PurchasePaidAmount,
                        PaidDate = model.PurchaseDate,
                        Description = model.Description
                    }
                }
            };
        }

        Db.Purchases.Add(purchase);
        Db.SaveChanges();

        return new DbResponse<int>(true, $"Purchase Successfully", purchase.PurchaseId);
    }

    public DbResponse<PurchaseReceiptViewModel> Get(int id)
    {
        var purchase = Db.Purchases.Where(r => r.PurchaseId == id)
            .ProjectTo<PurchaseReceiptViewModel>(_mapper.ConfigurationProvider)
            .FirstOrDefault();

        return purchase == null
            ? new DbResponse<PurchaseReceiptViewModel>(false, "data Not Found")
            : new DbResponse<PurchaseReceiptViewModel>(true, $"{purchase!.PurchaseSn} Get Successfully",
                purchase);
    }

    public DbResponse<int> Edit(PurchaseEditModel model)
    {
        var purchase = Db.Purchases
            .Include(s => s.PurchaseLists)
            .Include(s => s.Supplier)
            .FirstOrDefault(s => s.PurchaseId == model.PurchaseId);

        if (purchase == null) return new DbResponse<int>(false, "data Not Found");
        var due = (model.PurchaseTotalPrice - model.PurchaseDiscountAmount) - purchase.PurchasePaidAmount;

        if (due < 0) return new DbResponse<int>(false, "Due amount cannot be less than zero");

        //Update Supplier
        var oldDiscount = purchase.PurchaseDiscountAmount;
        var newDiscount = model.PurchaseDiscountAmount;
        var oldTotalPrice = purchase.PurchaseTotalPrice;
        var newTotalPrice = model.PurchaseTotalPrice;

        purchase.Supplier.TotalAmount += newTotalPrice - oldTotalPrice;
        purchase.Supplier.TotalDiscount += newDiscount - oldDiscount;


        purchase.PurchaseDiscountAmount = model.PurchaseDiscountAmount;
        purchase.PurchaseTotalPrice = model.PurchaseTotalPrice;
        purchase.Description = model.Description;


        var newPurchaseList = model.PurchaseLists.Select(p => _mapper.Map<PurchaseList>(p)).ToList();
        newPurchaseList.Select(c =>
        {
            c.BranchId = purchase.BranchId;
            return c;
        }).ToList();
        var oldPurchaseList = purchase.PurchaseLists;
        purchase.PurchaseLists = newPurchaseList;


        //product stock update
        foreach (var list in oldPurchaseList)
        {
            var product = Db.Products.Find(list.ProductId);
            if (product == null) continue;
            product.Stock -= list.PurchaseQuantity;
            Db.Products.Update(product);
        }

        foreach (var list in newPurchaseList)
        {
            var product = Db.Products.Find(list.ProductId);
            if (product == null) continue;
            product.Stock += list.PurchaseQuantity;
            Db.Products.Update(product);
        }

        Db.Purchases.Update(purchase);
        Db.SaveChanges();
        return new DbResponse<int>(true, $"{purchase.PurchaseSn} Updated Successfully", purchase.PurchaseId);
    }

    public DbResponse UpdateDiscountAndPaid(List<PurchaseDuePayRecord> bills)
    {
        var purchases = Db.Purchases.Where(s => bills.Select(i => i.PurchaseId).Contains(s.PurchaseId)).ToList();

        if (!purchases.Any()) return new DbResponse(false, $"Data not found");

        foreach (var bill in bills)
        {
            var purchase = purchases.FirstOrDefault(s => s.PurchaseId == bill.PurchaseId);
            if (purchase == null) return new DbResponse(false, $"Bill not found");

            purchase.PurchaseDiscountAmount = bill.PurchaseDiscountAmount;
            var due = Math.Round(
                purchase.PurchaseTotalPrice - (purchase.PurchaseDiscountAmount + purchase.PurchasePaidAmount), 2);
            if (due < bill.PurchasePaidAmount)
                return new DbResponse(false, $"{bill.PurchasePaidAmount} Paid amount is greater than due");
            purchase.PurchasePaidAmount += bill.PurchasePaidAmount;
        }

        Db.Purchases.UpdateRange(purchases);
        Db.SaveChanges();
        return new DbResponse(true, $"Purchase record update successfully");
    }

    public DataResult<PurchaseRecordViewModel> List(int branchId, DataRequest request)
    {
        return Db.Purchases.Where(m => m.BranchId == branchId)
            .ProjectTo<PurchaseRecordViewModel>(_mapper.ConfigurationProvider)
            .OrderByDescending(a => a.PurchaseSn)
            .ToDataResult(request);
    }

    public DbResponse<PurchasePaymentReceipt> DuePay(int branchId, int registrationId, int receiptSn,
        PurchaseDuePayModel model)
    {
        var paymentReceipt = _mapper.Map<PurchasePaymentReceipt>(model);
        paymentReceipt.ReceiptSn = receiptSn;
        paymentReceipt.BranchId = branchId;
        paymentReceipt.RegistrationId = registrationId;

        paymentReceipt.PurchasePaymentRecords = model.Bills.Select(b =>
            new PurchasePaymentRecord
            {
                BranchId = branchId,
                PurchaseId = b.PurchaseId,
                AccountId = model.AccountId,
                Description = model.Description,
                PurchasePaidAmount = b.PurchasePaidAmount,
                PurchasePaidDate = model.PaidDate
            }).ToList();

        Db.PurchasePaymentReceipts.Add(paymentReceipt);
        Db.SaveChanges();
        return new DbResponse<PurchasePaymentReceipt>(true, "Due paid successfully", paymentReceipt);
    }

    public DbResponse<PurchaseDueViewModel> GetSupplierWiseDue(int supplierId, DateTime? sDate, DateTime? eDate)
    {
        var startDate = sDate ?? new DateTime(1000, 1, 1);
        var endDate = eDate ?? new DateTime(3000, 1, 1);

        var supplier = Db.Suppliers
            .Include(v =>
                v.Purchases.Where(p => p.PurchaseDate <= endDate && p.PurchaseDate >= startDate))
            //.ProjectTo<PurchaseDueViewModel>(_mapper.ConfigurationProvider) // not working for include filtering
            .FirstOrDefault(v => v.SupplierId == supplierId);

        var supplierModel = _mapper.Map<PurchaseDueViewModel>(supplier);

        if (supplierModel == null) return new DbResponse<PurchaseDueViewModel>(false, $"data not found");

        supplierModel.Amount = Math.Round(supplierModel.Purchases.Sum(s => s.PurchaseTotalPrice), 2);
        supplierModel.Due = Math.Round(supplierModel.Purchases.Sum(s => s.PurchaseDueAmount), 2);
        supplierModel.Paid = Math.Round(supplierModel.Purchases.Sum(s => s.PurchasePaidAmount), 2);
        supplierModel.Discount = Math.Round(supplierModel.Purchases.Sum(s => s.PurchaseDiscountAmount), 2);

        return new DbResponse<PurchaseDueViewModel>(true, $"{supplierModel.SupplierCompanyName} get successfully", supplierModel);
    }
}