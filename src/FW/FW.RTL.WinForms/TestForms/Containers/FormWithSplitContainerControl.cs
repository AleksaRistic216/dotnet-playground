using Bogus;

namespace FW.RTL.WinForms.TestForms.Containers {
    [TestForm("Containers", "Split Container Control")]
    public partial class FormWithSplitContainerControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithSplitContainerControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            labelControl1.Text = faker.Lorem.Paragraphs(2);
            labelControl2.Text = faker.Lorem.Paragraphs(2);
        }
    }
}
