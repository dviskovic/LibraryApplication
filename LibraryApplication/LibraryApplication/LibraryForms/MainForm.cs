using LibraryApplication.LibraryForms;
using LibraryApplication.LibraryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace LibraryApplication
{
    public partial class MainForm : Form
    {
        public StartupForm startupForm = null;

        public Dictionary<User, LibraryForms.UserControl> UserDictionary = new Dictionary<User, LibraryForms.UserControl>();
        public Dictionary<Book, LibraryForms.BookControl> BookDictionary = new Dictionary<Book, LibraryForms.BookControl>();

        private string SearchQuery = string.Empty;

        public AddNewUserForm CurrentAddNewUserForm = null;
        public AddNewAuthorForm CurrentAddNewAuthorForm = null;
        public AddNewBookForm CurrentAddNewBookForm = null;
        public ListViewItem SelectedItem = null;
        public About CurrentAboutForm = null;
        public ChangePasswordForm CurrentChangePasswordForm = null;

        private Timer LastSaveTimer = new Timer { Enabled = true, Interval = 1000 };

        public MainForm()
        {
            InitializeComponent();
            LibraryEvents.EventManager.OnDataFileChanged += new Action(UpdateList);
            this.LastSaveTimer.Tick += new EventHandler(RefreshLastTime);
            this.LastSaveTimer.Start(); 
            this.SearchTypeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SearchTypeBox.DataSource = SearchResult.StringArray();

            DataFileSystem.IO.SaveUserData();
        }

        private void RefreshLastTime(object o, EventArgs e)
        {
            TimeSpan TimeSpanSinceSave = LibraryHelpers.Data.TimeSinceLastSave();
            this.LastSaveTimeLabel.Text = "Last Save: " + LibraryHelpers.Data.GetReadableTimeFromTimeSpan(TimeSpanSinceSave);
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            DataFileSystem.IO.SaveConfig();
            DataFileSystem.IO.SaveUserData();
            startupForm.Close();
        }

        private void AddNewUserButton_Clicked(object sender, EventArgs e)
        {
            if (CurrentAddNewUserForm != null)
            {
                CurrentAddNewUserForm.Focus();
                return;
            }

            CurrentAddNewUserForm = new AddNewUserForm(this);
            CurrentAddNewUserForm.Show();
        }

        private void AddNewAuthorButton_Clicked(object sender, EventArgs e)
        {
            if (CurrentAddNewAuthorForm != null) CurrentAddNewAuthorForm.Focus();
            CurrentAddNewAuthorForm = new AddNewAuthorForm(this);
            CurrentAddNewAuthorForm.Show();
        }

        private void AddNewBookButton_Clicked(object sender, EventArgs e)
        {
            if (CurrentAddNewBookForm != null)
            {
                CurrentAddNewBookForm.Focus();
                return;
            }

            CurrentAddNewBookForm = new AddNewBookForm(this);
            CurrentAddNewBookForm.Show();
        }

        private void SearchQueryChanged(object sender, EventArgs e)
        {
            if (SearchBox.Text == string.Empty)
            {
                if (!this.ShowAllCheckBox.Checked)
                {
                    ClearSearchBox();
                }

                else
                {
                    ShowAllResults();
                    return;
                }
            }

            SearchQuery = SearchBox.Text.ToLower();
            UpdateList();
        }

        private void ShowAllResults()
        {
            var resultList = new List<SearchResult>();

            SearchResult.Types resultType = SearchResult.ParseFromString((string)this.SearchTypeBox.SelectedItem);

            if (resultType == SearchResult.Types.All || resultType == SearchResult.Types.User)
            {
                foreach (var user in DataFileSystem.IO.DataFile.Users)
                {
                    resultList.Add(new SearchResult { Name = "\"" + user.FirstName + " " + user.LastName + "\"" /*Image = string.IsNullOrEmpty(user.ImageID) ? "default_user.png" : user.ImageID*/, Author = "None", Available = "None", ISBN = "None"   });
                }
            }

            if (resultType == SearchResult.Types.All || resultType == SearchResult.Types.Book)
            {
                foreach (var book in DataFileSystem.IO.DataFile.Books)
                {
                    resultList.Add(new SearchResult { Name = "\"" + book.Name + "\""/*Image = string.IsNullOrEmpty(book.ImageID) ? "default_book.png" : book.ImageID*/, Author = "\"" + book.Author.FullName + "\"", Available = book.Available > 0 ? "Yes (" + book.Available + ")" : "No", ISBN = book.ISBN });
                }
            }

            this.ResultList.Rows.Clear();

            foreach (var result in resultList)
                this.ResultList.Rows.Add(result.Name, result.Author, result.Available, result.ISBN);
        }

        private void ClearSearchBox()
        {
            this.ResultList.Rows.Clear();
        }

        private void UpdateList()
        {
            if (SearchBox.Text == string.Empty)
            {
                if (!this.ShowAllCheckBox.Checked)
                {
                    ClearSearchBox();
                    return;
                }

                else
                {
                    ShowAllResults();
                    return;
                }
            }

            SearchResult.Types resultType = SearchResult.ParseFromString((string) this.SearchTypeBox.SelectedItem);

            var resultList = new List<SearchResult>();

            if (resultType == SearchResult.Types.All || resultType == SearchResult.Types.User)
            {
                foreach (var user in DataFileSystem.IO.DataFile.Users)
                {
                    if (string.Compare(user.FirstName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(user.LastName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 ||  user.LastName.ToLower().Contains(SearchQuery) || user.FirstName.ToLower().Contains(SearchQuery) || string.Compare(user.FullName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || user.Email.ToLower().Contains(SearchQuery) || string.Compare(user.Email, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        resultList.Add(new SearchResult { Name = user.FirstName + " " + user.LastName /*Image = string.IsNullOrEmpty(user.ImageID) ? "default_user.png" : user.ImageID*/, Available = "None", ISBN = "None", Author = "None" });
                    }
                }
            }
                
            if (resultType == SearchResult.Types.Book || resultType == SearchResult.Types.All)
            {
                foreach (var book in DataFileSystem.IO.DataFile.Books)
                {
                    var author = book.Author;
                    if (string.Compare(book.Name, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || book.Name.ToLower().Contains(SearchQuery) || string.Compare(author.FirstName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(author.LastName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(author.FullName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(book.ISBN, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || book.ISBN.ToLower().Contains(SearchQuery))
                    {
                        resultList.Add(new SearchResult { Name = "\"" + book.Name + "\"" /*Image = string.IsNullOrEmpty(book.ImageID) ? "default_book.png" : book.ImageID*/, Author = "\"" + book.Author.FullName + "\"", ISBN = book.ISBN, Available = book.Available > 0 ? "Yes (" + book.Available + ")" : "No" });
                    }
                }
            }

            this.ResultList.Rows.Clear();
            
            foreach (var result in resultList)
                this.ResultList.Rows.Add(result.Name, result.Author, result.Available, result.ISBN);

        }

        private void ResultBox_MouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Name = this.ResultList.Rows[e.RowIndex].Cells[0].Value.ToString();

            var item = LibraryHelpers.Data.Find(Name, SearchResult.Types.All);
            if (item == null) return;
            
            if (item is Book book)
            {
                if (this.BookDictionary.TryGetValue(book, out LibraryForms.BookControl form))
                {
                    form.Focus();
                }

                else
                {
                    var form2 = new LibraryForms.BookControl(book, this);
                    form2.Show();
                    this.BookDictionary.Add(book, form2);
                }
            }

            if (item is User user)
            {
                if (this.UserDictionary.TryGetValue(user, out LibraryForms.UserControl form))
                {
                   
                    form.Focus();
                }

                else
                {
                    var form2 = new LibraryForms.UserControl(user, this);
                    form2.Show();
                    this.UserDictionary.Add(user, form2);
                }
            }
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void SearchTypeBox_TextChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void deleteAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Are you sure you want to delete all data?", "Warning", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                var dialog2 = MessageBox.Show("Are you REALLY sure you want to delete all data?", "Warning", MessageBoxButtons.YesNo);

                if (dialog2 == DialogResult.Yes)
                {
                    var confirm = new PasswordForm(() => {
                        DataFileSystem.IO.Wipe();
                        MessageBox.Show("All user data has been deleted");
                    });
                    confirm.Show();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFileSystem.IO.SaveUserData();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentAboutForm != null)
            {
                CurrentAboutForm.Focus();
                return;
            }

            CurrentAboutForm = new About(this);
            CurrentAboutForm.Show();
        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewBookButton_Clicked(sender, e);
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewUserButton_Clicked(sender, e);
        }

        private void addNewAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewAuthorButton_Clicked(sender, e);
        }

        private void ShowAllCheckBox_CheckChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void changeDataLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirm = new PasswordForm(() => {
                var op = new FolderBrowserDialog
                {
                    Description = "Select the folder for storing data\nCurrent folder: " + DataFileSystem.FileLocations.DatabasePath
                };
                op.ShowDialog();

                if (string.IsNullOrEmpty(op.SelectedPath)) return;

                DataFileSystem.IO.SaveUserData();
                string prevPath = DataFileSystem.FileLocations.DatabasePath;
                DataFileSystem.IO.configFile.DataLocation = op.SelectedPath;
                DataFileSystem.IO.SaveConfig();
                MessageBox.Show("For changes to take effect the app has to be restarted, press OK to confirm");
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                this.Close();
                File.Move(Path.Combine(prevPath, DataFileSystem.IO.FileName), Path.Combine(DataFileSystem.IO.configFile.DataLocation, DataFileSystem.IO.FileName));
            });
            confirm.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CurrentChangePasswordForm != null) this.CurrentChangePasswordForm.Focus();
            else
            {
                this.CurrentChangePasswordForm = new ChangePasswordForm(this);
                this.CurrentChangePasswordForm.Show();
            }
        }
    }
}
