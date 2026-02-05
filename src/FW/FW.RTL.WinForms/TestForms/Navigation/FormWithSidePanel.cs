using Bogus;

namespace FW.RTL.WinForms.TestForms.Navigation {
    [TestForm("Navigation", "Side Panel")]
    public partial class FormWithSidePanel : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithSidePanel() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            labelControl1.Text = faker.Lorem.Paragraphs(2);
        }
    }
}
