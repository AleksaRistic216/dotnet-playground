namespace FW.RTL.WinForms {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            FormRegistry.PopulateMenu(barSubItem1, this);
        }
    }
}
