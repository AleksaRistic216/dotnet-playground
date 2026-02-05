using Bogus;
using System;

namespace FW.RTL.WinForms.TestForms.Editors {
    [TestForm("Editors", "Date Editors")]
    public partial class FormWithDateEditors : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithDateEditors() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();
            dateEdit1.DateTime = faker.Date.Past(5);
            dateEdit2.DateTime = faker.Date.Future(2);
            timeEdit1.Time = DateTime.Today.AddHours(faker.Random.Int(8, 17)).AddMinutes(faker.Random.Int(0, 59));
            timeSpanEdit1.TimeSpan = TimeSpan.FromHours(faker.Random.Int(1, 48));
            dateEditCalendar1.DateTime = DateTime.Today;
        }
    }
}
