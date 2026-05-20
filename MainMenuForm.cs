using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecureFileViewer
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void btnUploader_Click(object sender, EventArgs e)
        {
            UploaderForm uploader = new UploaderForm();
            uploader.Show();
            this.Hide();
        }

        private void btnViewer_Click(object sender, EventArgs e)
        {
            
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
