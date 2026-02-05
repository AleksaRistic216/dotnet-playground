using Bogus;

namespace FW.RTL.WinForms.TestForms.Containers {
    [TestForm("Containers", "Collapsible Splitter")]
    public partial class FormWithCollapsibleSplitter : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithCollapsibleSplitter() {
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
