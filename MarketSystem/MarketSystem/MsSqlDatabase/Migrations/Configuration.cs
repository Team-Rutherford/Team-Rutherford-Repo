namespace MsSqlDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MarketSystemModel;
    using System.Collections.Generic;

    public sealed class MsConfiguration : DbMigrationsConfiguration<DbMarketContext>
    {
        public MsConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "MsSqlDatabase.DbMarketContext";
        }

        protected override void Seed(DbMarketContext context)
        {
            List<Sale> sales = new List<Sale>()
            {
                new Sale(){ ProductId = 1, Quantity = 215, SupermarketId = 1, Date =  DateTime.Now.Date},
                new Sale(){ ProductId = 2, Quantity = 25, SupermarketId = 1, Date =  DateTime.Now.Date},
                new Sale(){ ProductId = 3, Quantity = 43, SupermarketId = 1, Date =  DateTime.Now},
                new Sale(){ ProductId = 4, Quantity = 124, SupermarketId = 1, Date =  DateTime.Now},
                new Sale(){ ProductId = 5, Quantity = 237, SupermarketId = 1, Date =  DateTime.Now},
                new Sale(){ ProductId = 6, Quantity = 218, SupermarketId = 1, Date =  DateTime.Now},
                new Sale(){ ProductId = 7, Quantity = 124, SupermarketId = 2, Date =  DateTime.Now},
                new Sale(){ ProductId = 8, Quantity = 55, SupermarketId = 2, Date =  DateTime.Now},
                new Sale(){ ProductId = 9, Quantity = 78, SupermarketId = 2, Date =  DateTime.Now},
                new Sale(){ ProductId = 10, Quantity = 22, SupermarketId = 2, Date =  DateTime.Now},
                new Sale(){ ProductId = 11, Quantity = 33, SupermarketId = 2, Date =  DateTime.Now},
                new Sale(){ ProductId = 12, Quantity = 12, SupermarketId = 3, Date =  DateTime.Now},
                new Sale(){ ProductId = 13, Quantity = 222, SupermarketId = 3, Date =  DateTime.Now},
                new Sale(){ ProductId = 14, Quantity = 82, SupermarketId = 3, Date =  DateTime.Now},
                new Sale(){ ProductId = 15, Quantity = 389, SupermarketId = 3, Date =  DateTime.Now},
                new Sale(){ ProductId = 16, Quantity = 22, SupermarketId = 3, Date =  DateTime.Now},
                new Sale(){ ProductId = 17, Quantity = 45, SupermarketId = 3, Date =  DateTime.Now},
                new Sale(){ ProductId = 18, Quantity = 144, SupermarketId = 4, Date =  DateTime.Now},
                new Sale(){ ProductId = 19, Quantity = 123, SupermarketId = 4, Date =  DateTime.Now},
                new Sale(){ ProductId = 20, Quantity = 145, SupermarketId = 4, Date =  DateTime.Now},
                new Sale(){ ProductId = 21, Quantity = 15, SupermarketId = 4, Date =  DateTime.Now},
                new Sale(){ ProductId = 22, Quantity = 345, SupermarketId = 4, Date =  DateTime.Now},
                new Sale(){ ProductId = 24, Quantity = 145, SupermarketId = 4, Date =  DateTime.Now},
                new Sale(){ ProductId = 25, Quantity = 145, SupermarketId = 4, Date =  DateTime.Now},
                new Sale(){ ProductId = 26, Quantity = 145, SupermarketId = 4, Date =  DateTime.Now}
            };

            List<VendorExpenses> expenses = new List<VendorExpenses>()
            {  
                // all vendors = 7 pcs.
                 new VendorExpenses(){VendorId = 1, Expenses = 55, Date =  DateTime.Now},
                new VendorExpenses(){VendorId = 2, Expenses = 35, Date =  DateTime.Now},
                new VendorExpenses(){VendorId = 3, Expenses = 25, Date =  DateTime.Now},
                new VendorExpenses(){VendorId = 4, Expenses = 15, Date =  DateTime.Now},
                new VendorExpenses(){VendorId = 5, Expenses = 55, Date =  DateTime.Now},
                new VendorExpenses(){VendorId = 6, Expenses = 66, Date =  DateTime.Now},
                new VendorExpenses(){VendorId = 7, Expenses = 45, Date =  DateTime.Now}
            };

            if (!context.Sales.Any())
            {
                context.Sales.AddRange(sales);
            }
            if (!context.VendorExpanses.Any())
            {
                context.VendorExpanses.AddRange(expenses);
            }

            context.SaveChanges();              
        }
    }
}
