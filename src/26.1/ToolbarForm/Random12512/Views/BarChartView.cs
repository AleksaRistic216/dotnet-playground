using DevExpress.XtraEditors;
using Random12512.Infrastructure;

namespace Random12512.Views {
    public partial class BarChartView : XtraUserControl {
        public BarChartView() {
            InitializeComponent();
        }

        public BarChartView(ICommonDataService dataService) : this() {
            chartDataBindingSource.DataSource = dataService.GetOrders();
        }
    }
}
