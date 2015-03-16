using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MarketSystemModel;

namespace MySqlDatabase
{
    public class MySQLMarketContext : DbContext
    {
        public MySQLMarketContext()
            : base("MySQLMarketContext")
        {
         
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Supermarket> Supermarkets { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
