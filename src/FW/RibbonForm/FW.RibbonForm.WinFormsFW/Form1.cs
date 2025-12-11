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
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1() {
            InitializeComponent();
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.SidePane.SizeChanged += SidePanel_SizeChanged;
        }

        private void SidePanel_SizeChanged(object sender, EventArgs e) {
            labelControl1.Text = $"Side Panel Width: {this.SidePane.Width}";
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            using(NormalForm form = new NormalForm())
                form.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.RightToLeft = this.RightToLeft != RightToLeft.Yes ? RightToLeft.Yes : RightToLeft.No;
            this.RightToLeftLayout = !this.RightToLeftLayout;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.SidePane.Visible = !this.SidePane.Visible;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            NavigationControlLayoutMode = NavigationControlLayoutMode == DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToFormTitle
                ? DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToTop
                : DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToFormTitle;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var pf = new PureRibbonForm();
            pf.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            barButtonItem2_ItemClick(null, null);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var f3 = new Form3();
            f3.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var f2 = new Form2();
            f2.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var f4 = new Form4();
            f4.Show();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var f5 = new Form5();
            f5.Show();
        }

        private void accordionControlElement5_Click(object sender, EventArgs e) {
            this.IconOptions.ShowIcon = !this.IconOptions.ShowIcon;
        }

        private void navigationPage1_Paint(object sender, PaintEventArgs e) {

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            using(Form9 form = new Form9())
                form.ShowDialog();
        }
    }
}
