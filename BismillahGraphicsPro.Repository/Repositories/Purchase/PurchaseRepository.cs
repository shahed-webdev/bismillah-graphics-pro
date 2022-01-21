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
        purchase.PurchaseLists.Select(c => { c.BranchId = branchId; return c; }).ToList();
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

    public DbResponse Edit(PurchaseEditModel model)
    {
        var purchase = Db.Purchases
            .Include(s => s.PurchaseLists)
            .Include(s => s.Supplier)
            .FirstOrDefault(s => s.PurchaseId == model.PurchaseId);

        if (purchase == null) return new DbResponse(false, "data Not Found");
        var due = (model.PurchaseTotalPrice - model.PurchaseDiscountAmount) - purchase.PurchasePaidAmount;

        if (due < 0) return new DbResponse(false, "Due amount cannot be less than zero");

        //Update Supplier
        var oldDiscount = purchase.PurchaseDiscountAmount;
        var newDiscount = model.PurchaseDiscountAmount;
        var oldTotalPrice = purchase.PurchaseTotalPrice;
        var newTotalPrice = model.PurchaseTotalPrice;

        purchase.Supplier.TotalAmount += newDiscount - oldDiscount;
        purchase.Supplier.TotalDiscount += newTotalPrice - oldTotalPrice;


        purchase.PurchaseDiscountAmount = model.PurchaseDiscountAmount;
        purchase.PurchaseTotalPrice = model.PurchaseTotalPrice;
        purchase.Description = model.Description;


        var newPurchaseList = model.PurchaseLists.Select(p => _mapper.Map<PurchaseList>(p)).ToList();
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
        return new DbResponse(true, $"{purchase.PurchaseSn} Updated Successfully");
    }

    public DataResult<PurchaseRecordViewModel> List(int branchId, DataRequest request)
    {
        return Db.Suppliers.Where(m => m.BranchId == branchId)
            .ProjectTo<PurchaseRecordViewModel>(_mapper.ConfigurationProvider)
            .OrderByDescending(a => a.PurchaseSn)
            .ToDataResult(request);
    }
}