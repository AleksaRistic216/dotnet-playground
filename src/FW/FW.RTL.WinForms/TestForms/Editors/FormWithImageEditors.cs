namespace FW.RTL.WinForms.TestForms.Editors {
    [TestForm("Editors", "Image Editors")]
    public partial class FormWithImageEditors : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithImageEditors() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
        }
    }
}
