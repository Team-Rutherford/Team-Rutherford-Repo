using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketSystemModel;
using System.Data.Entity;
using System.Data.Objects;
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

                var newSales = SaleDuplicateChecker(marketData.Sales, db);
                db.Sales.AddRange(newSales);

                var newVendorExpenses = ExpenseDuplicateChacker(marketData.VendorExpenses, db);
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

        private static List<Sale> SaleDuplicateChecker(ICollection<Sale> newSales, MySQLMarketContext db)
        {
            var result = new List<Sale>() { };
            foreach (var newSale in newSales.ToList())
            {
                List<Sale> oldsales = db.Sales.ToList();
                bool exists = oldsales.Any(s => (s.Date.Date == newSale.Date.Date) &&
                                          (s.SupermarketId == newSale.SupermarketId) &&
                                          (s.ProductId == newSale.ProductId));

                if (!exists)
                {
                    result.Add( new Sale() { Id = newSale.Id,
                        ProductId = newSale.ProductId,
                        SupermarketId = newSale.SupermarketId,
                        Quantity = newSale.Quantity,
                        Date = newSale.Date
                    });
                }
            }
            return result;
        }

        private static ICollection<VendorExpenses> ExpenseDuplicateChacker(ICollection<VendorExpenses> newExpenses, MySQLMarketContext db)
        {
            var result = new List<VendorExpenses>() { };
            foreach (var newExpense in newExpenses)
            {
                List<VendorExpenses> oldExpense = db.VendorExpenses.ToList();
                bool existInDatabase = oldExpense.Any(x => (x.Date.Date == newExpense.Date.Date) &&
                                                     (x.VendorId == x.VendorId));
                if (!existInDatabase)
                {
                    result.Add( new VendorExpenses() 
                    {
                        Id = newExpense.Id,
                        VendorId = newExpense.VendorId,
                        Expenses = newExpense.Expenses,
                        Date = newExpense.Date
                    });
                }
            }
            return result;
        }

        public static double AllSaledProducts(Product product)
        {
            double result = 0;
            var mySqlDb = new MySQLMarketContext();

            var saledPrdQuantity = mySqlDb.Sales.Where(s => s.Product.Id == product.Id).Select(s => s.Quantity).ToList();

            if (saledPrdQuantity.Count > 0)
            {
                result = saledPrdQuantity.Aggregate((a, b) => a + b);
            }

            double productPrice = mySqlDb.Products.Where(p => p.Id == product.Id).Select(p => p.Price).FirstOrDefault();

            return result;
        }

        public static double IncomesByProduct(Product product)
        {
            var mySqlDb = new MySQLMarketContext();
            double sales = AllSaledProducts(product);
            double productPrice = mySqlDb.Products.Where(p => p.Id == product.Id).Select(p => p.Price).FirstOrDefault();

            return sales * productPrice;
        }

        public static List<Product> ProductsByVendor(Vendor vendor)
        {
            var mySqlDb = new MySQLMarketContext();

            var allProducts = mySqlDb.Products
                .Where(p => p.Vendor.Id == vendor.Id).ToList();

            return allProducts;
        }

        public static List<Vendor> GetAllVendors()
        {
           var vendors = new MySQLMarketContext().Vendors.ToList();
           return vendors;
        }
    }
}
