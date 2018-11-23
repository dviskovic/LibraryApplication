namespace LibraryApplication
{
    partial class MainForm
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
            this.RefreshButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.ResultList = new System.Windows.Forms.ListView();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchTypeBox = new System.Windows.Forms.ComboBox();
            this.AddNewUserButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.assToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewAuthorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSSToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LastSaveTimeLabel = new System.Windows.Forms.Label();
            this.ShowAllCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(401, 12);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(95, 20);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Clicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "Add new Book";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AddNewBookButton_Clicked);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "Add new Author";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AddNewAuthorButton_Clicked);
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(170, 13);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(225, 20);
            this.SearchBox.TabIndex = 0;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchQueryChanged);
            // 
            // ResultList
            // 
            this.ResultList.Location = new System.Drawing.Point(113, 39);
            this.ResultList.Name = "ResultList";
            this.ResultList.Size = new System.Drawing.Size(808, 482);
            this.ResultList.TabIndex = 5;
            this.ResultList.TabStop = false;
            this.ResultList.UseCompatibleStateImageBehavior = false;
            this.ResultList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ResultBox_MouseDoubleClick);
            this.ResultList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResultBox_MouseDown);
            // 
            // SearchLabel
            // 
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchLabel.Location = new System.Drawing.Point(111, 13);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(53, 20);
            this.SearchLabel.TabIndex = 0;
            this.SearchLabel.Text = "Search";
            this.SearchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(502, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchTypeBox
            // 
            this.SearchTypeBox.FormattingEnabled = true;
            this.SearchTypeBox.Location = new System.Drawing.Point(551, 12);
            this.SearchTypeBox.Name = "SearchTypeBox";
            this.SearchTypeBox.Size = new System.Drawing.Size(164, 21);
            this.SearchTypeBox.TabIndex = 3;
            this.SearchTypeBox.TextChanged += new System.EventHandler(this.SearchTypeBox_TextChanged);
            // 
            // AddNewUserButton
            // 
            this.AddNewUserButton.Location = new System.Drawing.Point(12, 143);
            this.AddNewUserButton.Name = "AddNewUserButton";
            this.AddNewUserButton.Size = new System.Drawing.Size(95, 20);
            this.AddNewUserButton.TabIndex = 0;
            this.AddNewUserButton.TabStop = false;
            this.AddNewUserButton.Text = "Add new User";
            this.AddNewUserButton.UseVisualStyleBackColor = true;
            this.AddNewUserButton.Click += new System.EventHandler(this.AddNewUserButton_Clicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assToolStripMenuItem,
            this.weToolStripMenuItem,
            this.aSSToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 524);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // assToolStripMenuItem
            // 
            this.assToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewBookToolStripMenuItem,
            this.addNewUserToolStripMenuItem,
            this.addNewAuthorToolStripMenuItem});
            this.assToolStripMenuItem.Name = "assToolStripMenuItem";
            this.assToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.assToolStripMenuItem.Text = "Tools";
            // 
            // addNewBookToolStripMenuItem
            // 
            this.addNewBookToolStripMenuItem.Name = "addNewBookToolStripMenuItem";
            this.addNewBookToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.addNewBookToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.addNewBookToolStripMenuItem.Text = "Add new Book";
            this.addNewBookToolStripMenuItem.Click += new System.EventHandler(this.addNewBookToolStripMenuItem_Click);
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.addNewUserToolStripMenuItem.Text = "Add new User";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
            // 
            // addNewAuthorToolStripMenuItem
            // 
            this.addNewAuthorToolStripMenuItem.Name = "addNewAuthorToolStripMenuItem";
            this.addNewAuthorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.addNewAuthorToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.addNewAuthorToolStripMenuItem.Text = "Add new Author";
            this.addNewAuthorToolStripMenuItem.Click += new System.EventHandler(this.addNewAuthorToolStripMenuItem_Click);
            // 
            // weToolStripMenuItem
            // 
            this.weToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteAllDataToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.weToolStripMenuItem.Name = "weToolStripMenuItem";
            this.weToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.weToolStripMenuItem.Text = "Data";
            // 
            // deleteAllDataToolStripMenuItem
            // 
            this.deleteAllDataToolStripMenuItem.Name = "deleteAllDataToolStripMenuItem";
            this.deleteAllDataToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.deleteAllDataToolStripMenuItem.Text = "Delete all data";
            this.deleteAllDataToolStripMenuItem.Click += new System.EventHandler(this.deleteAllDataToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // aSSToolStripMenuItem1
            // 
            this.aSSToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.aSSToolStripMenuItem1.Name = "aSSToolStripMenuItem1";
            this.aSSToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.aSSToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // LastSaveTimeLabel
            // 
            this.LastSaveTimeLabel.AutoSize = true;
            this.LastSaveTimeLabel.Location = new System.Drawing.Point(817, 529);
            this.LastSaveTimeLabel.Name = "LastSaveTimeLabel";
            this.LastSaveTimeLabel.Size = new System.Drawing.Size(103, 13);
            this.LastSaveTimeLabel.TabIndex = 7;
            this.LastSaveTimeLabel.Text = "Last Save: 00:00:00";
            // 
            // ShowAllCheckBox
            // 
            this.ShowAllCheckBox.AutoSize = true;
            this.ShowAllCheckBox.Location = new System.Drawing.Point(721, 15);
            this.ShowAllCheckBox.Name = "ShowAllCheckBox";
            this.ShowAllCheckBox.Size = new System.Drawing.Size(153, 17);
            this.ShowAllCheckBox.TabIndex = 8;
            this.ShowAllCheckBox.Text = "Show all if no search query";
            this.ShowAllCheckBox.UseVisualStyleBackColor = true;
            this.ShowAllCheckBox.CheckedChanged += new System.EventHandler(this.ShowAllCheckBox_CheckChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 548);
            this.Controls.Add(this.ShowAllCheckBox);
            this.Controls.Add(this.LastSaveTimeLabel);
            this.Controls.Add(this.SearchTypeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.ResultList);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddNewUserButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.ListView ResultList;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SearchTypeBox;
        private System.Windows.Forms.Button AddNewUserButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem assToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSSToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteAllDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label LastSaveTimeLabel;
        private System.Windows.Forms.ToolStripMenuItem addNewBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewAuthorToolStripMenuItem;
        private System.Windows.Forms.CheckBox ShowAllCheckBox;
    }
}

