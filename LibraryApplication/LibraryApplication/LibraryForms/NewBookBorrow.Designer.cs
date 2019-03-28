namespace LibraryApplication.LibraryForms
{
    partial class NewBookBorrow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewBookBorrow));
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.SinceTextBox = new System.Windows.Forms.TextBox();
            this.ToTextBox = new System.Windows.Forms.TextBox();
            this.SinceLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.BookNameTextBox = new System.Windows.Forms.TextBox();
            this.BookNameLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.BorrowButton = new System.Windows.Forms.Button();
            this.DaysTextBox = new System.Windows.Forms.TextBox();
            this.DayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.Location = new System.Drawing.Point(12, 165);
            this.Calendar.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.Calendar.MaxSelectionCount = 1;
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 0;
            this.Calendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateSelected);
            // 
            // SinceTextBox
            // 
            this.SinceTextBox.Enabled = false;
            this.SinceTextBox.Location = new System.Drawing.Point(83, 72);
            this.SinceTextBox.Name = "SinceTextBox";
            this.SinceTextBox.ReadOnly = true;
            this.SinceTextBox.Size = new System.Drawing.Size(156, 20);
            this.SinceTextBox.TabIndex = 1;
            this.SinceTextBox.TextChanged += new System.EventHandler(this.TextUpdate);
            // 
            // ToTextBox
            // 
            this.ToTextBox.Enabled = false;
            this.ToTextBox.Location = new System.Drawing.Point(83, 98);
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.ReadOnly = true;
            this.ToTextBox.Size = new System.Drawing.Size(156, 20);
            this.ToTextBox.TabIndex = 2;
            this.ToTextBox.TextChanged += new System.EventHandler(this.TextUpdate);
            // 
            // SinceLabel
            // 
            this.SinceLabel.AutoSize = true;
            this.SinceLabel.Location = new System.Drawing.Point(14, 75);
            this.SinceLabel.Name = "SinceLabel";
            this.SinceLabel.Size = new System.Drawing.Size(34, 13);
            this.SinceLabel.TabIndex = 3;
            this.SinceLabel.Text = "Since";
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(18, 101);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(20, 13);
            this.ToLabel.TabIndex = 3;
            this.ToLabel.Text = "To";
            // 
            // BookNameTextBox
            // 
            this.BookNameTextBox.Enabled = false;
            this.BookNameTextBox.Location = new System.Drawing.Point(83, 46);
            this.BookNameTextBox.Name = "BookNameTextBox";
            this.BookNameTextBox.ReadOnly = true;
            this.BookNameTextBox.Size = new System.Drawing.Size(156, 20);
            this.BookNameTextBox.TabIndex = 1;
            // 
            // BookNameLabel
            // 
            this.BookNameLabel.AutoSize = true;
            this.BookNameLabel.Location = new System.Drawing.Point(14, 49);
            this.BookNameLabel.Name = "BookNameLabel";
            this.BookNameLabel.Size = new System.Drawing.Size(63, 13);
            this.BookNameLabel.TabIndex = 3;
            this.BookNameLabel.Text = "Book Name";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Enabled = false;
            this.UserNameTextBox.Location = new System.Drawing.Point(83, 20);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.ReadOnly = true;
            this.UserNameTextBox.Size = new System.Drawing.Size(156, 20);
            this.UserNameTextBox.TabIndex = 1;
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Location = new System.Drawing.Point(14, 23);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(29, 13);
            this.UserLabel.TabIndex = 3;
            this.UserLabel.Text = "User";
            // 
            // BorrowButton
            // 
            this.BorrowButton.Location = new System.Drawing.Point(12, 339);
            this.BorrowButton.Name = "BorrowButton";
            this.BorrowButton.Size = new System.Drawing.Size(227, 23);
            this.BorrowButton.TabIndex = 4;
            this.BorrowButton.Text = "Borrow";
            this.BorrowButton.UseVisualStyleBackColor = true;
            this.BorrowButton.Click += new System.EventHandler(this.BorrowButton_Click);
            // 
            // DaysTextBox
            // 
            this.DaysTextBox.Enabled = false;
            this.DaysTextBox.Location = new System.Drawing.Point(83, 124);
            this.DaysTextBox.Name = "DaysTextBox";
            this.DaysTextBox.ReadOnly = true;
            this.DaysTextBox.Size = new System.Drawing.Size(156, 20);
            this.DaysTextBox.TabIndex = 2;
            this.DaysTextBox.TextChanged += new System.EventHandler(this.TextUpdate);
            // 
            // DayLabel
            // 
            this.DayLabel.AutoSize = true;
            this.DayLabel.Location = new System.Drawing.Point(18, 127);
            this.DayLabel.Name = "DayLabel";
            this.DayLabel.Size = new System.Drawing.Size(31, 13);
            this.DayLabel.TabIndex = 3;
            this.DayLabel.Text = "Days";
            // 
            // NewBookBorrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 372);
            this.Controls.Add(this.BorrowButton);
            this.Controls.Add(this.DayLabel);
            this.Controls.Add(this.ToLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.BookNameLabel);
            this.Controls.Add(this.SinceLabel);
            this.Controls.Add(this.DaysTextBox);
            this.Controls.Add(this.ToTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.BookNameTextBox);
            this.Controls.Add(this.SinceTextBox);
            this.Controls.Add(this.Calendar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewBookBorrow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Borrow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.TextBox SinceTextBox;
        private System.Windows.Forms.TextBox ToTextBox;
        private System.Windows.Forms.Label SinceLabel;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.TextBox BookNameTextBox;
        private System.Windows.Forms.Label BookNameLabel;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Button BorrowButton;
        private System.Windows.Forms.TextBox DaysTextBox;
        private System.Windows.Forms.Label DayLabel;
    }
}