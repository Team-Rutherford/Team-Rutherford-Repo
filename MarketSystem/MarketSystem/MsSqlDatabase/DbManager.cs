using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data;
using System.Collections.ObjectModel;


namespace MsSqlDatabase
{
    using MarketSystemModel;

    public static class DbManager
    {
        public static void SaveData(IMarketData marketData)
        {
            var db = new DbMarketContext();
            db.Database.Delete();
            db.Products.AddRange(marketData.Products);
            db.Vendors.AddRange(marketData.Vendors);
            db.Markets.AddRange(marketData.Supermarkets);
            db.Measeres.AddRange(marketData.Measures);
            db.Sales.AddRange(marketData.Sales);
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
