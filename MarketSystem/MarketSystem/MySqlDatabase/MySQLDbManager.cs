using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketSystemModel;
using System.Data.Entity;
using MsSqlDatabase;

namespace MySqlDatabase
{
    public class MySQLDbManager
    {
        public static void SaveData(IMarketData marketData)
        {
            try
            {                

                var db = new MySQLMarketContext();

                var newVendorIds = marketData.Vendors.Select(v => v.Id).ToList()
                    .Except(db.Vendors.Select(ve => ve.Id).ToList()).ToList();
                var newVendorEntityes = marketData.Vendors.Where(x => newVendorIds.Contains(x.Id)).ToList();
                db.Vendors.AddRange(newVendorEntityes);

                var newSupermarketsId = marketData.Supermarkets.Select(v => v.Id).ToList()
                    .Except(db.Supermarkets.Select(ve => ve.Id).ToList()).ToList();
                var newSupermarketsEntityes = marketData.Supermarkets.Where(x => newSupermarketsId.Contains(x.Id)).ToList();
                db.Supermarkets.AddRange(newSupermarketsEntityes);

                var newMeasuresId = marketData.Measures.Select(v => v.Id).ToList()
                    .Except(db.Measures.Select(ve => ve.Id).ToList()).ToList();
                var newMeasuresEntityes = marketData.Measures.Where(x => newMeasuresId.Contains(x.Id)).ToList();
                db.Measures.AddRange(newMeasuresEntityes);

                var newProductsId = marketData.Products.Select(v => v.Id).ToList()
                    .Except(db.Products.Select(ve => ve.Id).ToList()).ToList();
                var newProductsEntityes = marketData.Products.Where(x => newProductsId.Contains(x.Id)).ToList();
                db.Products.AddRange(newProductsEntityes);

                var newSales = SaleDuplicateChecker(marketData.Sales);
                db.Sales.AddRange(newSales);

                var newVendorExpenses = ExpenseDuplicateChacker(marketData.VendorExpenses);
                db.VendorExpenses.AddRange(newVendorExpenses);

                db.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                Console.WriteLine(ex);
            }
            catch (MySql.Data.MySqlClient.MySqlException mySqlEx)
            {
                
            }
        }

        private static ICollection<Sale> SaleDuplicateChecker(ICollection<Sale> newSales)
        {
            var db = new MySQLMarketContext();
            var result = new List<Sale>() { };
            foreach (var newSale in newSales)
            {
                var existInDatabase = db.Sales.Any(s => (s.Date == newSale.Date) &&
                                                  (s.Supermarket.Name == newSale.Supermarket.Name) &&
                                                  (s.ProductId == newSale.ProductId)).ToString();
                if (existInDatabase == "False")
                {
                    result.Add(newSale);
                }
            }
            return result;
        }

        private static ICollection<VendorExpense> ExpenseDuplicateChacker(ICollection<VendorExpense> newExpenses)
        {
            var db = new MySQLMarketContext();
            var result = new List<VendorExpense>() { };
            foreach (var newExpense in newExpenses)
            {
                var existInDatabase = db.VendorExpenses.Any(x => (x.Date == newExpense.Date) &&
                                                  (x.Vendor.Id == newExpense.Vendor.Id)).ToString();
                if (existInDatabase == "False")
                {
                    result.Add(newExpense);
                }
            }
            return result;
        }
    }
}
