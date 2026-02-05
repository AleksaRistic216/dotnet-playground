using Bogus;

namespace FW.RTL.WinForms.TestForms.Layout {
    [TestForm("Layout", "Layout Control")]
    public partial class FormWithLayoutControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithLayoutControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            textEdit1.Text = faker.Name.FirstName();
            textEdit2.Text = faker.Name.LastName();
            textEdit3.Text = faker.Internet.Email();
            textEdit4.Text = faker.Phone.PhoneNumber();
            memoEdit1.Text = faker.Lorem.Paragraph();
        }
    }
}
