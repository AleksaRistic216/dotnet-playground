using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Bogus;
using System.Collections.Generic;

namespace FW.RTL.WinForms.TestForms.Editors {
    [TestForm("Editors", "Button Editors")]
    public partial class FormWithButtonEditors : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithButtonEditors() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var faker = new Faker();

            // ButtonEdit
            buttonEdit1.Text = faker.Commerce.Product();

            // ComboBoxEdit
            var categories = new List<string> { "Electronics", "Clothing", "Home & Garden", "Sports", "Books", "Toys" };
            comboBoxEdit1.Properties.Items.AddRange(categories);
            comboBoxEdit1.SelectedIndex = faker.Random.Int(0, categories.Count - 1);

            // LookUpEdit
            var products = SampleDataGenerator.GenerateProducts(20);
            lookUpEdit1.Properties.DataSource = products;
            lookUpEdit1.Properties.DisplayMember = "ProductName";
            lookUpEdit1.Properties.ValueMember = "ProductId";
            lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("ProductName", "Product"));
            lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("Category", "Category"));
            lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("Price", "Price"));
            lookUpEdit1.EditValue = products[faker.Random.Int(0, products.Count - 1)].ProductId;

            // SearchLookUpEdit
            var persons = SampleDataGenerator.GeneratePersons(30);
            searchLookUpEdit1.Properties.DataSource = persons;
            searchLookUpEdit1.Properties.DisplayMember = "FullName";
            searchLookUpEdit1.Properties.ValueMember = "Id";
            searchLookUpEdit1.Properties.View.Columns.AddVisible("FirstName");
            searchLookUpEdit1.Properties.View.Columns.AddVisible("LastName");
            searchLookUpEdit1.Properties.View.Columns.AddVisible("Email");
            searchLookUpEdit1.Properties.View.Columns.AddVisible("Company");
            searchLookUpEdit1.EditValue = persons[faker.Random.Int(0, persons.Count - 1)].Id;

            // PopupContainerEdit
            popupContainerEdit1.Text = faker.Lorem.Sentence();
        }
    }
}
