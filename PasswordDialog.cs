using System;
using System.Drawing;
using System.Windows.Forms;

namespace SecureFileViewer
{
    public partial class PasswordDialog : Form
    {
        public string EnteredPassword { get; private set; }

        // Constructor dengan 2 parameter (sesuai yang dipanggil di Form1)
        public PasswordDialog(string fileName, int remainingAttempts)
        {
            InitializeComponent();
            SetupUI(fileName, remainingAttempts);
        }

        private void SetupUI(string fileName, int remainingAttempts)
        {
            Label lblTitle = new Label
            {
                Text = $"🔐 Open File: {fileName}",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(20, 20),
                Size = new Size(350, 30)
            };

            Label lblWarning = new Label
            {
                Text = $"⚠️ {remainingAttempts} attempt(s) remaining. 3 wrong attempts = file deleted",
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Location = new Point(20, 55),
                Size = new Size(350, 25),
                ForeColor = Color.OrangeRed
            };

            Label lblPassword = new Label
            {
                Text = "Encryption Key:",
                Location = new Point(20, 95),
                Size = new Size(100, 25)
            };

            TextBox txtPassword = new TextBox
            {
                Location = new Point(130, 93),
                Size = new Size(230, 25),
                PasswordChar = '•'
            };

            Button btnOk = new Button
            {
                Text = "UNLOCK",
                Location = new Point(130, 135),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.OK
            };

            Button btnCancel = new Button
            {
                Text = "CANCEL",
                Location = new Point(240, 135),
                Size = new Size(100, 30),
                DialogResult = DialogResult.Cancel
            };

            // Simpan password saat OK diklik
            btnOk.Click += (s, e) =>
            {
                EnteredPassword = txtPassword.Text;
            };

            // Enter key = OK
            txtPassword.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    EnteredPassword = txtPassword.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            };

            this.Controls.AddRange(new Control[] {
                lblTitle, lblWarning, lblPassword, txtPassword, btnOk, btnCancel
            });
        }
    }
}