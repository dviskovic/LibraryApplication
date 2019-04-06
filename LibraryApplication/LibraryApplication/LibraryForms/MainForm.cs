using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using LibraryApplication.LibraryForms;
using LibraryApplication.LibraryHelpers;
using LibraryApplication.LibraryObjects;

namespace LibraryApplication
{
    public partial class MainForm : Form
    {
        public StartupForm StartupForm = null;

        public Dictionary<User, UserInfo> UserDictionary = new Dictionary<User, UserInfo>();
        public Dictionary<Book, BookInfo> BookDictionary = new Dictionary<Book, BookInfo>();

        public AddNewUser CurrentAddNewUserForm = null;
        public AddNewAuthor CurrentAddNewAuthorForm = null;
        public AddNewBook CurrentAddNewBookForm = null;
        public ListViewItem SelectedItem = null;
        public About CurrentAboutForm = null;
        public ChangePassword CurrentChangePasswordForm = null;

        private string searchQuery = string.Empty;
        private Timer lastSaveTimer = new Timer { Enabled = true, Interval = 1000 };

        public MainForm()
        {
            var t = StringHelper.RandomString();
            MessageBox.Show(t);
            this.InitializeComponent();
            this.Shown += new EventHandler((o, e) => LibraryEvents.EventManager.OnStartupFinished());
            LibraryEvents.EventManager.OnDataFileChanged += new Action(this.UpdateList);
            this.lastSaveTimer.Tick += new EventHandler(this.RefreshLastTime);
            this.lastSaveTimer.Start(); 
            this.SearchTypeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SearchTypeBox.DataSource = SearchResult.StringArray();

            var doubleBuffer = typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            doubleBuffer.SetValue(this.ResultList, true, null);
            DataFileSystem.IO.SaveUserData();
        }

        private void RefreshLastTime(object o, EventArgs e)
        {
            TimeSpan timeSpanSinceSave = LibraryHelpers.Data.TimeSinceLastSave();
            this.LastSaveTimeLabel.Text = "Last Save: " + LibraryHelpers.Data.GetReadableTimeFromTimeSpan(timeSpanSinceSave);
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            DataFileSystem.IO.SaveConfig();
            DataFileSystem.IO.SaveUserData();
            this.StartupForm.Close();
        }

        private void AddNewUserButton_Clicked(object sender, EventArgs e)
        {
            if (this.CurrentAddNewUserForm != null)
            {
                this.CurrentAddNewUserForm.Focus();
                return;
            }

            this.CurrentAddNewUserForm = new AddNewUser(this);
            this.CurrentAddNewUserForm.Show();
        }

        private void AddNewAuthorButton_Clicked(object sender, EventArgs e)
        {
            if (this.CurrentAddNewAuthorForm != null)
            {
                this.CurrentAddNewAuthorForm.Focus();
            }

            else
            {
                this.CurrentAddNewAuthorForm = new AddNewAuthor(this);
                this.CurrentAddNewAuthorForm.Show();
            }
        }

        private void AddNewBookButton_Clicked(object sender, EventArgs e)
        {
            if (this.CurrentAddNewBookForm != null)
            {
                this.CurrentAddNewBookForm.Focus();
                return;
            }

            this.CurrentAddNewBookForm = new AddNewBook(this);
            this.CurrentAddNewBookForm.Show();
        }

