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
    public partial class PureRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public PureRibbonForm() {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.RightToLeft = this.RightToLeft != RightToLeft.Yes ? RightToLeft.Yes : RightToLeft.No;
            this.RightToLeftLayout = !this.RightToLeftLayout;
        }
    }
}
