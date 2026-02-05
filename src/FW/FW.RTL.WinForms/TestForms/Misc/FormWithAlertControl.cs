using DevExpress.XtraBars.Alerter;

namespace FW.RTL.WinForms.TestForms.Misc {
    [TestForm("Misc", "Alert Control")]
    public partial class FormWithAlertControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithAlertControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
        }

        private void ShowInfoAlert() {
            alertControl1.Show(this, "Information", "This is an informational alert message.", "");
        }

        private void ShowWarningAlert() {
            alertControl1.Show(this, "Warning", "This is a warning alert. Please review your settings.", "");
        }

        private void ShowSuccessAlert() {
            alertControl1.Show(this, "Success", "Operation completed successfully!", "");
        }

        private void ShowErrorAlert() {
            alertControl1.Show(this, "Error", "An error occurred while processing your request.", "");
        }
    }
}
