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
using System.Runtime.InteropServices;
using Microsoft.Azure.Amqp.Framing;


namespace MOSSUWI
{
    public partial class Form1 : Form
    {
        protected string zipPath = @"";
        protected string extractPath = @"";
        

        public Form1()
        {
            InitializeComponent();
        }

        private void selectArchive_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox1.Text = dialog.FileName;
                    zipPath = dialog.FileName;
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

        private void getFilesRecursive(string root)
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
                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Debug.WriteLine(e.Message);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {

                    Debug.WriteLine(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    Debug.WriteLine(e.Message);
                    continue;
                }
                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                {
                    dirs.Push(str);
                }
                // Perform the required action on each file here.
                // Modify this block to perform your required task.
                foreach (string file in files)
                {
                    string studentFolder = "";
                    string[] directoryEntries = currentDir.Split(Path.DirectorySeparatorChar);
                    foreach (string str in directoryEntries)
                    {
                        if (str.Contains("assignsubmission_file_"))
                            studentFolder = str;
                    }
                    string studentFolderAddress = Path.Combine(root, studentFolder);
                    try
                    {
                        // Perform whatever action is required in your scenario.
                        if (file.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                        {
                            ExtractFiles1(file, studentFolderAddress);
                            if (File.Exists(file))
                                File.Delete(file);
                            WalkDirectoryTree(currentDir, studentFolderAddress);
                        }

                        else if (file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                        {
                            string filename = Path.GetFileName(file);
                            string movePath = Path.Combine(studentFolderAddress, filename);
                            FileInfo fim = new FileInfo(movePath);
                            MessageBox.Show(movePath);
                            if (!fim.Exists)
                            {
                                File.Move(studentFolderAddress, movePath);
                            }
                        }
                        else if (file.EndsWith(".7z", StringComparison.OrdinalIgnoreCase))
                        {
                            ExtractFiles1(file, studentFolderAddress);
                            if (File.Exists(file))
                                File.Delete(file);
                            WalkDirectoryTree(currentDir, studentFolderAddress);
                        }
                        else
                        {
                            //flag student

                        }
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        Debug.WriteLine(e.Message);
                        continue;
                    }
                }   
            }
        }
        private void ExtractFiles1(string zipPath, string extractPath)
        {
            string zPath = "7za.exe"; 
            try
            {
                ProcessStartInfo process = new ProcessStartInfo();
                process.WindowStyle = ProcessWindowStyle.Hidden;
                process.FileName = zPath;
                process.Arguments = string.Format("x \"{0}\" -y -o\"{1}\"", zipPath, extractPath);
                Process x = Process.Start(process);
                x.WaitForExit();
            }
            catch (System.Exception Ex)
            {
                Debug.WriteLine(Ex);
                //handle error
            }
        }
        
        private void WalkDirectoryTree(string path, string stfa)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;
            System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(path);
            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                log.Add(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Debug.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    if (fi.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        string destinationPath = Path.GetFullPath(Path.Combine(root.ToString(), fi.FullName));

                        string filename = Path.GetFileName(destinationPath);
                        string movePath = Path.Combine(stfa, filename);
                        FileInfo fim = new FileInfo(movePath);
                        MessageBox.Show(movePath);
                        if (!fim.Exists)
                        {
                            File.Move(destinationPath, movePath);
                        }
                    }
                    else if (fi.FullName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        ExtractFiles1(fi.FullName, root.ToString());
                        if (File.Exists(fi.FullName))
                            File.Delete(fi.FullName);
                    }
                    else if (fi.FullName.EndsWith(".7z", StringComparison.OrdinalIgnoreCase))
                    {
                        ExtractFiles1(fi.FullName, root.ToString());
                        if (File.Exists(fi.FullName))
                            File.Delete(fi.FullName);
                    }
                }
                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo.ToString(), stfa);
                }
            }
        }
        private void ExtractButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select an empty folder.");
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    extractPath = dialog.SelectedPath;
                }
            }
            if (CheckDirectoryEmpty_Fast(extractPath) == true)
            {
                if (!String.IsNullOrEmpty(zipPath))

                {
                    ExtractFiles1(zipPath, extractPath);
                    getFilesRecursive(extractPath);
                }
                else MessageBox.Show("Please select an Archive.");
            } 
            else MessageBox.Show("Folder you selected is not empty.");
        }

        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct WIN32_FIND_DATA
        {
            public uint dwFileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll")]
        private static extern bool FindClose(IntPtr hFindFile);

        public static bool CheckDirectoryEmpty_Fast(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(path);
            }

            if (Directory.Exists(path))
            {
                if (path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    path += "*";
                else
                    path += Path.DirectorySeparatorChar + "*";

                WIN32_FIND_DATA findData;
                var findHandle = FindFirstFile(path, out findData);

                if (findHandle != INVALID_HANDLE_VALUE)
                {
                    try
                    {
                        bool empty = true;
                        do
                        {
                            if (findData.cFileName != "." && findData.cFileName != "..")
                                empty = false;
                        } while (empty && FindNextFile(findHandle, out findData));

                        return empty;
                    }
                    finally
                    {
                        FindClose(findHandle);
                    }
                }

                throw new Exception("Failed to get directory first file",
                    Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()));
            }
            throw new DirectoryNotFoundException();
        }

        private string[] findStudents(string str)
        {
            string[] studentList = new string[] {

            };


            
            return studentList;
        }

        //
        private void button2_Click(object sender, EventArgs e) // Collates data from other GUI elemets and uploads to MOSS | Mimics Strawberry Perl Command Line
        {
             string selectedLang = "";
             string selectedLang2 = "";
             selectedLang += langComboBox.Text; // if the spaces in Arguments throw errors, set variables to " " and concatenate specific texts

             string selectedReps = "";
             selectedReps += " -m " + maxRepsUpDown.Text;

             string customText = "";
             while (!String.IsNullOrEmpty(customTextTextBox.Text))
             {
                 customText += " -c " + customTextTextBox.Text;
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

             if (selectedLang == "Python")
             {
                 selectedLang2 = "python";
             }
             if (selectedLang == "C#")
             {
                 selectedLang2 = "csharp";
             }
             if (selectedLang == "C++")
             {
                 selectedLang2 = "cc";
             }
             if (selectedLang == "MIPS Assembly")
             {
                 selectedLang2 = "mips";
             }
             if (selectedLang == "Visual Basic")
             {
                 selectedLang2 = "vb";
             }
             if (selectedLang == "A8086 Assembly")
             {
                 selectedLang2 = "a8086";
             }
             if (selectedLang == "PL/SQL")
             {
                 selectedLang2 = "plsql";
             }

             //string line = "";
             ProcessStartInfo ps = new ProcessStartInfo();
             //Process process = new Process();
             ps.RedirectStandardOutput = true;
             ps.UseShellExecute = false;
             //ps.CreateNoWindow = true;
             ps.FileName = "cmd.exe";
             ps.WindowStyle = ProcessWindowStyle.Normal;
             ps.Arguments = @"/k cd C:\Users\shani\Documents && perl moss.pl -l " + selectedLang2 + groupFiles + baseFile + maxMatching + selectedReps + customText + " test1.py test2.py"; // *.py
             //ps.Arguments = @"/k cd C:\Users\shani\Documents && perl moss.pl -l python test1.py test2.py";
             //ps.Arguments = @"/k perl C:\Users\shani\Documents\moss.pl -l python C:\Users\shani\Documents\test1.py C:\Users\shani\Documents\test2.py";
             //Process.Start(ps);
             //process.StartInfo.RedirectStandardOutput = true;
             var process = Process.Start(ps);
             var output = process.StandardOutput.ReadToEnd();
             //process.WaitForExit();
             MessageBox.Show(output);

             int sub1 = output.IndexOf("http");
             int sub2 = output.IndexOf("C:");
             int sub3 = sub2 - sub1;

             string substring = output.Substring(sub1, sub3);

             textBox2.Text = substring;



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