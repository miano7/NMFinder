namespace NMFinder
{
    partial class NMFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NMFinder));
            this.btnStartCopy = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.statusDirectory = new System.Windows.Forms.Label();
            this.tBox_Coll_Index = new System.Windows.Forms.TextBox();
            this.statmentOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listOfStatement = new System.Windows.Forms.CheckedListBox();
            this.btnFromDir = new System.Windows.Forms.Button();
            this.adressFieldIn = new System.Windows.Forms.TextBox();
            this.btnToDir = new System.Windows.Forms.Button();
            this.adressFieldOut = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.copyOnlyLastVersionsChk = new System.Windows.Forms.CheckBox();
            this.listOfFoundedFiles = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartCopy
            // 
            this.btnStartCopy.Location = new System.Drawing.Point(522, 397);
            this.btnStartCopy.Name = "btnStartCopy";
            this.btnStartCopy.Size = new System.Drawing.Size(120, 98);
            this.btnStartCopy.TabIndex = 0;
            this.btnStartCopy.Text = "Начать копирование";
            this.btnStartCopy.UseVisualStyleBackColor = true;
            this.btnStartCopy.Click += new System.EventHandler(this.StartCopyBtn_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(13, 397);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(495, 30);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.Text = "Открыть ведомость";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.BtnOpenFile_Click);
            // 
            // statusDirectory
            // 
            this.statusDirectory.AutoSize = true;
            this.statusDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusDirectory.CausesValidation = false;
            this.statusDirectory.ForeColor = System.Drawing.Color.DarkOrange;
            this.statusDirectory.Location = new System.Drawing.Point(13, 536);
            this.statusDirectory.Name = "statusDirectory";
            this.statusDirectory.Size = new System.Drawing.Size(0, 13);
            this.statusDirectory.TabIndex = 3;
            // 
            // tBox_Coll_Index
            // 
            this.tBox_Coll_Index.Location = new System.Drawing.Point(16, 21);
            this.tBox_Coll_Index.Name = "tBox_Coll_Index";
            this.tBox_Coll_Index.Size = new System.Drawing.Size(24, 20);
            this.tBox_Coll_Index.TabIndex = 4;
            this.tBox_Coll_Index.Text = "0";
            // 
            // statmentOpenFileDialog
            // 
            this.statmentOpenFileDialog.FileName = "...Find_me...";
            // 
            // listOfStatement
            // 
            this.listOfStatement.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listOfStatement.FormattingEnabled = true;
            this.listOfStatement.HorizontalScrollbar = true;
            this.listOfStatement.Location = new System.Drawing.Point(6, 19);
            this.listOfStatement.Name = "listOfStatement";
            this.listOfStatement.Size = new System.Drawing.Size(254, 308);
            this.listOfStatement.TabIndex = 5;
            // 
            // btnFromDir
            // 
            this.btnFromDir.Location = new System.Drawing.Point(13, 433);
            this.btnFromDir.Name = "btnFromDir";
            this.btnFromDir.Size = new System.Drawing.Size(94, 30);
            this.btnFromDir.TabIndex = 6;
            this.btnFromDir.Text = "Копировать из";
            this.btnFromDir.UseVisualStyleBackColor = true;
            this.btnFromDir.Click += new System.EventHandler(this.BtnAdress_Click);
            // 
            // adressFieldIn
            // 
            this.adressFieldIn.AllowDrop = true;
            this.adressFieldIn.Location = new System.Drawing.Point(113, 439);
            this.adressFieldIn.Name = "adressFieldIn";
            this.adressFieldIn.Size = new System.Drawing.Size(395, 20);
            this.adressFieldIn.TabIndex = 7;
            this.adressFieldIn.Text = "Выберите или перетащите папку...";
            this.adressFieldIn.DragDrop += new System.Windows.Forms.DragEventHandler(this.AdressField_DragDrop);
            this.adressFieldIn.DragEnter += new System.Windows.Forms.DragEventHandler(this.AdressField_DragEnter);
            // 
            // btnToDir
            // 
            this.btnToDir.Location = new System.Drawing.Point(13, 469);
            this.btnToDir.Name = "btnToDir";
            this.btnToDir.Size = new System.Drawing.Size(94, 30);
            this.btnToDir.TabIndex = 8;
            this.btnToDir.Text = "Копировать в";
            this.btnToDir.UseVisualStyleBackColor = true;
            this.btnToDir.Click += new System.EventHandler(this.BtnAdress_Click);
            // 
            // adressFieldOut
            // 
            this.adressFieldOut.AllowDrop = true;
            this.adressFieldOut.Location = new System.Drawing.Point(113, 475);
            this.adressFieldOut.Name = "adressFieldOut";
            this.adressFieldOut.Size = new System.Drawing.Size(395, 20);
            this.adressFieldOut.TabIndex = 9;
            this.adressFieldOut.Text = "Выберите или перетащите папку...";
            this.adressFieldOut.DragDrop += new System.Windows.Forms.DragEventHandler(this.AdressField_DragDrop);
            this.adressFieldOut.DragEnter += new System.Windows.Forms.DragEventHandler(this.AdressField_DragEnter);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 505);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(628, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // copyOnlyLastVersionsChk
            // 
            this.copyOnlyLastVersionsChk.AutoSize = true;
            this.copyOnlyLastVersionsChk.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.copyOnlyLastVersionsChk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copyOnlyLastVersionsChk.Location = new System.Drawing.Point(198, 22);
            this.copyOnlyLastVersionsChk.Name = "copyOnlyLastVersionsChk";
            this.copyOnlyLastVersionsChk.Size = new System.Drawing.Size(446, 20);
            this.copyOnlyLastVersionsChk.TabIndex = 11;
            this.copyOnlyLastVersionsChk.Text = "Копировать только последнии версии вне зависимости от директории";
            this.copyOnlyLastVersionsChk.UseVisualStyleBackColor = true;
            // 
            // listOfFoundedFiles
            // 
            this.listOfFoundedFiles.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listOfFoundedFiles.FormattingEnabled = true;
            this.listOfFoundedFiles.HorizontalScrollbar = true;
            this.listOfFoundedFiles.Location = new System.Drawing.Point(294, 68);
            this.listOfFoundedFiles.Name = "listOfFoundedFiles";
            this.listOfFoundedFiles.Size = new System.Drawing.Size(342, 308);
            this.listOfFoundedFiles.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listOfStatement);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox1.Location = new System.Drawing.Point(16, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 342);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файлы ведомости";
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.groupBox2.Location = new System.Drawing.Point(288, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 342);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Список найденных файлов";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(46, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Номер столбца от 0...";
            // 
            // NMFinder
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(656, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listOfFoundedFiles);
            this.Controls.Add(this.copyOnlyLastVersionsChk);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.adressFieldOut);
            this.Controls.Add(this.btnToDir);
            this.Controls.Add(this.adressFieldIn);
            this.Controls.Add(this.btnFromDir);
            this.Controls.Add(this.tBox_Coll_Index);
            this.Controls.Add(this.statusDirectory);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnStartCopy);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NMFinder";
            this.Text = "NMFinder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartCopy;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label statusDirectory;
        private System.Windows.Forms.TextBox tBox_Coll_Index;
        private System.Windows.Forms.OpenFileDialog statmentOpenFileDialog;
        private System.Windows.Forms.CheckedListBox listOfStatement;
        private System.Windows.Forms.Button btnFromDir;
        private System.Windows.Forms.TextBox adressFieldIn;
        private System.Windows.Forms.Button btnToDir;
        private System.Windows.Forms.TextBox adressFieldOut;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.CheckBox copyOnlyLastVersionsChk;
        private System.Windows.Forms.CheckedListBox listOfFoundedFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}

