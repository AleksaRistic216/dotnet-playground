using Bogus;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;

namespace FW.RTL.WinForms {
    internal static class GridHelpers {
        private static readonly Random _random = new Random();

        internal static void FillSampleData(GridControl gridControl) {
            // Generate sample data using Bogus
            var data = GenerateSampleData(50);

            // Create and configure AdvBandedGridView with randomized layout
            var view = CreateRandomizedBandedView(gridControl);

            // Bind data
            gridControl.DataSource = data;
            gridControl.MainView = view;

            view.BestFitColumns();
        }

        private static List<SamplePerson> GenerateSampleData(int count) {
            var faker = new Faker<SamplePerson>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Company, f => f.Company.CompanyName())
                .RuleFor(p => p.JobTitle, f => f.Name.JobTitle())
                .RuleFor(p => p.Department, f => f.Commerce.Department())
                .RuleFor(p => p.Street, f => f.Address.StreetAddress())
                .RuleFor(p => p.City, f => f.Address.City())
                .RuleFor(p => p.State, f => f.Address.State())
                .RuleFor(p => p.ZipCode, f => f.Address.ZipCode())
                .RuleFor(p => p.Country, f => f.Address.Country())
                .RuleFor(p => p.BirthDate, f => f.Date.Past(50, DateTime.Now.AddYears(-18)))
                .RuleFor(p => p.HireDate, f => f.Date.Past(10))
                .RuleFor(p => p.Salary, f => f.Finance.Amount(30000, 150000))
                .RuleFor(p => p.IsActive, f => f.Random.Bool(0.85f))
                .RuleFor(p => p.Rating, f => f.Random.Int(1, 5))
                .RuleFor(p => p.Notes, f => f.Lorem.Sentence());

            return faker.Generate(count);
        }

        private static AdvBandedGridView CreateRandomizedBandedView(GridControl gridControl) {
            var view = new AdvBandedGridView(gridControl);
            view.OptionsBehavior.AutoPopulateColumns = false;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ColumnAutoWidth = false;

            // Choose a random layout configuration
            int layoutType = _random.Next(4);

            switch (layoutType) {
                case 0:
                    CreateLayout_PersonalInfo_WorkInfo_Address(view);
                    break;
                case 1:
                    CreateLayout_Compact_TwoRowsPerBand(view);
                    break;
                case 2:
                    CreateLayout_ThreeRowMixed(view);
                    break;
                case 3:
                    CreateLayout_NestedBands(view);
                    break;
            }

            return view;
        }

        // Layout 1: Classic bands with varying row counts
        private static void CreateLayout_PersonalInfo_WorkInfo_Address(AdvBandedGridView view) {
            // Personal Info Band
            var bandPersonal = new GridBand { Caption = "Personal Information", Name = "bandPersonal" };
            view.Bands.Add(bandPersonal);

            var colId = CreateColumn(view, "Id", "ID", bandPersonal, 0, 2); // Spans 2 rows
            var colFirstName = CreateColumn(view, "FirstName", "First Name", bandPersonal, 0, 1);
            var colLastName = CreateColumn(view, "LastName", "Last Name", bandPersonal, 1, 1);
            var colEmail = CreateColumn(view, "Email", "Email", bandPersonal, 0, 1);
            var colPhone = CreateColumn(view, "Phone", "Phone", bandPersonal, 1, 1);
            var colBirthDate = CreateColumn(view, "BirthDate", "Birth Date", bandPersonal, 0, 2);

            colId.Width = 50;
            colFirstName.Width = 100;
            colLastName.Width = 100;
            colEmail.Width = 180;
            colPhone.Width = 120;
            colBirthDate.Width = 90;

            // Work Info Band
            var bandWork = new GridBand { Caption = "Employment", Name = "bandWork" };
            view.Bands.Add(bandWork);

            var colCompany = CreateColumn(view, "Company", "Company", bandWork, 0, 1);
            var colJobTitle = CreateColumn(view, "JobTitle", "Job Title", bandWork, 0, 1);
            var colDepartment = CreateColumn(view, "Department", "Department", bandWork, 1, 1);
            var colHireDate = CreateColumn(view, "HireDate", "Hire Date", bandWork, 1, 1);
            var colSalary = CreateColumn(view, "Salary", "Salary", bandWork, 0, 2);
            var colIsActive = CreateColumn(view, "IsActive", "Active", bandWork, 0, 2);

            colCompany.Width = 150;
            colJobTitle.Width = 150;
            colDepartment.Width = 100;
            colHireDate.Width = 90;
            colSalary.Width = 100;
            colIsActive.Width = 50;

            // Address Band
            var bandAddress = new GridBand { Caption = "Address", Name = "bandAddress" };
            view.Bands.Add(bandAddress);

            var colStreet = CreateColumn(view, "Street", "Street", bandAddress, 0, 1);
            var colCity = CreateColumn(view, "City", "City", bandAddress, 1, 1);
            var colState = CreateColumn(view, "State", "State", bandAddress, 0, 1);
            var colZipCode = CreateColumn(view, "ZipCode", "Zip", bandAddress, 1, 1);
            var colCountry = CreateColumn(view, "Country", "Country", bandAddress, 0, 2);

            colStreet.Width = 180;
            colCity.Width = 120;
            colState.Width = 80;
            colZipCode.Width = 70;
            colCountry.Width = 100;
        }

