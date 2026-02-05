using Bogus;

namespace FW.RTL.WinForms.TestForms.Containers {
    [TestForm("Containers", "Scrollable Control")]
    public partial class FormWithXtraScrollableControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithXtraScrollableControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            labelControl1.Text = faker.Lorem.Paragraphs(10);
        }
    }
}
