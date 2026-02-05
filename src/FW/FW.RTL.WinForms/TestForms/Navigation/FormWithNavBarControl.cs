using Bogus;

namespace FW.RTL.WinForms.TestForms.Navigation {
    [TestForm("Navigation", "NavBar Control")]
    public partial class FormWithNavBarControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithNavBarControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            string[] categories = { "Mail", "Calendar", "Contacts", "Tasks", "Notes" };

            foreach (var category in categories) {
                var group = new DevExpress.XtraNavBar.NavBarGroup {
                    Caption = category,
                    Expanded = true
                };

                for (int i = 0; i < faker.Random.Int(2, 4); i++) {
                    var item = new DevExpress.XtraNavBar.NavBarItem {
                        Caption = faker.Lorem.Word()
                    };
                    navBarControl1.Items.Add(item);
                    group.ItemLinks.Add(new DevExpress.XtraNavBar.NavBarItemLink(item));
                }

                navBarControl1.Groups.Add(group);
            }
        }
    }
}
