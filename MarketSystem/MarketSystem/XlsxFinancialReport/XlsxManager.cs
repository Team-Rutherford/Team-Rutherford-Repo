using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketSystemModel;
using MySqlDatabase;
using SqLiteDatabase;
using System.Data.Entity;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;



namespace XlsxFinancialReport
{
    public class XlsxManager
    {
        public static void FinancialReportByVendor(string printFilePath)
        {
            List<VendorReportContainer> reports = FillVendorReports();
            PrintFinancialReportByVendor(reports, printFilePath);
        }

        public static void PrintFinancialReportByVendor(List<VendorReportContainer> reportsData, string printFilePath)
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                p.Workbook.Properties.Author = "Team Rutherford";
                p.Workbook.Properties.Title = "Finantial Report By Vendor";
                p.Workbook.Properties.Company = "Soft Uni";

                p.Workbook.Worksheets.Add("Finantial Report By Vendor" + DateTime.Now.Date.ToString());
                ExcelWorksheet workSheet = p.Workbook.Worksheets[1]; // 1 is the position of the worksheet
                workSheet.Name = "Finantial Report By Vendor";
                
                // Set the cell values
                var vendorHeadCell = workSheet.Cells[1, 1];
                var incomesHeadCell = workSheet.Cells[1, 2];
                var expensesHeadCell = workSheet.Cells[1, 3];
                var taxsesHeadCell = workSheet.Cells[1, 4];
                var financialResultHead = workSheet.Cells[1, 5];

                // Header cells text
                vendorHeadCell.Value = "Vendor";
                incomesHeadCell.Value = "Incomes";
                expensesHeadCell.Value = "Expenses";
                taxsesHeadCell.Value = "Total Taxes";
                financialResultHead.Value = "Financial Result";

                // Header cells style
                var headerCells = workSheet.Cells[1, 1, 1, 5].Style;                
                headerCells.WrapText = true;
                headerCells.VerticalAlignment = ExcelVerticalAlignment.Center;
                headerCells.Indent = 1;
                headerCells.Font.SetFromFont(new Font("Calibri", 10, FontStyle.Bold));
                headerCells.Font.Color.SetColor(Color.Black);
                headerCells.Fill.PatternType = ExcelFillStyle.Solid;
                headerCells.Fill.BackgroundColor.SetColor(Color.LightGray);

                // Column indexes for clarity
                int vendorColIndex = 1;
                int incomesColIndex = 2;
                int expensesColIndex = 3;
                int taxesColIndex = 4;
                int financialResultColIndex = 5;

                int dataRowIndex = 2; // Row 1 is the header

                foreach (var report in reportsData)
                {
                    // Vendor
                    var vendorCell = workSheet.Cells[dataRowIndex, vendorColIndex];
                    vendorCell.Value = report.Vendor.Name;
                   
                    // Incomes
                    var incomesCell = workSheet.Cells[dataRowIndex, incomesColIndex];
                    incomesCell.Value = report.Incomes;

                    // Expenses
                    var expensesCell = workSheet.Cells[dataRowIndex, expensesColIndex];
                    expensesCell.Value = report.Expenses;

                    // Taxses
                    var taxsesCell = workSheet.Cells[dataRowIndex, taxesColIndex];
                    taxsesCell.Value = report.TotalTaxes;

                    // Financial Result
                    var financialResultCell = workSheet.Cells[dataRowIndex, financialResultColIndex];
                    financialResultCell.Value = report.FinancialResult;

                    var financialResultCellStyle = financialResultCell.Style.Font;
                    financialResultCellStyle.SetFromFont(new Font("Calibri", 11, FontStyle.Bold));
                    financialResultCellStyle.Color.SetColor(Color.Black);

                    dataRowIndex++;
                }          
    
                // Adjust column width
                int maxLength = reportsData.Select(d => d.Vendor.Name).Max(n => n.Count(c => char.IsLetterOrDigit(c)));
                workSheet.Column(vendorColIndex).Width = maxLength + 2;
                
                // Set all borders
                var wholeTable = workSheet.Cells[1, 1, dataRowIndex - 1, 5].Style;
                wholeTable.Border.Left.Style = ExcelBorderStyle.Thin;
                wholeTable.Border.Top.Style = ExcelBorderStyle.Thin;
                wholeTable.Border.Right.Style = ExcelBorderStyle.Thin;
                wholeTable.Border.Bottom.Style = ExcelBorderStyle.Thin;

                // Save the Excel file
                 Byte[] bin = p.GetAsByteArray();
                 File.WriteAllBytes(printFilePath, bin);
            }
        }

        private static List<VendorReportContainer> FillVendorReports()
        {
            List<VendorReportContainer> reports = new List<VendorReportContainer>();
            var vendors = MySQLDbManager.GetAllVendors();
            foreach (var vendor in vendors)
            {
                VendorReportContainer report = new VendorReportContainer();
                report.Vendor = vendor;
                report.Incomes = CalculateTotalVendorIncomes(vendor);
                report.Expenses = CalculateTotalVendorExpenses(vendor);
                report.TotalTaxes = CalculateTotalVendorTaxes(vendor);
                report.FinancialResult = (report.Incomes - report.Expenses) - report.TotalTaxes;

                reports.Add(report);
            }

            return reports;
        }

        public static double CalculateTotalVendorTaxes(Vendor vendor)
        {
            var allVendorSaledProducts = MySQLDbManager.ProductsByVendor(vendor); 
            double taxes = 0;
            double saleIncomes = 0;
            double currentTax = 0;

            foreach (var product in allVendorSaledProducts)
            {
                saleIncomes = MySQLDbManager.IncomesByProduct(product);
                currentTax = SqLiteManager.TaxPercentage(product);

                taxes += (saleIncomes * currentTax);
            }

            return taxes;
        }

        private static double CalculateTotalVendorExpenses(Vendor vendor)
        {
            var mySqlDb = new MySQLMarketContext();
            List<double> expenses = mySqlDb.VendorExpenses.Where(e => e.Vendor.Id == vendor.Id).Select(e => e.Expenses).ToList();
            double result = 0;
            if (expenses.Count > 0)
            {
                result = expenses.Aggregate((a, b) => a + b);
            }

            return result;
        }

        private static double CalculateTotalVendorIncomes(Vendor vendor)
        {
            var allProducts =  MySQLDbManager.ProductsByVendor(vendor);
            double incomes = MySQLDbManager.TotalIncomesByProdustsList(allProducts);

            return incomes;
        }
    }
}
