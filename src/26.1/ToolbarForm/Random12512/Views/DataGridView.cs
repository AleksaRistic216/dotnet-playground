using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Random12512.Infrastructure;

namespace Random12512.Views {
    public partial class DataGridView : XtraUserControl {
        public DataGridView() {
            InitializeComponent();
        }
        public DataGridView(ICommonDataService dataService) : this() {
            DataService = dataService;
            customerBindingSource.DataSource = dataService.GetCustomers();
        }
        protected ICommonDataService? DataService { get; set; }

        void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            gridView1.ShowRibbonPrintPreview();
        }

        void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }
    }
}
