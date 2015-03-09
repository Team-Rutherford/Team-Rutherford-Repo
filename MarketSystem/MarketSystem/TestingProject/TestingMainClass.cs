using System;
using System.Linq;
using MarketSystemModel;
using MsSqlDatabase;
using OracleDatabase;

namespace TestingProject
{
    class TestingMainClass
    {
        static void Main()
        {
            var oracleDb = new OracleEntities();
            Console.WriteLine(oracleDb.VENDORS.Find(1).VENDORNAME);
            var transmiter = new OracleTransmiter();
            var marketData = transmiter.GetData();

            Console.WriteLine(marketData.Vendors.First().Name);
        }
   }
}
