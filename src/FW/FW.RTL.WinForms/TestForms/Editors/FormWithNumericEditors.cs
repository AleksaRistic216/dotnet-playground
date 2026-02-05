using Bogus;

namespace FW.RTL.WinForms.TestForms.Editors {
    [TestForm("Editors", "Numeric Editors")]
    public partial class FormWithNumericEditors : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithNumericEditors() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            spinEdit1.Value = faker.Random.Decimal(0, 1000);
            calcEdit1.Value = faker.Random.Decimal(0, 10000);
            trackBarControl1.Value = faker.Random.Int(0, 100);
            zoomTrackBarControl1.Value = faker.Random.Int(50, 200);
        }
    }
}
