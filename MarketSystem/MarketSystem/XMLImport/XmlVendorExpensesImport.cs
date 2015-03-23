namespace XMLImport
{
    using MarketSystemModel;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Threading;
    using System.Xml;
    using MsSqlDatabase;

    public class XmlVendorExpensesImport : MarketData, ITransmitter
    {
        private const string DateFormat = "MMM-yyyy";

        private string pathToReportFile;

        public XmlVendorExpensesImport(string pathToReportFile) {
            this.pathToReportFile = pathToReportFile;
        }

        public IMarketData GetData()
        {
            this.ParseExpenseReport();
            return this;
        }

        private void ParseExpenseReport()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(this.pathToReportFile);

            string xPathQuery = "/expenses-by-month/vendor";
            XmlNodeList vendorsList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode vendorNode in vendorsList)
            {
                var vendorName = vendorNode.Attributes.GetNamedItem("name").InnerText;
                var dbVendor = DbManager.GetVendorByName(vendorName);
                var vendor = new Vendor();
                vendor.Name = dbVendor.Name;
                vendor.Id = dbVendor.Id;
                
               

                var expenses = vendorNode.ChildNodes;
                foreach (XmlNode expense in expenses)
                {
                    string dateString = expense.Attributes.GetNamedItem("month").InnerText;
                    DateTime parsedDate = DateTime.ParseExact(dateString, DateFormat, null, DateTimeStyles.None);

                    double expenseMoney = Double.Parse(expense.InnerText);

                    // create expense report by collected data
                    var exp = new VendorExpenses();
                    exp.VendorId = vendor.Id;
                    exp.Date = parsedDate;
                    exp.Expenses = expenseMoney;
                    this.VendorExpenses.Add(exp);
                }
            }
        }
    }
}
