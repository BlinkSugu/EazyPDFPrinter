namespace EazyPDFPrinter
{
    partial class EazyPDFPrinter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EazyPDFPrinter));
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            PDFName = new DataGridViewTextBoxColumn();
            PrintPage = new DataGridViewTextBoxColumn();
            Action = new DataGridViewButtonColumn();
            pathTextBox = new TextBox();
            button1 = new Button();
            label1 = new Label();
            checkBox1 = new CheckBox();
            PageNotextBox = new TextBox();
            label2 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label3 = new Label();
            linkLabel1 = new LinkLabel();
            button6 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(12, 93);
            panel1.Name = "panel1";
            panel1.Size = new Size(900, 349);
            panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SunkenVertical;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { PDFName, PrintPage, Action });
            dataGridView1.Location = new Point(0, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(897, 343);
            dataGridView1.TabIndex = 0;
            dataGridView1.VirtualMode = true;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // PDFName
            // 
            PDFName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            PDFName.Frozen = true;
            PDFName.HeaderText = "PDF Path and Name";
            PDFName.MinimumWidth = 6;
            PDFName.Name = "PDFName";
            PDFName.Width = 594;
            // 
            // PrintPage
            // 
            PrintPage.Frozen = true;
            PrintPage.HeaderText = "Print Page";
            PrintPage.MinimumWidth = 6;
            PrintPage.Name = "PrintPage";
            PrintPage.Width = 125;
            // 
            // Action
            // 
            Action.Frozen = true;
            Action.HeaderText = "Delete";
            Action.MinimumWidth = 6;
            Action.Name = "Action";
            Action.Text = "Delete";
            Action.ToolTipText = "Delete Row";
            Action.UseColumnTextForButtonValue = true;
            Action.Width = 125;
            // 
            // pathTextBox
            // 
            pathTextBox.Location = new Point(147, 16);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.ReadOnly = true;
            pathTextBox.Size = new Size(627, 27);
            pathTextBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(780, 14);
            button1.Name = "button1";
            button1.Size = new Size(91, 29);
            button1.TabIndex = 2;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 3;
            label1.Text = "PDF Folder Path:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(256, 55);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(166, 24);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "IsSamePageInAllPDF";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // PageNotextBox
            // 
            PageNotextBox.BackColor = Color.White;
            PageNotextBox.Enabled = false;
            PageNotextBox.Location = new Point(120, 53);
            PageNotextBox.MaxLength = 5;
            PageNotextBox.Name = "PageNotextBox";
            PageNotextBox.Size = new Size(77, 27);
            PageNotextBox.TabIndex = 5;
            PageNotextBox.Text = "1";
            PageNotextBox.TextAlign = HorizontalAlignment.Center;
            PageNotextBox.KeyPress += textBox2_KeyPress;
            PageNotextBox.Leave += PageNotextBox_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 56);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 6;
            label2.Text = "Page Number:";
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.InitialDirectory = "Documents";
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(597, 55);
            button2.Name = "button2";
            button2.Size = new Size(177, 29);
            button2.TabIndex = 7;
            button2.Text = "Start Print";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button3.Enabled = false;
            button3.Location = new Point(203, 49);
            button3.Name = "button3";
            button3.Size = new Size(47, 33);
            button3.TabIndex = 8;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(780, 55);
            button4.Name = "button4";
            button4.Size = new Size(129, 29);
            button4.TabIndex = 9;
            button4.Text = "Clear All";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Zoom;
            button5.Location = new Point(872, 11);
            button5.Name = "button5";
            button5.Size = new Size(40, 35);
            button5.TabIndex = 10;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 452);
            label3.Name = "label3";
            label3.Size = new Size(181, 20);
            label3.TabIndex = 11;
            label3.Text = "Download Adobe Reader:";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(199, 452);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(78, 20);
            linkLabel1.TabIndex = 12;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Download";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button6
            // 
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Zoom;
            button6.Location = new Point(872, 445);
            button6.Name = "button6";
            button6.Size = new Size(37, 37);
            button6.TabIndex = 13;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // EazyPDFPrinter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(920, 485);
            Controls.Add(button6);
            Controls.Add(linkLabel1);
            Controls.Add(label3);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(PageNotextBox);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(pathTextBox);
            Controls.Add(panel1);
            Name = "EazyPDFPrinter";
            Text = "EazyPDFPrinter";
            Load += EazyPDFPrinter_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox pathTextBox;
        private Button button1;
        private Label label1;
        private CheckBox checkBox1;
        private TextBox PageNotextBox;
        private Label label2;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn PDFName;
        private DataGridViewTextBoxColumn PrintPage;
        private DataGridViewButtonColumn Action;
        private Button button5;
        private Label label3;
        private LinkLabel linkLabel1;
        private Button button6;
    }
}
