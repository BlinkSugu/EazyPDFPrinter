using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using System.Diagnostics;
using Microsoft.Win32;
using System.Xml.Linq;
using System.Xml.XPath;

namespace EazyPDFPrinter
{
    public partial class EazyPDFPrinter : Form
    {
        public string DefaultPath { get; set; } = string.Empty;
        public string DefaultExePath { get; set; } = string.Empty;
        public string myDocs { get; set; } = string.Empty;

        public EazyPDFPrinter()
        {
            InitializeComponent();
            dataGridView1.CellClick += (s, e) =>
            {
                // Check if the clicked cell is in the "Delete" button column
                if (e.ColumnIndex == dataGridView1.Columns["Action"].Index && e.RowIndex >= 0)
                {
                    // Remove the row that contains the clicked "Delete" button
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            };
            dataGridView1.Columns[1].ReadOnly = true;
        }


        private void EazyPDFPrinter_Load(object sender, EventArgs e)
        {
            if (DateTime.Now.Year > 2025)
            {
                return;
            }
            myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!File.Exists("EazyPDFPrinterSettings.xml"))
            {
                createSettingsXML();
            }
            try
            {
                XDocument xdoc = XDocument.Load("EazyPDFPrinterSettings.xml");
                if (xdoc != null && xdoc.Root != null)
                {
                    if (xdoc.Root.XPathSelectElement("Software") != null && xdoc.Root.XPathSelectElement("Software/Name") != null && xdoc.Root.XPathSelectElement("Software/ExePath") != null)
                    {
                        DefaultExePath = xdoc.Root.XPathSelectElement("Software/ExePath")?.Value ?? string.Empty;
                    }
                    if (xdoc.Root.XPathSelectElement("Directory") != null && xdoc.Root.XPathSelectElement("Directory/Default") != null)
                    {
                        DefaultPath = xdoc.Root.XPathSelectElement("Directory/Default")?.Value ?? myDocs;
                        pathTextBox.Text = DefaultPath;
                        folderBrowserDialog1.SelectedPath = DefaultPath;
                    }
                }
            }
            catch (Exception)
            {
                createSettingsXML();
                MessageBox.Show("Settings XML has issue, so XML resets to original state!");
            }
            folderBrowserDialog1.InitialDirectory = DefaultPath;
            label3.Visible = false;
            linkLabel1.Visible = false;
            GridLoadFunc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                GridLoadFunc();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.CheckState == CheckState.Unchecked)
            {
                PageNotextBox.Enabled = false;
                dataGridView1.Columns[1].ReadOnly = false;
                button3.Enabled = false;
            }
            else
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    PageNotextBox.Enabled = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    button3.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Loop through each row in the DataGridView
            try
            {
                PdfDocument printDoc = new PdfDocument();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string? pdfFilePath = row.Cells[0].Value?.ToString(); // Assuming file path is in the first column
                    string? pageNumbersText = row.Cells[1].Value?.ToString(); // Assuming page numbers are in the second column

                    if (string.IsNullOrEmpty(pdfFilePath) || string.IsNullOrEmpty(pageNumbersText))
                        continue;

                    // Parse the page numbers from the text (e.g., "1,3-5" -> [1,3,4,5])
                    List<int> pagesToPrint = ParsePageNumbers(pageNumbersText);

                    // Load the PDF
                    using (PdfDocument pdfDoc = PdfReader.Open(pdfFilePath, PdfDocumentOpenMode.Import))
                    {
                        foreach (int pageNumber in pagesToPrint)
                        {
                            if (pageNumber > 0 && pageNumber <= pdfDoc.PageCount)
                            {
                                // Add the specified page to the print document
                                printDoc.AddPage(pdfDoc.Pages[pageNumber - 1]);
                            }
                        }
                    }
                }
                // Print the PDF
                string tempFilePath = myDocs + "/temp_print.pdf";
                printDoc.Save(tempFilePath);
                PrintPDF(tempFilePath);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Error", "Close the \"temp_print.pdf\" from MyDocuments directory! Then try again.");
            }
        }

        private string? GetDefaultPdfApplication(RegistryKey? registryKey)
        {
            // Check the registry for the default application associated with .pdf files
            using (RegistryKey? pdfAppKey = registryKey)
            {
                if (pdfAppKey != null)
                {
                    // Retrieve the default command path
                    string? command = pdfAppKey.GetValue("") as string;

                    if (!string.IsNullOrEmpty(command))
                    {
                        // Remove additional parameters, keeping only the executable path
                        string exePath = command.Split(new[] { '\"' }, StringSplitOptions.RemoveEmptyEntries)[0];

                        if (File.Exists(exePath))
                        {
                            return exePath;
                        }
                    }
                }
            }

            return null;
        }

        private void PrintPDF(string pdfFilePath)
        {
            // Check if Adobe Reader is installed and set as the default print application
            string? softwarePath = string.Empty;
            if (string.IsNullOrEmpty(DefaultExePath) || !File.Exists(DefaultExePath))
            {
                softwarePath = GetDefaultPdfApplication(Registry.ClassesRoot.OpenSubKey(@"SOFTWARE\Adobe\Acrobat\Exe"));
            }
            else
            {
                softwarePath = DefaultExePath;
            }

            // Check if the Adobe Reader executable exists
            if (!File.Exists(softwarePath))
            {
                MessageBox.Show("Error!", "PDF print software not found. Please install Adobe Reader or specify an alternative PDF reader path.");
                label3.Visible = true;
                linkLabel1.Visible = true;
                return;
            }

            // Create the process to open Adobe Reader and print the PDF
            Process printProcess = new Process();
            printProcess.StartInfo.FileName = softwarePath;
            printProcess.StartInfo.Arguments = $"/p \"{pdfFilePath}\""; // /p for print, /h for hiding Adobe window
            printProcess.StartInfo.CreateNoWindow = false;
            printProcess.StartInfo.UseShellExecute = false;

            try
            {
                printProcess.Start();
                printProcess.WaitForExit(10000); // Wait for up to 10 seconds for printing to start
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!", $"An error occurred while trying to print the PDF: {ex.Message}");
            }
        }

        private void PageNotextBox_Leave(object sender, EventArgs e)
        {
            button3.Enabled = !string.IsNullOrEmpty(PageNotextBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[1].Value = PageNotextBox.Text;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            button4.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = false;
            PageNotextBox.Enabled = false;
            pathTextBox.Text = string.Empty;
            folderBrowserDialog1.SelectedPath = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private List<int> ParsePageNumbers(string pageNumbersText)
        {
            List<int> pages = new List<int>();
            string[] parts = pageNumbersText.Split(',');

            foreach (string part in parts)
            {
                if (part.Contains("-"))
                {
                    string[] range = part.Split('-');
                    int start = int.Parse(range[0]);
                    int end = int.Parse(range[1]);

                    for (int i = start; i <= end; i++)
                    {
                        pages.Add(i);
                    }
                }
                else
                {
                    pages.Add(int.Parse(part));
                }
            }

            return pages;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!File.Exists("EazyPDFPrinterSettings.xml"))
            {
                createSettingsXML();
            }
            var xmlpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EazyPDFPrinterSettings.xml");
            Process.Start(new ProcessStartInfo() { UseShellExecute = true, CreateNoWindow = true, FileName = "notepad.exe", Arguments = xmlpath });
        }
        private void createSettingsXML()
        {
            XDocument xdoc = new XDocument();
            xdoc.Add(
                new XElement("EazyPDFPrinterSettings",
                new XElement("Software",
                    new XElement("Name", "Adobe"),
                    new XElement("ExePath", @"c:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe")
                ),
                new XElement("Directory",
                    new XElement("Default", myDocs)
                )));
            string xmlcont = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" + xdoc.ToString();
            File.WriteAllText("EazyPDFPrinterSettings.xml", xmlcont);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://get.adobe.com/reader/");
        }

        private void GridLoadFunc()
        {
            if (!string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath) && Directory.Exists(folderBrowserDialog1.SelectedPath))
            {
                if (dataGridView1 == null)
                {
                    dataGridView1 = new DataGridView
                    {
                        Dock = DockStyle.Fill // Adjust the DockStyle as needed
                    };

                    // Add the DataGridView to the form (if not already added)
                    this.Controls.Add(dataGridView1);
                }
                dataGridView1.VirtualMode = false;

                // Clear existing columns and rows
                //dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();


                string selPath = folderBrowserDialog1.SelectedPath;
                pathTextBox.Text = selPath;
                var pdfs = Directory.GetFiles(selPath, "*.pdf");

                foreach (var file in pdfs)
                {
                    dataGridView1.Rows.Add(file, PageNotextBox.Text);
                }
                dataGridView1.Refresh();
                button2.Enabled = true;
                PageNotextBox.Enabled = true;
                button3.Enabled = !string.IsNullOrEmpty(PageNotextBox.Text);
                button4.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }
    }
}
