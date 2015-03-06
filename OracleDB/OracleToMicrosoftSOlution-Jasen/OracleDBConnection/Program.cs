using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration.Assemblies;
using System.Configuration;
using OracleToMicrosoft.OracleDBTableAdapters;
using OracleToMicrosoft;

namespace OracleToMicrosoft
{
    class Program
    {
        static void Main(string[] args)
        {

            MEASURESTableAdapter measuresOracle = new MEASURESTableAdapter();
            PRODUCTSTableAdapter productsOracle = new PRODUCTSTableAdapter();
            VENDORSTableAdapter vendorsOracle = new VENDORSTableAdapter();
            DataTable measuresTableOracle = measuresOracle.GetData();
            DataTable productsTableOracle = productsOracle.GetData();
            DataTable vendorsTableOracle = vendorsOracle.GetData();

            MarketDBContext microsoftDB = new MarketDBContext();
            DbSet measuresMicrosoft = microsoftDB.MEASURES;
           

            DataTable[] tables = new DataTable[] 
            { 
                measuresTableOracle,
                //productsTable,
                vendorsTableOracle    
            };

            //DataSet transDataset = new DataSet();
            //transDataset.Tables.Add(measuresTableOracle);
            //transDataset.Tables.Add(productsTableOracle);
            //transDataset.Tables.Add(vendorsTable);

            //string st = measuresTableOracle.TableName.ToString();

            AddTablesToDB(tables);
        }

        public static void AddTablesToDB(DataTable[] tables)
        {
            // provider connection string=&quot; data source=.;initial catalog=MarketDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient"
            var connectionStr = "Data Source=.; " +
            " Integrated Security=true;" +
            "MultipleActiveResultSets=True;" +
            "App=EntityFramework&quot;"+
            "initial catalog=MarketDB;";

            // Open a connection to the AdventureWorks database. 
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {

                    for (int i = 0; i < tables.Length; i++)
                    {
                        bulkCopy.DestinationTableName = "dbo."+tables[i].TableName.ToString();
                        try
                        {                            
                            bulkCopy.WriteToServer(tables[i]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            } 
        }
    }
}
