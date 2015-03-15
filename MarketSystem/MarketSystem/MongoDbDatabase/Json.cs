

using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MongoDbDatabase
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Collections.Generic;
    using MarketSystemModel;

    public static class Json
    {
        public static string Stringify<T>(T obj)
        {
            string result;

            using (var stream = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(T));

                ser.WriteObject(stream, obj);
                stream.Position = 0;

                using (var sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }

        public static T Parse<T>(string json)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(typeof(T));
            var obj = (T)ser.ReadObject(stream);
            return obj;
        }

        public static void SaveObjectToFile<T>(string pathFile, T obj)
        {
            var jsonString = Stringify(obj);
            using (var stream = new FileStream(pathFile, FileMode.Create))
            {
                stream.Position = 0;
                var streamWriter = new StreamWriter(stream);
                streamWriter.Write(jsonString);
                streamWriter.Close();
            }
        }

        public static string ReadJsonFromFile(string fileName)
        {
            string json;

            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                stream.Position = 0;
                var streamReader = new StreamReader(stream);
                json = streamReader.ReadToEnd();
            }

            return json;
        }

        public static IEnumerable<ProductReportClass> GetProductReportsFromDirectory(string directoryName)
        {
            var products = new Collection<ProductReportClass>();
            var files = Directory.EnumerateFiles(directoryName, "*.json", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                var json = ReadJsonFromFile(file);
                var product = Parse<ProductReportClass>(json);
                products.Add(product);
            }

            return products;
        }

        public static void SaveRaportToJsonFiles(string path, IEnumerable<ReportContainer> reports)
        {
            foreach (var reportContainer in reports)
            {
                var p = reportContainer.SaleReport[0];
                var totalQuantiySold = reportContainer.SaleReport.Sum(pr => pr.Quantity);

                var product = new ProductReportClass();
                product.id = p.Id;
                product.productName = reportContainer.PrductName.Trim();
                product.vendorName = p.VendorName.Trim();
                product.totalQuantiySold = totalQuantiySold;
                product.totalIncomes = totalQuantiySold * p.Price;
                
                var filePath = path + "\\" + p.Id + ".json";
                Json.SaveObjectToFile(filePath, product);
            }
        }
    }
}