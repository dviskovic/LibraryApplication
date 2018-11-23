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

        private string SearchQuery = string.Empty;

        public AddNewUserForm CurrentAddNewUserForm = null;
        public AddNewAuthorForm CurrentAddNewAuthorForm = null;
        public AddNewBookForm CurrentAddNewBookForm = null;
        public ListViewItem SelectedItem = null;
        public About CurrentAboutForm = null;

        private ContextMenu CurrentContextMenu = null;
        private Timer LastSaveTimer = new Timer { Enabled = true, Interval = 1000 };

        public MainForm()
        {
            InitializeComponent();
            LibraryEvents.EventManager.OnDataFileChanged += new Action(UpdateList);
            this.LastSaveTimer.Tick += new EventHandler(RefreshLastTime);
            this.LastSaveTimer.Start(); 
            this.SearchTypeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SearchTypeBox.DataSource = SearchResultType.StringArray();
        }


        private void RefreshLastTime(object o, EventArgs e)
        {
            TimeSpan TimeSpanSinceSave = Helpers.Data.TimeSinceLastSave();
            this.LastSaveTimeLabel.Text = "Last Save: " + Helpers.Data.GetReadableTimeFromTimeSpan(TimeSpanSinceSave);
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
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
                    return;
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

            foreach (var user in DataFileSystem.IO.DataFile.Users)
            {
                if (string.Compare(user.FirstName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(user.LastName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || user.LastName.ToLower().Contains(SearchQuery) || user.FirstName.ToLower().Contains(SearchQuery) || string.Compare(user.FullName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    resultList.Add(new SearchResult { Text = user.FirstName + " " + user.LastName, Image = string.IsNullOrEmpty(user.ImageID) ? "default_user.png" : user.ImageID });
                }
            }

            foreach (var book in DataFileSystem.IO.DataFile.Books)
            {
                if (string.Compare(book.Name, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || book.Name.ToLower().Contains(SearchQuery) || string.Compare(book.Author.FirstName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(book.Author.LastName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(book.Author.FullName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    resultList.Add(new SearchResult { Text = book.Name, Image = string.IsNullOrEmpty(book.ImageID) ? "default_book.png" : book.ImageID });
                }
            }

            var imagelist = new ImageList
            {
                ImageSize = new Size(64, 64),
                ColorDepth = ColorDepth.Depth32Bit
            };

            foreach (var result in resultList)
            {
                string path = string.Empty;

                if (!string.IsNullOrEmpty(result.Image))
                {
                    path = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, result.Image);
                }

                else path = DataFileSystem.FileLocations.DefaultUserImagePath;
                imagelist.Images.Add(result.Image, Image.FromFile(path));
            }

            this.ResultList.BeginUpdate();
            this.ResultList.Clear();
            this.ResultList.LargeImageList = imagelist;

            foreach (var result in resultList)
                this.ResultList.Items.Add(new ListViewItem(result.Text, result.Image));

            this.ResultList.EndUpdate();
        }

        private void ClearSearchBox()
        {
            this.ResultList.BeginUpdate();
            this.ResultList.Clear();
            this.ResultList.Items.Clear();
            this.ResultList.EndUpdate();
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

            SearchResultType.Type resultType = SearchResultType.ParseFromString((string) this.SearchTypeBox.SelectedItem);

            var resultList = new List<SearchResult>();

            if (resultType == SearchResultType.Type.All || resultType == SearchResultType.Type.Users)
            {
                foreach (var user in DataFileSystem.IO.DataFile.Users)
                {
                    if (string.Compare(user.FirstName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(user.LastName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || user.LastName.ToLower().Contains(SearchQuery) || user.FirstName.ToLower().Contains(SearchQuery) || string.Compare(user.FullName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        resultList.Add(new SearchResult { Text = user.FirstName + " " + user.LastName, Image = string.IsNullOrEmpty(user.ImageID) ? "default_user.png" : user.ImageID });
                    }
                }
            }
                
            if (resultType == SearchResultType.Type.Books || resultType == SearchResultType.Type.All)
            {
                foreach (var book in DataFileSystem.IO.DataFile.Books)
                {
                    if (string.Compare(book.Name, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || book.Name.ToLower().Contains(SearchQuery) || string.Compare(book.Author.FirstName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(book.Author.LastName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(book.Author.FullName, SearchQuery, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        resultList.Add(new SearchResult { Text = book.Name, Image = string.IsNullOrEmpty(book.ImageID) ? "default_book.png" : book.ImageID });
                    }
                }
            }
                
            var imagelist = new ImageList
            {
                ImageSize = new Size(64, 64),
                ColorDepth = ColorDepth.Depth32Bit
            };

            foreach (var result in resultList)
            {
                string path = string.Empty;

                if (!string.IsNullOrEmpty(result.Image))
                {
                    path = Path.Combine(DataFileSystem.FileLocations.ImagesFolderPath, result.Image);
                }

                else path = DataFileSystem.FileLocations.DefaultUserImagePath;
                imagelist.Images.Add(result.Image, Image.FromFile(path));
            }

            this.ResultList.BeginUpdate();
            this.ResultList.Clear();
            this.ResultList.LargeImageList = imagelist;
            
            foreach (var result in resultList)
                this.ResultList.Items.Add(new ListViewItem(result.Text, result.Image));

            this.ResultList.EndUpdate();
        }

        private void ResultBox_ItemDeleteClick(object o, EventArgs e)
        {
            if (CurrentContextMenu != null)
            {
                CurrentContextMenu.Dispose();
                this.ResultList.SelectedItems.Clear();
            }

            if (this.SelectedItem == null) return;

            var SearchResult = Helpers.Data.FindByNameAndImage(this.SelectedItem.Text, this.SelectedItem.ImageKey);
            if (SearchResult == null) MessageBox.Show("NULL!");

            string name = "Undefined";
            if (SearchResult is User) name = "\"" + (SearchResult as User).FullName + "\"";
            if (SearchResult is Book) name = "\"" + (SearchResult as Book).Name + "\"";

            this.SelectedItem = null;

            var Dialog = MessageBox.Show("Are you sure you want to delete " + name, "Delete Confirmation", MessageBoxButtons.YesNo);

            if (Dialog == DialogResult.Yes)
            {
                Helpers.Data.DeleteEntryFromDataFile(SearchResult);
                MessageBox.Show("Deleted " + name, "Notification");
            }
        }

        private void ResultBox_ItemOpenClick(object o, EventArgs e)
        {
            if (CurrentContextMenu != null)
            {
                CurrentContextMenu.Dispose();
                this.ResultList.SelectedItems.Clear();
            }

            if (this.SelectedItem == null) return;

            var SearchResult = Helpers.Data.FindByNameAndImage(this.SelectedItem.Text, this.SelectedItem.ImageKey);
            if (SearchResult == null) MessageBox.Show("NULL!");

            this.SelectedItem = null;

            if (SearchResult is User)
            {
                MessageBox.Show("User!");
            }

            if (SearchResult is Book)
            {
                MessageBox.Show("Book!");
            }
        }

        private void ResultBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.CurrentContextMenu != null) this.CurrentContextMenu.Dispose();
                foreach (ListViewItem item in ResultList.Items)
                {
                    if (item.Bounds.Contains(new Point(e.X, e.Y)))
                    {
                        item.Selected = true;
                        this.SelectedItem = item;
                        MenuItem[] mi = new MenuItem[] { new MenuItem("Open", new EventHandler(ResultBox_ItemOpenClick)), new MenuItem("Delete", new EventHandler(ResultBox_ItemDeleteClick)) };
                        ResultList.ContextMenu = this.CurrentContextMenu = new ContextMenu(mi);
                        ResultList.ContextMenu.Show(ResultList, new Point(e.X, e.Y));
                    }
                }
            }
        }

        private void ResultBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in ResultList.Items)
            {
                if (item.Bounds.Contains(new Point(e.X, e.Y)))
                {
                    this.SelectedItem = item;
                    ResultBox_ItemOpenClick(null, null);
                    return;
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

                if (dialog2 == DialogResult.Yes) DataFileSystem.IO.Wipe();
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
    }
}
