namespace SecureFileViewer
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btnViewer = new System.Windows.Forms.Button();
            this.btnUploader = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(55)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(650, 120);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(650, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔐 SECURE FILE VAULT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lblSubTitle.Location = new System.Drawing.Point(0, 85);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(650, 20);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Select your operation mode to proceed";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelButtons.Controls.Add(this.btnViewer);
            this.panelButtons.Controls.Add(this.btnUploader);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 120);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(650, 250);
            this.panelButtons.TabIndex = 1;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelFooter.Controls.Add(this.lblFooter);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 370);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(650, 35);
            this.panelFooter.TabIndex = 2;
            // 
            // lblFooter
            // 
            this.lblFooter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFooter.ForeColor = System.Drawing.Color.Gray;
            this.lblFooter.Location = new System.Drawing.Point(0, 10);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(650, 15);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "Your files are never shared without your password";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewer
            // 
            this.btnViewer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnViewer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewer.FlatAppearance.BorderSize = 0;
            this.btnViewer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewer.ForeColor = System.Drawing.Color.White;
            this.btnViewer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnViewer.Location = new System.Drawing.Point(328, 40);
            this.btnViewer.Name = "btnViewer";
            this.btnViewer.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.btnViewer.Size = new System.Drawing.Size(197, 180);
            this.btnViewer.TabIndex = 1;
            this.btnViewer.Text = "VIEWER\r";
            this.btnViewer.UseVisualStyleBackColor = false;
            this.btnViewer.Click += new System.EventHandler(this.btnViewer_Click);
            // 
            // btnUploader
            // 
            this.btnUploader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUploader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnUploader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUploader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploader.FlatAppearance.BorderSize = 0;
            this.btnUploader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploader.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnUploader.ForeColor = System.Drawing.Color.White;
            this.btnUploader.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUploader.Location = new System.Drawing.Point(109, 40);
            this.btnUploader.Name = "btnUploader";
            this.btnUploader.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.btnUploader.Size = new System.Drawing.Size(200, 180);
            this.btnUploader.TabIndex = 0;
            this.btnUploader.Text = "UPLOAD";
            this.btnUploader.UseVisualStyleBackColor = false;
            this.btnUploader.Click += new System.EventHandler(this.btnUploader_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 405);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secure File Vault";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.panelHeader.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnUploader;
        private System.Windows.Forms.Button btnViewer;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}