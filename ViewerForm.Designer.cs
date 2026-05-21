
namespace SecureFileViewer
{
    partial class ViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpVault = new System.Windows.Forms.GroupBox();
            this.btnOpenVault = new System.Windows.Forms.Button();
            this.lblVaultPath = new System.Windows.Forms.Label();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.grpVault.SuspendLayout();
            this.grpLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpVault
            // 
            this.grpVault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVault.Controls.Add(this.btnOpenVault);
            this.grpVault.Controls.Add(this.lblVaultPath);
            this.grpVault.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpVault.Location = new System.Drawing.Point(24, 20);
            this.grpVault.Name = "grpVault";
            this.grpVault.Size = new System.Drawing.Size(656, 85);
            this.grpVault.TabIndex = 0;
            this.grpVault.TabStop = false;
            this.grpVault.Text = "VAULT STORAGE LOCATION";
            // 
            // btnOpenVault
            // 
            this.btnOpenVault.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOpenVault.Location = new System.Drawing.Point(20, 32);
            this.btnOpenVault.Name = "btnOpenVault";
            this.btnOpenVault.Size = new System.Drawing.Size(140, 32);
            this.btnOpenVault.TabIndex = 0;
            this.btnOpenVault.Text = "Open Vault";
            this.btnOpenVault.UseVisualStyleBackColor = true;
            this.btnOpenVault.Click += new System.EventHandler(this.btnOpenVault_Click);
            // 
            // lblVaultPath
            // 
            this.lblVaultPath.AutoSize = true;
            this.lblVaultPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblVaultPath.ForeColor = System.Drawing.Color.DimGray;
            this.lblVaultPath.Location = new System.Drawing.Point(180, 38);
            this.lblVaultPath.Name = "lblVaultPath";
            this.lblVaultPath.Size = new System.Drawing.Size(97, 15);
            this.lblVaultPath.TabIndex = 1;
            this.lblVaultPath.Text = "No vault selected";
            // 
            // grpLogin
            // 
            this.grpLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogin.Controls.Add(this.btnPreview);
            this.grpLogin.Controls.Add(this.btnLogout);
            this.grpLogin.Controls.Add(this.lstFiles);
            this.grpLogin.Controls.Add(this.lblStatus);
            this.grpLogin.Controls.Add(this.btnUnlock);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpLogin.Location = new System.Drawing.Point(24, 120);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(656, 409);
            this.grpLogin.TabIndex = 1;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "SECURE VAULT ACCESS";
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPreview.Location = new System.Drawing.Point(490, 359);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(146, 34);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "Preview Selected";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogout.Location = new System.Drawing.Point(372, 359);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 34);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Lock & Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstFiles.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 22;
            this.lstFiles.Location = new System.Drawing.Point(20, 80);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(616, 268);
            this.lstFiles.TabIndex = 4;
            this.lstFiles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstFiles_DrawItem);
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.Crimson;
            this.lblStatus.Location = new System.Drawing.Point(420, 38);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 3;
            // 
            // btnUnlock
            // 
            this.btnUnlock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUnlock.Location = new System.Drawing.Point(300, 32);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(100, 28);
            this.btnUnlock.TabIndex = 1;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(20, 33);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(272, 25);
            this.txtPassword.TabIndex = 0;
            // 
            // ViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(704, 541);
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.grpVault);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secure File Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewerForm_FormClosing);
            this.grpVault.ResumeLayout(false);
            this.grpVault.PerformLayout();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpVault;
        private System.Windows.Forms.Button btnOpenVault;
        private System.Windows.Forms.Label lblVaultPath;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.TextBox txtPassword;
    }
}