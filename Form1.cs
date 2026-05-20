using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SecureFileViewer.Models;
using System.Collections.Generic;

namespace SecureFileViewer
{
    public partial class Form1 : Form
    {
        private StorageManager _storage;
        private bool _isUnlocked = false;
        private string _currentStoragePath = null;

        // UI Controls
        private TextBox txtMasterPassword;
        private Button btnLogin;
        private Button btnOpenVault;     
        private Label lblStoragePath;   
        private Label lblStatus;
        private ListBox lstFiles;
        private Button btnUpload;
        private PictureBox picPreview;
        private WebBrowser webPreview;

        private Dictionary<string, int> _fileAttempts = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void InitializeComponent()
        {
            this.Text = "Secure File Vault - Portable Storage";
            this.Size = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SetupUI()
        {
            // ===== PANEL LOGIN =====
            Panel pnlLogin = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(45, 45, 55) };

            Label lblTitle = new Label
            {
                Text = "SECURE FILE VAULT",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(50, 60),
                Size = new Size(400, 45)
            };

            Label lblSub = new Label
            {
                Text = "Encrypted file storage - Choose your vault location",
                ForeColor = Color.FromArgb(180, 180, 180),
                Location = new Point(50, 110),
                Size = new Size(400, 25)
            };

            // ===== SECTION: PILIH LOKASI STORAGE =====
            GroupBox grpStorage = new GroupBox
            {
                Text = "📍 VAULT LOCATION",
                ForeColor = Color.White,
                Location = new Point(50, 150),
                Size = new Size(400, 80),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            lblStoragePath = new Label
            {
                Text = "No vault selected",
                ForeColor = Color.Gray,
                Location = new Point(15, 25),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 8)
            };

            btnOpenVault = new Button
            {
                Text = "📂 OPEN VAULT",
                Location = new Point(280, 22),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnOpenVault.Click += BtnOpenVault_Click;

            grpStorage.Controls.Add(lblStoragePath);
            grpStorage.Controls.Add(btnOpenVault);

            // ===== SECTION: LOGIN =====
            GroupBox grpLogin = new GroupBox
            {
                Text = "🔐 UNLOCK VAULT",
                ForeColor = Color.White,
                Location = new Point(50, 245),
                Size = new Size(400, 110),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            Label lblPass = new Label
            {
                Text = "Master Password:",
                ForeColor = Color.White,
                Location = new Point(15, 30),
                Size = new Size(120, 25)
            };

            txtMasterPassword = new TextBox
            {
                Location = new Point(145, 28),
                Size = new Size(235, 25),
                PasswordChar = '•'
            };

            btnLogin = new Button
            {
                Text = "UNLOCK",
                Location = new Point(145, 65),
                Size = new Size(235, 30),
                BackColor = Color.FromArgb(76, 175, 80),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnLogin.Click += BtnLogin_Click;

            grpLogin.Controls.Add(lblPass);
            grpLogin.Controls.Add(txtMasterPassword);
            grpLogin.Controls.Add(btnLogin);

            lblStatus = new Label
            {
                Text = "",
                Location = new Point(50, 370),
                Size = new Size(400, 25),
                ForeColor = Color.OrangeRed
            };

            pnlLogin.Controls.AddRange(new Control[] {
                lblTitle, lblSub, grpStorage, grpLogin, lblStatus
            });

            // ===== PANEL MAIN =====
            Panel pnlMain = new Panel { Dock = DockStyle.Fill, Visible = false };

            // Top bar dengan info storage
            Panel topBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.FromArgb(45, 45, 55)
            };

            Label lblInfo = new Label
            {
                Text = "📁 Vault: ",
                ForeColor = Color.White,
                Location = new Point(10, 12),
                AutoSize = true
            };

            Label lblVaultInfo = new Label
            {
                Text = "",
                ForeColor = Color.FromArgb(100, 200, 100),
                Location = new Point(80, 12),
                AutoSize = true,
                Name = "lblVaultInfo"
            };

            Button btnChangeVault = new Button
            {
                Text = "CHANGE VAULT",
                Location = new Point(this.Width - 130, 8),
                Size = new Size(110, 25),
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnChangeVault.Click += (s, e) => { LogoutAndChangeVault(); };

            topBar.Controls.Add(lblInfo);
            topBar.Controls.Add(lblVaultInfo);
            topBar.Controls.Add(btnChangeVault);

            // Left panel - file list
            Panel leftPanel = new Panel { Dock = DockStyle.Left, Width = 280 };

            Label lblFilesTitle = new Label
            {
                Text = "  FILES IN VAULT",
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.FromArgb(240, 240, 240),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            lstFiles = new ListBox { Dock = DockStyle.Fill };

            Panel btnPanel = new Panel { Dock = DockStyle.Bottom, Height = 120, Padding = new Padding(5) };

            btnUpload = new Button
            {
                Text = "📤 UPLOAD FILE (Choose location)",
                Dock = DockStyle.Top,
                Height = 35,
                Margin = new Padding(0, 0, 0, 5),
                BackColor = Color.FromArgb(33, 150, 243),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

           

            btnUpload.Click += BtnUpload_Click;
            lstFiles.SelectedIndexChanged += (s, e) =>
            {
                bool hasSelected = lstFiles.SelectedItem != null;
            };

            btnPanel.Controls.Add(btnUpload);

            leftPanel.Controls.Add(lstFiles);
            leftPanel.Controls.Add(btnPanel);
            leftPanel.Controls.Add(lblFilesTitle);

            // Right panel - preview
            Panel rightPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };

            Label lblPreviewTitle = new Label
            {
                Text = "PREVIEW (Save/Download Disabled)",
                Dock = DockStyle.Top,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightGray
            };

            picPreview = new PictureBox { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, Visible = false };
            webPreview = new WebBrowser { Dock = DockStyle.Fill, Visible = false };

            // Disable save context menu
            webPreview.IsWebBrowserContextMenuEnabled = false;
            webPreview.WebBrowserShortcutsEnabled = false;

            rightPanel.Controls.Add(picPreview);
            rightPanel.Controls.Add(webPreview);
            rightPanel.Controls.Add(lblPreviewTitle);

            pnlMain.Controls.Add(rightPanel);
            pnlMain.Controls.Add(leftPanel);
            pnlMain.Controls.Add(topBar);

            // Add to form
            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlLogin);

            // Resize handler untuk update anchor
            this.Resize += (s, e) =>
            {
                if (pnlLogin.Visible)
                {

                }
            };
        }

        // ===== MEMILIH LOKASI STORAGE =====
        private void BtnOpenVault_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select existing vault file (.dat) or choose location to create new";
                ofd.Filter = "Vault files (*.dat)|*.dat|All files (*.*)|*.*";
                ofd.CheckFileExists = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = ofd.FileName;
                    _currentStoragePath = selectedPath;
                    lblStoragePath.Text = selectedPath;
                    lblStoragePath.ForeColor = Color.White;

                    // Inisialisasi storage dengan path yang dipilih
                    _storage = new StorageManager(selectedPath);

                    // Simpan path ke file konfigurasi 
                    SaveConfig(selectedPath);

                    MessageBox.Show($"Vault location set to:\n{selectedPath}\n\nEnter your password to unlock.",
                        "Vault Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SaveConfig(string path)
        {
            string configPath = Path.Combine(Application.StartupPath, "vault_config.ini");
            File.WriteAllText(configPath, path);
        }

        private string LoadConfig()
        {
            string configPath = Path.Combine(Application.StartupPath, "vault_config.ini");
            if (File.Exists(configPath))
            {
                return File.ReadAllText(configPath);
            }
            return null;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (_storage == null)
            {
                lblStatus.Text = "Please select a vault location first!";
                return;
            }

            string password = txtMasterPassword.Text;

            if (_storage.Load(password))
            {
                _isUnlocked = true;
                this.Controls[1].Visible = false; // hide login panel
                this.Controls[0].Visible = true;  // show main panel

                // Update vault info di main panel
                foreach (Control ctrl in this.Controls[0].Controls)
                {
                    if (ctrl is Panel p)
                    {
                        foreach (Control c in p.Controls)
                        {
                            if (c is Panel topBar)
                            {
                                foreach (Control label in topBar.Controls)
                                {
                                    if (label is Label l && l.Name == "lblVaultInfo")
                                    {
                                        l.Text = Path.GetFileName(_currentStoragePath);
                                        // l.ToolTipText = _currentStoragePath;  
                                    }
                                }
                            }
                        }
                    }
                }

                RefreshFileList();
                lblStatus.Text = "";
            }
            else
            {
                lblStatus.Text = "Invalid master password!";
                txtMasterPassword.Clear();
            }
        }

        private void LogoutAndChangeVault()
        {
            var result = MessageBox.Show("Lock vault and choose different location?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _storage = null;
                _currentStoragePath = null;
                _isUnlocked = false;
                _fileAttempts.Clear();

                this.Controls[0].Visible = false;  // hide main
                this.Controls[1].Visible = true;   // show login

                lblStoragePath.Text = "No vault selected";
                lblStoragePath.ForeColor = Color.Gray;
                txtMasterPassword.Clear();
                lblStatus.Text = "";
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

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select file to upload (from ANY location - Desktop, USB, Documents, etc)";
                ofd.Filter = "Supported Files|*.jpg;*.jpeg;*.png;*.pdf|Image Files|*.jpg;*.jpeg;*.png|PDF Files|*.pdf";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _storage.AddFile(ofd.FileName);
                        RefreshFileList();
                        MessageBox.Show($"File uploaded and encrypted!\n\nSource: {ofd.FileName}\nStored in: {_currentStoragePath}",
                            "Upload Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Upload failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if (!(lstFiles.SelectedItem is StoredFile)) return;
            StoredFile file = (StoredFile)lstFiles.SelectedItem;
            if (!_fileAttempts.ContainsKey(file.Id))
                _fileAttempts[file.Id] = 0;

            int remaining = 3 - _fileAttempts[file.Id];

            if (remaining <= 0)
            {
                MessageBox.Show($"Too many failed attempts! File '{file.Name}' will be deleted permanently.",
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
                        string tempFile = Path.Combine(Path.GetTempPath(), $"preview_{Guid.NewGuid()}{file.Extension}");
                        File.WriteAllBytes(tempFile, data);

                        if (file.Extension == ".pdf")
                        {
                            picPreview.Visible = false;
                            webPreview.Visible = true;
                            webPreview.Navigate(tempFile);
                        }
                        else
                        {
                            webPreview.Visible = false;
                            picPreview.Visible = true;
                            picPreview.Image = Image.FromFile(tempFile);
                        }
                    }
                    else
                    {
                        _fileAttempts[file.Id]++;
                        MessageBox.Show($"Wrong password! {2 - _fileAttempts[file.Id]} attempts remaining.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem is StoredFile file)
            {
                if (MessageBox.Show($"Delete '{file.Name}' from vault?\nLocation: {_currentStoragePath}",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _storage.DeleteFile(file.Id);
                    RefreshFileList();
                    picPreview.Visible = false;
                    webPreview.Visible = false;
                }
            }
        }
    }
}