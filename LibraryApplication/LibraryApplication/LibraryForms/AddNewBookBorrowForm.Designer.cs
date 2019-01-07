namespace LibraryApplication.LibraryForms
{
    partial class AddNewBookBorrowForm
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
            this.AvailableBookList = new System.Windows.Forms.ListView();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowAllCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AvailableBookList
            // 
            this.AvailableBookList.Location = new System.Drawing.Point(12, 38);
            this.AvailableBookList.Name = "AvailableBookList";
            this.AvailableBookList.Size = new System.Drawing.Size(776, 400);
            this.AvailableBookList.TabIndex = 0;
            this.AvailableBookList.UseCompatibleStateImageBehavior = false;
            this.AvailableBookList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AvailableBookList_DoubleClick);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(274, 12);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(299, 20);
            this.SearchTextBox.TabIndex = 1;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchQueryChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search";
            // 
            // ShowAllCheckBox
            // 
            this.ShowAllCheckBox.AutoSize = true;
            this.ShowAllCheckBox.Location = new System.Drawing.Point(581, 14);
            this.ShowAllCheckBox.Name = "ShowAllCheckBox";
            this.ShowAllCheckBox.Size = new System.Drawing.Size(207, 17);
            this.ShowAllCheckBox.TabIndex = 3;
            this.ShowAllCheckBox.Text = "Show all if no search query is provided";
            this.ShowAllCheckBox.UseVisualStyleBackColor = true;
            this.ShowAllCheckBox.CheckedChanged += new System.EventHandler(this.SearchQueryChanged);
            // 
            // AddNewBookBorrowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ShowAllCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.AvailableBookList);
            this.Name = "AddNewBookBorrowForm";
            this.Text = "Borrow a Book";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewBookBorrowForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView AvailableBookList;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ShowAllCheckBox;
    }
}