namespace WindowsFormsClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FromDestination = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.OracleToMsSql = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ToDestination = new System.Windows.Forms.TextBox();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FromDestination);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "From Destination";
            // 
            // FromDestination
            // 
            this.FromDestination.Location = new System.Drawing.Point(7, 32);
            this.FromDestination.Name = "FromDestination";
            this.FromDestination.Size = new System.Drawing.Size(227, 20);
            this.FromDestination.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.OracleToMsSql);
            this.groupBox2.Location = new System.Drawing.Point(258, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 392);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 183);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(197, 41);
            this.button5.TabIndex = 6;
            this.button5.Text = "MsSql to XML Report";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 138);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(197, 39);
            this.button4.TabIndex = 5;
            this.button4.Text = "Ms Sql to PDF";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(197, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "Xml To MsSql";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Zip Excel To MySql";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OracleToMsSql
            // 
            this.OracleToMsSql.Location = new System.Drawing.Point(6, 18);
            this.OracleToMsSql.Name = "OracleToMsSql";
            this.OracleToMsSql.Size = new System.Drawing.Size(198, 34);
            this.OracleToMsSql.TabIndex = 0;
            this.OracleToMsSql.Text = "Transfer From Oracle To MSSQL";
            this.OracleToMsSql.UseVisualStyleBackColor = true;
            this.OracleToMsSql.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ToDestination);
            this.groupBox3.Location = new System.Drawing.Point(476, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "To Destination";
            // 
            // ToDestination
            // 
            this.ToDestination.Location = new System.Drawing.Point(6, 32);
            this.ToDestination.Name = "ToDestination";
            this.ToDestination.Size = new System.Drawing.Size(226, 20);
            this.ToDestination.TabIndex = 0;
            this.ToDestination.TextChanged += new System.EventHandler(this.ToDestination_TextChanged);
            // 
            // FromDate
            // 
            this.FromDate.Location = new System.Drawing.Point(6, 33);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(221, 20);
            this.FromDate.TabIndex = 3;
            // 
            // ToDate
            // 
            this.ToDate.Location = new System.Drawing.Point(6, 33);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(200, 20);
            this.ToDate.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ToDate);
            this.groupBox4.Location = new System.Drawing.Point(482, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(226, 62);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "To Date";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.FromDate);
            this.groupBox5.Location = new System.Drawing.Point(19, 97);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(233, 62);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "From Date";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(265, 259);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(197, 69);
            this.splitContainer1.SplitterDistance = 65;
            this.splitContainer1.TabIndex = 5;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(11, 231);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(190, 40);
            this.button7.TabIndex = 8;
            this.button7.Text = "MsSql to JSON";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "MsSql to MySql";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(11, 323);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(190, 45);
            this.button6.TabIndex = 10;
            this.button6.Text = "SqLite And MySql Report";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 416);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button OracleToMsSql;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox FromDestination;
        private System.Windows.Forms.TextBox ToDestination;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
    }
}

