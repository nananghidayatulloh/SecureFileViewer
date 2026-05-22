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
        private float _zoom = 1.0f;
        private const float ZOOM_STEP = 0.1f;
        private const float MIN_ZOOM = 0.1f;
        private const float MAX_ZOOM = 5.0f;
        private Image _originalImage;

        public PreviewForm(byte[] fileData, string fileName, string extension)
        {
            InitializeComponent();

            _fileName = fileName;
            _fileExtension = extension;

            this.Text = $"Preview - {fileName}";
            lblFileName.Text = fileName;

            // Sembunyikan container image dulu
            panelImageContainer.Visible = false;
            panelZoom.Visible = false;

            this.UseWaitCursor = true;

            try
            {
                _tempFilePath = Path.Combine(Path.GetTempPath(), $"secure_preview_{Guid.NewGuid()}{extension}");
                File.WriteAllBytes(_tempFilePath, fileData);

                // Validasi file berhasil ditulis
                if (!File.Exists(_tempFilePath))
                {
                    throw new Exception("Temporary file could not be created");
                }

                var fileInfo = new FileInfo(_tempFilePath);
                if (fileInfo.Length == 0)
                {
                    throw new Exception("Temporary file is empty");
                }

                DisplayPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading preview: {ex.Message}\n\nFile: {fileName}",
                    "Preview Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClosePreview();
            }
            finally
            {
                this.UseWaitCursor = false;
            }

            DisableSaveFeatures();
        }

        private void DisplayPreview()
        {
            if (_fileExtension == ".pdf")
            {
                // PDF menggunakan WebBrowser (tidak ada zoom)
                panelImageContainer.Visible = false;
                webPreview.Visible = true;
                panelZoom.Visible = false;
                webPreview.Navigate(_tempFilePath);
            }
            else if (_fileExtension == ".jpg" || _fileExtension == ".jpeg" || _fileExtension == ".png")
            {
                // Gambar menggunakan PictureBox dengan zoom support
                LoadImageSafely();
            }
            else
            {
                lblInfo.Text = "File format not supported for preview. Only JPG, PNG, PDF are supported.";
                lblInfo.ForeColor = Color.Orange;
            }
        }

        private void LoadImageSafely()
        {
            try
            {
                webPreview.Visible = false;
                panelImageContainer.Visible = true;
                panelZoom.Visible = true;

                // Load image dengan using untuk mencegah file lock
                using (var fs = new FileStream(_tempFilePath, FileMode.Open, FileAccess.Read))
                {
                    _originalImage = Image.FromStream(fs);
                }

                // Buat copy untuk ditampilkan
                picPreview.Image = (Image)_originalImage.Clone();
                picPreview.Visible = true;

                // Set initial zoom to fit
                btnZoomFit_Click(null, null);
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Image file is too large or corrupted.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClosePreview();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Invalid image format or corrupted file.\n\nDetails: {ex.Message}",
                    "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClosePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load image: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClosePreview();
            }
        }

        private void UpdateZoom()
        {
            if (picPreview.Image == null || _originalImage == null) return;

            try
            {
                // Hitung ukuran baru berdasarkan zoom
                int newWidth = (int)(_originalImage.Width * _zoom);
                int newHeight = (int)(_originalImage.Height * _zoom);

                // Validasi ukuran tidak negatif atau terlalu besar
                if (newWidth <= 0 || newHeight <= 0)
                {
                    _zoom = MIN_ZOOM;
                    newWidth = (int)(_originalImage.Width * _zoom);
                    newHeight = (int)(_originalImage.Height * _zoom);
                }

                // Batasi ukuran maksimum untuk mencegah out of memory
                if (newWidth > 5000 || newHeight > 5000)
                {
                    _zoom = MAX_ZOOM;
                    newWidth = (int)(_originalImage.Width * _zoom);
                    newHeight = (int)(_originalImage.Height * _zoom);
                }

                // Resize gambar
                using (var newImage = new Bitmap(newWidth, newHeight))
                {
                    using (Graphics g = Graphics.FromImage(newImage))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.DrawImage(_originalImage, 0, 0, newWidth, newHeight);
                    }

                    // Ganti gambar dengan aman
                    var oldImage = picPreview.Image;
                    picPreview.Image = (Image)newImage.Clone();
                    oldImage?.Dispose();
                }

                // Update label persentase
                lblZoomPercent.Text = $"{(_zoom * 100):F0}%";

                // Update size gambar agar scrollbar muncul
                picPreview.Size = new Size(newWidth, newHeight);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateZoom error: {ex.Message}");
                lblInfo.Text = "Zoom error, please try FIT button";
                lblInfo.ForeColor = Color.Orange;
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (_fileExtension == ".pdf" || _originalImage == null) return;

            _zoom += ZOOM_STEP;
            if (_zoom > MAX_ZOOM) _zoom = MAX_ZOOM;
            UpdateZoom();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (_fileExtension == ".pdf" || _originalImage == null) return;

            _zoom -= ZOOM_STEP;
            if (_zoom < MIN_ZOOM) _zoom = MIN_ZOOM;
            UpdateZoom();
        }

        private void btnZoomFit_Click(object sender, EventArgs e)
        {
            if (_fileExtension == ".pdf" || _originalImage == null) return;

            try
            {
                // Hitung zoom agar gambar pas dengan container
                float containerWidth = panelImageContainer.ClientSize.Width;
                float containerHeight = panelImageContainer.ClientSize.Height;

                if (containerWidth <= 0 || containerHeight <= 0) return;

                float zoomWidth = containerWidth / _originalImage.Width;
                float zoomHeight = containerHeight / _originalImage.Height;

                _zoom = Math.Min(zoomWidth, zoomHeight);
                if (_zoom > MAX_ZOOM) _zoom = MAX_ZOOM;
                if (_zoom < MIN_ZOOM) _zoom = MIN_ZOOM;

                UpdateZoom();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ZoomFit error: {ex.Message}");
            }
        }

        private void PreviewForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_fileExtension == ".pdf" || _originalImage == null) return;

            // Zoom dengan scroll wheel
            if (e.Delta > 0)
            {
                btnZoomIn_Click(null, null);
            }
            else if (e.Delta < 0)
            {
                btnZoomOut_Click(null, null);
            }
        }

        private void DisableSaveFeatures()
        {
            webPreview.IsWebBrowserContextMenuEnabled = false;
            webPreview.WebBrowserShortcutsEnabled = false;
            this.KeyPreview = true;
        }

        private void ClosePreview()
        {
            if (_isClosing) return;
            _isClosing = true;

            try
            {
                // Bersihkan gambar dengan aman
                if (picPreview.Image != null)
                {
                    picPreview.Image.Dispose();
                    picPreview.Image = null;
                }

                if (_originalImage != null)
                {
                    _originalImage.Dispose();
                    _originalImage = null;
                }

                // Bersihkan WebBrowser
                if (webPreview.Visible && webPreview.Url != null)
                {
                    webPreview.Navigate("about:blank");
                }

                // Hapus file temporary
                if (!string.IsNullOrEmpty(_tempFilePath) && File.Exists(_tempFilePath))
                {
                    try { File.Delete(_tempFilePath); } catch { }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ClosePreview error: {ex.Message}");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PreviewForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ClosePreview();
                return;
            }

            if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true;
                ShowTempMessage("Save/Download is disabled!");
                return;
            }

            if (e.Control && e.KeyCode == Keys.P)
            {
                e.SuppressKeyPress = true;
                ShowTempMessage("Printing is disabled!");
                return;
            }

            // Shortcut untuk zoom
            if (e.Control && e.KeyCode == Keys.Add)
            {
                btnZoomIn_Click(null, null);
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.Subtract)
            {
                btnZoomOut_Click(null, null);
                e.SuppressKeyPress = true;
            }

            if (e.Control && e.KeyCode == Keys.D0)
            {
                btnZoomFit_Click(null, null);
                e.SuppressKeyPress = true;
            }
        }

        private void ShowTempMessage(string message)
        {
            lblInfo.Text = message;
            lblInfo.ForeColor = Color.Orange;

            Timer timer = new Timer { Interval = 2000 };
            timer.Tick += (s, args) =>
            {
                lblInfo.Text = "🔍 Use + / - buttons or scroll wheel to zoom | ESC to close";
                lblInfo.ForeColor = Color.FromArgb(200, 200, 200);
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void PreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosePreview();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Jika gambar dan mode fit, sesuaikan ulang
            if (_fileExtension != ".pdf" && _originalImage != null && _zoom > 0)
            {
                btnZoomFit_Click(null, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ClosePreview();
        }
    }
}