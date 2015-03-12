using System;
using System.Linq;

namespace OracleDatabase
{
    using MarketSystemModel;

    public class OracleTransmiter : MarketData, ITransmitter
    {

        public IMarketData GetData()
        {
            var oracleDb = new OracleEntities();
            oracleDb.PRODUCTS
                .ToList()
                .ForEach(p => this.Products.Add(this.ProductAdapter(p)));

            oracleDb.MEASURES
                .ToList()
                .ForEach(m => this.Measures.Add(this.MeasureAapter(m)));

            oracleDb.SUPERMARKETS
            .ToList()
            .ForEach(s => this.Supermarkets.Add(this.SupermarketAdapter(s)));

            oracleDb.VENDORS
                .ToList()
                .ForEach(v => this.Vendors.Add(this.VendorAdapter(v)));

            oracleDb.SALES
                .ToList()
                .ForEach(s => this.Sales.Add(SaleAdapter(s)));

            return this;
        }

        private Product ProductAdapter(PRODUCT oracleProduct)
        {
            var product = new Product
            {
                Id = oracleProduct.ID,
                Name = oracleProduct.PRODUCTNAME, 
                Price = (double) oracleProduct.PRICE,
                MeasureId = oracleProduct.MEASUREID,
                VendorId = oracleProduct.VENDORID
            };

            return product;
        }

        private Measure MeasureAapter(MEASURE oracleMeasure)
        {
            var measure = new Measure
            {
                Id = oracleMeasure.ID,
                Name = oracleMeasure.MEASURENAME
            };

            return measure;
        }

        private Supermarket SupermarketAdapter(SUPERMARKET oracleSupermarket)
        {
            var supeermarket = new Supermarket()
            {
                Id = oracleSupermarket.ID,
                Name = oracleSupermarket.SUPERMARKET_NAME
            };

            return supeermarket;
        }

        private Vendor VendorAdapter(VENDOR oracleVendor)
        {
            var vendor = new Vendor
            {
                Id = oracleVendor.ID,
                Name = oracleVendor.VENDORNAME
            };

            return vendor;
        }

        private Sale SaleAdapter(SALE oracleSale)
        {
            var sale = new Sale
            {
                Id = oracleSale.ID,
                Date = oracleSale.SALE_DATE,
                ProductId = oracleSale.PRODUCT_ID,
                SupermarketId = oracleSale.SUPERMARKET_ID,
                Quantity = (double)oracleSale.QUANTITY
            };

            return sale;
        }
    }
}

