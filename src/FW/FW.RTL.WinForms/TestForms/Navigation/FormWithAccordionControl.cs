using Bogus;

namespace FW.RTL.WinForms.TestForms.Navigation {
    [TestForm("Navigation", "Accordion Control")]
    public partial class FormWithAccordionControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithAccordionControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            string[] categories = { "Dashboard", "Reports", "Settings", "Users", "Help" };

            foreach (var category in categories) {
                var group = new DevExpress.XtraBars.Navigation.AccordionControlElement {
                    Text = category,
                    Style = DevExpress.XtraBars.Navigation.ElementStyle.Group
                };

                for (int i = 0; i < faker.Random.Int(2, 5); i++) {
                    var item = new DevExpress.XtraBars.Navigation.AccordionControlElement {
                        Text = faker.Lorem.Word(),
                        Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
                    };
                    group.Elements.Add(item);
                }

                accordionControl1.Elements.Add(group);
            }
        }
    }
}
