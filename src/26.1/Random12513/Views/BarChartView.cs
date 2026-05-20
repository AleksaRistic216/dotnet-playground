using DevExpress.XtraEditors;
using Random12513.Infrastructure;

namespace Random12513.Views {
    public partial class BarChartView : XtraUserControl {
        public BarChartView() {
            InitializeComponent();
        }

        public BarChartView(ICommonDataService dataService) : this() {
            chartDataBindingSource.DataSource = dataService.GetOrders();
        }
    }
}
