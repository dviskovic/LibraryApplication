namespace LibraryApplication.LibraryForms
{
    partial class AddNewBook
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
            this.NameBox = new System.Windows.Forms.TextBox();
            this.SelectImageButton = new System.Windows.Forms.Button();
            this.AddNewBookButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AuthorBox = new System.Windows.Forms.ComboBox();
            this.CountBox = new System.Windows.Forms.TextBox();
            this.ISBNTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.ISBNLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(58, 237);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(210, 20);
            this.NameBox.TabIndex = 1;
            this.NameBox.TextChanged += new System.EventHandler(this.TextChangedEvent);
            // 
            // SelectImageButton
            // 
            this.SelectImageButton.Location = new System.Drawing.Point(12, 208);
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.Size = new System.Drawing.Size(256, 23);
            this.SelectImageButton.TabIndex = 0;
            this.SelectImageButton.Text = "SelectImage";
            this.SelectImageButton.UseVisualStyleBackColor = true;
            this.SelectImageButton.Click += new System.EventHandler(this.SelectImageButton_Click);
            // 
            // AddNewBookButton
            // 
            this.AddNewBookButton.Location = new System.Drawing.Point(12, 342);
            this.AddNewBookButton.Name = "AddNewBookButton";
            this.AddNewBookButton.Size = new System.Drawing.Size(256, 23);
            this.AddNewBookButton.TabIndex = 5;
            this.AddNewBookButton.Text = "Add a new book";
            this.AddNewBookButton.UseVisualStyleBackColor = true;
            this.AddNewBookButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 185);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // AuthorBox
            // 
            this.AuthorBox.FormattingEnabled = true;
            this.AuthorBox.Location = new System.Drawing.Point(58, 315);
            this.AuthorBox.Name = "AuthorBox";
            this.AuthorBox.Size = new System.Drawing.Size(210, 21);
            this.AuthorBox.TabIndex = 4;
            this.AuthorBox.ValueMemberChanged += new System.EventHandler(this.TextChangedEvent);
            this.AuthorBox.TextChanged += new System.EventHandler(this.TextChangedEvent);
            // 
            // CountBox
            // 
            this.CountBox.Location = new System.Drawing.Point(58, 263);
            this.CountBox.Name = "CountBox";
            this.CountBox.Size = new System.Drawing.Size(210, 20);
            this.CountBox.TabIndex = 2;
            this.CountBox.TextChanged += new System.EventHandler(this.TextChangedEvent);
            this.CountBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CountBox_KeyPress);
            // 
            // ISBNTextBox
            // 
            this.ISBNTextBox.Location = new System.Drawing.Point(58, 289);
            this.ISBNTextBox.Name = "ISBNTextBox";
            this.ISBNTextBox.Size = new System.Drawing.Size(210, 20);
            this.ISBNTextBox.TabIndex = 3;
            this.ISBNTextBox.TextChanged += new System.EventHandler(this.TextChangedEvent);
            this.ISBNTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ISBNBox_KeyPress);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 240);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Name";
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Location = new System.Drawing.Point(12, 266);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(46, 13);
            this.CountLabel.TabIndex = 6;
            this.CountLabel.Text = "Quantity";
            // 
            // ISBNLabel
            // 
            this.ISBNLabel.AutoSize = true;
            this.ISBNLabel.Location = new System.Drawing.Point(12, 292);
            this.ISBNLabel.Name = "ISBNLabel";
            this.ISBNLabel.Size = new System.Drawing.Size(32, 13);
            this.ISBNLabel.TabIndex = 6;
            this.ISBNLabel.Text = "ISBN";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(12, 318);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(38, 13);
            this.AuthorLabel.TabIndex = 6;
            this.AuthorLabel.Text = "Author";
            // 
            // AddNewBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 377);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.ISBNLabel);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.ISBNTextBox);
            this.Controls.Add(this.AuthorBox);
            this.Controls.Add(this.AddNewBookButton);
            this.Controls.Add(this.SelectImageButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CountBox);
            this.Controls.Add(this.NameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "AddNewBookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add a new book";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewBookForm_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddNewBookForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SelectImageButton;
        private System.Windows.Forms.Button AddNewBookButton;
        private System.Windows.Forms.ComboBox AuthorBox;
        private System.Windows.Forms.TextBox CountBox;
        private System.Windows.Forms.TextBox ISBNTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label ISBNLabel;
        private System.Windows.Forms.Label AuthorLabel;
    }
}