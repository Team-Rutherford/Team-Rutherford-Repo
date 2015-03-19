using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketSystemModel;
using System.IO;
using SqLiteDatabase;

namespace SqLiteDatabase
{
    public class SqLiteManager
    {
        protected SqLiteContext SqLiteDb = new SqLiteContext();

        public static void SaveData(IMarketData inputData)
        {
            var db = new SqLiteContext();

            var products = inputData.Products.ToList();

            foreach (var product in products)
            {
                db.TaxInformations.Add(new TaxInformation { Id = product.Id, ProductName = product.Name, TaxPercentage = 0 });
            }

            db.SaveChanges();
        }

        public static void ManageTaxes()
        {
            var context = new SqLiteContext();
            var taxInformations = context.TaxInformations.ToArray();
            int tax = 0;
            bool hasNext = true;
            int index = 0;
            while (hasNext)
            {
                try
                {
                    var taxInfo = taxInformations[index];
                    Console.Write("Current record\n  {0} - {1}%\nNew Tax % : ", taxInfo.ProductName, taxInfo.TaxPercentage);
                    tax = int.Parse(Console.ReadLine());
                    taxInfo.TaxPercentage = tax;
                    index++;
                    if (index >= taxInformations.Length)
                    {
                        hasNext = false;
                    }
                }
                catch (FormatException fx)
                {
                    Console.Write("Invalid Input");
                    Console.ReadLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                }
            }

            context.SaveChanges();
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static IMarketData LoadData()
        {
            var db = new SqLiteContext();
            var data = new MarketData();

            Product product = new Product();
            Tax tax = new Tax();

            foreach (var item in db.TaxInformations)
            {
                product.Name = item.ProductName;
                tax.TaxPercentage = item.TaxPercentage;

                data.Products.Add(product);
                data.Taxes.Add(tax);
            }

            return data;
        }

        public static double TaxPercentage(Product product)
        {
            var SqLiteDb = new SqLiteContext();
            double result = SqLiteDb.TaxInformations
                    .Where(t => t.Id == product.Id)
                    .Select(t => t.TaxPercentage)
                    .FirstOrDefault();
            return result / 100;
        }
    }
}
