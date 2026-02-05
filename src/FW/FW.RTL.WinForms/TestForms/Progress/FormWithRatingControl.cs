namespace FW.RTL.WinForms.TestForms.Progress {
    [TestForm("Progress", "Rating Control")]
    public partial class FormWithRatingControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithRatingControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            ratingControl1.Rating = 3.5m;
            ratingControl2.Rating = 4m;
            ratingControl3.Rating = 2.5m;
        }
    }
}
