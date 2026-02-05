namespace FW.RTL.WinForms.TestForms.Progress {
    [TestForm("Progress", "Marquee Progress Bar")]
    public partial class FormWithMarqueeProgressBar : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithMarqueeProgressBar() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
        }
    }
}
