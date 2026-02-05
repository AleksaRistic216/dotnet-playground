namespace FW.RTL.WinForms.TestForms.Grids {
    [TestForm("Grids", "Grid View (AdvBanded)")]
    public partial class FormWithGridView : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithGridView() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            GridViewHelpers.FillSampleData(gridControl1);
        }
    }
}
