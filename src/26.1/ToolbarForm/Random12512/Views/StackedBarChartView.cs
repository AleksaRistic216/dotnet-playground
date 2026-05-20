using DevExpress.XtraEditors;
using Random12512.Infrastructure;

namespace Random12512.Views {
    public partial class StackedBarChartView : XtraUserControl {
        public StackedBarChartView() {
            InitializeComponent();
        }

        public StackedBarChartView(ICommonDataService dataService) : this() {
            chartDataBindingSource.DataSource = dataService.GetOrders();
        }
    }
}
