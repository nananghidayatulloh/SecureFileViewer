using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SecureFileViewer
{
    public partial class PreviewForm : Form
    {
        private string _tempFilePath;
        private string _fileExtension;
        private string _fileName;
        private bool _isClosing = false;

        public PreviewForm(byte[] fileData, string fileName, string extension)
        {
            InitializeComponent();

            _fileName = fileName;
            _fileExtension = extension;

            this.Text = $"Preview - {fileName}";
            lblFileName.Text = fileName;

            this.UseWaitCursor = true;

            try
            {
                _tempFilePath = Path.Combine(Path.GetTempPath(), $"secure_preview_{Guid.NewGuid()}{extension}");
                File.WriteAllBytes(_tempFilePath, fileData);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading preview: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
            }

        }
    }
}
