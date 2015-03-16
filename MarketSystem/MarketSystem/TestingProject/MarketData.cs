using System.Collections.Generic;

using System.Collections.ObjectModel;

namespace TestingProject
{
    using MarketSystemModel;

    class MarketData : IMarketData
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
            this.supermarkets = new Collection<Supermarket>();
            this.sales = new Collection<Sale>();
        }

        public ICollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public ICollection<Vendor> Vendors
        {
            get { return vendors; }
            set { vendors = value; }
        }

        public ICollection<Measure> Measures
        {
            get { return measures; }
            set { measures = value; }
        }

        public ICollection<Supermarket> Supermarkets
        {
            get { return supermarkets; }
            set { supermarkets = value; }
        }

        public ICollection<Sale> Sales
        {
            get { return sales; }
            set { sales = value; }
        }

        public ICollection<VendorExpenses> VendorExpenses
        {
            get { return vendorExpenses; }
            set { vendorExpenses = value; }
        }
    }
}
