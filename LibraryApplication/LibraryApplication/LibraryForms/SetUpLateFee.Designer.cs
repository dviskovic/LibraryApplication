namespace LibraryApplication.LibraryForms
{
    partial class SetUpLateFee
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
            this.FeeLabel = new System.Windows.Forms.Label();
            this.FeeTextBox = new System.Windows.Forms.TextBox();
            this.FinishButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FeeLabel
            // 
            this.FeeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeeLabel.Location = new System.Drawing.Point(12, 9);
            this.FeeLabel.Name = "FeeLabel";
            this.FeeLabel.Size = new System.Drawing.Size(267, 65);
            this.FeeLabel.TabIndex = 0;
            this.FeeLabel.Text = "Enter the fee per day for being late\r\nwhen returning a book in the textbox below";
            this.FeeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FeeTextBox
            // 
            this.FeeTextBox.Location = new System.Drawing.Point(12, 77);
            this.FeeTextBox.Name = "FeeTextBox";
            this.FeeTextBox.Size = new System.Drawing.Size(265, 20);
            this.FeeTextBox.TabIndex = 1;
            this.FeeTextBox.TextChanged += new System.EventHandler(this.Form_TextChanged);
            // 
            // FinishButton
            // 
            this.FinishButton.Location = new System.Drawing.Point(12, 103);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(265, 23);
            this.FinishButton.TabIndex = 2;
            this.FinishButton.Text = "Finish";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // SetUpLateFeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 138);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.FeeTextBox);
            this.Controls.Add(this.FeeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SetUpLateFeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Up Late Fee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FeeLabel;
        private System.Windows.Forms.TextBox FeeTextBox;
        private System.Windows.Forms.Button FinishButton;
    }
}