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
    public partial class Form2 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form2() {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            SidePane.Visible = !SidePane.Visible;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.RightToLeft = RightToLeft == RightToLeft.No ? RightToLeft.Yes : RightToLeft.No;
            this.RightToLeftLayout = true;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.IconOptions.ShowIcon = !this.IconOptions.ShowIcon;
        }
    }
}
