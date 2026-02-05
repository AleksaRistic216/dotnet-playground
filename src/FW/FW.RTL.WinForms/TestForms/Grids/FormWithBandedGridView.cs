using DevExpress.XtraGrid.Views.BandedGrid;

namespace FW.RTL.WinForms.TestForms.Grids {
    [TestForm("Grids", "Banded Grid View")]
    public partial class FormWithBandedGridView : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithBandedGridView() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var data = SampleDataGenerator.GeneratePersons(50);
            gridControl1.DataSource = data;

            var view = (BandedGridView)gridControl1.MainView;
            view.OptionsView.ShowGroupPanel = false;

            var bandPersonal = new GridBand { Caption = "Personal" };
            view.Bands.Add(bandPersonal);

            var bandContact = new GridBand { Caption = "Contact" };
            view.Bands.Add(bandContact);

            var bandWork = new GridBand { Caption = "Work" };
            view.Bands.Add(bandWork);

            view.Columns["Id"].OwnerBand = bandPersonal;
            view.Columns["FirstName"].OwnerBand = bandPersonal;
            view.Columns["LastName"].OwnerBand = bandPersonal;
            view.Columns["BirthDate"].OwnerBand = bandPersonal;

            view.Columns["Email"].OwnerBand = bandContact;
            view.Columns["Phone"].OwnerBand = bandContact;
            view.Columns["City"].OwnerBand = bandContact;
            view.Columns["Country"].OwnerBand = bandContact;

            view.Columns["Company"].OwnerBand = bandWork;
            view.Columns["JobTitle"].OwnerBand = bandWork;
            view.Columns["Department"].OwnerBand = bandWork;
            view.Columns["Salary"].OwnerBand = bandWork;
            view.Columns["IsActive"].OwnerBand = bandWork;

            view.BestFitColumns();
        }
    }
}
