namespace MicrosoftDataPersister
{
    using System.Data.Entity;
    using Market.Model;
    public class MicrosoftEntities : DbContext
    {    
        public virtual DbSet<Measure> Measures { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        public virtual DbSet<Supermarket> Supermarkets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MarketDb"); // DB - USERNAME
        }
    }
}
