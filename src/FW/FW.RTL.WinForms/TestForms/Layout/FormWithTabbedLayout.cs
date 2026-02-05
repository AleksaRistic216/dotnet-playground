using Bogus;

namespace FW.RTL.WinForms.TestForms.Layout {
    [TestForm("Layout", "Tabbed Layout")]
    public partial class FormWithTabbedLayout : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithTabbedLayout() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            textEdit1.Text = faker.Name.FullName();
            textEdit2.Text = faker.Internet.Email();
            textEdit3.Text = faker.Company.CompanyName();
            textEdit4.Text = faker.Address.FullAddress();
        }
    }
}
