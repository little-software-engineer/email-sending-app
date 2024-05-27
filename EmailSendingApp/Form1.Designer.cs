
namespace EmailSendingApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            buttonSendAll = new Button();
            buttonSendSelected = new Button();
            buttonClose = new Button();
            buttonCancel = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            pictureBoxBrowse = new PictureBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            listBox1 = new ListBox();
            label3 = new Label();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxBrowse).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(48, 97);
            label1.Name = "label1";
            label1.Size = new Size(241, 41);
            label1.TabIndex = 1;
            label1.Text = "Select file/folder:";
            label1.Click += label1_Click;
            // 
            // buttonSendAll
            // 
            buttonSendAll.Location = new Point(47, 260);
            buttonSendAll.Name = "buttonSendAll";
            buttonSendAll.Size = new Size(140, 40);
            buttonSendAll.TabIndex = 2;
            buttonSendAll.Text = "Send All";
            buttonSendAll.UseVisualStyleBackColor = true;
            buttonSendAll.Click += button1_Click;
            // 
            // buttonSendSelected
            // 
            buttonSendSelected.Location = new Point(193, 260);
            buttonSendSelected.Name = "buttonSendSelected";
            buttonSendSelected.Size = new Size(145, 40);
            buttonSendSelected.TabIndex = 3;
            buttonSendSelected.Text = "Send Selected";
            buttonSendSelected.UseVisualStyleBackColor = true;
            buttonSendSelected.Click += buttonSendSelected_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(344, 260);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(142, 40);
            buttonClose.TabIndex = 4;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += button3_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(492, 260);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(142, 40);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.HelpRequest += folderBrowserDialog1_HelpRequest;
            // 
            // pictureBoxBrowse
            // 
            pictureBoxBrowse.Image = (Image)resources.GetObject("pictureBoxBrowse.Image");
            pictureBoxBrowse.Location = new Point(687, 120);
            pictureBoxBrowse.Name = "pictureBoxBrowse";
            pictureBoxBrowse.Size = new Size(76, 59);
            pictureBoxBrowse.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxBrowse.TabIndex = 6;
            pictureBoxBrowse.TabStop = false;
            pictureBoxBrowse.Click += pictureBoxBrowse_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(665, 327);
            label2.Name = "label2";
            label2.Size = new Size(153, 17);
            label2.TabIndex = 7;
            label2.Text = "Made by Bojana Stajić";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._2560px_Adient_svg;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(158, 71);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            listBox1.ForeColor = Color.LimeGreen;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(48, 141);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(611, 84);
            listBox1.TabIndex = 9;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(687, 97);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 10;
            label3.Text = "Select a file";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(680, 182);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 12;
            label4.Text = "Select a folder";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.folder_browse;
            pictureBox2.Location = new Point(680, 205);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(93, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 353);
            Controls.Add(pictureBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(listBox1);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(pictureBoxBrowse);
            Controls.Add(buttonCancel);
            Controls.Add(buttonClose);
            Controls.Add(buttonSendSelected);
            Controls.Add(buttonSendAll);
            Controls.Add(label1);
            Name = "Form1";
            Text = "eEmail";
            ((System.ComponentModel.ISupportInitialize)pictureBoxBrowse).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button buttonSendAll;
        private Button buttonSendSelected;
        private Button buttonClose;
        private Button buttonCancel;
        private FolderBrowserDialog folderBrowserDialog1;
        private PictureBox pictureBoxBrowse;
        private Label label2;
        private PictureBox pictureBox1;
        private ListBox listBox1;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox2;
    }
}
