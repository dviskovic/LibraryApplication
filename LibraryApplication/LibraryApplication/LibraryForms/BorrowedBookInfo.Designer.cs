namespace LibraryApplication.LibraryForms
{
    partial class BorrowedBookInfo
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorrowedBookInfo));
            this.ReturnButton = new System.Windows.Forms.Button();
            this.LateTextBox = new System.Windows.Forms.TextBox();
            this.LateLabel = new System.Windows.Forms.Label();
            this.UntilTextBox = new System.Windows.Forms.TextBox();
            this.BorrowedUntilLabel = new System.Windows.Forms.Label();
            this.AtTextBox = new System.Windows.Forms.TextBox();
            this.BorrowedAtLabel = new System.Windows.Forms.Label();
            this.BookTextBox = new System.Windows.Forms.TextBox();
            this.BookLabel = new System.Windows.Forms.Label();
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(12, 362);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(255, 23);
            this.ReturnButton.TabIndex = 0;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // LateTextBox
            // 
            this.LateTextBox.Enabled = false;
            this.LateTextBox.Location = new System.Drawing.Point(88, 336);
            this.LateTextBox.Name = "LateTextBox";
            this.LateTextBox.ReadOnly = true;
            this.LateTextBox.Size = new System.Drawing.Size(179, 20);
            this.LateTextBox.TabIndex = 1;
            // 
            // LateLabel
            // 
            this.LateLabel.AutoSize = true;
            this.LateLabel.Location = new System.Drawing.Point(12, 339);
            this.LateLabel.Name = "LateLabel";
            this.LateLabel.Size = new System.Drawing.Size(28, 13);
            this.LateLabel.TabIndex = 2;
            this.LateLabel.Text = "Late";
            // 
            // UntilTextBox
            // 
            this.UntilTextBox.Enabled = false;
            this.UntilTextBox.Location = new System.Drawing.Point(88, 310);
            this.UntilTextBox.Name = "UntilTextBox";
            this.UntilTextBox.ReadOnly = true;
            this.UntilTextBox.Size = new System.Drawing.Size(179, 20);
            this.UntilTextBox.TabIndex = 1;
            // 
            // BorrowedUntilLabel
            // 
            this.BorrowedUntilLabel.AutoSize = true;
            this.BorrowedUntilLabel.Location = new System.Drawing.Point(12, 313);
            this.BorrowedUntilLabel.Name = "BorrowedUntilLabel";
            this.BorrowedUntilLabel.Size = new System.Drawing.Size(76, 13);
            this.BorrowedUntilLabel.TabIndex = 2;
            this.BorrowedUntilLabel.Text = "Borrowed Until";
            // 
            // AtTextBox
            // 
            this.AtTextBox.Enabled = false;
            this.AtTextBox.Location = new System.Drawing.Point(88, 284);
            this.AtTextBox.Name = "AtTextBox";
            this.AtTextBox.ReadOnly = true;
            this.AtTextBox.Size = new System.Drawing.Size(179, 20);
            this.AtTextBox.TabIndex = 1;
            // 
            // BorrowedAtLabel
            // 
            this.BorrowedAtLabel.AutoSize = true;
            this.BorrowedAtLabel.Location = new System.Drawing.Point(12, 287);
            this.BorrowedAtLabel.Name = "BorrowedAtLabel";
            this.BorrowedAtLabel.Size = new System.Drawing.Size(65, 13);
            this.BorrowedAtLabel.TabIndex = 2;
            this.BorrowedAtLabel.Text = "Borrowed At";
            // 
            // BookTextBox
            // 
            this.BookTextBox.Enabled = false;
            this.BookTextBox.Location = new System.Drawing.Point(88, 258);
            this.BookTextBox.Name = "BookTextBox";
            this.BookTextBox.ReadOnly = true;
            this.BookTextBox.Size = new System.Drawing.Size(179, 20);
            this.BookTextBox.TabIndex = 1;
            // 
            // BookLabel
            // 
            this.BookLabel.AutoSize = true;
            this.BookLabel.Location = new System.Drawing.Point(12, 261);
            this.BookLabel.Name = "BookLabel";
            this.BookLabel.Size = new System.Drawing.Size(63, 13);
            this.BookLabel.TabIndex = 2;
            this.BookLabel.Text = "Book Name";
            // 
            // UserTextBox
            // 
            this.UserTextBox.Enabled = false;
            this.UserTextBox.Location = new System.Drawing.Point(88, 232);
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.ReadOnly = true;
            this.UserTextBox.Size = new System.Drawing.Size(179, 20);
            this.UserTextBox.TabIndex = 1;
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Location = new System.Drawing.Point(12, 235);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(60, 13);
            this.UserLabel.TabIndex = 2;
            this.UserLabel.Text = "User Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 193);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // BorrowedBookInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 393);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.BookLabel);
            this.Controls.Add(this.BorrowedAtLabel);
            this.Controls.Add(this.BorrowedUntilLabel);
            this.Controls.Add(this.LateLabel);
            this.Controls.Add(this.UserTextBox);
            this.Controls.Add(this.BookTextBox);
            this.Controls.Add(this.AtTextBox);
            this.Controls.Add(this.UntilTextBox);
            this.Controls.Add(this.LateTextBox);
            this.Controls.Add(this.ReturnButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BorrowedBookInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BorrowedBookInfo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.TextBox LateTextBox;
        private System.Windows.Forms.Label LateLabel;
        private System.Windows.Forms.TextBox UntilTextBox;
        private System.Windows.Forms.Label BorrowedUntilLabel;
        private System.Windows.Forms.TextBox AtTextBox;
        private System.Windows.Forms.Label BorrowedAtLabel;
        private System.Windows.Forms.TextBox BookTextBox;
        private System.Windows.Forms.Label BookLabel;
        private System.Windows.Forms.TextBox UserTextBox;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}