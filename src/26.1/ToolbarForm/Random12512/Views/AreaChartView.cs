using DevExpress.XtraEditors;
using Random12512.Infrastructure;

namespace Random12512.Views {
    public partial class AreaChartView : XtraUserControl {
        public AreaChartView() {
            InitializeComponent();
        }

        public AreaChartView(ICommonDataService dataService) : this() {
            chartDataBindingSource.DataSource = dataService.GetOrders();
        }

        void chartControl1_BoundDataChanged(object sender, EventArgs e) {
            if(chartControl1.Series.Count > 0)
                chartControl1.Series[0].CheckedInLegend = true;
        }
    }
}
