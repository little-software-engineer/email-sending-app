using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace EmailSendingApp
{
    public partial class SelectRecipientsForm : Form //This is the second form for sending emails only to selected adresses
        
    {
        private string[] attachmentFilePaths;
        private List<string> recipients;
        // Read the email body content from the external file
        string emailBodyContent = File.ReadAllText("emailBody.txt");
        public List<string> SelectedRecipients { get; private set; }
        public SelectRecipientsForm(List<string> recipients, string[] attachmentFilePaths)
        {
            InitializeComponent();
            this.recipients = recipients;
            this.attachmentFilePaths = attachmentFilePaths;

            foreach (string recipient in recipients)
            {
                listBoxEmails.Items.Add(recipient);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSendSelected_Click(object sender, EventArgs e)
        {
            SelectedRecipients = new List<string>();

            foreach (string item in listBoxEmails.SelectedItems)
            {
                SelectedRecipients.Add(item);
            }

            SendEmails(SelectedRecipients);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SendEmails(List<string> recipients)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)outlookApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                foreach (string recipient in recipients)
                {
                    mailItem.Recipients.Add(recipient);
                }

                mailItem.Subject = ""; // Subject will be defined by the user in Outlook.

                // Retrieve Outlook signature
                string outlookSignature = GetOutlookSignature();

                // Append Outlook signature to the email body content
                string fullEmailBody = emailBodyContent + GetOutlookSignature();

                // Set the email body
                mailItem.HTMLBody = fullEmailBody;

                foreach (string attachmentFilePath in attachmentFilePaths)
                {
                    if (!string.IsNullOrEmpty(attachmentFilePath))
                    {
                        mailItem.Attachments.Add(attachmentFilePath);
                    }
                }

                mailItem.Display(false);
                // MessageBox.Show("Emails sent successfully.");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error sending emails: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
