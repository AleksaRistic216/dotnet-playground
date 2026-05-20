using DevExpress.XtraEditors;
using Random12513.Infrastructure;

namespace Random12513.Views {
    public partial class AreaStackedChartView : XtraUserControl {
        public AreaStackedChartView() {
            InitializeComponent();
        }

        public AreaStackedChartView(ICommonDataService dataService) : this() {
            chartDataBindingSource.DataSource = dataService.GetOrders();
        }

        void chartControl1_BoundDataChanged(object sender, EventArgs e) {
            DateTime endRange = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            rangeControl1.SelectedRange = new RangeControlRange(endRange.AddMonths(-4), endRange);
        }
    }
}
