using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW.RibbonForm.WinFormsFW {
    public partial class Form3 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form3() {
            InitializeComponent();
        }

        private void ribbonControl1_Click(object sender, EventArgs e) {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.NavigationControlLayoutMode = this.NavigationControlLayoutMode == DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToFormTitle ? DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToTop : DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToFormTitle;
        }
    }
}
