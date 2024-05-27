namespace EmailSendingApp
{
    partial class SelectRecipientsForm
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
            listBoxEmails = new ListBox();
            buttonSendSelected = new Button();
            buttonCancel = new Button();
            buttonClose = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBoxEmails
            // 
            listBoxEmails.FormattingEnabled = true;
            listBoxEmails.Location = new Point(43, 117);
            listBoxEmails.Name = "listBoxEmails";
            listBoxEmails.Size = new Size(639, 104);
            listBoxEmails.TabIndex = 0;
            listBoxEmails.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // buttonSendSelected
            // 
            buttonSendSelected.Location = new Point(56, 269);
            buttonSendSelected.Name = "buttonSendSelected";
            buttonSendSelected.Size = new Size(389, 29);
            buttonSendSelected.TabIndex = 1;
            buttonSendSelected.Text = "Send Selected";
            buttonSendSelected.UseVisualStyleBackColor = true;
            buttonSendSelected.Click += buttonSendSelected_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(473, 269);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(588, 269);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(94, 29);
            buttonClose.TabIndex = 3;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(633, 380);
            label2.Name = "label2";
            label2.Size = new Size(153, 17);
            label2.TabIndex = 8;
            label2.Text = "Made by Bojana Stajić";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._2560px_Adient_svg;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(158, 71);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // SelectRecipientsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(798, 406);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(buttonClose);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSendSelected);
            Controls.Add(listBoxEmails);
            Name = "SelectRecipientsForm";
            Text = "eEmail - Select Recipients";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxEmails;
        private Button buttonSendSelected;
        private Button buttonCancel;
        private Button buttonClose;
        private Label label2;
        private PictureBox pictureBox1;
    }
}