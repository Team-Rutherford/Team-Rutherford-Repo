namespace MsSqlDatabase
{
    using System.Data.Entity;
    using MarketSystemModel;

    public class DbMarketContext : DbContext
    {
        public DbMarketContext()
            : base("MarketSystem")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Measure> Measeres { get; set; }
        public DbSet<Supermarket> Markets { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}


