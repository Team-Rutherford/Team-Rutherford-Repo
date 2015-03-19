using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using MarketSystemModel;
using Excel;

namespace ZipExcelExtractor
{
    public class Extractor : MarketData, ITransmitter
    {
        private const string FileForExtract = "Reports";
        private string pathToArchive;
        private string archiveName = "sample-reports.zip";

        public Extractor(string pathToArchive)
        {
            this.pathToArchive = pathToArchive;
        }

        public string ArchiveName
        {
            get { return this.archiveName; }
            set { this.archiveName = value; }
        }

        public IMarketData GetData()
        {
            ZipFile.ExtractToDirectory(this.pathToArchive + this.ArchiveName, this.pathToArchive + FileForExtract);
            var allFolders = Directory.GetDirectories(this.pathToArchive + FileForExtract);


            foreach (var folder in allFolders)
            {
                var folderName = Path.GetFileName(folder);
                var allFiles = Directory.GetFiles(folder);

                foreach (var file in allFiles)
                {
                    foreach (var worksheet in Workbook.Worksheets(file))
                    {
                        var supermarket = new Supermarket
                        {
                            Name = worksheet.Rows[0].Cells[1].Text
                        };

                        for (int r = 0; r < worksheet.Rows.Length; r++)
                        {
                            var sale = new Sale();
                            var row = worksheet.Rows[r];
                            if (r == 1 || r == 0)
                            {
                                continue;
                            }
                            else if (r == worksheet.Rows.Length - 1)
                            {
                                break;
                            }
                            for (int c = 0; c < row.Cells.Length; c++)
                            {
                                if (row.Cells[c] != null)
                                {
                                    if (c == 1)
                                    {
                                        var product = new Product
                                        {
                                            Name = row.Cells[c].Text
                                        };

                                        sale.Product = product;
                                    }
                                    else if (c == 2)
                                    {
                                        sale.Quantity = double.Parse(row.Cells[c].Text);
                                    }
                                    else if (c == 3)
                                    {
                                        sale.Product.Price = double.Parse(row.Cells[c].Text);
                                    }

                                    //Console.Write("r{0}, c{1}", r, c);
                                    //Console.Write(" - " + row.Cells[c].Text);
                                }
                            }

                            sale.Supermarket = supermarket;
                            sale.Date = DateTime.ParseExact(folderName, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                            this.Sales.Add(sale);
                        }
                    }
                }
            }
            if (Directory.Exists(this.pathToArchive + FileForExtract))
            {
                Directory.Delete(this.pathToArchive + FileForExtract, true);
            }
            //Console.WriteLine("Importing finised successfully");
            return this;
        }
    }
}
