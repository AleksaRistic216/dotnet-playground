namespace FW.RTL.WinForms {
    public partial class FormWithGrid : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithGrid() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            GridHelpers.FillSampleData(gridControl1);
        }
    }
}
