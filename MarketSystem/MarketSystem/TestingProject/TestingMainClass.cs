namespace TestingProject
{
    using System;
    using System.Linq;
    //using OracleDatabase;
    using XmlSalesReport;
    using  System.Xml.Linq;
    using MsSqlDatabase;
    using System.Collections.Generic;
    using JasenOracle;
    using MarketSystemModel;
    using MySqlDatabase;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.IO;
   // using MongoDB.Bson;
    using MongoDbDatabase;
    using System.Data.Entity;
    using MySql.Data.Entity;
    using MySql.Data.MySqlClient;


    class TestingMainClass
    { 
        static void Main()
        {

            //Process.Start(@"C:\Program Files\MongoDB 2.6 Standard\bin\mongo.exe");

            //var oracleDb = new OracleEntities();
           // Console.WriteLine(oracleDb.VENDORS.Find(1).VENDORNAME);
            //var oracleDb = new Entities();

            // ::::::::::::   ADD DATA FROM ORACLE TO MsSQLDB ::::::::::::::::

            //var transmiter = new OracleTransmiter();
            //var marketData = transmiter.GetData();

            //DbManager.SaveData(marketData); 

            // :::::::::::::: GET XML SALES REPORT ::::::::::::::::::::::::::::::::::

            //var data = DbManager.GetSalesGroupByVendorAndDate();
            //var xmlSalesReport = new XmlSalesReportByVendor(data);
            //xmlSalesReport.Document.Save(Console.Out);
            //xmlSalesReport.Save(@"d:\1\sales-report.xml");

            //Console.WriteLine(marketData.Vendors.First().Name);

            //var report = new XmlSalesReportByVendor();
            //report.Document.Save(Console.Out);

            //var content = report.Document;
            //var result = content.GetElementsByTagName("summary");
            //Console.WriteLine(result[0].InnerText);

            // ::::::::::::  ADD DATA FROM MsSQLDB TO MySQLDb :::::::::::::::
            //DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            
            var MsDb = new DbMarketContext();
            var MySqlDb = new MySQLMarketContext();

            var data = new MarketData();

            MsDb.Measures.ToList().ForEach(m => data.Measures.Add(m));
            //MsDb.Products.ForEachAsync(m => data.Products.Add(m)).Wait();
            //MsDb.Sales.ForEachAsync(m => data.Sales.Add(m)).Wait();
            //MsDb.Supermarkets.ForEachAsync(m => data.Supermarkets.Add(m)).Wait();
            //MsDb.Vendors.ForEachAsync(m => data.Vendors.Add(m)).Wait();
            MySQLDbManager.SaveData(data);

        }
   }
}

