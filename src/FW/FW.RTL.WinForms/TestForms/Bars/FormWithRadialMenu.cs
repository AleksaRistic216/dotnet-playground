namespace FW.RTL.WinForms.TestForms.Bars {
    [TestForm("Bars", "Radial Menu")]
    public partial class FormWithRadialMenu : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithRadialMenu() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            labelControl1.Click += (s, e) => {
                radialMenu1.ShowPopup(System.Windows.Forms.Control.MousePosition);
            };
        }
    }
}
