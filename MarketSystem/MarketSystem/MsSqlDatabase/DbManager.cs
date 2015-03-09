using System.Data.Entity;

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


    }
}
