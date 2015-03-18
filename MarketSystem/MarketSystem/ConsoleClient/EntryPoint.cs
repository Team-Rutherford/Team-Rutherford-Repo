using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketSystemController;

namespace ConsoleClient
{
    class EntryPoint
    {
        private const int MainMenu = 0;
        private const int ReportMenu = 4;
        public delegate void ExecuteController(string fileName);
        public delegate void ExecuteControllerForDatePeriod(string fileName, DateTime stertDate, DateTime endDate);

        static void Main()
        {
            var nextProcess = MainMenu;

            while (true)
            {
                if (nextProcess == MainMenu)
                {
                    Console.Clear();
                    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("+                 Supermarkets Chain              +");
                    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine();
                    Console.WriteLine(" 1. Transfer Data ");
                    Console.WriteLine(" 2. Create reports");
                    Console.WriteLine(" 3. Exit");
                    Console.WriteLine();

                    Console.Write("Input number (1 or 3): ");
                    var number = Console.ReadLine();

                    switch (number)
                    {
                        case "1":
                            nextProcess = 1;
                            break;
                        case "2": 
                            nextProcess = 4;
                            break;
                        case "3":
                            return;
                            break;
                        default:
                            nextProcess = MainMenu;
                            break;
                    }
                }

                try
                {
                    if (nextProcess >= 1 && nextProcess <= 3)
                    {
                        Console.Clear();
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine("+                 Supermarkets Chain              +");
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine();
                        Console.WriteLine("                Transfer Data ");
                        Console.WriteLine();
                    }

                    ProcessController(1,
                        "1. Data from Oracle database to MSSQL Database\n Do You want to transfer data /yes (Y), no (N)/: ",
                        ref nextProcess,
                        delegate(string inputInfo)
                        {
                            Controller.OracleToMsSql();
                        },
                        null,
                        MainMenu);

                    ProcessController(2,
                        "2. Data from Zip files to MSSQL Database\n\nDo You want to transfer data /yes (Y), no (N)/: ",
                        ref nextProcess,
                        Controller.ZipExcelToMsSql,
                        "Input file name: ",
                        MainMenu);


                    ProcessController(3,
                        "3. Data from XML files to MSSQL database\n\nDo You want to transfer data /yes (Y), no (N)/: ",
                        ref nextProcess,
                        Controller.XmlToMsSql,
                        "Input file name: ",
                        MainMenu);


                    if (nextProcess == ReportMenu)
                    {
                        Console.Clear();
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine("+                 Supermarkets Chain              +");
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine();
                        Console.WriteLine("             Create reports");
                        Console.WriteLine();
                        Console.WriteLine(" 1. Reports for the sales of each product for given period (output in MongoDB) ");
                        Console.WriteLine(" 2. Report in XML format holding the sales by vendor for given period");
                        Console.WriteLine(" 3. Reports summarizing the sales information for given period to PDF format");
                        Console.WriteLine(" 4. Financial results report to Excel file");
                        Console.WriteLine(" 5. Exit");
                        Console.WriteLine();

                        Console.Write("Choose number of report (1 - 5): ");
                        nextProcess = int.Parse(Console.ReadLine()) + 4;
                        if (nextProcess == 9)
                        {
                            nextProcess = MainMenu;
                        }

                        Console.Clear();
                    }

                    ProcessController(5,
                        "1. Create reports for the sales of each product for given period in JSON format. \n\nDo You want create report? /yes (Y) or no (N)/: ",
                        ref nextProcess,
                        delegate(string directory, DateTime starDate, DateTime endDate)
                        {
                            Controller.MsSqlToJson(directory, starDate, endDate);
                            Controller.JsonFilesToMongoDb(directory);
                        },
                        "Enter repository's directory",
                        ReportMenu);

                    ProcessController(6,
                        "2. Report in XML format holding the sales by vendor for given period. \n\nDo You want create report? /yes (Y) or no (N)/: ",
                        ref nextProcess,
                        Controller.MsSqlToXml,
                        "Enter file name: ",
                        ReportMenu);

                    ProcessController(7,
                        "3. Reports summarizing the sales information for given period to PDF format. \n\nDo You want create report? /yes (Y) or no (N)/: ",
                        ref nextProcess,
                        Controller.MsSqlToPdf,
                        "Enter file name: ",
                        ReportMenu);

                }
                catch (Exception ex)
                {
                    if (!(ex is TaskCanceledException))
                    {
                        Console.Clear();
                        Console.WriteLine("Error: " + ex.Message);
                        Console.WriteLine();                       
                    }
                }
            }
            
        }

        private static void ProcessController(int processNumber, string message, ref int nextProcess,
            ExecuteController controller, string inputInfo = null, int returnNumberProcess = -1)
        {
            if (processNumber != nextProcess)
            {
                return;
            }

            string input = null;
            Console.Write(message);
            var userChoose = Console.ReadLine();
            if (userChoose == null || userChoose.ToUpper() != "Y")
            {
                processNumber = returnNumberProcess;
                throw new TaskCanceledException();
            }


            if (inputInfo != null)
            {
                Console.Write(inputInfo + " ");
                input = Console.ReadLine();
            }

            Console.WriteLine("\nPlease wait...");
            controller(input);
            if (returnNumberProcess == -1)
            {
                nextProcess++;
            }
            else
            {
                nextProcess = returnNumberProcess;
            }
                
            Console.Clear();
        }

        private static void ProcessController(int processNumber, string message, ref int nextProcess, 
            ExecuteControllerForDatePeriod controller, string inputInfo, int returnNumberProcess = -1)
        {
            if (processNumber != nextProcess)
            {
                return;
            }

            Console.Write(message);
            var userChoose = Console.ReadLine();
            if (userChoose == null || userChoose.ToUpper() != "Y")
            {
                nextProcess = returnNumberProcess;
                throw new TaskCanceledException();
            };

            string input = null;
            if (inputInfo != null)
            {
                Console.Write(inputInfo + " ");
                input = Console.ReadLine();
            }

            try
            {
                Console.Write("Input start date (dd-mm-yyyy): ");
                var startDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Input end date (dd-mm-yyyy): ");
                var endDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("\nPlease wait...");
                controller(input, startDate, endDate);
            }
            catch (InvalidDataException)
            {
                throw new Exception("Invalid date format.");
            }

            if (returnNumberProcess == -1)
            {
                nextProcess++;
            }
            else
            {
                nextProcess = returnNumberProcess;
            }

            Console.Clear();
        }
    }
}
