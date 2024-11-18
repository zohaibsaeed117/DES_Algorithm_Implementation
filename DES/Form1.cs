using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace DES
{
    public partial class Form1 : Form
    {
        bool action = false;//false means encryption
        string filePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void radio_encrypt_CheckedChanged(object sender, EventArgs e)
        {
            Action_btn.Text = "Encrypt";
            action = false;
        }

        private void radio_decrypt_CheckedChanged(object sender, EventArgs e)
        {
            Action_btn.Text = "Decrypt";
            action = true;

        }

        private void UploadFileBtn_Click(object sender, EventArgs e)
        {
            // Create and configure the OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"; // Filter for PDF files
            openFileDialog.Title = "Select a PDF file";

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                filePath = openFileDialog.FileName;

                file_lbl.Text = filePath.Split('\\').Last();
            }
        }

        private void Action_btn_Click(object sender, EventArgs e)
        {
            string key = key_input.Text;
            if (key == "")
            {
                MessageBox.Show("Please enter a key:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (key.Length < 8)
            {
                MessageBox.Show("Key must be atleast 8 character long", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (key.Length > 8)
            {
                key = key.Substring(0, 8);
            }

            if (filePath.Length<=0)
            {
                MessageBox.Show("Please select a pdf file first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string extractedText = ExtractTextFromPdf(filePath);
            string saveText;
            DES des=new DES();
            if (!action)
            {
                saveText = des.Encrpyt(extractedText, key);
            }
            else
            {
                saveText = des.Decrypt(extractedText, key);
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"; // File filter for PDFs
            saveFileDialog.Title = "Save PDF as";

            // Check if user has selected a valid file path
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string filePath = saveFileDialog.FileName;

                // Create and save the PDF at the selected path
                CreatePdf(filePath,saveText);

                // Inform the user that the file has been saved
                MessageBox.Show("PDF file saved successfully to: " + filePath);
            }

        }
        private void CreatePdf(string filePath,string text)
        {
            // Create a PdfWriter instance to write the document
            using (PdfWriter writer = new PdfWriter(filePath))
            {
                // Create a PdfDocument instance
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    // Create a Document object to add content
                    Document document = new Document(pdf);

                    // Add content to the PDF
                    document.Add(new Paragraph(text));

                    // You can add more content, such as tables, images, etc.
                }
            }
        }
        private string ExtractTextFromPdf(string pdfFilePath)
        {
            StringBuilder text = new StringBuilder();

            // Open the PDF file
            using (PdfReader reader = new PdfReader(pdfFilePath))
            using (PdfDocument pdfDoc = new PdfDocument(reader))
            {
                // Iterate through each page of the PDF
                for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
                {
                    // Extract text from each page
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string pageText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
                    text.AppendLine(pageText);
                }
            }

            return text.ToString();
        }
    }

}
