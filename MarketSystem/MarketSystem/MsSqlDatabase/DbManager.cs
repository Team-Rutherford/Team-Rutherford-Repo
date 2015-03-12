using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace MsSqlDatabase
{
    using MarketSystemModel;

    public static class DbManager
    {
        public static void SaveData(IMarketData marketData)
        {
            var db = new DbMarketContext();

            db.Database.Delete();
            db.Vendors.AddRange(marketData.Vendors);
            db.Markets.AddRange(marketData.Supermarkets);
            db.Measeres.AddRange(marketData.Measures);
            db.Products.AddRange(marketData.Products);
            db.Sales.AddRange(marketData.Sales);

            db.SaveChanges();
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
    }
}
