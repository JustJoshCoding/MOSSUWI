using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.AccessControl;

namespace MOSSUWI
{
    public partial class Form1 : Form
    {
        protected List<string> files = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    textBox1.Text = dialog.SelectedPath;
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
            string selectedLang = " ";
            selectedLang += langComboBox.Text; // if the spaces in Arguments throw errors, set variables to " " and concatenate specific texts
            
            string selectedReps = " ";
            selectedReps += "-m " + maxRepsUpDown.Text;
            
            string customText = "";
            while (!String.IsNullOrEmpty(customTextTextBox.Text))
            {
                customText += "-c " + customTextTextBox.Text;
            }
            
            string baseFile = "";
            while (!String.IsNullOrEmpty(baseFileTextBox.Text))
            {
                baseFile += " -b " + baseFileTextBox.Text;
            }
            
            string groupFiles = "";
            if (groupFilesCheckBox.Checked)
            {
                groupFiles += " -d";
            }

            string maxMatching = " -n " + maxMatchingFilesUpDown.Text;

            if(selectedLang == "Python")
            {
                selectedLang = "python";
            }
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

            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "cmd.exe";
            ps.WindowStyle = ProcessWindowStyle.Normal;
            ps.Arguments = @"/k cd C:\Users\shani\Documents && perl moss.pl -l " + selectedLang + groupFiles + baseFile + maxMatching + selectedReps + customText + " test1.py test2.py"; // *.py
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

        private void getFilesRecursive(string root, string extractPath)
        {
            // Data structure to hold names of subfolders to be
            // examined for files.
            Stack<string> dirs = new Stack<string>(20);

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                // An UnauthorizedAccessException exception will be thrown if we do not have
                // discovery permission on a folder or file. It may or may not be acceptable
                // to ignore the exception and continue enumerating the remaining files and
                // folders. It is also possible (but unlikely) that a DirectoryNotFound exception
                // will be raised. This will happen if currentDir has been deleted by
                // another application or thread after our call to Directory.Exists. The
                // choice of which exceptions to catch depends entirely on the specific task
                // you are intending to perform and also on how much you know with certainty
                // about the systems on which this code will run.
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {

                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                // Perform the required action on each file here.
                // Modify this block to perform your required task.
                foreach (string file in files)
                {
                    try
                    {
                        // Perform whatever action is required in your scenario.
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                    dirs.Push(str);
            }
        }

        protected void ExtractFiles(string zipPath, string extractPath)
        {
            // Ensures that the last character on the extraction path
            // is the directory separator char.
            // Without this, a malicious zip file could try to traverse outside of the expected
            // extraction path.
            if (!extractPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                extractPath += Path.DirectorySeparatorChar;

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        // Gets the full path to ensure that relative segments are removed.
                        string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

                        // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
                        // are case-insensitive.
                        if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
                            entry.ExtractToFile(destinationPath);
                    }
                }
            }
        }
    }
}

