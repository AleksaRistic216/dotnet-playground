

namespace DocumentManger.WinForms {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            //Font = new Font("Consolas", 24);
        }
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified) {
            base.ScaleControl(factor, specified);
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
