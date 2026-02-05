namespace FW.RTL.WinForms.TestForms.Grids {
    [TestForm("Grids", "Tile View")]
    public partial class FormWithTileView : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithTileView() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var data = SampleDataGenerator.GenerateProducts(40);
            gridControl1.DataSource = data;
        }
    }
}
