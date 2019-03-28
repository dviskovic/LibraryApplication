namespace LibraryApplication.LibraryForms
{
    partial class UserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfo));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.ChangeImageButton = new System.Windows.Forms.Button();
            this.SaveAndExit = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.BooksButton = new System.Windows.Forms.Button();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.TextBox();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 180);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(96, 227);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(171, 20);
            this.FirstName.TabIndex = 1;
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(96, 253);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(171, 20);
            this.LastName.TabIndex = 2;
            // 
            // ChangeImageButton
            // 
            this.ChangeImageButton.Location = new System.Drawing.Point(12, 198);
            this.ChangeImageButton.Name = "ChangeImageButton";
            this.ChangeImageButton.Size = new System.Drawing.Size(255, 23);
            this.ChangeImageButton.TabIndex = 3;
            this.ChangeImageButton.Text = "Change Image";
            this.ChangeImageButton.UseVisualStyleBackColor = true;
            this.ChangeImageButton.Click += new System.EventHandler(this.SelectImageButton_Click);
            // 
            // SaveAndExit
            // 
            this.SaveAndExit.Location = new System.Drawing.Point(12, 415);
            this.SaveAndExit.Name = "SaveAndExit";
            this.SaveAndExit.Size = new System.Drawing.Size(255, 23);
            this.SaveAndExit.TabIndex = 4;
            this.SaveAndExit.Text = "Save and close";
            this.SaveAndExit.UseVisualStyleBackColor = true;
            this.SaveAndExit.Click += new System.EventHandler(this.SaveAndExit_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(12, 444);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(255, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // BooksButton
            // 
            this.BooksButton.Location = new System.Drawing.Point(12, 357);
            this.BooksButton.Name = "BooksButton";
            this.BooksButton.Size = new System.Drawing.Size(255, 23);
            this.BooksButton.TabIndex = 4;
            this.BooksButton.Text = "Books";
            this.BooksButton.UseVisualStyleBackColor = true;
            this.BooksButton.Click += new System.EventHandler(this.BooksButton_Click);
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(12, 230);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(57, 13);
            this.FirstNameLabel.TabIndex = 5;
            this.FirstNameLabel.Text = "First Name";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(12, 256);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(58, 13);
            this.LastNameLabel.TabIndex = 5;
            this.LastNameLabel.Text = "Last Name";
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(96, 279);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(171, 20);
            this.Email.TabIndex = 2;
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(12, 282);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(32, 13);
            this.EmailLabel.TabIndex = 5;
            this.EmailLabel.Text = "Email";
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(96, 305);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(171, 20);
            this.Phone.TabIndex = 2;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Location = new System.Drawing.Point(12, 308);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(78, 13);
            this.PhoneLabel.TabIndex = 5;
            this.PhoneLabel.Text = "Phone Number";
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(96, 331);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(171, 20);
            this.Address.TabIndex = 2;
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(12, 334);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(45, 13);
            this.AddressLabel.TabIndex = 5;
            this.AddressLabel.Text = "Address";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(12, 386);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(255, 23);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 478);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.BooksButton);
            this.Controls.Add(this.SaveAndExit);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.ChangeImageButton);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Info about ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.Button ChangeImageButton;
        private System.Windows.Forms.Button SaveAndExit;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button BooksButton;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Button DeleteButton;
    }
}