using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW.Random.WinFromsFW {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1() {
            InitializeComponent();
            //textEdit1.AccessibilityObject.Name = "First";
            //textEdit1.AccessibilityObject.Value = "Hello Accessibility";
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.RightToLeft = this.RightToLeft == RightToLeft.Yes ? RightToLeft.No : RightToLeft.Yes;
            this.RightToLeftLayout = this.RightToLeft == RightToLeft.Yes;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            NavigationControlLayoutMode = NavigationControlLayoutMode == DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToFormTitle
                ? DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToTop
                : DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToFormTitle;
        }
    }
}
