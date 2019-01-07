namespace LibraryApplication.LibraryForms
{
    partial class UserControl
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.ChangeImageButton = new System.Windows.Forms.Button();
            this.SaveAndExit = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.BooksButton = new System.Windows.Forms.Button();
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
            this.FirstName.Location = new System.Drawing.Point(12, 227);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(255, 20);
            this.FirstName.TabIndex = 1;
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(12, 253);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(255, 20);
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
            this.SaveAndExit.Location = new System.Drawing.Point(12, 308);
            this.SaveAndExit.Name = "SaveAndExit";
            this.SaveAndExit.Size = new System.Drawing.Size(255, 23);
            this.SaveAndExit.TabIndex = 4;
            this.SaveAndExit.Text = "Save and close";
            this.SaveAndExit.UseVisualStyleBackColor = true;
            this.SaveAndExit.Click += new System.EventHandler(this.SaveAndExit_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(12, 337);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(255, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // BooksButton
            // 
            this.BooksButton.Location = new System.Drawing.Point(12, 279);
            this.BooksButton.Name = "BooksButton";
            this.BooksButton.Size = new System.Drawing.Size(255, 23);
            this.BooksButton.TabIndex = 4;
            this.BooksButton.Text = "Books";
            this.BooksButton.UseVisualStyleBackColor = true;
            this.BooksButton.Click += new System.EventHandler(this.BooksButton_Click);
            // 
            // UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 374);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.BooksButton);
            this.Controls.Add(this.SaveAndExit);
            this.Controls.Add(this.ChangeImageButton);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UserControl";
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
    }
}