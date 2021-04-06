using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MOSSUWI
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox1.Text = dialog.FileName;
                }
            }
        }

        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            if (files != null && files.Any())
                textBox1.Text = files.First(); //select the first one 
        }

        private void button2_Click(object sender, EventArgs e) // Collates data from other GUI elemets and uploads to MOSS | Mimics Strawberry Perl Command Line
        {
            string selectedLang = langComboBox.Text; // if the spaces in Arguments throw errors, set variables to " " and concatenate specific texts
            string selectedReps = maxRepsUpDown.Text;
            string customText = customTextTextBox.Text;
            string baseFile = baseFileTextBox.Text;
            string groupFiles = "";
            string maxMatching = maxMatchingFilesUpDown.Text;

            if (selectedLang == "C#") 
            {
                selectedLang = "csharp";
            }
            if (selectedLang == "C++") 
            {
                selectedLang = "cc";
            }
            if (selectedLang == "MIPS Assembly")
            {
                selectedLang = "mips";
            }
            if (selectedLang == "Visual Basic")
            {
                selectedLang = "vb";
            }
            if (selectedLang == "A8086 Assembly")
            {
                selectedLang = "a8086";
            }
            if (selectedLang == "PL/SQL")
            {
                selectedLang = "plsql";
            }

            if (groupFilesCheckBox.Checked) 
            {
                groupFiles = "-d";
            }

            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "cmd.exe";
            ps.WindowStyle = ProcessWindowStyle.Normal;
            ps.Arguments = @"/k cd C:\Users\shani\Documents && perl moss.pl -l " + selectedLang + " " + groupFiles + " " + baseFile + " " + selectedReps + " " + customText + " " + maxMatching + " test1.py test2.py"; // *.py
            //ps.Arguments = @"/k cd C:\Users\shani\Documents && perl moss.pl -l python test1.py test2.py";
            //ps.Arguments = @"/k perl C:\Users\shani\Documents\moss.pl -l python C:\Users\shani\Documents\test1.py C:\Users\shani\Documents\test2.py";
            Process.Start(ps);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void selectFolder_ItemClicked(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox1.Text = dialog.FileName;
                }
            }
        }

        private void langComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var selection = this.langComboBox.GetItemText(this.langComboBox.SelectedItem);
        }

        private void printLangButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(langComboBox.Text);
        }

        private void maxRepsUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void printRepsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(maxRepsUpDown.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void baseFileTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void baseFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    baseFileTextBox.Text = dialog.FileName;
                }
            }
        }

        private void baseFileTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            if (files != null && files.Any())
                baseFileTextBox.Text = files.First(); //select the first one
        }

        private void baseFileTextBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void customTextButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(customTextTextBox.Text);
        }

        private void groupFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //groupFilesCheckBox.Checked
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