        private void SearchQueryChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text))
            {
                if (!this.ShowAllCheckBox.Checked)
                {
                    this.ClearSearchBox();
                }

                else
                {
                    this.ShowResults(true);
                }
            }

            else
            {
                this.searchQuery = SearchBox.Text.ToLower();
                this.UpdateList();
            }
        }

        private void ClearSearchBox()
        {
            this.ResultList.Rows.Clear();
        }

        private void ShowResults(bool all)
        {
            SearchResult.Types resultType = SearchResult.ParseFromString((string)this.SearchTypeBox.SelectedItem);

            var resultList = new List<SearchResult>();

            if (resultType == SearchResult.Types.All || resultType == SearchResult.Types.User)
            {
                foreach (var user in DataFileSystem.IO.DataFile.Users)
                {
                    if (all || user.FirstName.IncludesOrEqual(this.searchQuery) || user.LastName.IncludesOrEqual(this.searchQuery) || user.FullName.IncludesOrEqual(this.searchQuery) || user.Email.IncludesOrEqual(this.searchQuery) || user.Address.IncludesOrEqual(this.searchQuery) || user.Phone.IncludesOrEqual(this.searchQuery))
                    {
                        resultList.Add(new SearchResult { Name = user.FirstName + " " + user.LastName, Address = user.Address, Phone = user.Phone, Email = user.Email, Author = "None", Available = "None", BorrowedCount = user.BorrowedBookCount, ISBN = "None" });
                    }
                }
            }

            if (resultType == SearchResult.Types.Book || resultType == SearchResult.Types.All)
            {
                foreach (var book in DataFileSystem.IO.DataFile.Books)
                {
                    var author = book.Author;
                    if (all || book.Name.IncludesOrEqual(this.searchQuery) || author.FirstName.IncludesOrEqual(this.searchQuery) || author.LastName.IncludesOrEqual(this.searchQuery) || author.FullName.IncludesOrEqual(this.searchQuery) || book.ISBN.IncludesOrEqual(this.searchQuery))
                    {
                        resultList.Add(new SearchResult { Name = "\"" + book.Name + "\"", Author = "\"" + book.Author.FullName + "\"", ISBN = book.ISBN, Available = book.Available > 0 ? "Yes (" + book.Available + ")" : "No", BorrowedCount = -1, Address = "None", Email = "None", Phone = "None" });
                    }
                }
            }

            this.ResultList.Rows.Clear();
            this.ResultList.Columns.Clear();

            switch (resultType)
            {
                case SearchResult.Types.Book:
                    {
                        this.ResultList.Columns.Add("NameHeader", "Name");
                        this.ResultList.Columns.Add("AuthorHeader", "Author");
                        this.ResultList.Columns.Add("ISBNHeader", "ISBN");
                        this.ResultList.Columns.Add("AvailableHeader", "Available");

                        foreach (var result in resultList)
                        {
                            this.ResultList.Rows.Add(result.Name, result.Author, result.ISBN, result.Available);
                        }

                        return;
                    }

                case SearchResult.Types.User:
                    {
                        this.ResultList.Columns.Add("NameHeader", "Name");
                        this.ResultList.Columns.Add("EmailHeader", "Email");
                        this.ResultList.Columns.Add("PhoneHeader", "Phone");
                        this.ResultList.Columns.Add("AddressHeader", "Address");
                        this.ResultList.Columns.Add("BorrowedHeader", "Borrowed Books");

                        foreach (var result in resultList)
                        {
                            this.ResultList.Rows.Add(result.Name, result.Email, result.Phone, result.Address, result.BorrowedCount);
                        }

                        return;
                    }

                case SearchResult.Types.All:
                    {
                        this.ResultList.Columns.Add("NameHeader", "Name");
                        this.ResultList.Columns.Add("AuthorHeader", "Author");
                        this.ResultList.Columns.Add("AvailableHeader", "Available");

                        foreach (var result in resultList)
                        {
                            this.ResultList.Rows.Add(result.Name, result.Author, result.Available);
                        }

                        return;
                    }

                default: return;
            }
        }

        private void UpdateList()
        {
            if (string.IsNullOrEmpty(SearchBox.Text))
            {
                if (!this.ShowAllCheckBox.Checked)
                {
                    this.ClearSearchBox();
                    return;
                }

                else
                {
                    this.ShowResults(true);
                    return;
                }
            }

            this.ShowResults(false);
        }

        private void ResultBox_MouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Name = this.ResultList.Rows[e.RowIndex].Cells[0].Value.ToString();

            var item = LibraryHelpers.Data.Find(Name, SearchResult.Types.All);

            if (item == null)
            {
                return;
            }
            
            if (item is Book book)
            {
                if (this.BookDictionary.TryGetValue(book, out LibraryForms.BookInfo form))
                {
                    form.Focus();
                }

                else
                {
                    var form2 = new LibraryForms.BookInfo(book, this);
                    form2.Show();
                    this.BookDictionary.Add(book, form2);
                }
            }

            if (item is User user)
            {
                if (this.UserDictionary.TryGetValue(user, out LibraryForms.UserInfo form))
                {
                    form.Focus();
                }

                else
                {
                    var form2 = new LibraryForms.UserInfo(user, this);
                    form2.Show();
                    this.UserDictionary.Add(user, form2);
                }
            }
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            this.UpdateList();
        }

        private void SearchTypeBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateList();
        }

        private void DeleteAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Are you sure you want to delete all data?", "Warning", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                var dialog2 = MessageBox.Show("Are you REALLY sure you want to delete all data?", "Warning", MessageBoxButtons.YesNo);

                if (dialog2 == DialogResult.Yes)
                {
                    var confirm = new PasswordForm(() => 
                    {
                        DataFileSystem.IO.Wipe();
                        MessageBox.Show("All user data has been deleted");
                    });
                    confirm.Show();
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFileSystem.IO.SaveUserData();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CurrentAboutForm != null)
            {
                this.CurrentAboutForm.Focus();
                return;
            }

            this.CurrentAboutForm = new About(this);
            this.CurrentAboutForm.Show();
        }

        private void AddNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddNewBookButton_Clicked(sender, e);
        }

        private void AddNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddNewUserButton_Clicked(sender, e);
        }

        private void AddNewAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AddNewAuthorButton_Clicked(sender, e);
        }

        private void ShowAllCheckBox_CheckChanged(object sender, EventArgs e)
        {
            this.UpdateList();
        }

        private void ChangeDataLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirm = new PasswordForm(() => 
            {
                var op = new FolderBrowserDialog
                {
                    Description = "Select the folder for storing data\nCurrent folder: " + DataFileSystem.FileLocations.DatabasePath
                };
                op.ShowDialog();

                if (string.IsNullOrEmpty(op.SelectedPath))
                {
                    return;
                }

                DataFileSystem.IO.SaveUserData();
                string prevPath = DataFileSystem.FileLocations.DatabasePath;
                DataFileSystem.IO.ConfigFile.DataLocation = op.SelectedPath;
                DataFileSystem.IO.SaveConfig();
                MessageBox.Show("For changes to take effect the app has to be restarted, press OK to confirm");
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                this.Close();
                File.Move(Path.Combine(prevPath, DataFileSystem.IO.FileName), Path.Combine(DataFileSystem.IO.ConfigFile.DataLocation, DataFileSystem.IO.FileName));
            });
            confirm.Show();
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CurrentChangePasswordForm != null)
            {
                this.CurrentChangePasswordForm.Focus();
            }

            else
            {
                this.CurrentChangePasswordForm = new ChangePassword(this);
                this.CurrentChangePasswordForm.Show();
            }
        }
    }
}
