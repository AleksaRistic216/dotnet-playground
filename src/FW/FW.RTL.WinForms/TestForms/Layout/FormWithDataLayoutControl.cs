namespace FW.RTL.WinForms.TestForms.Layout {
    [TestForm("Layout", "Data Layout Control")]
    public partial class FormWithDataLayoutControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithDataLayoutControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var data = SampleDataGenerator.GeneratePersons(1);
            dataLayoutControl1.DataSource = data[0];
        }
    }
}
