using DevExpress.XtraBars;

namespace FW.RTL.WinForms {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        FormWithGrid fwg;
        FormWithVerticalGrid fwvg;
        public Form1() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e) {
            if (fwg == null || fwg.IsDisposed)
                fwg = new FormWithGrid();
            fwg.Show(this);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e) {
            if (fwvg == null || fwvg.IsDisposed)
                fwvg = new FormWithVerticalGrid();
            fwvg.Show(this);
        }
    }
}
