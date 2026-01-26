using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace FW.RTL.WinForms {
    internal static class FormHelpers {
        internal static void InitializeCommonControlsPanel(RibbonPage ribbonPage, XtraForm form) {
            var ribbonControl = ribbonPage.Ribbon;
            var rtlGroup = new RibbonPageGroup("RTL");

            var rtlButton = new BarButtonItem {
                Caption = "Toggle RTL"
            };
            rtlButton.ItemClick += (s, e) => {
                form.RightToLeft = form.RightToLeft == RightToLeft.Yes ? RightToLeft.No : RightToLeft.Yes;
                form.RightToLeftLayout = !form.RightToLeftLayout;
            };

            ribbonControl.Items.Add(rtlButton);
            rtlGroup.ItemLinks.Add(rtlButton);
            ribbonPage.Groups.Add(rtlGroup);
        }
    }
}
