using DevExpress.XtraEditors;
using Random12513.Infrastructure;
using Random12513.Model;
using System;
using System.Linq;

namespace Random12513.Views {
    public partial class EditFormView : XtraUserControl {
        public EditFormView() {
            InitializeComponent();
        }
        public EditFormView(ICommonDataService dataService) : this() {
            countries = dataService.GetCountries();
            countryComboBox.Properties.Items.AddRange(countries.ToList());
            imageComboBoxEdit1.Properties.Items.AddEnum<PersonPrefix>();
        }
        IEnumerable<string> countries;

        async void simpleButton1_Click(object sender, EventArgs e) {
            await Task.Delay(700);
            XtraMessageBox.Show("Asynchronous save action");
        }
    }
}
