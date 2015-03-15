namespace MongoDbDatabase
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using MongoDB.Driver.GridFS;
    using MongoDB.Driver.Linq;

    public static class MongoDbManager
    {
        public static void AddSalesProductReportsFromFilesToDatabase(string directoryName)
        {
            var reports = Json.GetProductReportsFromDirectory(directoryName);
            var db = new MongoDb("MarketSystem");
            db.CreateCollection<ProductReportClass>("SaleProducts");
            foreach (var report in reports)
            {
                db.Collections["SaleProducts"].Insert(report);
            }
        }
    }
}
