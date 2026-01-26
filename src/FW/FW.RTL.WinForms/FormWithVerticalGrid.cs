namespace FW.RTL.WinForms {
    public partial class FormWithVerticalGrid : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithVerticalGrid() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            VerticalGridHelpers.FillSampleData(vGridControl1);
        }
    }
}
