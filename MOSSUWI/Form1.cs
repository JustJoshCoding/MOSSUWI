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
using HtmlAgilityPack;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using System.Text.RegularExpressions;

namespace MOSSUWI
{
    public partial class Form1 : Form
    {
        protected string zipPath = @"";
        protected string extractPath = @"";
        protected List<string> flaggedStudents = new List<string>();
        protected List<string> students = new List<string>();
        protected string ext = "";
        protected string linkToResults = "";
        protected string selectedCourse = "";
        protected List<string> results = new List<string>();
        private static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "dfadqKovUbxz2GKPM0H0fnc3kOE6R8sY9spW2rY8",
            BasePath = "https://mossuwi-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FirebaseClient(config);
            if (client != null)
            {
                MessageBox.Show("Connection to FireBase Established!");
            }
            ExtractButton.Visible = false;
        }
        private void selectArchive_Click(object sender, EventArgs e)
        {
            ExtractButton.Visible = true;
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
                        {
                            studentFolder = str;
                        }
                            
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

                        else if (file.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                        {
                            string filename = Path.GetFileName(file);
                            string movePath = Path.Combine(studentFolderAddress, filename);
                            FileInfo fim = new FileInfo(movePath);
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
                            //flag student for not using .7z or .zip
                            flaggedStudents.Add(studentFolder);
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
                    if (fi.FullName.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                    {
                        string destinationPath = Path.GetFullPath(Path.Combine(root.ToString(), fi.FullName));

                        string filename = Path.GetFileName(destinationPath);
                        string movePath = Path.Combine(stfa, filename);
                        FileInfo fim = new FileInfo(movePath);
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
        private void RenameAllStudentFolders(string path)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] dirs = null;
            System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(path);
            // First, process all the files directly under this folder
            try
            {
                dirs = root.GetDirectories();
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

            if (dirs != null)
            {
                foreach (System.IO.DirectoryInfo dir in dirs)
                {
                    string studentFolder = "";
                    string[] directoryEntries = dir.ToString().Split(Path.DirectorySeparatorChar);
                    foreach (string str in directoryEntries)
                    {
                        if (str.Contains("assignsubmission_file_"))
                        {
                            studentFolder = Regex.Replace(str, @"\s+", "");
                        }
                    }
                    string renamedPath = Path.Combine(path, studentFolder);
                    Directory.Move(dir.ToString(), renamedPath);
                    DirectoryInfo d = new DirectoryInfo(renamedPath);
                    files = d.GetFiles("*.*");
                    if (files != null)
                    {
                        foreach (System.IO.FileInfo fi in files)
                        {
                            if (fi.FullName.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                                students.Add(fi.FullName);
                        }
                    }

                }
            }
            
            
        }
        private async void ExtractButton_Click(object sender, EventArgs e)
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
            (string selectedLang2, string exten) = GetLanguage();
            ext = exten;
            if (ext != "")
            {
                if (extractPath != "")
                {
                    if (CheckDirectoryEmpty_Fast(extractPath) == true)
                    {
                        if (!String.IsNullOrEmpty(zipPath))

                        {
                            ExtractFiles1(zipPath, extractPath);
                            getFilesRecursive(extractPath);
                            String[] str = flaggedStudents.ToArray();
                            await File.WriteAllLinesAsync("blacklist.txt", str);
                            var data = new Data
                            {
                                Students = str
                            };
                            PushResponse response = await client.PushTaskAsync("Submission Flags", data);
                        }
                        else MessageBox.Show("Please select an Archive.");
                    }
                    else MessageBox.Show("Folder you selected is not empty.");
                }
                else MessageBox.Show("Folder Not selected.");
            }
            else MessageBox.Show("Please Select a Language before Extraction.");
            
            

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
        //
        private (string,string) GetLanguage()
        {
            string selectedLang = "";
            string selectedLang2 = "";
            selectedLang += langComboBox.Text; 
            if (selectedLang == "Python")
            {
                selectedLang2 = "python";
                ext = ".py";
            }
            if (selectedLang == "C#")
            {
                selectedLang2 = "csharp";
                ext = ".cs";
            }
            if (selectedLang == "C++")
            {
                selectedLang2 = "cc";
                ext = ".cpp";
            }
            if (selectedLang == "MIPS Assembly (.s)")
            {
                selectedLang2 = "mips";
                ext = ".s";
            }
            if (selectedLang == "MIPS Assembly (.asm)")
            {
                selectedLang2 = "mips";
                ext = ".asm";
            }
            if (selectedLang == "Visual Basic")
            {
                selectedLang2 = "vb";
                ext = ".vb";
            }
            if (selectedLang == "A8086 Assembly (.s)")
            {
                selectedLang2 = "a8086";
                ext = ".s";
            }
            if (selectedLang == "A8086 Assembly (.asm)")
            {
                selectedLang2 = "a8086";
                ext = ".asm";
            }
            if (selectedLang == "PL/SQL (.pks)")
            {
                selectedLang2 = "plsql";
                ext = ".pks";
            }
            if (selectedLang == "PL/SQL (.pkb)")
            {
                selectedLang2 = "plsql";
                ext = ".pkb";
            }
            if (selectedLang == "ASCII")
            {
                selectedLang2 = "ascii";
                ext = ".txt";
            }
            if (selectedLang == "Ada")
            {
                selectedLang2 = "ada";
                ext = ".ada";
            }
            if (selectedLang == "C")
            {
                selectedLang2 = "c";
                ext = ".c";
            }
            if (selectedLang == "FORTRAN (.f90)")
            {
                selectedLang2 = "fortran";
                ext = ".f90";
            }
            if (selectedLang == "FORTRAN (.for)")
            {
                selectedLang2 = "fortran";
                ext = ".for";
            }
            if (selectedLang == "FORTRAN (.f)")
            {
                selectedLang2 = "fortran";
                ext = ".f";
            }
            if (selectedLang == "HCL2 (.pkr.hcl)")
            {
                selectedLang2 = "hcl2";
                ext = ".pkr.hcl";
            }
            if (selectedLang == "HCL2 (.pkr.json)")
            {
                selectedLang2 = "hcl2";
                ext = ".pkr.json";
            }
            if (selectedLang == "Haskell (.hs)")
            {
                selectedLang2 = "haskell";
                ext = ".hs";
            }
            if (selectedLang == "Haskell (.lhs)")
            {
                selectedLang2 = "haskell";
                ext = ".lhs";
            }
            if (selectedLang == "Haskell (.hs)")
            {
                selectedLang2 = "haskell";
                ext = ".hs";
            }
            if (selectedLang == "Java")
            {
                selectedLang2 = "java";
                ext = ".java";
            }
            if (selectedLang == "JavaScript")
            {
                selectedLang2 = "javascript";
                ext = ".js";
            }
            if (selectedLang == "Lisp")
            {
                selectedLang2 = "lisp";
                ext = ".lsp";
            }
            if (selectedLang == "ML")
            {
                selectedLang2 = "ml";
                ext = ".ml";
            }
            if (selectedLang == "Matlab (.m)")
            {
                selectedLang2 = "matlab";
                ext = ".m";
            }
            if (selectedLang == "Matlab (.mat)")
            {
                selectedLang2 = "matlab";
                ext = ".mat";
            }
            if (selectedLang == "Pascal (.pas)")
            {
                selectedLang2 = "pascal";
                ext = ".pas";
            }
            if (selectedLang == "Pascal (.pp)")
            {
                selectedLang2 = "pascal";
                ext = ".pp";
            }
            if (selectedLang == "Prolog")
            {
                selectedLang2 = "prolog";
                ext = ".pl";
            }
            if (selectedLang == "Scheme")
            {
                selectedLang2 = "scheme";
                ext = ".scm";
            }
            if (selectedLang == "Spice (.lib)")
            {
                selectedLang2 = "spice";
                ext = ".lib";
            }
            if (selectedLang == "Spice (.mod)")
            {
                selectedLang2 = "spice";
                ext = ".mod";
            }
            if (selectedLang == "TCL")
            {
                selectedLang2 = "tcl";
                ext = ".tcl";
            }
            if (selectedLang == "VHDL")
            {
                selectedLang2 = "vhdl";
                ext = ".vhdl";
            }
            if (selectedLang == "Verilog")
            {
                selectedLang2 = "verilog";
                ext = ".v";
            }
            return (selectedLang2, ext);
        }
        private void button2_Click(object sender, EventArgs e) // Collates data from other GUI elemets and uploads to MOSS | Mimics Strawberry Perl Command Line
        {
            selectedCourse = GetCourseSelected();
            (string selectedLang2, string ext) = GetLanguage();
            if (selectedCourse == "" || selectedCourse == "Select Course")
            {
                MessageBox.Show("Please Select the Course Code First.");
            }
            else
            {
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
                RenameAllStudentFolders(extractPath);

                if (ext != "")
                {
                    string studentFiles = "";
                    string[] studentFolders = students.ToArray();

                    foreach (string s in studentFolders)
                    {
                        studentFiles += " " + s;
                    }
                    string mosspath = "";
                    MessageBox.Show("Select moss script.");
                    using (OpenFileDialog dialog = new OpenFileDialog())
                    {
                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            mosspath = dialog.FileName;
                        }
                    }
                    if (mosspath != "")
                    {
                        ProcessStartInfo ps = new ProcessStartInfo();
                        ps.RedirectStandardOutput = true;
                        ps.UseShellExecute = false;
                        ps.FileName = "cmd.exe";
                        ps.WindowStyle = ProcessWindowStyle.Normal;
                        ps.Arguments = @"/k perl " + mosspath + " -l " + selectedLang2 + groupFiles + baseFile + maxMatching + selectedReps + customText + studentFiles;
                        var process = Process.Start(ps);
                        string output = process.StandardOutput.ReadToEnd();
                        string[] results = output.Split("\n");
                        foreach (string res in results)
                        {
                            if (res.Contains("http"))
                            {
                                linkToResults = res;
                                textBox2.Text = res;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Moss Script location.");
                    }
                }
                else MessageBox.Show("Please select Language.");
            }
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
        private void printRepsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(maxRepsUpDown.Text);
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
        private void mossDownloadButton_Click(object sender, EventArgs e)
        {
            /*if (linkToResults != "")
            {*/
            var html = @"http://moss.stanford.edu/results/1/3177155154730/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            HtmlNode[] nodes = htmlDoc.DocumentNode.SelectNodes("//td").ToArray();
            
            for (int i =0; i <= nodes.Length-3; i = i + 3)
            {
                string a = nodes[i].InnerText + "       " + nodes[i + 1].InnerText + "        " + nodes[i + 2].InnerText + "\r\n";
                results.Add(a);
            }
            string[] r = results.ToArray();
            string completeResults = "File 1     File 2     Lines Repeated\r\n";
            foreach (string s in r)
            {
                completeResults += s + "\r\n";
            }

            ReportBox.Text = completeResults;
            /*}
            else MessageBox.Show("Please Upload First.");*/
            
        }
        public string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            return "";
        }

        private string GetCourseSelected()
        {
            string sc = SelectCourseComboBox.Text;
            return sc;
        }
        private (string, string) GetPercentagesSelected()
        {
            string f1p = file1PercentUpDown.Text;
            string f2p = file2PercentUpDown.Text;
            return (f1p,f2p);
        }
        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            (string f1p, string f2p) = GetPercentagesSelected();
            int file1 = Int16.Parse(f1p);
            int file2 = Int16.Parse(f2p);
            string[] r = results.ToArray();
            string customResults = "File 1     File 2     Lines Repeated\r\n";
            
            foreach (string s in r)
            {
                string p1="", p2 ="";
                string[] sbp = s.Split();
                bool fp = false;
                foreach (string ch in sbp)
                {
                    if (ch.Contains("(") && fp == false)
                    {
                        p1 = getBetween(ch, "(", "%)");
                        fp = true;
                    }
                    if (ch.Contains("(") && fp == true)
                    {
                        p2 = getBetween(ch, "(", "%)");
                    }
                }
                if (Int16.Parse(p1) >= file1 || Int16.Parse(p2) >= file2)
                {
                    customResults += s + "\r\n";
                }
            }
            ReportBox.Text = customResults;
        }
    }
}