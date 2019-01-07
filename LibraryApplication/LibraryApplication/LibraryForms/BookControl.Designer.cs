namespace LibraryApplication.LibraryForms
{
    partial class BookControl
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
            this.SelectImageButton = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.CountBox = new System.Windows.Forms.TextBox();
            this.AuthorBox = new System.Windows.Forms.ComboBox();
            this.SaveAndExit = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 185);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // SelectImageButton
            // 
            this.SelectImageButton.Location = new System.Drawing.Point(12, 203);
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.Size = new System.Drawing.Size(256, 23);
            this.SelectImageButton.TabIndex = 3;
            this.SelectImageButton.Text = "SelectImage";
            this.SelectImageButton.UseVisualStyleBackColor = true;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(12, 232);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(256, 20);
            this.NameBox.TabIndex = 4;
            // 
            // CountBox
            // 
            this.CountBox.Location = new System.Drawing.Point(12, 258);
            this.CountBox.Name = "CountBox";
            this.CountBox.Size = new System.Drawing.Size(256, 20);
            this.CountBox.TabIndex = 5;
            // 
            // AuthorBox
            // 
            this.AuthorBox.FormattingEnabled = true;
            this.AuthorBox.Location = new System.Drawing.Point(12, 284);
            this.AuthorBox.Name = "AuthorBox";
            this.AuthorBox.Size = new System.Drawing.Size(256, 21);
            this.AuthorBox.TabIndex = 6;
            // 
            // SaveAndExit
            // 
            this.SaveAndExit.Location = new System.Drawing.Point(12, 311);
            this.SaveAndExit.Name = "SaveAndExit";
            this.SaveAndExit.Size = new System.Drawing.Size(256, 23);
            this.SaveAndExit.TabIndex = 7;
            this.SaveAndExit.Text = "Save and close";
            this.SaveAndExit.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(13, 340);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(255, 23);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // BookControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 372);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveAndExit);
            this.Controls.Add(this.AuthorBox);
            this.Controls.Add(this.CountBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.SelectImageButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BookControl";
            this.Text = "BookInfoForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SelectImageButton;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox CountBox;
        private System.Windows.Forms.ComboBox AuthorBox;
        private System.Windows.Forms.Button SaveAndExit;
        private System.Windows.Forms.Button CloseButton;
    }
}