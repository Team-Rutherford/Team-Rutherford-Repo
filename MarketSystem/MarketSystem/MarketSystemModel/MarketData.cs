using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace MarketSystemModel
{
    public class MarketData : IMarketData
    {
        private ICollection<Product> products;
        private ICollection<Vendor> vendors;
        private ICollection<Measure> measures;
        private ICollection<Supermarket> supermarkets;
        private ICollection<Sale> sales;
        private ICollection<VendorExpenses> vendorExpenses;

        public MarketData()
        {
            this.products = new Collection<Product>();
            this.vendors = new Collection<Vendor>();
            this.measures = new Collection<Measure>();
            this.supermarkets = new  Collection<Supermarket>();
            this.sales = new Collection<Sale>();
            this.vendorExpenses = new Collection<VendorExpenses>();
        }

        public ICollection<Product> Products
        {
            get { return products; }
        }

        public ICollection<Vendor> Vendors
        {
            get { return vendors; }
        }

        public ICollection<Measure> Measures
        {
            get { return measures; }
        }

        public ICollection<Supermarket> Supermarkets
        {
            get { return supermarkets; }
         }

        public ICollection<Sale> Sales

        {
            get { return sales; }
         }

        public ICollection<VendorExpenses> VendorExpenses
        {
            get { return this.vendorExpenses; }
        }
    }
}
