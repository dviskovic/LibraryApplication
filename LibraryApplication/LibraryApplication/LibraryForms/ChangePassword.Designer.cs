namespace LibraryApplication.LibraryForms
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.CurrentText = new System.Windows.Forms.TextBox();
            this.NewText = new System.Windows.Forms.TextBox();
            this.ConfirmNewText = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CurrentText
            // 
            this.CurrentText.Location = new System.Drawing.Point(15, 12);
            this.CurrentText.Name = "CurrentText";
            this.CurrentText.Size = new System.Drawing.Size(196, 20);
            this.CurrentText.TabIndex = 0;
            this.CurrentText.Text = "Current Password";
            this.CurrentText.TextChanged += new System.EventHandler(this.Form_TextChanged);
            this.CurrentText.Enter += new System.EventHandler(this.CurrentText_Enter);
            this.CurrentText.Leave += new System.EventHandler(this.CurrentText_Leave);
            // 
            // NewText
            // 
            this.NewText.Location = new System.Drawing.Point(15, 38);
            this.NewText.Name = "NewText";
            this.NewText.Size = new System.Drawing.Size(196, 20);
            this.NewText.TabIndex = 1;
            this.NewText.Text = "New Password";
            this.NewText.TextChanged += new System.EventHandler(this.Form_TextChanged);
            this.NewText.Enter += new System.EventHandler(this.NewText_Enter);
            this.NewText.Leave += new System.EventHandler(this.NewText_Leave);
            // 
            // ConfirmNewText
            // 
            this.ConfirmNewText.Location = new System.Drawing.Point(15, 64);
            this.ConfirmNewText.Name = "ConfirmNewText";
            this.ConfirmNewText.Size = new System.Drawing.Size(196, 20);
            this.ConfirmNewText.TabIndex = 2;
            this.ConfirmNewText.Text = "Confirm new Password";
            this.ConfirmNewText.TextChanged += new System.EventHandler(this.Form_TextChanged);
            this.ConfirmNewText.Enter += new System.EventHandler(this.ConfirmNewText_Enter);
            this.ConfirmNewText.Leave += new System.EventHandler(this.ConfirmNewText_Leave);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(12, 90);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(199, 23);
            this.ConfirmButton.TabIndex = 3;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(12, 119);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(199, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 156);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.ConfirmNewText);
            this.Controls.Add(this.NewText);
            this.Controls.Add(this.CurrentText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangePasswordForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CurrentText;
        private System.Windows.Forms.TextBox NewText;
        private System.Windows.Forms.TextBox ConfirmNewText;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button CancelButton;
    }
}