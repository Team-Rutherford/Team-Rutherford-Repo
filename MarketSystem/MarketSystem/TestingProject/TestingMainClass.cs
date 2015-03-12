namespace TestingProject
{
    using System;
    using System.Linq;
    using OracleDatabase;
    using XmlSalesReport;
    using  System.Xml.Linq;
    using MsSqlDatabase;

    class TestingMainClass
    { 
        static void Main()
        {
            //var oracleDb = new OracleEntities();
            //Console.WriteLine(oracleDb.VENDORS.Find(1).VENDORNAME);
           // var transmiter = new OracleTransmiter();
           // var marketData = transmiter.GetData();

            //DbManager.SaveData(marketData);
            var data = DbManager.GetSalesGroupByVendorAndDate();
            var xmlSalesReport = new XmlSalesReportByVendor(data);
            xmlSalesReport.Document.Save(Console.Out);
            xmlSalesReport.Save(@"d:\sales-report.xml");

            //Console.WriteLine(marketData.Vendors.First().Name);

            //var report = new XmlSalesReportByVendor();
            //report.Document.Save(Console.Out);

            //var content = report.Document;
            //var result = content.GetElementsByTagName("summary");
            //Console.WriteLine(result[0].InnerText);


        }
   }
}
