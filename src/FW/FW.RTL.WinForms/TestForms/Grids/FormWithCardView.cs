namespace FW.RTL.WinForms.TestForms.Grids {
    [TestForm("Grids", "Card View")]
    public partial class FormWithCardView : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithCardView() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var data = SampleDataGenerator.GeneratePersons(30);
            gridControl1.DataSource = data;
        }
    }
}
