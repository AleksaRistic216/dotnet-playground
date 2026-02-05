namespace FW.RTL.WinForms.TestForms.Bars {
    [TestForm("Bars", "Ribbon Status Bar")]
    public partial class FormWithRibbonStatusBar : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithRibbonStatusBar() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
        }
    }
}
