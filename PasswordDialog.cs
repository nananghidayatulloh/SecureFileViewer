using System;
using System.Drawing;
using System.Windows.Forms;

namespace SecureFileViewer
{
    public partial class PasswordDialog : Form
    {
        public string EnteredPassword { get; private set; }

        public PasswordDialog(string fileName, int remainingAttempts)
        {
            InitializeComponent();

            // Set values
            lblFileNameValue.Text = fileName;
            lblFileNameValue.ForeColor = Color.FromArgb(45, 45, 55);

            // Set warning color based on remaining attempts
            if (remainingAttempts == 1)
            {
                lblAttempts.Text = $"{remainingAttempts} attempt(s) remaining - LAST CHANCE!";
                lblAttempts.ForeColor = Color.FromArgb(244, 67, 54);
                lblWarning.ForeColor = Color.FromArgb(244, 67, 54);
            }
            else
            {
                lblAttempts.Text = $"{remainingAttempts} attempt(s) remaining";
                lblAttempts.ForeColor = Color.FromArgb(255, 152, 0);
            }

            // Setup event handlers
            btnUnlock.Click += BtnUnlock_Click;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            txtPassword.KeyPress += TxtPassword_KeyPress;
        }

        private void BtnUnlock_Click(object sender, EventArgs e)
        {
            EnteredPassword = txtPassword.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                EnteredPassword = txtPassword.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txtPassword.Focus();
        }
    }
}