namespace FW.RTL.WinForms.TestForms.Bars {
    [TestForm("Bars", "Standalone Bar Dock Control")]
    public partial class FormWithStandaloneBarDockControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithStandaloneBarDockControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
        }
    }
}
