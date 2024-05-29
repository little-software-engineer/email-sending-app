# Email Sending Application

The **Email Sending Application** is a straightforward yet robust tool designed to simplify the process of sending personalized emails to multiple recipients along with attachments. Developed as part of an internship project, this application harnesses the Microsoft Office Interop Outlook API to seamlessly integrate with Outlook, enabling users to compose and dispatch emails directly from their Outlook account.

## Key Features

- **Bulk Email Sending**: Seamlessly send emails to multiple recipients by selecting email addresses from a data file.
- **Attachment Support**: Attach files such as Excel spreadsheets or PDF documents to your emails for added context.
- **Recipient Selection**: Choose recipients from a list or send emails to all the addresses found in the corresponding row of the `data.txt` file based on the file name.
- **Dynamic Email Subject**: Automatically set the email subject based on the first entry in the corresponding row of the `data.txt` file and the current week number from the Outlook calendar.
- **Outlook Integration**: Leverage the familiar interface of Microsoft Outlook for composing and sending emails, ensuring a smooth user experience.

## Usage

1. **Select Files**: Choose Excel or PDF files to be sent as attachments. The application supports selecting multiple files at once.
2. **Recipient Selection**:
   - **Send All**: Automatically send emails to all recipients listed in the `data.txt` file based on the file name.
   - **Send Selected**: Open a form to manually select recipients from a list before sending the email.
3. **Compose Email**: The email body can be customized, and the email subject is automatically set using the format `BR224 CW23` where `BR224` is the first entry from the `data.txt` file and `CW23` represents the current week number.
4. **Send Email**: Send the email directly from Outlook with the click of a button.

## Setup Instructions

### Prerequisites

- Microsoft Outlook installed on your system.
- .NET Framework installed.

### Steps

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/your-username/email-sending-application.git
