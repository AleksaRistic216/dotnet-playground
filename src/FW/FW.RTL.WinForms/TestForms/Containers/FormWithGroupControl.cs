using Bogus;

namespace FW.RTL.WinForms.TestForms.Containers {
    [TestForm("Containers", "Group Control")]
    public partial class FormWithGroupControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithGroupControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            labelControl1.Text = faker.Lorem.Paragraph();
            labelControl2.Text = faker.Lorem.Paragraph();
        }
    }
}
