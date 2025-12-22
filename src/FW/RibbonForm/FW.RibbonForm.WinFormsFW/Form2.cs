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
            foreach(var e in Enum.GetValues(typeof(DevExpress.XtraBars.Ribbon.RibbonControlStyle)))
                repositoryItemComboBox1.Items.Add(e);
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

        private void barEditItem1_EditValueChanged(object sender, EventArgs e) {
            var style = (DevExpress.XtraBars.Ribbon.RibbonControlStyle)barEditItem1.EditValue;
            ribbonControl1.RibbonStyle = style;
        }
    }
}
