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
            LoadLastConfig();
            UpdateUIState();
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
                    lblVaultPath.Text = path;
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
                    lblVaultPath.Text = _currentStoragePath;
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
            foreach (var file in _storage.GetFiles())
            {
                lstFiles.Items.Add(file);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _isUnlocked = false;
            _storage = null;
            UpdateUIState();
            lstFiles.Items.Clear();
            lblStatus.Text = "Logged out";
            lblStatus.ForeColor = Color.Orange;
            this.Text = "Uploader";
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
                lblStatus.Text = "✓ Vault unlocked!";
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select file to upload and encrypt";
                ofd.Filter = "Supported Files|*.jpg;*.jpeg;*.png;*.pdf|All Files|*.*";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    int success = 0;
                    foreach (string filePath in ofd.FileNames)
                    {
                        try
                        {
                            _storage.AddFile(filePath);
                            success++;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed: {Path.GetFileName(filePath)}\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    RefreshFileList();
                    MessageBox.Show($"Uploaded {success} file(s) successfully!",
                        "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem is StoredFile file)
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
            //Application.Exit();
            DialogResult result = MessageBox.Show(
                "Are you sure you want to close Uploader?\n\nAny unsaved changes will be lost.",
                "Confirm Close",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                MainMenuForm mainMenu = new MainMenuForm();
                mainMenu.Show();

                e.Cancel = false; 
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
