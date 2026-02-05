using Bogus;

namespace FW.RTL.WinForms.TestForms.Navigation {
    [TestForm("Navigation", "Tab Control")]
    public partial class FormWithTabControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithTabControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            for (int i = 0; i < 5; i++) {
                var page = new DevExpress.XtraTab.XtraTabPage {
                    Text = faker.Commerce.Department()
                };
                var label = new DevExpress.XtraEditors.LabelControl {
                    Text = faker.Lorem.Paragraph(),
                    Dock = System.Windows.Forms.DockStyle.Fill,
                    AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
                };
                page.Controls.Add(label);
                xtraTabControl1.TabPages.Add(page);
            }
        }
    }
}
