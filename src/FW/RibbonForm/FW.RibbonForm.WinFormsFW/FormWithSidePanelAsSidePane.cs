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
    public partial class FormWithSidePanelAsSidePane : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithSidePanelAsSidePane() {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            SidePane.Visible = !SidePane.Visible;
        }
    }
}
