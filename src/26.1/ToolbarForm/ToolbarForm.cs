
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolbarForm {
    public partial class TF : DevExpress.XtraBars.ToolbarForm.ToolbarForm {
        public TF() {
            InitializeComponent();
            this.ShowInTaskbar = false;
            Task.Run(async () => {
                await Task.Delay(3000);
                // invoke on main thread
                this.Invoke(new MethodInvoker(() => {
                }));
            });
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            MessageBox.Show("hi");
        }
    }
}
