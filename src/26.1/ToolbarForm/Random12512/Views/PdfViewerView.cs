using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace Random12512.Views {
    public partial class PdfViewerView : XtraUserControl {
        public PdfViewerView() {
            InitializeComponent();
            pdfViewer1.LoadDocument(@"Resources/SamplePdfDoc.pdf");
        }
    }
}
