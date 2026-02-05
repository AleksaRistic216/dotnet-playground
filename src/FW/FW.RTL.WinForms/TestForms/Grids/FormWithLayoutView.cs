namespace FW.RTL.WinForms.TestForms.Grids {
    [TestForm("Grids", "Layout View")]
    public partial class FormWithLayoutView : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithLayoutView() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var data = SampleDataGenerator.GenerateProducts(30);
            gridControl1.DataSource = data;
        }
    }
}
