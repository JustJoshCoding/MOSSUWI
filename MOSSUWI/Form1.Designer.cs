namespace MOSSUWI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.langComboBox = new System.Windows.Forms.ComboBox();
            this.maxRepsUpDown = new System.Windows.Forms.NumericUpDown();
            this.baseFileTextBox = new System.Windows.Forms.TextBox();
            this.baseFileButton = new System.Windows.Forms.Button();
            this.customTextTextBox = new System.Windows.Forms.TextBox();
            this.groupFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.maxMatchingFilesUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.mossDownloadButton = new System.Windows.Forms.Button();
            this.selectArchive = new System.Windows.Forms.Button();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Retrieve = new System.Windows.Forms.Button();
            this.IDtextBox = new System.Windows.Forms.TextBox();
            this.SearchStudent = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.file1PercentUpDown = new System.Windows.Forms.NumericUpDown();
            this.file2PercentUpDown = new System.Windows.Forms.NumericUpDown();
            this.GenerateReportButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectCourseComboBox = new System.Windows.Forms.ComboBox();
            this.selectedYear = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.maxRepsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxMatchingFilesUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.file1PercentUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.file2PercentUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(39, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Archived Folder";
            this.textBox1.Size = new System.Drawing.Size(258, 19);
            this.textBox1.TabIndex = 0;
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox1_DragOver);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 347);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "MOSS Upload";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // langComboBox
            // 
            this.langComboBox.FormattingEnabled = true;
            this.langComboBox.Items.AddRange(new object[] {
            "A8086 Assembly (.asm)",
            "A8086 Assembly (.s)",
            "ASCII",
            "Ada",
            "C",
            "C#",
            "C++",
            "FORTRAN (.f)",
            "FORTRAN (.f90)",
            "FORTRAN (.for)",
            "HCL2 (.pkr.hcl)",
            "HCL2 (.pkr.json)",
            "Haskell (.hs)",
            "Haskell (.lhs)",
            "Java",
            "JavaScript",
            "Lisp",
            "MIPS Assembly (.asm)",
            "MIPS Assembly (.s)",
            "ML",
            "Matlab (.m)",
            "Matlab (.mat)",
            "Modula-2 (.def)",
            "Modula-2 (.m2)",
            "Modula-2 (.md)",
            "Modula-2 (.mi)",
            "Modula-2 (.mod)",
            "PL/SQL (.pkb)",
            "PL/SQL (.pks)",
            "Pascal (.pas)",
            "Pascal (.pp)",
            "Perl",
            "Prolog",
            "Python",
            "Scheme",
            "Spice (.lib)",
            "Spice (.mod)",
            "TCL",
            "VHDL",
            "Verilog",
            "Visual Basic"});
            this.langComboBox.Location = new System.Drawing.Point(343, 19);
            this.langComboBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.langComboBox.Name = "langComboBox";
            this.langComboBox.Size = new System.Drawing.Size(187, 20);
            this.langComboBox.TabIndex = 5;
            this.langComboBox.Text = "Select Language";
            // 
            // maxRepsUpDown
            // 
            this.maxRepsUpDown.Location = new System.Drawing.Point(242, 102);
            this.maxRepsUpDown.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.maxRepsUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.maxRepsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxRepsUpDown.Name = "maxRepsUpDown";
            this.maxRepsUpDown.Size = new System.Drawing.Size(53, 19);
            this.maxRepsUpDown.TabIndex = 7;
            this.maxRepsUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // baseFileTextBox
            // 
            this.baseFileTextBox.AllowDrop = true;
            this.baseFileTextBox.Location = new System.Drawing.Point(39, 140);
            this.baseFileTextBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.baseFileTextBox.Name = "baseFileTextBox";
            this.baseFileTextBox.PlaceholderText = "Base File";
            this.baseFileTextBox.Size = new System.Drawing.Size(258, 19);
            this.baseFileTextBox.TabIndex = 9;
            this.baseFileTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.baseFileTextBox_DragDrop);
            this.baseFileTextBox.DragOver += new System.Windows.Forms.DragEventHandler(this.baseFileTextBox_DragOver);
            // 
            // baseFileButton
            // 
            this.baseFileButton.Location = new System.Drawing.Point(317, 140);
            this.baseFileButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.baseFileButton.Name = "baseFileButton";
            this.baseFileButton.Size = new System.Drawing.Size(152, 19);
            this.baseFileButton.TabIndex = 10;
            this.baseFileButton.Text = "Select Base File";
            this.baseFileButton.UseVisualStyleBackColor = true;
            this.baseFileButton.Click += new System.EventHandler(this.baseFileButton_Click);
            // 
            // customTextTextBox
            // 
            this.customTextTextBox.Location = new System.Drawing.Point(131, 182);
            this.customTextTextBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.customTextTextBox.Name = "customTextTextBox";
            this.customTextTextBox.PlaceholderText = "Custom Text To Appear In All Submission Files";
            this.customTextTextBox.Size = new System.Drawing.Size(399, 19);
            this.customTextTextBox.TabIndex = 11;
            this.customTextTextBox.Visible = false;
            // 
            // groupFilesCheckBox
            // 
            this.groupFilesCheckBox.AutoSize = true;
            this.groupFilesCheckBox.Location = new System.Drawing.Point(39, 227);
            this.groupFilesCheckBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.groupFilesCheckBox.Name = "groupFilesCheckBox";
            this.groupFilesCheckBox.Size = new System.Drawing.Size(192, 16);
            this.groupFilesCheckBox.TabIndex = 13;
            this.groupFilesCheckBox.Text = "Group Files by Directory";
            this.groupFilesCheckBox.UseVisualStyleBackColor = true;
            // 
            // maxMatchingFilesUpDown
            // 
            this.maxMatchingFilesUpDown.Location = new System.Drawing.Point(255, 260);
            this.maxMatchingFilesUpDown.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.maxMatchingFilesUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.maxMatchingFilesUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxMatchingFilesUpDown.Name = "maxMatchingFilesUpDown";
            this.maxMatchingFilesUpDown.Size = new System.Drawing.Size(53, 19);
            this.maxMatchingFilesUpDown.TabIndex = 14;
            this.maxMatchingFilesUpDown.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "Max Number of Matching Files";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(167, 305);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Copy This URL And Paste Into Browser For Results";
            this.textBox2.Size = new System.Drawing.Size(363, 19);
            this.textBox2.TabIndex = 16;
            // 
            // mossDownloadButton
            // 
            this.mossDownloadButton.Location = new System.Drawing.Point(317, 347);
            this.mossDownloadButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.mossDownloadButton.Name = "mossDownloadButton";
            this.mossDownloadButton.Size = new System.Drawing.Size(151, 40);
            this.mossDownloadButton.TabIndex = 17;
            this.mossDownloadButton.Text = "MOSS Download";
            this.mossDownloadButton.UseVisualStyleBackColor = true;
            this.mossDownloadButton.Click += new System.EventHandler(this.mossDownloadButton_Click);
            // 
            // selectArchive
            // 
            this.selectArchive.Location = new System.Drawing.Point(317, 64);
            this.selectArchive.Name = "selectArchive";
            this.selectArchive.Size = new System.Drawing.Size(117, 19);
            this.selectArchive.TabIndex = 19;
            this.selectArchive.Text = "Select Archive";
            this.selectArchive.UseVisualStyleBackColor = true;
            this.selectArchive.Click += new System.EventHandler(this.selectArchive_Click);
            // 
            // ExtractButton
            // 
            this.ExtractButton.Location = new System.Drawing.Point(451, 63);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(78, 18);
            this.ExtractButton.TabIndex = 20;
            this.ExtractButton.Text = "Extract";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Retrieve);
            this.panel1.Controls.Add(this.IDtextBox);
            this.panel1.Controls.Add(this.SearchStudent);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.file1PercentUpDown);
            this.panel1.Controls.Add(this.file2PercentUpDown);
            this.panel1.Controls.Add(this.GenerateReportButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(16, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 237);
            this.panel1.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(525, 1);
            this.label3.TabIndex = 31;
            // 
            // Retrieve
            // 
            this.Retrieve.Location = new System.Drawing.Point(15, 131);
            this.Retrieve.Name = "Retrieve";
            this.Retrieve.Size = new System.Drawing.Size(252, 25);
            this.Retrieve.TabIndex = 30;
            this.Retrieve.Text = "Retrieve Flagged Students";
            this.Retrieve.UseVisualStyleBackColor = true;
            this.Retrieve.Click += new System.EventHandler(this.Retrieve_Click);
            // 
            // IDtextBox
            // 
            this.IDtextBox.Location = new System.Drawing.Point(129, 85);
            this.IDtextBox.Name = "IDtextBox";
            this.IDtextBox.PlaceholderText = "ID";
            this.IDtextBox.Size = new System.Drawing.Size(133, 19);
            this.IDtextBox.TabIndex = 29;
            // 
            // SearchStudent
            // 
            this.SearchStudent.Location = new System.Drawing.Point(268, 84);
            this.SearchStudent.Name = "SearchStudent";
            this.SearchStudent.Size = new System.Drawing.Size(78, 18);
            this.SearchStudent.TabIndex = 28;
            this.SearchStudent.Text = "Search";
            this.SearchStudent.UseVisualStyleBackColor = true;
            this.SearchStudent.Click += new System.EventHandler(this.SearchStudent_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "Student Search";
            // 
            // file1PercentUpDown
            // 
            this.file1PercentUpDown.Location = new System.Drawing.Point(297, 37);
            this.file1PercentUpDown.Name = "file1PercentUpDown";
            this.file1PercentUpDown.Size = new System.Drawing.Size(53, 19);
            this.file1PercentUpDown.TabIndex = 26;
            // 
            // file2PercentUpDown
            // 
            this.file2PercentUpDown.Location = new System.Drawing.Point(357, 37);
            this.file2PercentUpDown.Name = "file2PercentUpDown";
            this.file2PercentUpDown.Size = new System.Drawing.Size(53, 19);
            this.file2PercentUpDown.TabIndex = 25;
            // 
            // GenerateReportButton
            // 
            this.GenerateReportButton.Location = new System.Drawing.Point(417, 36);
            this.GenerateReportButton.Name = "GenerateReportButton";
            this.GenerateReportButton.Size = new System.Drawing.Size(78, 18);
            this.GenerateReportButton.TabIndex = 24;
            this.GenerateReportButton.Text = "Sort";
            this.GenerateReportButton.UseVisualStyleBackColor = true;
            this.GenerateReportButton.Click += new System.EventHandler(this.GenerateReportButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "Select Maximum Similarity Percentage";
            // 
            // SelectCourseComboBox
            // 
            this.SelectCourseComboBox.FormattingEnabled = true;
            this.SelectCourseComboBox.Items.AddRange(new object[] {
            "COMP 1601",
            "COMP 1602",
            "COMP 1603",
            "COMP 2611",
            "COMP 2603",
            "INFO 2602",
            "INFO 2604",
            "COMP 3606",
            "COMP 3607"});
            this.SelectCourseComboBox.Location = new System.Drawing.Point(184, 19);
            this.SelectCourseComboBox.Name = "SelectCourseComboBox";
            this.SelectCourseComboBox.Size = new System.Drawing.Size(126, 20);
            this.SelectCourseComboBox.TabIndex = 25;
            this.SelectCourseComboBox.Text = "Select Course";
            // 
            // selectedYear
            // 
            this.selectedYear.Location = new System.Drawing.Point(81, 19);
            this.selectedYear.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.selectedYear.Name = "selectedYear";
            this.selectedYear.Size = new System.Drawing.Size(60, 19);
            this.selectedYear.TabIndex = 27;
            this.selectedYear.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "YEAR";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(579, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(686, 620);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.AllowUserToAddRowsChanged += new System.EventHandler(this.SearchStudent_Click);
            this.dataGridView1.AllowUserToDeleteRowsChanged += new System.EventHandler(this.SearchStudent_Click);
            this.dataGridView1.AllowUserToOrderColumnsChanged += new System.EventHandler(this.SearchStudent_Click);
            this.dataGridView1.AllowUserToResizeColumnsChanged += new System.EventHandler(this.SearchStudent_Click);
            this.dataGridView1.AllowUserToResizeRowsChanged += new System.EventHandler(this.SearchStudent_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 187);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 12);
            this.label6.TabIndex = 33;
            this.label6.Text = "Custom Text";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 107);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "Max Number of Repetitions";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 309);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "MOSS Results URL";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1271, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(439, 620);
            this.dataGridView2.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1745, 721);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.selectedYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SelectCourseComboBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.selectArchive);
            this.Controls.Add(this.mossDownloadButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxMatchingFilesUpDown);
            this.Controls.Add(this.groupFilesCheckBox);
            this.Controls.Add(this.customTextTextBox);
            this.Controls.Add(this.baseFileButton);
            this.Controls.Add(this.baseFileTextBox);
            this.Controls.Add(this.maxRepsUpDown);
            this.Controls.Add(this.langComboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxRepsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxMatchingFilesUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.file1PercentUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.file2PercentUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox langComboBox;
        private System.Windows.Forms.NumericUpDown maxRepsUpDown;
        private System.Windows.Forms.TextBox baseFileTextBox;
        private System.Windows.Forms.Button baseFileButton;
        private System.Windows.Forms.TextBox customTextTextBox;
        private System.Windows.Forms.CheckBox groupFilesCheckBox;
        private System.Windows.Forms.NumericUpDown maxMatchingFilesUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button mossDownloadButton;
        private System.Windows.Forms.Button selectArchive;
        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GenerateReportButton;
        private System.Windows.Forms.ComboBox SelectCourseComboBox;
        private System.Windows.Forms.NumericUpDown file2PercentUpDown;
        private System.Windows.Forms.NumericUpDown file1PercentUpDown;
        private System.Windows.Forms.TextBox IDtextBox;
        private System.Windows.Forms.Button SearchStudent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Retrieve;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown selectedYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}
