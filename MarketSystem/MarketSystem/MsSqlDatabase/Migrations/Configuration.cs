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
                new Sale(){ ProductId = 1, Quantity = 215, SupermarketId = 1, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 4, Quantity = 25, SupermarketId = 1, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 6, Quantity = 43, SupermarketId = 1, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 11, Quantity = 124, SupermarketId = 1, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 12, Quantity = 237, SupermarketId = 1, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 14, Quantity = 218, SupermarketId = 1, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 21, Quantity = 124, SupermarketId = 2, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 10, Quantity = 55, SupermarketId = 2, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 3, Quantity = 78, SupermarketId = 2, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 6, Quantity = 22, SupermarketId = 2, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 7, Quantity = 33, SupermarketId = 2, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 8, Quantity = 12, SupermarketId = 3, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 9, Quantity = 222, SupermarketId = 3, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 3, Quantity = 82, SupermarketId = 3, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 3, Quantity = 389, SupermarketId = 3, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 4, Quantity = 22, SupermarketId = 3, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 7, Quantity = 45, SupermarketId = 3, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 19, Quantity = 144, SupermarketId = 4, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 16, Quantity = 123, SupermarketId = 4, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 14, Quantity = 145, SupermarketId = 4, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 15, Quantity = 15, SupermarketId = 4, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 13, Quantity = 345, SupermarketId = 4, Date = new DateTime(2012, 5, 3)},
                new Sale(){ ProductId = 11, Quantity = 145, SupermarketId = 4, Date = new DateTime(2012, 5, 3)},
            };

            List<VendorExpense> expenses = new List<VendorExpense>()
            {  
                // all vendors = 7 pcs.
                 new VendorExpense(){VendorId = 1, Expenses = 55, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 1, Expenses = 35, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 2, Expenses = 25, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 2, Expenses = 15, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 2, Expenses = 55, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 3, Expenses = 66, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 3, Expenses = 45, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 3, Expenses = 188, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 4, Expenses = 12, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 4, Expenses = 3, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 5, Expenses = 5, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 5, Expenses = 6, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 5, Expenses = 23, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 5, Expenses = 67, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 6, Expenses = 11, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 6, Expenses = 4, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 6, Expenses = 46, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 7, Expenses = 5, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 7, Expenses = 12, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 7, Expenses = 13, Date =  DateTime.Now},
                new VendorExpense(){VendorId = 7, Expenses = 4, Date =  DateTime.Now}
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
