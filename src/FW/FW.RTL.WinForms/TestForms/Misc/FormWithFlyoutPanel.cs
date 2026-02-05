namespace FW.RTL.WinForms.TestForms.Misc {
    [TestForm("Misc", "Flyout Panel")]
    public partial class FormWithFlyoutPanel : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithFlyoutPanel() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            SetupFlyoutContent();
        }

        private void SetupFlyoutContent() {
            // Flyout panel content is set in designer
        }

        private void ShowFlyoutLeft() {
            flyoutPanel1.OwnerControl = this;
            flyoutPanel1.Options.Location = new System.Drawing.Point(Top - flyoutPanel1.Width, Left);
            flyoutPanel1.ShowPopup();
        }

        private void ShowFlyoutRight() {
            flyoutPanel1.OwnerControl = this;
            flyoutPanel1.Options.Location = new System.Drawing.Point(Top - flyoutPanel1.Width, Left);
            flyoutPanel1.ShowPopup();
        }

        private void ShowFlyoutTop() {
            flyoutPanel1.OwnerControl = this;
            flyoutPanel1.Options.Location = new System.Drawing.Point(Top - flyoutPanel1.Width, Left);
            flyoutPanel1.ShowPopup();
        }

        private void ShowFlyoutBottom() {
            flyoutPanel1.OwnerControl = this;
            flyoutPanel1.Options.Location = new System.Drawing.Point(Top - flyoutPanel1.Width, Left);
            flyoutPanel1.ShowPopup();
        }
    }
}
