using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace Random12513.Views {
    public partial class SpreadsheetView : XtraUserControl {
        public SpreadsheetView() {
            InitializeComponent();
            spreadsheetControl1.LoadDocument(@"Resources/SampleExcelDoc.xlsx");
        }
    }
}
