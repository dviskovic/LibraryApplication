using System;
using System.Windows.Forms;

namespace LibraryApplication.LibraryForms
{
    public partial class StartupForm : Form
    {
        private Timer timer = new Timer { Enabled = true, Interval = 10 };
        private Timer StartTimer = new Timer { Enabled = true, Interval = 1000 };

        private MainForm mainForm = null;

        public StartupForm()
        {
            InitializeComponent();
            this.Opacity = 0;
            this.timer.Tick += new EventHandler(IncreaseOpacy);
            this.timer.Start();
            LibraryEvents.EventManager.Startup();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var current = base.CreateParams;
                current.ClassStyle |= 0x00020000;
                return current;
            }
        }

        private void IncreaseOpacy(object o, EventArgs e)
        {
            this.Opacity += 0.025;
            if (this.Opacity >= 1)
            {
                this.timer.Stop();
                this.StartTimer.Tick += new EventHandler(StartMainForm);
                this.StartTimer.Start();
            }
        }

        private void StartMainForm(object o, EventArgs e)
        {
            this.StartTimer.Stop();
            this.StartTimer.Dispose();

            mainForm = new MainForm
            {
                startupForm = this
            };
            mainForm.Show();
            this.Hide();
        }
    }
}
