using MySqlDatabase;
using XlsxFinancialReport;
using ZipExcelExtractor;

namespace MarketSystemController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MarketSystemModel;
    using OracleDatabase;
    using MongoDbDatabase;
    using MsSqlDatabase;
    using XMLImport;
    using XmlSalesReport;
	using PDFSalesReport;

    public static class Controller
    {
        public static void OracleToMsSql()
        {
            var oracleTransmitter = new OracleTransmiter();
            var data = oracleTransmitter.GetData();
            DbManager.SaveData(data);
        }

        public static void ZipExcelToMsSql(string fileName)
        {
            var zipTransmiter = new Extractor(fileName);
            var data = zipTransmiter.GetData();
            DbManager.SaveData(data);
        }

        public static void XmlToMsSql(string pathToExpensesReport)
        {
            var xmlTransmitter = new XmlVendorExpensesImport(pathToExpensesReport);
            var data = xmlTransmitter.GetData();
            DbManager.SaveData(data);
        }

        public static void MsSqlToPdf(string fileName, DateTime startDate, DateTime endDate)
        {
            var data = DbManager.GetSalesForPeriod(startDate, endDate);
            PdfAggregatedSalesReport.PdfSaleReportForPeriod(fileName, data);
        }

        public static void MsSqlToXml(string fileName, DateTime startDate, DateTime endDate )
        {
            var data = DbManager.GetSalesGroupByVendorAndDate(startDate, endDate);
            var xmlGenerator = new XmlSalesReportByVendor(data);
            xmlGenerator.Save(fileName);
        }

        public static void JsonFilesToMongoDb(string directoryName)
        {
            var data = Json.GetProductReportsFromDirectory(directoryName);
            MongoDbManager.AddSalesProductReportsFromFilesToDatabase(data);
        }

        public static void MsSqlToJson(string directoryName, DateTime startDate, DateTime endDate)
        {
            var data = DbManager.GetSalesOfEachProductForPeriod(startDate, endDate);
            Json.SaveRaportToJsonFiles(directoryName, data);
        }

        public static void MsSqlToMySql()
        {
            var data = DbManager.LoadData();
            MySQLDbManager.SaveData(data);
        }

        public static void SqliteMySqlToExcel(string fileName)
        {
            XlsxManager.FinancialReportByVendor(fileName);
        }
    }
}