        // Layout 2: Compact with two rows per band
        private static void CreateLayout_Compact_TwoRowsPerBand(AdvBandedGridView view) {
            // Identity Band
            var bandIdentity = new GridBand { Caption = "Identity", Name = "bandIdentity" };
            view.Bands.Add(bandIdentity);

            CreateColumn(view, "Id", "ID", bandIdentity, 0, 2).Width = 50;
            CreateColumn(view, "FirstName", "First", bandIdentity, 0, 1).Width = 80;
            CreateColumn(view, "LastName", "Last", bandIdentity, 1, 1).Width = 80;
            CreateColumn(view, "IsActive", "Active", bandIdentity, 0, 2).Width = 50;

            // Contact Band
            var bandContact = new GridBand { Caption = "Contact", Name = "bandContact" };
            view.Bands.Add(bandContact);

            CreateColumn(view, "Email", "Email", bandContact, 0, 1).Width = 180;
            CreateColumn(view, "Phone", "Phone", bandContact, 1, 1).Width = 120;

            // Location Band
            var bandLocation = new GridBand { Caption = "Location", Name = "bandLocation" };
            view.Bands.Add(bandLocation);

            CreateColumn(view, "City", "City", bandLocation, 0, 1).Width = 100;
            CreateColumn(view, "State", "State", bandLocation, 0, 1).Width = 60;
            CreateColumn(view, "Country", "Country", bandLocation, 1, 1).Width = 100;
            CreateColumn(view, "ZipCode", "Zip", bandLocation, 1, 1).Width = 60;

            // Career Band
            var bandCareer = new GridBand { Caption = "Career", Name = "bandCareer" };
            view.Bands.Add(bandCareer);

            CreateColumn(view, "Company", "Company", bandCareer, 0, 1).Width = 140;
            CreateColumn(view, "Department", "Dept", bandCareer, 0, 1).Width = 80;
            CreateColumn(view, "JobTitle", "Title", bandCareer, 1, 1).Width = 140;
            CreateColumn(view, "Salary", "Salary", bandCareer, 1, 1).Width = 80;

            // Dates Band
            var bandDates = new GridBand { Caption = "Dates", Name = "bandDates" };
            view.Bands.Add(bandDates);

            CreateColumn(view, "BirthDate", "Birth", bandDates, 0, 1).Width = 85;
            CreateColumn(view, "HireDate", "Hired", bandDates, 1, 1).Width = 85;
        }

        // Layout 3: Three rows with mixed spanning
        private static void CreateLayout_ThreeRowMixed(AdvBandedGridView view) {
            // Main Band
            var bandMain = new GridBand { Caption = "Employee Data", Name = "bandMain" };
            view.Bands.Add(bandMain);

            CreateColumn(view, "Id", "ID", bandMain, 0, 3).Width = 50;  // Full height
            CreateColumn(view, "FirstName", "First Name", bandMain, 0, 1).Width = 100;
            CreateColumn(view, "LastName", "Last Name", bandMain, 1, 1).Width = 100;
            CreateColumn(view, "Email", "Email", bandMain, 2, 1).Width = 100;
            CreateColumn(view, "Rating", "Rating", bandMain, 0, 3).Width = 50;  // Full height

            // Contact & Location Band
            var bandContactLoc = new GridBand { Caption = "Contact & Location", Name = "bandContactLoc" };
            view.Bands.Add(bandContactLoc);

            CreateColumn(view, "Phone", "Phone", bandContactLoc, 0, 1).Width = 120;
            CreateColumn(view, "Street", "Street", bandContactLoc, 1, 2).Width = 120;  // Spans 2 rows
            CreateColumn(view, "City", "City", bandContactLoc, 0, 1).Width = 100;
            CreateColumn(view, "State", "State", bandContactLoc, 0, 1).Width = 60;
            CreateColumn(view, "Country", "Country", bandContactLoc, 0, 1).Width = 80;

            // Employment Band
            var bandEmployment = new GridBand { Caption = "Employment Details", Name = "bandEmployment" };
            view.Bands.Add(bandEmployment);

            CreateColumn(view, "Company", "Company", bandEmployment, 0, 2).Width = 150;  // Spans 2 rows
            CreateColumn(view, "JobTitle", "Job Title", bandEmployment, 0, 1).Width = 140;
            CreateColumn(view, "Department", "Department", bandEmployment, 1, 1).Width = 100;
            CreateColumn(view, "Salary", "Salary", bandEmployment, 2, 1).Width = 100;
            CreateColumn(view, "IsActive", "Active", bandEmployment, 0, 3).Width = 50;  // Full height
            CreateColumn(view, "HireDate", "Hire Date", bandEmployment, 2, 1).Width = 85;
        }

