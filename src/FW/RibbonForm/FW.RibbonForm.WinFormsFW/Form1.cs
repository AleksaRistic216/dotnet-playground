using DevExpress.XtraBars.Ribbon;
using System;
using System.Windows.Forms;

namespace FW.RibbonForm.WinFormsFW {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1() {
            InitializeComponent();
            InitializeRibbonStyleCmb();
            this.SidePane.SizeChanged += SidePanel_SizeChanged;
            InitializeShowPageHeadersModeCmb();
            InitializeRibbonToolbarLocationCmb();
        }

        private void InitializeRibbonStyleCmb() {
            foreach(var style in Enum.GetValues(typeof(DevExpress.XtraBars.Ribbon.RibbonControlStyle)))
                repositoryItemComboBox1.Items.Add(style);
            cmb_RibbonStyle.EditValue = this.Ribbon.RibbonStyle;
        }

        private void InitializeShowPageHeadersModeCmb() {
            foreach(var mode in Enum.GetValues(typeof(ShowPageHeadersMode)))
                repositoryItemComboBox2.Items.Add(mode);
            ribbonHeaderMode_cmb.EditValue = this.Ribbon.ShowPageHeadersMode;
        }

        private void InitializeRibbonToolbarLocationCmb() {
            foreach(var location in Enum.GetValues(typeof(RibbonQuickAccessToolbarLocation))) 
                repositoryItemComboBox3.Items.Add(location);
            ribbonToolbarLocation_cmb.EditValue = this.Ribbon.ToolbarLocation;
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
        }

        private void cmb_RibbonStyle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
        }

        private void cmb_RibbonStyle_EditValueChanged(object sender, EventArgs e) {
            var style = (DevExpress.XtraBars.Ribbon.RibbonControlStyle)cmb_RibbonStyle.EditValue;
            ribbonControl1.RibbonStyle = style;
        }

        private void ribbonHeaderMode_cmb_EditValueChanged(object sender, EventArgs e) {
            var mode = (ShowPageHeadersMode)ribbonHeaderMode_cmb.EditValue;
            this.Ribbon.ShowPageHeadersMode = mode;
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            using(NestedRibbonWithinRibbonForm form = new NestedRibbonWithinRibbonForm())
                form.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {

        }

        private void barButtonItem10_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            using (SimpleFormWithRibbonControl form = new SimpleFormWithRibbonControl())
                form.ShowDialog();
        }

        private void barButtonItem11_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            using(Form5 form = new Form5())
                form.ShowDialog();
        }

        private void barButtonItem9_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            using (Form4 form = new Form4())
                form.ShowDialog();
        }

        private void barButtonItem8_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            using (Form2 form = new Form2())
                form.ShowDialog();
        }

        private void barButtonItem6_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            using (PureRibbonForm form = new PureRibbonForm())
                form.ShowDialog();
        }

        private void barButtonItem5_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            using (NormalForm form = new NormalForm())
                form.ShowDialog();
        }

        private void ribbonToolbarLocation_cmb_EditValueChanged(object sender, EventArgs e) {
            var location = (RibbonQuickAccessToolbarLocation)ribbonToolbarLocation_cmb.EditValue;
            this.Ribbon.ToolbarLocation = location;
        }
    }
}
