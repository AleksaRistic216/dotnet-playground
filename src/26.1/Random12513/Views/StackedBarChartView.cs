using DevExpress.XtraEditors;
using Random12513.Infrastructure;

namespace Random12513.Views {
    public partial class StackedBarChartView : XtraUserControl {
        public StackedBarChartView() {
            InitializeComponent();
        }

        public StackedBarChartView(ICommonDataService dataService) : this() {
            chartDataBindingSource.DataSource = dataService.GetOrders();
        }
    }
}
