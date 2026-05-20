
namespace SecureFileViewer
{
    partial class UploaderForm
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
            this.btnCreateVault = new System.Windows.Forms.Button();
            this.btnOpenVault = new System.Windows.Forms.Button();
            this.lblVaultPath = new System.Windows.Forms.Label();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
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
            this.grpVault.Controls.Add(this.btnCreateVault);
            this.grpVault.Controls.Add(this.btnOpenVault);
            this.grpVault.Controls.Add(this.lblVaultPath);
            this.grpVault.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpVault.Location = new System.Drawing.Point(24, 20);
            this.grpVault.Name = "grpVault";
            this.grpVault.Size = new System.Drawing.Size(656, 110);
            this.grpVault.TabIndex = 0;
            this.grpVault.TabStop = false;
            this.grpVault.Text = "VAULT STORAGE LOCATION";
            // 
            // btnCreateVault
            // 
            this.btnCreateVault.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCreateVault.Location = new System.Drawing.Point(20, 32);
            this.btnCreateVault.Name = "btnCreateVault";
            this.btnCreateVault.Size = new System.Drawing.Size(140, 32);
            this.btnCreateVault.TabIndex = 0;
            this.btnCreateVault.Text = "Create New Vault";
            this.btnCreateVault.UseVisualStyleBackColor = true;
            this.btnCreateVault.Click += new System.EventHandler(this.btnCreateVault_Click);
            // 
            // btnOpenVault
            // 
            this.btnOpenVault.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOpenVault.Location = new System.Drawing.Point(168, 32);
            this.btnOpenVault.Name = "btnOpenVault";
            this.btnOpenVault.Size = new System.Drawing.Size(140, 32);
            this.btnOpenVault.TabIndex = 1;
            this.btnOpenVault.Text = "Open Existing Vault";
            this.btnOpenVault.UseVisualStyleBackColor = true;
            this.btnOpenVault.Click += new System.EventHandler(this.btnOpenVault_Click);
            // 
            // lblVaultPath
            // 
            this.lblVaultPath.AutoSize = true;
            this.lblVaultPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblVaultPath.ForeColor = System.Drawing.Color.DimGray;
            this.lblVaultPath.Location = new System.Drawing.Point(20, 76);
            this.lblVaultPath.Name = "lblVaultPath";
            this.lblVaultPath.Size = new System.Drawing.Size(100, 15);
            this.lblVaultPath.TabIndex = 2;
            this.lblVaultPath.Text = "No vault selected";
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.btnUpload);
            this.grpLogin.Controls.Add(this.btnDelete);
            this.grpLogin.Controls.Add(this.btnLogout);
            this.grpLogin.Controls.Add(this.lstFiles);
            this.grpLogin.Controls.Add(this.lblStatus);
            this.grpLogin.Controls.Add(this.btnUnlock);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpLogin.Location = new System.Drawing.Point(24, 150);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(656, 320);
            this.grpLogin.TabIndex = 1;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "SECURE VAULT ACCESS";
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpload.Location = new System.Drawing.Point(20, 268);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(130, 34);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload File...";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.Location = new System.Drawing.Point(372, 268);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 34);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogout.Location = new System.Drawing.Point(490, 268);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(146, 34);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Lock && Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 17;
            this.lstFiles.Location = new System.Drawing.Point(20, 80);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(616, 157);
            this.lstFiles.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // UploaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(704, 501);
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.grpVault);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UploaderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secure File Viewer & Uploader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UploaderForm_FormClosing);
            this.grpVault.ResumeLayout(false);
            this.grpVault.PerformLayout();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.GroupBox grpVault;
        private System.Windows.Forms.Button btnCreateVault;
        private System.Windows.Forms.Button btnOpenVault;
        private System.Windows.Forms.Label lblVaultPath;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Label lblStatus;
    }
}