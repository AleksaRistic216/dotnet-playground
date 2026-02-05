using DevExpress.XtraEditors;
using Bogus;

namespace FW.RTL.WinForms.TestForms.Editors {
    [TestForm("Editors", "Text Editors")]
    public partial class FormWithTextEditors : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithTextEditors() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            textEdit1.Text = faker.Name.FullName();
            textEdit2.Text = faker.Internet.Email();
            memoEdit1.Text = faker.Lorem.Paragraphs(3);
            hyperLinkEdit1.Text = faker.Internet.Url();
            tokenEdit1.Text = string.Join(";", faker.Lorem.Words(5));
        }
    }
}
