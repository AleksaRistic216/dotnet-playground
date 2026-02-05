namespace FW.RTL.WinForms.TestForms.Editors {
    [TestForm("Editors", "List Editors")]
    public partial class FormWithListEditors : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithListEditors() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var strings = SampleDataGenerator.GenerateStrings(15);
            listBoxControl1.Items.AddRange(strings.ToArray());
            imageListBoxControl1.Items.AddRange(strings.ToArray());
        }
    }
}
