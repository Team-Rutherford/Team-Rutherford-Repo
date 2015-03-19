using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MarketSystemModel;

namespace PDFSalesReport
{
    public class PdfAggregatedSalesReport
    {
        public static void PdfSaleReportForPeriod(String fileName, IList<ReportContainer> inputData)
        {
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 35, 35);
            StringBuilder sb = new StringBuilder();
            PdfWriter pdf = PdfWriter.GetInstance(document, new FileStream(@"../../../../../Reports/" + fileName + ".pdf", FileMode.Create));
            document.Open();

            int tableColounms = 5;
            bool itIsNotFirstRow = false;
            double totalSum = 0;
            //DateTime totalDate = new DateTime();

            PdfPTable table = new PdfPTable(tableColounms);

            PdfPCell header = new PdfPCell(new Phrase("Aggregated Sales Report"));
            header.Colspan = tableColounms;
            header.HorizontalAlignment = 1;
            table.AddCell(header);

            DateTime currenDate = new DateTime();

            foreach (var data in inputData)
            {
                foreach (var report in data.SaleReport)
                {

                if (currenDate != DateTime.Parse(report.Date.ToString()))
                {
                    if (itIsNotFirstRow)
                    {

                        PdfPCell totalSumRow = new PdfPCell(new Phrase("Total sum for: " + currenDate.ToShortDateString())); //.ToShortDateString()
                        totalSumRow.Colspan = tableColounms - 1;
                        totalSumRow.HorizontalAlignment = 2;
                        table.AddCell(totalSumRow);
                        table.AddCell(totalSum.ToString());
                        totalSum = 0;
                    }
                    DateTime cellDate = DateTime.Parse(report.Date.ToString());
                    PdfPCell date = new PdfPCell(new Phrase(cellDate.ToShortDateString())); //.ToShortDateString()
                    date.Colspan = tableColounms;
                    date.BackgroundColor = GrayColor.LIGHT_GRAY;
                    table.AddCell(date);

                    table.AddCell("Product");
                    table.AddCell("Quantity");
                    table.AddCell("Unit Price");
                    table.AddCell("Location");
                    table.AddCell("Sum");

                    itIsNotFirstRow = true;

                    currenDate = DateTime.Parse(report.Date.ToString()); ;
                }

                table.AddCell(report.ProductName);
                table.AddCell(report.Quantity + " " + report.Measure);
                table.AddCell(report.Price.ToString());
                table.AddCell(report.VendorName);
                table.AddCell((report.Quantity * report.Price).ToString());

                totalSum += (report.Quantity * report.Price);
                }
            }

            if (itIsNotFirstRow)
            {

                PdfPCell totalSumRow = new PdfPCell(new Phrase("Total sum for: " + currenDate.ToShortDateString())); //.ToShortDateString()
                totalSumRow.Colspan = tableColounms - 1;
                totalSumRow.HorizontalAlignment = 2;
                table.AddCell(totalSumRow);
                table.AddCell(totalSum.ToString());
                totalSum = 0;
            }

            if (table.Rows.Count < 2)
            {

                PdfPCell noResultsMsg = new PdfPCell(new Phrase("There are no sales for this period."));
                noResultsMsg.Colspan = tableColounms;
                table.AddCell(noResultsMsg);
            }

            document.Add(table);
            document.Close();
        }
    }
}
