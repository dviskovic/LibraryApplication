using System;
using System.Windows.Forms;

namespace LibraryApplication.LibraryForms
{
    public partial class StartupForm : Form
    {
        private Timer timer = new Timer { Enabled = true, Interval = 10 };
        private Timer startTimer = new Timer { Enabled = true, Interval = 1000 };

        private MainForm mainForm = null;

        public StartupForm()
        {
            this.InitializeComponent();
            this.Opacity = 0;
            this.timer.Tick += new EventHandler(this.IncreaseOpacy);
            this.timer.Start();
            LibraryEvents.EventManager.Startup();
        }

        private void IncreaseOpacy(object o, EventArgs e)
        {
            this.Opacity += 0.0125;
            if (this.Opacity >= 1)
            {
                this.timer.Stop();
                this.startTimer.Tick += new EventHandler(this.StartMainForm);
                this.startTimer.Start();
            }
        }

        private void StartMainForm(object o, EventArgs e)
        {
            this.startTimer.Stop();
            this.startTimer.Dispose();
            this.mainForm = new MainForm
            {
                StartupForm = this
            };
            this.mainForm.Show();
            this.Hide();
        }
    }
}
