namespace TestingProject
{
    using System;
    using System.Linq;
    //using OracleDatabase;
    using XmlSalesReport;
    using System.Xml.Linq;
    using MsSqlDatabase;
    using System.Collections.Generic;
    using JasenOracle;
    using MarketSystemModel;
    using MySqlDatabase;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Runtime.CompilerServices;
    using System.IO;
   // using MongoDB.Bson;
   // using MongoDbDatabase;
    using System.Data.Entity;
    using MySql.Data.Entity;
    using MySql.Data.MySqlClient;
    using SqLiteDatabase;
    using XlsxFinancialReport;
    using MsSqlDatabase.Migrations;
    using PDFSalesReport;
    using ZipExcelExtractor;
    using XMLImport;


    class TestingMainClass
    { 
        static void Main()
        {

            //Process.Start(@"C:\Program Files\MongoDB 2.6 Standard\bin\mongo.exe");

            //var oracleDb = new OracleEntities();
           // Console.WriteLine(oracleDb.VENDORS.Find(1).VENDORNAME);
            //var oracleDb = new Entities();

            // ::::::::::::   ADD DATA FROM ORACLE TO MsSQLDB ::::::::::::::::
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbMarketContext, MsConfiguration>());
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
            //var transferData = DbManager.LoadData();
            //MySQLDbManager.SaveData(transferData);

            // :::::::::::: ADD Product NAMES TO SQLITE DATA ::::::::::::::

            //var mSdata = DbManager.LoadData();

            //SqLiteManager.SaveData(mSdata);

            // ::::::::::: SQLITE MANAGE TAXES ::::::::::::

            //SqLiteManager.ManageTaxes();

            // :::::::::::::  XLSX REPORT ::::::::::::::

            XlsxManager.FinancialReportByVendor(@"..\..\..\..\..\Reports\rep.xlsx");

            // :::::::::::::  PDF REPORT ::::::::::::::

            //Null test
            //DateTime startDate = DateTime.Parse("2016-07-22");
            //DateTime endDate = DateTime.Parse("2016-02-15");

            //Only one result test
            // DateTime startDate = DateTime.Parse("2014-07-22");
            // DateTime endDate = DateTime.Parse("2014-07-22");

            //Normal test
            //DateTime startDate = DateTime.Parse("2014-07-22");
            //DateTime endDate = DateTime.Parse("2015-02-15");

            // var pdfData = DbManager.GetSalesForPeriod(startDate, endDate);
            // PDFSalesReport.PdfAggregatedSalesReport.PdfSaleReportForPeriod("PDF-Rreport", pdfData);

            // ::::::::::::::: ZIP ARCHIVE ::::::::::::::::::::::::

            //Extractor extractor = new Extractor(@"..\..\..\..\..\DataFiles\sales-reports.zip");
            //var sample = extractor.GetData();
            //DbManager.SaveData(sample);

            // ::::::::::::::::::  XML INPORT :::::::::::::::::::::::
            //XmlVendorExpensesImport importer = new XmlVendorExpensesImport(@"C:\Users\Jazzy\Documents\GitHub\Team-Rutherford-Repo\DataFiles\Vendor-Expenses.xml");
            //var data = importer.GetData();
            //DbManager.SaveData(data);
        }
   }
}

