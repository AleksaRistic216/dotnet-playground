namespace FW.RTL.WinForms.TestForms.Bars {
    [TestForm("Bars", "Popup Menu")]
    public partial class FormWithPopupMenu : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithPopupMenu() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            labelControl1.Click += (s, e) => {
                popupMenu1.ShowPopup(System.Windows.Forms.Control.MousePosition);
            };
        }
    }
}
