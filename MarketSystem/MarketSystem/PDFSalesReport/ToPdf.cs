namespace PDFSalesReport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.IO;
    using MsSqlDatabase;


    public class ToPdf
    {
        public static void SaleReportToPdf(string fileName)
        {
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 35, 35);
            StringBuilder sb = new StringBuilder();
            var file = new FileStream(fileName + ".pdf", FileMode.Create);
            PdfWriter pdf = PdfWriter.GetInstance(document, file);
            document.Open();

            var db = new DbMarketContext();

            var report =
                from pr in db.Products
                join sl in db.Sales on pr.Id equals sl.ProductId
                join sm in db.Supermarkets on sl.SupermarketId equals sm.Id
                join me in db.Measures on pr.Measure.Name equals me.Name
                select new
                {
                    productName = pr.Name,
                    productPrice = pr.Price,
                    salesQuantity = sl.Quantity,
                    MarketName = sm.Name,
                    MeasureName = me.Name
                };

            PdfPTable table = new PdfPTable(6);

            foreach (var r in report)
            {
                table.AddCell(r.productName);
                table.AddCell(r.salesQuantity.ToString());
                table.AddCell(r.MeasureName);
                table.AddCell(r.productPrice.ToString());
                table.AddCell(r.MarketName);
                table.AddCell((r.salesQuantity * r.productPrice).ToString());
            }

            document.Add(table);
            document.Close();
        }
    }
}
