using DevExpress.XtraBars;
namespace RibbonForm.WinForms {
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1() {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e) {
            Thread.Sleep(2000);
            using PureRibbon p = new PureRibbon();
            p.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e) {
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e) {
            using Form2 f = new Form2();
            f.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e) {
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e) {
            this.IconOptions.ShowIcon = !this.IconOptions.ShowIcon;

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e) {

        }
    }
}
