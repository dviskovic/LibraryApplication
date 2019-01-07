namespace LibraryApplication.LibraryForms
{
    partial class UserBooksForm
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
            this.BookList = new System.Windows.Forms.ListView();
            this.AddNewBook = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BookList
            // 
            this.BookList.Location = new System.Drawing.Point(135, 24);
            this.BookList.Name = "BookList";
            this.BookList.Size = new System.Drawing.Size(653, 414);
            this.BookList.TabIndex = 0;
            this.BookList.UseCompatibleStateImageBehavior = false;
            this.BookList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BookList_DoubleClick);
            // 
            // AddNewBook
            // 
            this.AddNewBook.Location = new System.Drawing.Point(6, 19);
            this.AddNewBook.Name = "AddNewBook";
            this.AddNewBook.Size = new System.Drawing.Size(104, 23);
            this.AddNewBook.TabIndex = 1;
            this.AddNewBook.Text = "Borrow a Book";
            this.AddNewBook.UseVisualStyleBackColor = true;
            this.AddNewBook.Click += new System.EventHandler(this.AddNewButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(6, 48);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(104, 23);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddNewBook);
            this.groupBox1.Controls.Add(this.RefreshButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // UserBooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BookList);
            this.Name = "UserBooksForm";
            this.Text = "UserBooksForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserBooksForm_Closing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView BookList;
        private System.Windows.Forms.Button AddNewBook;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}