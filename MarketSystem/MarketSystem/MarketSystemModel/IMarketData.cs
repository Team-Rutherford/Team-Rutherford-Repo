namespace MarketSystemModel
{
    using System.Collections.Generic;

    public interface IMarketData
    {
        ICollection<Product> Products { get; }
        ICollection<Vendor> Vendors { get; }
        ICollection<Measure> Measures { get; }
        ICollection<Supermarket> Supermarkets { get; }
        ICollection<Sale> Sales { get; }
        ICollection<VendorExpenses> VendorExpenses { get; }
    }
}