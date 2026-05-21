using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using SecureFileViewer.Models;

namespace SecureFileViewer
{
    public partial class ViewerForm : Form
    {
        private StorageManager _storage;
        private string _currentStoragePath = null;
        private bool _isUnlocked = false;
        private Dictionary<string, int> _fileAttempts = new Dictionary<string, int>();
        private string _currentPreviewFile = null;

        public ViewerForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

            lstFiles.DrawMode = DrawMode.OwnerDrawFixed;
            lstFiles.ItemHeight = 22;

            LoadLastConfig();
            UpdateUIState();
            DisableSaveFeatures();

            lstFiles.DrawItem += new DrawItemEventHandler(lstFiles_DrawItem);
            lstFiles.SelectedIndexChanged += new EventHandler(lstFiles_SelectedIndexChanged);
        }

        private void LoadLastConfig()
        {
            string configPath = Path.Combine(Application.StartupPath, "viewer_config.ini");
            if (File.Exists(configPath))
            {
                string path = File.ReadAllText(configPath);
                if (File.Exists(path))
                {
                    _currentStoragePath = path;
                    lblVaultPath.Text = "Last Storage Access: " + path;
                    lblVaultPath.ForeColor = Color.Green;
                    _storage = new StorageManager(path);
                }
            }
        }

        private void SaveConfig(string path)
        {
            string configPath = Path.Combine(Application.StartupPath, "viewer_config.ini");
            File.WriteAllText(configPath, path);
        }

