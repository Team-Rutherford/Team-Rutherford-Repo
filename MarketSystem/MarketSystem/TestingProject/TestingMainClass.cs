using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using MarketSystemModel;
using MongoDB.Bson;
using MongoDbDatabase;

namespace TestingProject
{
    using System;
    using System.Linq;
    using OracleDatabase;
    using XmlSalesReport;
    using System.Runtime.Serialization.Json;
    using MsSqlDatabase;
    using System.Diagnostics;

    class TestingMainClass
    { 
        static void Main()
        {

            //Process.Start(@"C:\Program Files\MongoDB 2.6 Standard\bin\mongo.exe");

            var oracleDb = new OracleEntities();
            //Console.WriteLine(oracleDb.VENDORS.Find(1).VENDORNAME);
            //var transmiter = new OracleTransmiter();
            //var marketData = transmiter.GetData();
            //DbManager.SaveData(marketData);

            //var data = DbManager.GetSalesGroupByVendorAndDate();
            //var xmlSalesReport = new XmlSalesReportByVendor(data);
            //xmlSalesReport.Document.Save(Console.Out);
            //xmlSalesReport.Save(@"d:\1\sales-report.xml");

            var reports = DbManager.GetSalesOfEachProductForPeriod(new DateTime(2014, 1, 1), new DateTime(2014, 9, 1));
            foreach (var reportContainer in reports)
            {
                var p = reportContainer.SaleReport[0];
                var result = Json.Stringify(p);

                Console.WriteLine(result);

                var filePath = @"d:\1\" + p.Id + ".json";
                Json.SaveObjectToFile(filePath, p);
            }
        }
   }
}
