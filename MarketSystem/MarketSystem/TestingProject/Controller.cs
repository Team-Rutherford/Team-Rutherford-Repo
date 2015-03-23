namespace TestingProject
{
    using System;
    //using OracleDatabase;
    using System.Linq;
    using JasenOracle;
    using MongoDbDatabase;
    using MsSqlDatabase;
    using XMLImport;
    using XmlSalesReport;
	using PDFSalesReport;
    using MySqlDatabase;
    using XlsxFinancialReport;
    using ZipExcelExtractor;
    using MySql.Data.Entity;
    using MySql.Data.MySqlClient;
    using SqLiteDatabase;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Runtime.CompilerServices;
    using System.IO;
    using System.Data.Entity;
    using MsSqlDatabase.Migrations;

    public static class Controller
    {
        private const string DataFolderPath = @"..\..\..\..\..\DataFiles\";
        private const string ReportsFolderPath = @"..\..\..\..\..\Reports\";
        public static void OracleToMsSql()
        {
            var oracleTransmitter = new OracleTransmiter();
            var data = oracleTransmitter.GetData();
            DbManager.SaveData(data);
        }

        public static void ZipExcelToMsSql(string filename)
        {
            var zipTransmiter = new Extractor(DataFolderPath + filename);
            var data = zipTransmiter.GetData();
            DbManager.SaveData(data);
        }

        public static void XmlToMsSql(string filename)
        {
            var xmlTransmitter = new XmlVendorExpensesImport(DataFolderPath + filename);
            var data = xmlTransmitter.GetData();
            DbManager.SaveData(data);
        }

        public static void MsSqlToPdf(string fileName, DateTime startDate, DateTime endDate)
        {
            var data = DbManager.GetSalesForPeriod(startDate, endDate);
            PdfAggregatedSalesReport.PdfSaleReportForPeriod(ReportsFolderPath + fileName, data);
        }

        public static void MsSqlToXml(string fileName, DateTime startDate, DateTime endDate )
        {
            var data = DbManager.GetSalesGroupByVendorAndDate(startDate, endDate);
            var xmlGenerator = new XmlSalesReportByVendor(data);
            xmlGenerator.Save(ReportsFolderPath + fileName);
        }

        public static void JsonFilesToMongoDb()
        {
            var data = Json.GetProductReportsFromDirectory(ReportsFolderPath + "Json-Reports");
            MongoDbManager.AddSalesProductReportsFromFilesToDatabase(data);
        }

        public static void MsSqlToJson(DateTime startDate, DateTime endDate)
        {
            var data = DbManager.GetSalesOfEachProductForPeriod(startDate, endDate);
            Json.SaveRaportToJsonFiles(ReportsFolderPath + "Json-Reports", data);
        }

        public static void MsSqlToMySql()
        {
            var transferData = DbManager.LoadData();
            MySQLDbManager.SaveData(transferData);
        }

        public static void SqliteMySqlToXlsx(string filename)
        {
            XlsxManager.FinancialReportByVendor(DataFolderPath + filename);
        }
    }    
}
