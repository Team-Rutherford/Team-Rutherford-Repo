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

    public class Controller
    {
        public void OracleToMsSql()
        {
            var oracleTransmitter = new OracleTransmiter();
            var data = oracleTransmitter.GetData();
            DbManager.SaveData(data);
        }

        public void ZipExcelToMsSql()
        {
            // TODO
            throw new NotImplementedException();
        }

        public void XmlToMsSql(string pathToExpensesReport)
        {
            var xmlTransmitter = new XmlVendorExpensesImport(pathToExpensesReport);
            var data = xmlTransmitter.GetData();
            DbManager.SaveData(data);
        }

        public void MsSqlToPdf()
        {
            // TODO
            throw new NotImplementedException();
        }

        public void MsSqlToXml(string pathToReport)
        {
            var data = DbManager.GetSalesGroupByVendorAndDate();
            var xmlGenerator = new XmlSalesReportByVendor(data);
            xmlGenerator.Save(pathToReport);
        }

        public void MsSqlToMongoDb()
        {
            // TODO
            throw new NotImplementedException();
        }

        public void MsSqlToMySql()
        {
            // TODO
            throw new NotImplementedException();
        }

        public void MySqlToExcel()
        {
            // TODO
            throw new NotImplementedException();
        }

        public void SqliteToExcel()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
