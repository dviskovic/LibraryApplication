namespace LibraryApplication.LibraryForms
{
    partial class AddNewBookForm
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
            this.NameBox = new System.Windows.Forms.TextBox();
            this.SelectImageButton = new System.Windows.Forms.Button();
            this.AddNewBookButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AuthorBox = new System.Windows.Forms.ComboBox();
            this.CountBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(12, 237);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(256, 20);
            this.NameBox.TabIndex = 1;
            this.NameBox.TextChanged += new System.EventHandler(this.TextChangedEvent);
            this.NameBox.Enter += new System.EventHandler(this.NameBox_Enter);
            this.NameBox.Leave += new System.EventHandler(this.NameBox_Leave);
            // 
            // SelectImageButton
            // 
            this.SelectImageButton.Location = new System.Drawing.Point(13, 208);
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.Size = new System.Drawing.Size(255, 23);
            this.SelectImageButton.TabIndex = 0;
            this.SelectImageButton.Text = "SelectImage";
            this.SelectImageButton.UseVisualStyleBackColor = true;
            this.SelectImageButton.Click += new System.EventHandler(this.SelectImageButton_Click);
            // 
            // AddNewBookButton
            // 
            this.AddNewBookButton.Location = new System.Drawing.Point(13, 317);
            this.AddNewBookButton.Name = "AddNewBookButton";
            this.AddNewBookButton.Size = new System.Drawing.Size(255, 23);
            this.AddNewBookButton.TabIndex = 4;
            this.AddNewBookButton.Text = "Add a new book";
            this.AddNewBookButton.UseVisualStyleBackColor = true;
            this.AddNewBookButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 185);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // AuthorBox
            // 
            this.AuthorBox.FormattingEnabled = true;
            this.AuthorBox.Location = new System.Drawing.Point(13, 289);
            this.AuthorBox.Name = "AuthorBox";
            this.AuthorBox.Size = new System.Drawing.Size(255, 21);
            this.AuthorBox.TabIndex = 3;
            this.AuthorBox.ValueMemberChanged += new System.EventHandler(this.TextChangedEvent);
            this.AuthorBox.TextChanged += new System.EventHandler(this.TextChangedEvent);
            // 
            // CountBox
            // 
            this.CountBox.Location = new System.Drawing.Point(12, 263);
            this.CountBox.Name = "CountBox";
            this.CountBox.Size = new System.Drawing.Size(256, 20);
            this.CountBox.TabIndex = 2;
            this.CountBox.TextChanged += new System.EventHandler(this.TextChangedEvent);
            this.CountBox.Enter += new System.EventHandler(this.CountBox_Enter);
            this.CountBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CountBox_KeyPress);
            this.CountBox.Leave += new System.EventHandler(this.CountBox_Leave);
            // 
            // AddNewBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 352);
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
    }
}