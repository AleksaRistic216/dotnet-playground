using Bogus;

namespace FW.RTL.WinForms.TestForms.Layout {
    [TestForm("Layout", "Split Layout")]
    public partial class FormWithSplitLayout : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithSplitLayout() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            memoEdit1.Text = faker.Lorem.Paragraphs(3);
            memoEdit2.Text = faker.Lorem.Paragraphs(2);
        }
    }
}
