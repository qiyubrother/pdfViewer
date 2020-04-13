using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdfViewer
{
    public partial class FrmMenu : Form
    {
        FrmMain frmDoc = new FrmMain();
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            using (var form = new OpenFileDialog())
            {
                form.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
                form.RestoreDirectory = true;
                form.Title = "Open PDF File";

                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                frmDoc.Dispose();
                frmDoc = new FrmMain();
                frmDoc.FileName = form.FileName;
                frmDoc.ShowDialog();
            }
        }
    }
}
