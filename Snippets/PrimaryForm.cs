using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snippets
{
    public partial class PrimaryForm : Form
    {
        public bool runOnStartup;

        public PrimaryForm()
        {
            InitializeComponent();

            runOnStartup = GetStartup();
            startupCheckbox.Checked = runOnStartup;
        }

        private void startupCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            runOnStartup = startupCheckbox.Checked;
            SetStartup(runOnStartup);
        }
        private static void SetStartup(bool enable)
        {
            using RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)!;

            if (enable)
            {
                rk.DeleteValue(Program.APP, false);
                rk.SetValue(Program.APP, Application.ExecutablePath);
            }
            else
                rk.DeleteValue(Program.APP, false);
        }
        private static bool GetStartup()
        {
            using RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)!;

            object? value = rk.GetValue(Program.APP, false);
            return value != null && value.Equals(Application.ExecutablePath);
        }

        internal void SetHidden(bool hidden)
        {
            notifyIcon.Visible = hidden;

            if (hidden)
                Hide();
            else
                Show();
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            SetHidden(true);
        }
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            SetHidden(false);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
