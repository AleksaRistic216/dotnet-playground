using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace Random12513.Views {
    public partial class RichEditorView : XtraUserControl {
        public RichEditorView() {
            InitializeComponent();
            richEditControl1.LoadDocument(@"Resources/SampleWordDoc.docx");
        }
    }
}
