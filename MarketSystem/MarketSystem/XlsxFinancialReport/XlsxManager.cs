using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketSystemModel;
using MySqlDatabase;
using SqLiteDatabase;
using System.Data.Entity;


namespace XlsxFinancialReport
{
    public class XlsxManager
    {
        public static void FinancialReportByVendor()
        {
            var MySqlDb = new MySQLMarketContext();
            var vendors = MySqlDb.Vendors;
            var sales = MySqlDb.Sales;
            var sqLiteDb = new SqLiteContext();
            var taxes = sqLiteDb.TaxInformations;

            List<VendorReportContainer> reports = new List<VendorReportContainer>();           

            foreach (var vendor in vendors)
            {
                VendorReportContainer report = new VendorReportContainer();
                report.Vendor = vendor;
                report.Incomes = CalculateTotalVendorIncomes(vendor);
                report.Expenses = CalculateTotalVendorExpenses(vendor);
                report.TotalTaxes = CalculateTotalVendorTaxes(vendor);
                report.FinancialResult = (report.Incomes - report.Expenses) - report.TotalTaxes;

                reports.Add(report);
            }

            Console.WriteLine();
        }

        private static double CalculateTotalVendorTaxes(Vendor vendor)
        {
            var mySqlDb = new MySQLMarketContext();
            var allVendorSaledProducts = mySqlDb.Products
                .Where(p => p.Vendor.Id == vendor.Id).ToList();
            var sqLiteDb = new SqLiteContext();        

            double taxes = 0;
            double saleIncomes = 0;
            double currentTax = 0;
            List<double> incomes = new List<double>();

            foreach (var product in allVendorSaledProducts)
            {
                incomes = mySqlDb.Sales.Where(s => s.Product.Id == product.Id).Select(s => s.Quantity).ToList();
                if (incomes.Count > 0)
                {
                    saleIncomes = incomes.Aggregate((a, b) => a + b);
                }    

                currentTax = sqLiteDb.TaxInformations
                    .Where(t => t.Id == product.Id)
                    .Select(t => t.TaxPercentage)
                    .FirstOrDefault();
                currentTax = currentTax / 100;

                taxes += (saleIncomes * currentTax) + saleIncomes;
            }

            return taxes;
        }

        private static double CalculateTotalVendorExpenses(Vendor vendor)
        {
            var mySqlDb = new MySQLMarketContext();
            List<double> expenses = mySqlDb.VendorExpenses.Where(e => e.Vendor.Id == vendor.Id).Select(e => e.Expenses).ToList();
            double result = 0;
            if (expenses.Count > 0)
            {
                result = expenses.Aggregate((a, b) => a + b);
            }

            return result;
        }

        private static double CalculateTotalVendorIncomes(Vendor vendor)
        {
            double incomes = 0;
            var mySqlDb = new MySQLMarketContext();
            var allProducts = mySqlDb.Products.Where(p => p.Vendor.Id == vendor.Id);
            var sales = mySqlDb.Sales.Select(s => new { ProductId = s.ProductId, Quantity = s.Quantity }).ToList();
            List<double> quantityes = new List<double>(); 

            foreach (var product in allProducts)
            {
                quantityes = sales.Where(s => s.ProductId == product.Id).Select(s => s.Quantity).ToList();
                if (quantityes.Count > 0)
                {
                    incomes = quantityes.Aggregate((a, b) => a + b) * product.Price;
                }   
            }           

            return incomes;
        }
    }
}
