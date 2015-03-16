using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data;
using System.Collections.ObjectModel;

namespace MsSqlDatabase
{
    using MarketSystemModel;

    public class DbManager
    {
        public static void SaveData(IMarketData marketData)
        {
            try
            {
                var db = new DbMarketContext();

                var newVendorIds = marketData.Vendors.Select(v => v.Id).ToList()
                    .Except(db.Vendors.Select(ve => ve.Id).ToList()).ToList();
                var newVendorEntityes = marketData.Vendors.Where(x => newVendorIds.Contains(x.Id)).ToList();
                db.Vendors.AddRange(newVendorEntityes);

                var newSupermarketsId = marketData.Supermarkets.Select(v => v.Id).ToList()
                    .Except(db.Supermarkets.Select(ve => ve.Id).ToList()).ToList();
                var newSupermarketsEntityes = marketData.Supermarkets.Where(x => newSupermarketsId.Contains(x.Id)).ToList();
                db.Supermarkets.AddRange(newSupermarketsEntityes);

                var newMeasuresId = marketData.Measures.Select(v => v.Id).ToList()
                    .Except(db.Measures.Select(ve => ve.Id).ToList()).ToList();
                var newMeasuresEntityes = marketData.Measures.Where(x => newMeasuresId.Contains(x.Id)).ToList();
                db.Measures.AddRange(newMeasuresEntityes);

                var newProductsId = marketData.Products.Select(v => v.Id).ToList()
                    .Except(db.Products.Select(ve => ve.Id).ToList()).ToList();
                var newProductsEntityes = marketData.Products.Where(x => newProductsId.Contains(x.Id)).ToList();
                db.Products.AddRange(newProductsEntityes);

                var newSales = SaleDuplicateChecker(marketData.Sales);
                db.Sales.AddRange(newSales);

                db.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                var a = ex;
            }
        }

        public static ICollection<IEntity> FilterById(ICollection<IEntity> newEntity, ICollection<IEntity> oldEntity)
        {
            var newId = newEntity.Select(v => v.Id).ToList()
            .Except(oldEntity.Select(ve => ve.Id).ToList()).ToList();
            var filteredEntityes = newEntity.Where(x => newId.Contains(x.Id)).ToList();

            return filteredEntityes;
        }

        private static ICollection<Sale> SaleDuplicateChecker(ICollection<Sale> newSales)
        {
            var db = new DbMarketContext();
            var result = new List<Sale>(){};
            foreach (var newSale in newSales)
            {       
                var existInDatabase = db.Sales.Any(s => (s.Date == newSale.Date) &&
                                                  (s.Supermarket.Name == newSale.Supermarket.Name)).ToString();
                if (existInDatabase == "False")
                {
                    result.Add(newSale);
                }                
            }
            return result;
        }

        public static IList<ReportContainer> GetSalesGroupByVendorAndDate()
        {
            var db = new DbMarketContext();

            var sales = db.Sales
                .Select(s => new {Suppermarket = s.Supermarket.Name, s.Date, TotalPrice = (s.Product.Price * s.Quantity)})
                .GroupBy(s => s.Suppermarket)
                .Select(g => new ReportContainer {SupermarkeName = g.Key, SaleReport = g.GroupBy(s => s.Date)
                    .Select(gd => new ReportData { Date = gd.Key, TotalSum = gd.Sum(s => s.TotalPrice)})
                    .ToList()})
                .ToList();

            return sales;
        }

        public static IList<ReportContainer> GetSalesOfEachProductForPeriod(DateTime startDate, DateTime endDate)
        {
            var db = new DbMarketContext();

            var sales = db.Sales
                //.Where(s => s.Date >= startDate && s.Date <= endDate)
                .GroupBy(s => s.Product.Name)
                .Select(g => new ReportContainer {
                    PrductName = g.Key, 
                    SaleReport = g.Select(s => new ReportData
                    {
                        Id = s.ProductId,
                        Price = s.Product.Price,
                        Quantity = s.Quantity,
                        VendorName = s.Product.Vendor.Name
                    })
                    .ToList()
                })
                .ToList();

            return sales;
        }
    }
}

