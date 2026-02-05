using Bogus;

namespace FW.RTL.WinForms.TestForms.Editors {
    [TestForm("Editors", "Check Editors")]
    public partial class FormWithCheckEditors : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithCheckEditors() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            checkEdit1.Checked = faker.Random.Bool();
            checkEdit2.Checked = faker.Random.Bool();
            checkEdit3.Checked = faker.Random.Bool();
            toggleSwitch1.IsOn = faker.Random.Bool();
            radioGroup1.SelectedIndex = faker.Random.Int(0, 3);

            checkedListBoxControl1.Items.Add("Option A", faker.Random.Bool());
            checkedListBoxControl1.Items.Add("Option B", faker.Random.Bool());
            checkedListBoxControl1.Items.Add("Option C", faker.Random.Bool());
            checkedListBoxControl1.Items.Add("Option D", faker.Random.Bool());
            checkedListBoxControl1.Items.Add("Option E", faker.Random.Bool());
        }
    }
}
