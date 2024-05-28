using System.Net.Mail;
using System.Net;
using Outlook = Microsoft.Office.Interop.Outlook;
using OfficeOpenXml;
using System.IO;
using Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;
using System.Globalization;

namespace EmailSendingApp
{
    public partial class Form1 : Form
    {
        private List<string> selectedFilePaths = new List<string>();
        private string selectedFolderPath = "";


        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SendEmail(string emailAddresses, string subject, string body, string attachmentFilePath)//This method is for sending emails
        {
            try
            {
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mail = outlookApp.CreateItem(Outlook.OlItemType.olMailItem) as Outlook.MailItem;

                mail.Subject = subject;

                // Append the body content and Outlook signature
                mail.HTMLBody = body + "<br><br>" + GetOutlookSignature();

                // Add recipients
                foreach (var emailAddress in emailAddresses.Split(';'))
                {
                    if (!string.IsNullOrWhiteSpace(emailAddress))
                    {
                        mail.Recipients.Add(emailAddress);
                    }
                }

                // Attach the file
                if (!string.IsNullOrEmpty(attachmentFilePath))
                {
                    mail.Attachments.Add(attachmentFilePath, Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                }

                // Display the email before sending (optional)
                mail.Display(false);

                // Send the email
                mail.Send();

                MessageBox.Show("Emails sent successfully.");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e) //button 1 is for Send All option
        {
            if (selectedFilePaths.Count == 0)
            {
                MessageBox.Show("Please select a file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Dictionary to store selected files grouped by their corresponding entries in data.txt
            Dictionary<string, List<string>> groupedFiles = new Dictionary<string, List<string>>();

            // Iterate over each selected file path and group them by their data.txt entry
            foreach (string filePath in selectedFilePaths)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                List<string> recipients = GetRecipientsFromDataFile(filePath);
                if (recipients.Count == 0)
                {
                    MessageBox.Show("No recipients found in data file for " + fileName + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                // Add the file path to the corresponding group in the dictionary
                if (!groupedFiles.ContainsKey(fileName))
                {
                    groupedFiles[fileName] = new List<string>();
                }
                groupedFiles[fileName].Add(filePath);
            }

            // Send emails for each group of files
            foreach (var entry in groupedFiles)
            {
                List<string> recipients = GetRecipientsFromDataFile(entry.Key);
                if (recipients.Count == 0)
                {
                    MessageBox.Show("No recipients found in data file for " + entry.Key + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                SendEmails(recipients, entry.Value);
            }
        }


        private void button3_Click(object sender, EventArgs e) //  buttons 3 is for Close option
        {
            this.Close();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBoxBrowse_Click(object sender, EventArgs e) //This method defines the logic behind clicking the pictureBoxBrowse for selecting the correct file
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel and PDF Files (*.xlsx, *.pdf)|*.xlsx;*.pdf";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePaths.Clear();
                selectedFilePaths.AddRange(openFileDialog.FileNames);

                // Clear the listbox before adding new files
                listBox1.Items.Clear();

                foreach (string filePath in selectedFilePaths)
                {
                    // Add each filename to the listbox
                    listBox1.Items.Add(Path.GetFileName(filePath));
                }
            }
        }






        private void buttonSendSelected_Click(object sender, EventArgs e)
        {
            if (selectedFilePaths.Count == 0)
            {
                MessageBox.Show("Please select a file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Dictionary to store selected files grouped by their corresponding entries in data.txt
            Dictionary<string, List<string>> groupedFiles = new Dictionary<string, List<string>>();

            // Iterate over each selected file path and group them by their data.txt entry
            foreach (string filePath in selectedFilePaths)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                List<string> recipients = GetRecipientsFromDataFile(filePath);
                if (recipients.Count == 0)
                {
                    MessageBox.Show("No recipients found in data file for " + fileName + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                // Add the file path to the corresponding group in the dictionary
                if (!groupedFiles.ContainsKey(fileName))
                {
                    groupedFiles[fileName] = new List<string>();
                }
                groupedFiles[fileName].Add(filePath);
            }

            // Open form for selecting recipients for each group of files
            foreach (var entry in groupedFiles)
            {
                using (SelectRecipientsForm form = new SelectRecipientsForm(GetRecipientsFromDataFile(entry.Key), entry.Value.ToArray()))
                {
                    form.ShowDialog();
                }
            }
        }
        private string GetSubjectFromDataFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines("data.txt");

                // Iterate over each line in the data.txt file
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new string[] { "---" }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 3 && parts[1].Trim().Equals(fileName, StringComparison.OrdinalIgnoreCase))
                    {
                        // Return the subject from the matching entry
                        return parts[0].Trim();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error reading data file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null; // If no matching entry is found, return null
        }

        private string GetSupplierFromDataFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines("data.txt");

                // Iterate over each line in the data.txt file
                foreach (string line in lines)
                {
                    string[] parts = line.Split(new string[] { "---" }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 3 && parts[1].Trim().Equals(fileName, StringComparison.OrdinalIgnoreCase))
                    {
                        // Return the subject from the matching entry
                        return parts[1].Trim();
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error reading data file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null; // If no matching entry is found, return null
        }
        private string GetCurrentWeek()
        {
            try
            {
                // Get the current date
                DateTime currentDate = DateTime.Now;

                // Return the ISO 8601 week number of the current date
                return GetIso8601WeekOfYear(currentDate).ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error getting current week from Outlook calendar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Unknown";
            }
        }

        private int GetIso8601WeekOfYear(DateTime date)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                date = date.AddDays(3);
            }

            // Return the ISO 8601 week number
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private List<string> GetRecipientsFromDataFile(string filePath)
        {
            List<string> recipients = new List<string>();
            string excelFileName = Path.GetFileNameWithoutExtension(filePath).ToLower();

            try
            {
                string[] lines = File.ReadAllLines("data.txt");

                foreach (string line in lines)
                {
                    string[] parts = line.Split(new string[] { "---" }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 3 && parts[1].Trim().Equals(excelFileName, StringComparison.OrdinalIgnoreCase))
                    {
                        string[] emails = parts[2].Split(';');
                        recipients.AddRange(emails);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error reading data file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return recipients;
        }

        private string GetOutlookSignature()
        {
            string signature = "";

            try
            {
                // Get the current Outlook application
                Outlook.Application outlookApp = new Outlook.Application();
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

                // Retrieve the current user's default signature
                string signaturePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Signatures\");
                DirectoryInfo signatureDirectory = new DirectoryInfo(signaturePath);

                if (signatureDirectory.Exists)
                {
                    // Find the latest modified HTML file which represents the signature
                    FileInfo[] signatureFiles = signatureDirectory.GetFiles("*.htm");

                    if (signatureFiles.Length > 0)
                    {
                        FileInfo latestSignatureFile = signatureFiles.OrderByDescending(f => f.LastWriteTime).First();
                        signature = File.ReadAllText(latestSignatureFile.FullName);
                    }
                }
            }
            catch (System.Exception ex)
            {
                // Handle any exceptions that might occur during the retrieval of the signature
                MessageBox.Show("Error retrieving Outlook signature: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return signature;
        }

        private void SendEmails(List<string> recipients, List<string> attachmentFilePaths)
        {
            try
            {
                // Define the path to the email body text file
                string emailBodyFilePath = "emailBody.txt";

                // Check if the emailBody.txt file exists
                if (File.Exists(emailBodyFilePath))
                {
                    // Read the content of the emailBody.txt file
                    string emailBodyContent = File.ReadAllText(emailBodyFilePath);

                    // Append Outlook signature to the email body content
                    string fullEmailBody = emailBodyContent + GetOutlookSignature();

                    // Iterate over each attachment file path
                    foreach (string attachmentFilePath in attachmentFilePaths)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(attachmentFilePath);

                        // Get the subject from data.txt based on the file name
                        string subject = GetSubjectFromDataFile(fileName);
                        string supplier = GetSupplierFromDataFile(fileName);

                        if (string.IsNullOrEmpty(subject))
                        {
                            MessageBox.Show("Subject not found in data file for " + fileName + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        if (string.IsNullOrEmpty(supplier))
                        {
                            MessageBox.Show("Supplier not found in data file for " + fileName + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        // Concatenate with "CW Current Week"
                        string emailSubject = "CW" + GetCurrentWeek() + " " + supplier + " " + subject;

                        // Create Outlook application and mail item
                        Outlook.Application outlookApp = new Outlook.Application();
                        Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);

                        // Add recipients
                        foreach (string recipient in recipients)
                        {
                            mailItem.Recipients.Add(recipient);
                        }

                        // Set subject
                        mailItem.Subject = emailSubject;

                        // Set email body
                        mailItem.HTMLBody = fullEmailBody;

                        // Add attachments
                        if (!string.IsNullOrEmpty(attachmentFilePath))
                        {
                            mailItem.Attachments.Add(attachmentFilePath);
                        }

                        // Display email
                        mailItem.Display(false);
                    }

                    // MessageBox.Show("Emails sent successfully.");
                }
                else
                {
                    // Show an error message to the user indicating that emailBody.txt is missing
                    MessageBox.Show("The email body file (emailBody.txt) is missing. Please make sure it exists in the application folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error sending emails: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SendSelectedEmails(List<string> recipients, List<string> attachmentFilePaths)
        {
            // Iterate over each attachment file path and process it individually
            foreach (string attachmentFilePath in attachmentFilePaths)
            {
                // Open new form for selecting recipients for the current attachment file
                using (var selectRecipientsForm = new SelectRecipientsForm(recipients, new string[] { attachmentFilePath }))
                {
                    if (selectRecipientsForm.ShowDialog() == DialogResult.OK)
                    {
                        List<string> selectedRecipients = selectRecipientsForm.SelectedRecipients;
                        if (selectedRecipients.Count > 0)
                        {
                            // Send emails for the selected recipients for the current attachment file
                            SendEmails(selectedRecipients, new List<string> { attachmentFilePath });
                        }
                        else
                        {
                            MessageBox.Show("No recipients selected for " + Path.GetFileName(attachmentFilePath) + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }




        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

            // Open folder browser dialog to select a folder containing Excel and PDF files
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder containing Excel and PDF files";
                folderBrowserDialog.ShowNewFolderButton = false;

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolderPath = folderBrowserDialog.SelectedPath;

                    // Clear existing selected file paths
                    selectedFilePaths.Clear();

                    // Process the selected folder
                    ProcessFolder(selectedFolderPath);

                    // Display selected files in the list box
                    DisplaySelectedFiles();
                }
            }
        }

        private void ProcessFolder(string folderPath)
        {
            // Get all Excel and PDF files in the selected folder
            string[] excelFiles = Directory.GetFiles(folderPath, "*.xlsx");
            string[] pdfFiles = Directory.GetFiles(folderPath, "*.pdf");

            // Add the paths of Excel and PDF files to selectedFilePaths
            selectedFilePaths.AddRange(excelFiles);
            selectedFilePaths.AddRange(pdfFiles);
        }

        private void DisplaySelectedFiles()
        {
            // Clear the list box before adding new files
            listBox1.Items.Clear();

            // Add each selected file to the list box
            foreach (string filePath in selectedFilePaths)
            {
                listBox1.Items.Add(Path.GetFileName(filePath));
            }
        }
    }

}
