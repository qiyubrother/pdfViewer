using PdfiumViewer;
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            pdfViewer1.ShowBookmarks = false;
            pdfViewer1.ShowToolbar = false;
            pdfViewer1.ZoomMode = PdfViewerZoomMode.FitWidth;
            pdfViewer1.Document?.Dispose();
            pdfViewer1.Document = OpenDocument(FileName);
            Text = FileName;
        }

        public string FileName { get; set; }

        private PdfDocument OpenDocument(string fileName)
        {
            try
            {
                return PdfDocument.Load(this, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
