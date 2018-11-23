namespace LibraryApplication.LibraryForms
{
    partial class AddNewAuthorForm
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
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.AddNewAuthorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(13, 13);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(255, 20);
            this.FirstNameTextBox.TabIndex = 0;
            this.FirstNameTextBox.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(13, 39);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(255, 20);
            this.LastNameTextBox.TabIndex = 1;
            this.LastNameTextBox.TextChanged += new System.EventHandler(this.TextChanged);
            // 
            // AddNewAuthorButton
            // 
            this.AddNewAuthorButton.Location = new System.Drawing.Point(13, 66);
            this.AddNewAuthorButton.Name = "AddNewAuthorButton";
            this.AddNewAuthorButton.Size = new System.Drawing.Size(255, 23);
            this.AddNewAuthorButton.TabIndex = 2;
            this.AddNewAuthorButton.Text = "Add a new author";
            this.AddNewAuthorButton.UseVisualStyleBackColor = true;
            this.AddNewAuthorButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddNewAuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 103);
            this.Controls.Add(this.AddNewAuthorButton);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.FirstNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "AddNewAuthorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a new author";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewAuthorForm_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddNewAuthorForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.Button AddNewAuthorButton;
    }
}