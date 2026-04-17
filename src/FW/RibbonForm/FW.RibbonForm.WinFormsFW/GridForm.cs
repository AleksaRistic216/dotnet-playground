using System.Collections.Generic;
using Bogus;
using DevExpress.XtraEditors;

namespace FW.RibbonForm.WinFormsFW {
    public partial class GridForm : XtraForm {
        public GridForm() {
            InitializeComponent();
            gridControl1.DataSource = GenerateEmployees(50);
        }

        private static List<Employee> GenerateEmployees(int count) {
            var faker = new Faker<Employee>()
                .RuleFor(e => e.Id, f => f.IndexFaker + 1)
                .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                .RuleFor(e => e.LastName, f => f.Name.LastName())
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
                .RuleFor(e => e.Department, f => f.Commerce.Department())
                .RuleFor(e => e.Salary, f => f.Finance.Amount(30000, 120000))
                .RuleFor(e => e.IsActive, f => f.Random.Bool());

            return faker.Generate(count);
        }
    }
}
