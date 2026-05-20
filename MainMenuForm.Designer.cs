
namespace SecureFileViewer
{
    partial class MainMenuForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUploader = new System.Windows.Forms.Button();
            this.btnViewer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Secure File Vault";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(600, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select your operation mode to proceed";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnUploader
            // 
            this.btnUploader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.btnUploader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploader.FlatAppearance.BorderSize = 0;
            this.btnUploader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploader.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnUploader.ForeColor = System.Drawing.Color.White;
            this.btnUploader.Location = new System.Drawing.Point(52, 160);
            this.btnUploader.Name = "btnUploader";
            this.btnUploader.Size = new System.Drawing.Size(248, 80);
            this.btnUploader.TabIndex = 2;
            this.btnUploader.Text = "Uploader Mode\r\n\r\nEncrypt & Store Files";
            this.btnUploader.UseVisualStyleBackColor = false;
            this.btnUploader.Click += new System.EventHandler(this.btnUploader_Click);
            // 
            // btnViewer
            // 
            this.btnViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnViewer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewer.FlatAppearance.BorderSize = 0;
            this.btnViewer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewer.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnViewer.ForeColor = System.Drawing.Color.White;
            this.btnViewer.Location = new System.Drawing.Point(324, 160);
            this.btnViewer.Name = "btnViewer";
            this.btnViewer.Size = new System.Drawing.Size(248, 80);
            this.btnViewer.TabIndex = 3;
            this.btnViewer.Text = "Viewer Mode\r\n\r\nPreview Encrypted Files";
            this.btnViewer.UseVisualStyleBackColor = false;
            this.btnViewer.Click += new System.EventHandler(this.btnViewer_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.btnViewer);
            this.Controls.Add(this.btnUploader);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secure File Vault - Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUploader;
        private System.Windows.Forms.Button btnViewer;
    }
}