using System;
using System.Data.Entity;
using System.Linq;
using MarketSystemModel;
using MsSqlDatabase;
using ZipExcelExtractor;

namespace ZipFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Extractor extractor = new Extractor("..\\..\\");
            var sample = extractor.GetData();
        }
    }
}