        private void DisableSaveFeatures()
        {
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.Control && e.KeyCode == Keys.S)
                {
                    e.SuppressKeyPress = true;
                    lblStatus.Text = "Save/Download disabled!";
                    lblStatus.ForeColor = Color.Red;
                }
            };
        }

        private void UpdateUIState()
        {
            bool hasVault = _storage != null;
            grpLogin.Enabled = hasVault;

            bool unlocked = _isUnlocked;
            lstFiles.Enabled = unlocked;
            btnPreview.Enabled = unlocked;
            btnLogout.Enabled = unlocked;
        }

        private void btnOpenVault_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select vault file (.dat) to view";
                ofd.Filter = "Vault files (*.dat)|*.dat";
                ofd.CheckFileExists = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentStoragePath = ofd.FileName;
                    lblVaultPath.Text = _currentStoragePath;
                    lblVaultPath.ForeColor = Color.White;
                    _storage = new StorageManager(_currentStoragePath);
                    SaveConfig(_currentStoragePath);
                    UpdateUIState();

                    MessageBox.Show($"Vault loaded:\n{_currentStoragePath}",
                        "Vault Opened", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (_storage == null)
            {
                lblStatus.Text = "Please select a vault first!";
                return;
            }

            string password = txtPassword.Text;

            if (_storage.Load(password))
            {
                _isUnlocked = true;
                lblStatus.Text = "Vault unlocked! Select a file to preview.";
                lblStatus.ForeColor = Color.Green;
                txtPassword.Clear();
                UpdateUIState();
                RefreshFileList();
                this.Text = $"Viewer - {Path.GetFileName(_currentStoragePath)}";
            }
            else
            {
                lblStatus.Text = "Invalid master password!";
                lblStatus.ForeColor = Color.Red;
                txtPassword.Clear();
            }
        }

        private void RefreshFileList()
        {
            lstFiles.Items.Clear();
            if (_storage == null) return;
            lstFiles.Items.Add("HEADER_ROW");

            foreach (var file in _storage.GetFiles())
            {
                lstFiles.Items.Add(file);
            }
        }

        private void lstFiles_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            Graphics g = e.Graphics;

            int colNameX = e.Bounds.X + 10;
            int colTypeX = e.Bounds.X + 450;
            int colSizeX = e.Bounds.X + 600;

            if (lstFiles.Items[e.Index].ToString() == "HEADER_ROW")
            {
                using (SolidBrush headerBg = new SolidBrush(Color.FromArgb(50, 50, 50)))
                {
                    g.FillRectangle(headerBg, e.Bounds);
                }
                using (Font headerFont = new Font(e.Font, FontStyle.Bold))
                {
                    g.DrawString("File Name", headerFont, Brushes.White, colNameX, e.Bounds.Y + 3);
                    g.DrawString("File Type", headerFont, Brushes.White, colTypeX, e.Bounds.Y + 3);
                    g.DrawString("File Size", headerFont, Brushes.White, colSizeX, e.Bounds.Y + 3);
                }
                g.DrawLine(Pens.DimGray, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            }
            else
            {
                var file = lstFiles.Items[e.Index] as StoredFile;
                if (file == null) return;

                bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                Color bgColor;

                if (isSelected)
                {
                    bgColor = SystemColors.Highlight;
                }
                else
                {
                    bgColor = (e.Index % 2 == 1) ? Color.FromArgb(245, 245, 245) : Color.White;
                }

                using (SolidBrush bgBrush = new SolidBrush(bgColor))
                {
                    g.FillRectangle(bgBrush, e.Bounds);
                }

                string ext = Path.GetExtension(file.Name).ToUpper();
                if (string.IsNullOrEmpty(ext)) ext = "UNKNOWN";
                string sizeStr = FormatBytes(file.Size);

                Brush textBrush = isSelected ? Brushes.White : Brushes.Black;

                g.DrawString(file.Name, e.Font, textBrush, colNameX, e.Bounds.Y + 4);
                g.DrawString(ext, e.Font, textBrush, colTypeX, e.Bounds.Y + 4);
                g.DrawString(sizeStr, e.Font, textBrush, colSizeX, e.Bounds.Y + 4);

                if (!isSelected)
                {
                    g.DrawLine(Pens.Gainsboro, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }
            }
        }

        private string FormatBytes(long bytes)
        {
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }
            return $"{dblSByte:0.##} {suffix[i]}";
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex == 0 || lstFiles.SelectedItem is string)
            {
                btnPreview.Enabled = false;
            }
            else
            {
                btnPreview.Enabled = _isUnlocked;
            }
        }


        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex <= 0) return;
            if (!(lstFiles.SelectedItem is StoredFile file)) return;

            if (!_fileAttempts.ContainsKey(file.Id))
                _fileAttempts[file.Id] = 0;

            int remaining = 3 - _fileAttempts[file.Id];

            if (remaining <= 0)
            {
                MessageBox.Show($"Too many failed attempts! File '{file.Name}' will be deleted.",
                    "File Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _storage.DeleteFile(file.Id);
                RefreshFileList();
                return;
            }

            using (var dialog = new PasswordDialog(file.Name, remaining))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string password = dialog.EnteredPassword;

                    if (_storage.TestFilePassword(file.Id, password))
                    {
                        _fileAttempts[file.Id] = 0;

                        byte[] data = _storage.GetFileData(file.Id, password);

                        using (var previewForm = new PreviewForm(data, file.Name, file.Extension))
                        {
                            previewForm.ShowDialog();
                        }

                        lblStatus.Text = $"Preview closed: {file.Name}";
                        lblStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        _fileAttempts[file.Id]++;
                        int newRemaining = 3 - _fileAttempts[file.Id];
                        MessageBox.Show($"Wrong password! {newRemaining} attempt(s) remaining.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblStatus.Text = $"Wrong password for {file.Name}";
                        lblStatus.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?\n\nVault will be locked.",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                _fileAttempts.Clear();
                _isUnlocked = false;
                _storage = null;
                UpdateUIState();
                lstFiles.Items.Clear();
                lblStatus.Text = "Logged out";
                lblStatus.ForeColor = Color.Orange;
                this.Text = "Viewer";
                txtPassword.Clear();
            }
        }

        private void ViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to close Viewer?",
                "Confirm Close",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form is MainMenuForm)
                    {
                        form.Show();
                        break;
                    }
                }
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}