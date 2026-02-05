using Bogus;

namespace FW.RTL.WinForms.TestForms.Containers {
    [TestForm("Containers", "Panel Control")]
    public partial class FormWithPanelControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithPanelControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            labelControl1.Text = faker.Lorem.Paragraph();
        }
    }
}
