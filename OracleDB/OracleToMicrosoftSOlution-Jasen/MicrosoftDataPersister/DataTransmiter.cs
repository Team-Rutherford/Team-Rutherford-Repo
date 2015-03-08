using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Market.Model;
using OracleDBConnection;
using System.Collections.Concurrent;


namespace MicrosoftDataPersister
{
    public class DataTransmiter
    {
        public static void Update()
        {
            MicrosoftEntities MicrosoftDb = new MicrosoftEntities();
            OracleEntities OracleDb = new OracleEntities();

            var measuresNew = from om in OracleDb.MEASURES
                            join mm in MicrosoftDb.Measures
                            on om.ID equals mm.Id
                            select om;
        }

        private void MeasureConvert(MEASURE measureIn, Measure measureOut)
        {
            measureOut.Id = measureIn.ID;
            measureOut.MeasureName = measureIn.MEASURENAME;
        }

        private void ProductConvert(PRODUCT productIn, Product productOut)
        {
            productOut.Id = productIn.ID;
            productOut.ProductName = productIn.PRODUCTNAME;
            productOut.VendorId = productIn.VENDORID;
            productOut.MeasureId = productIn.MEASUREID;
            productOut.Vendor = productOut.Vendor;
            productOut.Measure = productOut.Measure;
        }

        private void VendorConvert(VENDOR vendorIn, Vendor vendorOut)
        {
            vendorOut.Id = vendorIn.ID;
            vendorOut.VendorName = vendorIn.VENDORNAME;
        }
    }
}
