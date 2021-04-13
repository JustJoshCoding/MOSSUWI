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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.langComboBox = new System.Windows.Forms.ComboBox();
            this.printLangButton = new System.Windows.Forms.Button();
            this.maxRepsUpDown = new System.Windows.Forms.NumericUpDown();
            this.printRepsButton = new System.Windows.Forms.Button();
            this.baseFileTextBox = new System.Windows.Forms.TextBox();
            this.baseFileButton = new System.Windows.Forms.Button();
            this.customTextTextBox = new System.Windows.Forms.TextBox();
            this.customTextButton = new System.Windows.Forms.Button();
            this.groupFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.maxMatchingFilesUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.mossDownloadButton = new System.Windows.Forms.Button();
            this.mossResultsTextBox = new System.Windows.Forms.RichTextBox();
            this.selectArchive = new System.Windows.Forms.Button();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxRepsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxMatchingFilesUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(37, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.textBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox1_DragOver);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 345);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "MOSS Upload";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(901, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFolder});
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(37, 22);
            this.file.Text = "File";
            // 
            // selectFolder
            // 
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(147, 22);
            this.selectFolder.Text = "Select Folder..";
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_ItemClicked);
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
            this.langComboBox.Location = new System.Drawing.Point(37, 89);
            this.langComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.langComboBox.Name = "langComboBox";
            this.langComboBox.Size = new System.Drawing.Size(129, 23);
            this.langComboBox.TabIndex = 5;
            this.langComboBox.Text = "Select Language";
            this.langComboBox.SelectedIndexChanged += new System.EventHandler(this.langComboBox_SelectedIndexChanged);
            // 
            // printLangButton
            // 
            this.printLangButton.Location = new System.Drawing.Point(208, 88);
            this.printLangButton.Margin = new System.Windows.Forms.Padding(2);
            this.printLangButton.Name = "printLangButton";
            this.printLangButton.Size = new System.Drawing.Size(123, 20);
            this.printLangButton.TabIndex = 6;
            this.printLangButton.Text = "Print Language";
            this.printLangButton.UseVisualStyleBackColor = true;
            this.printLangButton.Click += new System.EventHandler(this.printLangButton_Click);
            // 
            // maxRepsUpDown
            // 
            this.maxRepsUpDown.Location = new System.Drawing.Point(38, 127);
            this.maxRepsUpDown.Margin = new System.Windows.Forms.Padding(2);
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
            this.maxRepsUpDown.Size = new System.Drawing.Size(126, 23);
            this.maxRepsUpDown.TabIndex = 7;
            this.maxRepsUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxRepsUpDown.ValueChanged += new System.EventHandler(this.maxRepsUpDown_ValueChanged);
            // 
            // printRepsButton
            // 
            this.printRepsButton.Location = new System.Drawing.Point(208, 125);
            this.printRepsButton.Margin = new System.Windows.Forms.Padding(2);
            this.printRepsButton.Name = "printRepsButton";
            this.printRepsButton.Size = new System.Drawing.Size(123, 20);
            this.printRepsButton.TabIndex = 8;
            this.printRepsButton.Text = "Print Max Reps";
            this.printRepsButton.UseVisualStyleBackColor = true;
            this.printRepsButton.Click += new System.EventHandler(this.printRepsButton_Click);
            // 
            // baseFileTextBox
            // 
            this.baseFileTextBox.AllowDrop = true;
            this.baseFileTextBox.Location = new System.Drawing.Point(37, 175);
            this.baseFileTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.baseFileTextBox.Name = "baseFileTextBox";
            this.baseFileTextBox.Size = new System.Drawing.Size(247, 23);
            this.baseFileTextBox.TabIndex = 9;
            this.baseFileTextBox.TextChanged += new System.EventHandler(this.baseFileTextBox_TextChanged);
            this.baseFileTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.baseFileTextBox_DragDrop);
            this.baseFileTextBox.DragOver += new System.Windows.Forms.DragEventHandler(this.baseFileTextBox_DragOver);
            // 
            // baseFileButton
            // 
            this.baseFileButton.Location = new System.Drawing.Point(331, 175);
            this.baseFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.baseFileButton.Name = "baseFileButton";
            this.baseFileButton.Size = new System.Drawing.Size(116, 20);
            this.baseFileButton.TabIndex = 10;
            this.baseFileButton.Text = "Select Base File";
            this.baseFileButton.UseVisualStyleBackColor = true;
            this.baseFileButton.Click += new System.EventHandler(this.baseFileButton_Click);
            // 
            // customTextTextBox
            // 
            this.customTextTextBox.Location = new System.Drawing.Point(37, 220);
            this.customTextTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.customTextTextBox.Name = "customTextTextBox";
            this.customTextTextBox.Size = new System.Drawing.Size(247, 23);
            this.customTextTextBox.TabIndex = 11;
            // 
            // customTextButton
            // 
            this.customTextButton.Location = new System.Drawing.Point(331, 220);
            this.customTextButton.Margin = new System.Windows.Forms.Padding(2);
            this.customTextButton.Name = "customTextButton";
            this.customTextButton.Size = new System.Drawing.Size(127, 20);
            this.customTextButton.TabIndex = 12;
            this.customTextButton.Text = "Print Custom Text";
            this.customTextButton.UseVisualStyleBackColor = true;
            this.customTextButton.Click += new System.EventHandler(this.customTextButton_Click);
            // 
            // groupFilesCheckBox
            // 
            this.groupFilesCheckBox.AutoSize = true;
            this.groupFilesCheckBox.Location = new System.Drawing.Point(38, 262);
            this.groupFilesCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.groupFilesCheckBox.Name = "groupFilesCheckBox";
            this.groupFilesCheckBox.Size = new System.Drawing.Size(152, 19);
            this.groupFilesCheckBox.TabIndex = 13;
            this.groupFilesCheckBox.Text = "Group Files by Directory";
            this.groupFilesCheckBox.UseVisualStyleBackColor = true;
            this.groupFilesCheckBox.CheckedChanged += new System.EventHandler(this.groupFilesCheckBox_CheckedChanged);
            // 
            // maxMatchingFilesUpDown
            // 
            this.maxMatchingFilesUpDown.Location = new System.Drawing.Point(220, 296);
            this.maxMatchingFilesUpDown.Margin = new System.Windows.Forms.Padding(2);
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
            this.maxMatchingFilesUpDown.Size = new System.Drawing.Size(126, 23);
            this.maxMatchingFilesUpDown.TabIndex = 14;
            this.maxMatchingFilesUpDown.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.maxMatchingFilesUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 299);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Max Number of Matching Files";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(85, 392);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(246, 23);
            this.textBox2.TabIndex = 16;
            // 
            // mossDownloadButton
            // 
            this.mossDownloadButton.Location = new System.Drawing.Point(350, 390);
            this.mossDownloadButton.Margin = new System.Windows.Forms.Padding(2);
            this.mossDownloadButton.Name = "mossDownloadButton";
            this.mossDownloadButton.Size = new System.Drawing.Size(127, 20);
            this.mossDownloadButton.TabIndex = 17;
            this.mossDownloadButton.Text = "MOSS Download";
            this.mossDownloadButton.UseVisualStyleBackColor = true;
            this.mossDownloadButton.Click += new System.EventHandler(this.mossDownloadButton_Click);
            // 
            // mossResultsTextBox
            // 
            this.mossResultsTextBox.Location = new System.Drawing.Point(529, 45);
            this.mossResultsTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.mossResultsTextBox.Name = "mossResultsTextBox";
            this.mossResultsTextBox.ReadOnly = true;
            this.mossResultsTextBox.Size = new System.Drawing.Size(361, 500);
            this.mossResultsTextBox.TabIndex = 18;
            this.mossResultsTextBox.Text = "";
            this.mossResultsTextBox.TextChanged += new System.EventHandler(this.mossResultsTextBox_TextChanged);
            // 
            // selectArchive
            // 
            this.selectArchive.Location = new System.Drawing.Point(331, 44);
            this.selectArchive.Name = "selectArchive";
            this.selectArchive.Size = new System.Drawing.Size(97, 23);
            this.selectArchive.TabIndex = 19;
            this.selectArchive.Text = "Select Archive";
            this.selectArchive.UseVisualStyleBackColor = true;
            this.selectArchive.Click += new System.EventHandler(this.selectArchive_Click);
            // 
            // ExtractButton
            // 
            this.ExtractButton.Location = new System.Drawing.Point(449, 43);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractButton.TabIndex = 20;
            this.ExtractButton.Text = "Extract";
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 592);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.selectArchive);
            this.Controls.Add(this.mossResultsTextBox);
            this.Controls.Add(this.mossDownloadButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxMatchingFilesUpDown);
            this.Controls.Add(this.groupFilesCheckBox);
            this.Controls.Add(this.customTextButton);
            this.Controls.Add(this.customTextTextBox);
            this.Controls.Add(this.baseFileButton);
            this.Controls.Add(this.baseFileTextBox);
            this.Controls.Add(this.printRepsButton);
            this.Controls.Add(this.maxRepsUpDown);
            this.Controls.Add(this.printLangButton);
            this.Controls.Add(this.langComboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxRepsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxMatchingFilesUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem selectFolder;
        private System.Windows.Forms.ComboBox langComboBox;
        private System.Windows.Forms.Button printLangButton;
        private System.Windows.Forms.NumericUpDown maxRepsUpDown;
        private System.Windows.Forms.Button printRepsButton;
        private System.Windows.Forms.TextBox baseFileTextBox;
        private System.Windows.Forms.Button baseFileButton;
        private System.Windows.Forms.TextBox customTextTextBox;
        private System.Windows.Forms.Button customTextButton;
        private System.Windows.Forms.CheckBox groupFilesCheckBox;
        private System.Windows.Forms.NumericUpDown maxMatchingFilesUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button mossDownloadButton;
        private System.Windows.Forms.RichTextBox mossResultsTextBox;
        private System.Windows.Forms.Button selectArchive;
        private System.Windows.Forms.Button ExtractButton;
    }
}