        // Layout 4: Nested bands
        private static void CreateLayout_NestedBands(AdvBandedGridView view) {
            // Root band for personal
            var bandPerson = new GridBand { Caption = "Person", Name = "bandPerson" };
            view.Bands.Add(bandPerson);

            // Nested band: Basic
            var bandBasic = new GridBand { Caption = "Basic", Name = "bandBasic" };
            bandPerson.Children.Add(bandBasic);

            CreateColumn(view, "Id", "ID", bandBasic, 0, 2).Width = 50;
            CreateColumn(view, "FirstName", "First", bandBasic, 0, 1).Width = 90;
            CreateColumn(view, "LastName", "Last", bandBasic, 1, 1).Width = 90;

            // Nested band: Contact
            var bandContact = new GridBand { Caption = "Contact", Name = "bandContact" };
            bandPerson.Children.Add(bandContact);

            CreateColumn(view, "Email", "Email", bandContact, 0, 1).Width = 170;
            CreateColumn(view, "Phone", "Phone", bandContact, 1, 1).Width = 120;

            // Root band for work
            var bandWork = new GridBand { Caption = "Work", Name = "bandWork" };
            view.Bands.Add(bandWork);

            // Nested band: Company
            var bandCompanyInfo = new GridBand { Caption = "Company", Name = "bandCompanyInfo" };
            bandWork.Children.Add(bandCompanyInfo);

            CreateColumn(view, "Company", "Name", bandCompanyInfo, 0, 1).Width = 140;
            CreateColumn(view, "Department", "Dept", bandCompanyInfo, 1, 1).Width = 90;

            // Nested band: Position
            var bandPosition = new GridBand { Caption = "Position", Name = "bandPosition" };
            bandWork.Children.Add(bandPosition);

            CreateColumn(view, "JobTitle", "Title", bandPosition, 0, 1).Width = 140;
            CreateColumn(view, "Salary", "Salary", bandPosition, 1, 1).Width = 90;
            CreateColumn(view, "IsActive", "Active", bandPosition, 0, 2).Width = 50;

            // Root band for location
            var bandLocation = new GridBand { Caption = "Location", Name = "bandLocation" };
            view.Bands.Add(bandLocation);

            CreateColumn(view, "City", "City", bandLocation, 0, 1).Width = 100;
            CreateColumn(view, "State", "State", bandLocation, 0, 1).Width = 60;
            CreateColumn(view, "Country", "Country", bandLocation, 1, 1).Width = 100;
            CreateColumn(view, "ZipCode", "Zip", bandLocation, 1, 1).Width = 60;

            // Misc band
            var bandMisc = new GridBand { Caption = "Other", Name = "bandMisc" };
            view.Bands.Add(bandMisc);

            CreateColumn(view, "BirthDate", "Birth", bandMisc, 0, 1).Width = 85;
            CreateColumn(view, "HireDate", "Hired", bandMisc, 1, 1).Width = 85;
            CreateColumn(view, "Rating", "Rating", bandMisc, 0, 2).Width = 50;
        }

        private static BandedGridColumn CreateColumn(AdvBandedGridView view, string fieldName, string caption,
            GridBand band, int rowIndex, int rowCount) {
            var column = new BandedGridColumn {
                FieldName = fieldName,
                Caption = caption,
                Visible = true,
                OwnerBand = band,
                RowIndex = rowIndex,
                RowCount = rowCount
            };

            if (rowCount > 1) {
                column.AutoFillDown = true;
            }

            view.Columns.Add(column);
            return column;
        }
    }

    internal class SamplePerson {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
    }
}
