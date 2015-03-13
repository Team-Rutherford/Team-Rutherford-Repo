using System.IO;
using System.Net.Mime;

namespace XmlSalesReport
{
    using System;
    using System.Xml;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using MarketSystemModel;

    public class XmlSalesReportByVendor
    {
        private XmlDocument document;
        private XmlNode sales;

        public XmlSalesReportByVendor(IList<ReportContainer> data)
        {
            this.document = new XmlDocument();
            XmlNode docNode = document.CreateXmlDeclaration("1.0", "UTF-8", null);
            this.document.AppendChild(docNode);

            this.sales = document.CreateElement("sales");
            this.document.AppendChild(this.sales);


            foreach (var supermarket in data)
            {
                var summaries = supermarket.SaleReport
                    .Select(record => this.CreateSummaryTag(record.Date, record.TotalSum))
                    .ToList();
                this.AddSaleTag(supermarket.SupermarkeName, summaries);
            }
        }

        public XmlDocument Document
        {
            get { return document; }
        }

        public string Save(string pathFile)
        {
            var writer = File.CreateText(pathFile);
            this.Document.Save(writer);
            return "Saved successfully.";
        }

        private XmlNode CreateSummaryTag(DateTime date, double totalSum)
        {
            XmlNode summary = Document.CreateElement("summary");
            XmlAttribute summaryDate = Document.CreateAttribute("date");
            summaryDate.Value = date.ToString("yy-MMM-yyyy", CultureInfo.CreateSpecificCulture("en-En"));
            XmlAttribute summaryTotalSum = Document.CreateAttribute("total-sum");
            summaryTotalSum.Value = totalSum.ToString("F2");
            summary.Attributes.Append(summaryDate);
            summary.Attributes.Append(summaryTotalSum);

            return summary;
        }

        private XmlNode AddSaleTag(string vendorName, IEnumerable<XmlNode> summaries)
        {
            XmlNode sale = Document.CreateElement("sale");
            XmlAttribute saleVendor = Document.CreateAttribute("vendor");
            saleVendor.Value = vendorName;
            sale.Attributes.Append(saleVendor);

            foreach (var summary in summaries)
            {
                sale.AppendChild(summary);
            }

            this.sales.AppendChild(sale);

            return sale;
        }
    }
}
