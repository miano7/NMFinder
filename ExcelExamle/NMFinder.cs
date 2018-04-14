using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;

namespace NMFinder
{
    public partial class NMFinder : Form
    {
        
        public NMFinder()
        {
            InitializeComponent();
            ChangeDir = false;
            adressFieldIn.Text = DefaulDirectoryInitialization();
        }
        //Progress bar state delegate
        public delegate void progressBarDelegate(int value, int maxValue);
        public delegate void directoryStatus(string directory);
        public delegate void fillListOfFoundedFile();
        //Search class reference
        SearchEngine Search = new SearchEngine();
        //Search thread
        private Thread searchThread;
        //Create a list of parts.

        //Hello Backup
        
        private static List<string> parts = new List<string>();
        private static List<string> partsOnlyLast = new List<string>();
        public static List<string> Parts
        {
           get { return parts; }
           set
            {
                if (value != null)
                {
                    parts = value;
                }
            }  
        }
        public static List<string> PartsOnlyLast
        {
            get { return partsOnlyLast; }
            set
            {
                if (value != null)
                {
                    partsOnlyLast = value;
                }
            }
        }
        //Initialize the temporary folder
        private string _tempFolder;
        public string TempFolder
        {
            get { return _tempFolder; }
            set
            {
                if (value != null)
                {
                    _tempFolder = value;
                }
            }
        }
        public static bool ChangeDir { get; set; }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            //Get collumn index
            int convertedCollIndex;
            bool parsed = Int32.TryParse(tBox_Coll_Index.Text, out convertedCollIndex);
            statmentOpenFileDialog.Filter = "Excel files (*.xls)|*.xls";
            //Очищаем от старого текста окно вывода.
            listOfStatement.Items.Clear();
            //Открываем файл Экселя
            if (statmentOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Открываем книгу.
                Workbook book = Workbook.Load(statmentOpenFileDialog.FileName);
                //Выбираем таблицу(лист). 
                Worksheet sheet = book.Worksheets[0];                
                //Выбираем первые сто записей из столбца.
                //Выбираем область таблицы. (в нашем случае просто ячейку)
                    for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= 101; rowIndex++)
                    {
                        Row row = sheet.Cells.GetRow(rowIndex);
                        Cell cell = row.GetCell(convertedCollIndex);
                    //Добавляем полученный из ячейки текст.
                    listOfStatement.Items.Add(cell.ToString(), CheckState.Checked);
                    if (cell.ToString() == "")
                    {
                        break;
                    }
                    //FileListHandler(range.Text.ToString());
                    Application.DoEvents();
                }
                //Delete impty item
                listOfStatement.Items.RemoveAt(listOfStatement.Items.Count - 1);
            }
        }

        private void StartCopyBtn_Click(object sender, EventArgs e)
        {
            //Clear list of parts
            Parts.Clear();
            searchThread = new Thread(new ThreadStart(FileListHandler));
            searchThread.Start();
            listOfFoundedFiles.Items.Clear();

            btnStartCopy.Enabled = false;
            btnStartCopy.Text = "Идет поиск";
        }
        
        private void FileListHandler()
        {  
            try
            {
                Search.changeDirectory += UpdateProgressText; // Very slow method 
                for (int i = 0; i < listOfStatement.CheckedItems.Count; i++)
                {
                    //Search, sort and add files to the list
                    string fileNameFromTable = listOfStatement.CheckedItems[i].ToString() + ".*.*";
                    Search.TraverseTree(adressFieldIn.Text, fileNameFromTable);
                    BeginInvoke(new progressBarDelegate(UpdateProgressBar), i, listOfStatement.CheckedItems.Count);
                }
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine(e.Message);
                Thread.ResetAbort();
            }
            
            BeginInvoke(new fillListOfFoundedFile(FillListOfFoundedFiles));

            if (Parts != null)
            {
                if (copyOnlyLastVersionsChk.Checked)
                {
                    //Сreate hidden temporary folder
                    DirectoryInfo tDir = System.IO.Directory.CreateDirectory(adressFieldOut.Text + @"\Temp");
                    tDir.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                    TempFolder = adressFieldOut.Text + @"\Temp";
                    //Copy temporary files
                    CopyFiles(Parts, TempFolder);
                    //Erase previous list of files
                    Parts.Clear();
                    try
                    {
                        for (int i = 0; i < listOfStatement.CheckedItems.Count; i++)
                        {
                            //Search, sort and add files to the list
                            string fileNameFromTable = listOfStatement.CheckedItems[i].ToString() + ".*.*";
                            Search.TraverseTree(TempFolder, fileNameFromTable);
                            BeginInvoke(new progressBarDelegate(UpdateProgressBar), i, listOfStatement.CheckedItems.Count);
                        }
                    }
                    catch (ThreadAbortException e)
                    {
                        Console.WriteLine(e.Message);
                        Thread.ResetAbort();
                    }

                    CopyFiles(Parts, adressFieldOut.Text);
                    // Delete temp folder
                    Directory.Delete(TempFolder, true);
                }
                else
                {
                    CopyFiles(Parts, adressFieldOut.Text);
                }
            }            
            searchThread.Abort();

        }
        //Update Progress Bar method
        private void UpdateProgressBar(int value, int maxValue)
        {
            progressBar1.Value = value + 1;
            progressBar1.Maximum = maxValue;
        }
        //Update path directory (very slow)
        public void UpdateProgressText(bool t)
        {
            //Thread.Sleep(1);
            ChangeDir = t;
            if (Parts == null)
            {
                BeginInvoke(new directoryStatus(TextUpdater), Search.currentDirectoryText);
            }
            
            ChangeDir = false;
        }
        //Update textBox sattusDirectory
        public void TextUpdater(string text) 
        {
            statusDirectory.Text = text;
        }
        
        private void FillListOfFoundedFiles()
        {
            foreach (var item in Parts)
            {
                listOfFoundedFiles.Items.Add(item, CheckState.Checked);
            }
            btnStartCopy.Enabled = true;
            btnStartCopy.Text = "Начать копирование";
        }

        private void CopyFiles(List<string> input, string outputPath)
        {
            foreach (var f in input)
            {
                var position = f.LastIndexOf(@"\");
                // Remove path from the file name.
                string fName = f.Substring(position + 1);
                // Copy files
                // Will overwrite if the destination file already exists.
                File.Copy(f, Path.Combine(outputPath, fName), true);
            }
        }

        private void AdressField_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void AdressField_DragDrop(object sender, DragEventArgs e)
        {
            
            string[] folderNameIn = (string[])e.Data.GetData(DataFormats.FileDrop);
            string[] folderNameOut = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (Directory.Exists(folderNameIn[0]) || Directory.Exists(folderNameOut[0]))
            {
                if (sender == adressFieldIn)
                {
                    adressFieldIn.Text = folderNameIn[0];
                }
                else
                {
                    adressFieldOut.Text = folderNameOut[0];
                }
            }
        }

        private void BtnAdress_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
            if (sender == btnFromDir)
            {
                adressFieldIn.Text = folderBrowserDialog.SelectedPath;
            }
            else
            {
                adressFieldOut.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ObjExcel.Workbooks.Close();
            //ObjExcel.Quit();           
        }
        //Read config
        private string DefaulDirectoryInitialization()
        {
            string defaultPath = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @"\config.nmc");
            return defaultPath;
        }
    }
}
