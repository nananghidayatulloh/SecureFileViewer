namespace SecureFileViewer
{
    partial class PreviewForm
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
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.webPreview = new System.Windows.Forms.WebBrowser();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panelZoom = new System.Windows.Forms.Panel();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.lblZoomPercent = new System.Windows.Forms.Label();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomFit = new System.Windows.Forms.Button();
            this.panelImageContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.panelZoom.SuspendLayout();
            this.panelImageContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelImageContainer
            // 
            this.panelImageContainer.AutoScroll = true;
            this.panelImageContainer.Controls.Add(this.picPreview);
            this.panelImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImageContainer.Location = new System.Drawing.Point(0, 40);
            this.panelImageContainer.Name = "panelImageContainer";
            this.panelImageContainer.Size = new System.Drawing.Size(800, 410);
            this.panelImageContainer.TabIndex = 0;
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(100, 100);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Visible = false;
            // 
            // webPreview
            // 
            this.webPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webPreview.Location = new System.Drawing.Point(0, 40);
            this.webPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.webPreview.Name = "webPreview";
            this.webPreview.Size = new System.Drawing.Size(800, 410);
            this.webPreview.TabIndex = 1;
            this.webPreview.Visible = false;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(45, 45, 55);
            this.panelTop.Controls.Add(this.lblFileName);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.panelZoom);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 40);
            this.panelTop.TabIndex = 2;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFileName.ForeColor = System.Drawing.Color.White;
            this.lblFileName.Location = new System.Drawing.Point(12, 10);
            this.lblFileName.MaximumSize = new System.Drawing.Size(350, 0);  // Batasi lebar maksimum
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(77, 19);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "File Name";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(715, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelZoom
            // 
            this.panelZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelZoom.Controls.Add(this.btnZoomOut);
            this.panelZoom.Controls.Add(this.lblZoomPercent);
            this.panelZoom.Controls.Add(this.btnZoomIn);
            this.panelZoom.Controls.Add(this.btnZoomFit);
            this.panelZoom.Location = new System.Drawing.Point(430, 3);  // Digeser lebih kiri
            this.panelZoom.Name = "panelZoom";
            this.panelZoom.Size = new System.Drawing.Size(280, 34);
            this.panelZoom.TabIndex = 2;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnZoomOut.FlatAppearance.BorderSize = 0;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnZoomOut.ForeColor = System.Drawing.Color.White;
            this.btnZoomOut.Location = new System.Drawing.Point(70, 3);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(45, 28);
            this.btnZoomOut.TabIndex = 3;
            this.btnZoomOut.Text = "─";
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // lblZoomPercent
            // 
            this.lblZoomPercent.AutoSize = true;
            this.lblZoomPercent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblZoomPercent.ForeColor = System.Drawing.Color.White;
            this.lblZoomPercent.Location = new System.Drawing.Point(121, 8);
            this.lblZoomPercent.Name = "lblZoomPercent";
            this.lblZoomPercent.Size = new System.Drawing.Size(38, 15);
            this.lblZoomPercent.TabIndex = 2;
            this.lblZoomPercent.Text = "100%";
            this.lblZoomPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnZoomIn.FlatAppearance.BorderSize = 0;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnZoomIn.ForeColor = System.Drawing.Color.White;
            this.btnZoomIn.Location = new System.Drawing.Point(19, 3);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(45, 28);
            this.btnZoomIn.TabIndex = 1;
            this.btnZoomIn.Text = "＋";
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomFit
            // 
            this.btnZoomFit.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnZoomFit.FlatAppearance.BorderSize = 0;
            this.btnZoomFit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomFit.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnZoomFit.ForeColor = System.Drawing.Color.White;
            this.btnZoomFit.Location = new System.Drawing.Point(170, 3);
            this.btnZoomFit.Name = "btnZoomFit";
            this.btnZoomFit.Size = new System.Drawing.Size(55, 28);
            this.btnZoomFit.TabIndex = 0;
            this.btnZoomFit.Text = "FIT";
            this.btnZoomFit.UseVisualStyleBackColor = false;
            this.btnZoomFit.Click += new System.EventHandler(this.btnZoomFit_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(60, 60, 70);
            this.panelStatus.Controls.Add(this.lblInfo);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 450);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(800, 30);
            this.panelStatus.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.lblInfo.Location = new System.Drawing.Point(12, 6);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(363, 15);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "🔍 Use + / - buttons or scroll wheel to zoom | ESC to close";
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 35);
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.webPreview);
            this.Controls.Add(this.panelImageContainer);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelStatus);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "PreviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secure File Preview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreviewForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PreviewForm_KeyDown);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PreviewForm_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.panelZoom.ResumeLayout(false);
            this.panelZoom.PerformLayout();
            this.panelImageContainer.ResumeLayout(false);
            this.panelImageContainer.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.WebBrowser webPreview;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel panelZoom;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Label lblZoomPercent;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomFit;
        private System.Windows.Forms.Panel panelImageContainer;
    }
}