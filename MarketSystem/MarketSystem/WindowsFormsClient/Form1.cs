using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsClient
{
    using TestingProject;
    using System.Windows.Forms;
    using System.Threading;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            this.Hide();     
            Messages mess = new Messages();
            ShowMessage("In Process ...", mess);
            Controller.OracleToMsSql();
            mess.Close();            
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MessageBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = FromDestination.Text;

            this.Hide();
            Messages mess = new Messages();
            ShowMessage("In Process ...", mess);
            Controller.ZipExcelToMsSql(filename);
            mess.Close();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filename = FromDestination.Text;

            this.Hide();
            Messages mess = new Messages();
            ShowMessage("Importing XML VendorExpenses to MSSQL database ...", mess);

            Controller.XmlToMsSql(filename);
            mess.Close();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime startDate = FromDate.Value;
            DateTime endDate = ToDate.Value;
            string fileName = ToDestination.Text;

            this.Hide();
            Messages mess = new Messages();
            ShowMessage("Exporting Sales To PDF ...", mess);

            Controller.MsSqlToPdf(fileName, startDate, endDate);
            mess.Close();
            this.Show();
        }

        private void ToDestination_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime startDate = FromDate.Value;
            DateTime endDate = ToDate.Value;
            string fileName = ToDestination.Text;

            this.Hide();
            Messages mess = new Messages();
            ShowMessage("Exporting Sales by Vendor ...", mess);
            Controller.MsSqlToXml(fileName, startDate, endDate);
            mess.Close();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime startDate = FromDate.Value;
            DateTime endDate = ToDate.Value;
            string folderName = ToDestination.Text;

            this.Hide();
            Messages mess = new Messages();
            ShowMessage("Exporting MSSQL Data to JSON ...", mess);

            Controller.MsSqlToJson(startDate, endDate);
            ShowMessage("Importing JSON To MongoDb ...", mess);

            Controller.JsonFilesToMongoDb();
            mess.Close();
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Controller.MsSqlToMySql();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string filename = ToDestination.Text;
            Controller.SqliteMySqlToXlsx(filename);
        }

        private void ShowMessage(string message, Messages messageObj)
        {
            messageObj.Text = "Message window";
            messageObj.label1.Text = message;
            messageObj.Show();
            messageObj.Refresh(); 
        }
    }
}
