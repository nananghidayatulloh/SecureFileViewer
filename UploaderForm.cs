using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecureFileViewer.Models;


namespace SecureFileViewer
{
    public partial class UploaderForm : Form
    {
        private StorageManager _storage;
        private string _currentStoragePath = null;
        private bool _isUnlocked = false;

        public UploaderForm()
        {
            InitializeComponent();

            // Maximize saat load
            this.WindowState = FormWindowState.Maximized;

            // Set ListBox 
            lstFiles.DrawMode = DrawMode.OwnerDrawFixed;
            lstFiles.ItemHeight = 22;

            lstFiles.DrawItem += new DrawItemEventHandler(lstFiles_DrawItem);

            LoadLastConfig();
            UpdateUIState();
            lstFiles.SelectedIndexChanged += lstFiles_SelectedIndexChanged;
        }

        private void LoadLastConfig()
        {
            string configPath = Path.Combine(Application.StartupPath, "uploader_config.ini");
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
            string configPath = Path.Combine(Application.StartupPath, "uploader_config.ini");
            File.WriteAllText(configPath, path);
        }

        private void UpdateUIState()
        {
            bool hasVault = _storage != null;
            grpLogin.Enabled = hasVault;

            bool unlocked = _isUnlocked;
            btnUpload.Enabled = unlocked;
            btnDelete.Enabled = unlocked;
            lstFiles.Enabled = unlocked;
            btnLogout.Enabled = unlocked;
        }

        private void btnOpenVault_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select existing vault file (.dat)";
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

        private void btnCreateVault_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Create new vault file";
                sfd.Filter = "Vault files (*.dat)|*.dat";
                sfd.FileName = "secure_vault.dat";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _currentStoragePath = sfd.FileName;
                    lblVaultPath.Text = sfd.FileName;
                    lblVaultPath.ForeColor = Color.White;
                    _storage = new StorageManager(_currentStoragePath);
                    SaveConfig(_currentStoragePath);
                    UpdateUIState();

                    MessageBox.Show($"New vault will be created at:\n{_currentStoragePath}\n\n" +
                        "Enter a password and click UNLOCK to initialize.",
                        "New Vault", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            int colTypeX = e.Bounds.X + 450; // Jarak kolom tipe file
            int colSizeX = e.Bounds.X + 600; // Jarak kolom ukuran file

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
                _isUnlocked = false;
                _storage = null;
                UpdateUIState();
                lstFiles.Items.Clear();
                lblStatus.Text = "Logged out";
                lblStatus.ForeColor = Color.Orange;
                this.Text = "Uploader";
                txtPassword.Clear();
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (_storage == null)
            {
                lblStatus.Text = "Please select or create a vault first!";
                return;
            }

            string password = txtPassword.Text;

            if (_storage.Load(password))
            {
                _isUnlocked = true;
                lblStatus.Text = "Vault unlocked!";
                lblStatus.ForeColor = Color.Green;
                txtPassword.Clear();
                UpdateUIState();
                RefreshFileList();
                this.Text = $"Uploader - {Path.GetFileName(_currentStoragePath)}";
            }
            else
            {
                lblStatus.Text = "Invalid master password!";
                lblStatus.ForeColor = Color.Red;
                txtPassword.Clear();
            }
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            if (!_isUnlocked)
            {
                MessageBox.Show("Please unlock the vault first!", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select file to upload and encrypt";
                ofd.Filter = "Supported Files|*.jpg;*.jpeg;*.png;*.pdf|All Files|*.*";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    SetListBoxUploadMode(true);

                    btnUpload.Enabled = false;
                    btnDelete.Enabled = false;
                    btnLogout.Enabled = false;
                    btnUnlock.Enabled = false;

                    progressBarUpload.Visible = true;
                    lblUploadStatus.Visible = true;

                    int totalFiles = ofd.FileNames.Length;
                    int success = 0;
                    int fail = 0;

                    progressBarUpload.Maximum = totalFiles;
                    progressBarUpload.Value = 0;

                    for (int i = 0; i < totalFiles; i++)
                    {
                        string filePath = ofd.FileNames[i];
                        string fileName = Path.GetFileName(filePath);

                        lblUploadStatus.Text = $"Uploading: {fileName} ({i + 1}/{totalFiles})";
                        lblUploadStatus.ForeColor = Color.Blue;
                        progressBarUpload.Value = i;

                        Application.DoEvents();

                        await Task.Run(() =>
                        {
                            try
                            {
                                _storage.AddFile(filePath);
                                success++;
                            }
                            catch (Exception ex)
                            {
                                fail++;
                                System.Diagnostics.Debug.WriteLine($"Failed: {fileName} - {ex.Message}");
                            }
                        });

                        progressBarUpload.Value = i + 1;
                        Application.DoEvents();
                    }

                    progressBarUpload.Value = totalFiles;

                    if (fail > 0)
                    {
                        lblUploadStatus.Text = $"Complete! Success: {success}, Failed: {fail}";
                        lblUploadStatus.ForeColor = Color.Orange;

                        MessageBox.Show($"Upload completed!\n\nSuccess: {success}\nFailed: {fail}\n\nCheck failed files and try again.",
                            "Upload Result", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    else
                    {
                        lblUploadStatus.Text = $"Complete! Successfully uploaded {success} file(s)!";
                        lblUploadStatus.ForeColor = Color.Green;

                        MessageBox.Show($"Successfully uploaded {success} file(s)!",
                            "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    RefreshFileList();

                    Timer hideTimer = new Timer { Interval = 2000 };
                    hideTimer.Tick += (s, args) =>
                    {
                        progressBarUpload.Visible = false;
                        lblUploadStatus.Visible = false;
                        hideTimer.Stop();
                        hideTimer.Dispose();
                    };
                    hideTimer.Start();

                    btnUpload.Enabled = true;
                    btnDelete.Enabled = _isUnlocked;
                    btnLogout.Enabled = _isUnlocked;
                    btnUnlock.Enabled = true;

                    SetListBoxUploadMode(false);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex > 0 && lstFiles.SelectedItem is StoredFile file)
            {
                var result = MessageBox.Show($"Delete '{file.Name}' permanently?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _storage.DeleteFile(file.Id);
                    RefreshFileList();
                }
            }
        }

        private void UploaderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                 "Are you sure you want to close Uploader?\n\nAny unsaved changes will be lost.",
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

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex == 0 || lstFiles.SelectedItem is string)
            {
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = _isUnlocked;
            }
        }

        private void SetListBoxUploadMode(bool isUploading)
        {
            if (isUploading)
            {
                lstFiles.Enabled = false;
                lstFiles.BackColor = Color.FromArgb(240, 240, 240);
                lstFiles.ForeColor = Color.Gray;

                this.Cursor = Cursors.WaitCursor;
            }
            else
            {
                lstFiles.Enabled = true;
                lstFiles.BackColor = Color.White;
                lstFiles.ForeColor = Color.Black;

                this.Cursor = Cursors.Default;
            }
        }
    }
}