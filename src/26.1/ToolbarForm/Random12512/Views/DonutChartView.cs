using DevExpress.XtraEditors;
using Random12512.Infrastructure;
using Random12512.Model;
using System.Data;

namespace Random12512.Views {
    public partial class DonutChartView : XtraUserControl {
        public DonutChartView() {
            InitializeComponent();
        }

        IEnumerable<Order> orders;
        IEnumerable<ChartDataPoint<string, decimal>> chartData;

        public DonutChartView(ICommonDataService dataService) : this() {
            orders = dataService.GetOrders();
            chartData = orders
                .SelectMany(o => o.Items)
                .GroupBy(oi => oi.Order.Customer.Country)
                .Select(g => new ChartDataPoint<string, decimal>(g.Key, g.Sum(oi => oi.Amount)))
                .OrderByDescending(c => c.Value);
            chartDataBindingSource.DataSource = chartData;
            chartControl1.Series[0].ArgumentDataMember = nameof(ChartDataPoint<string, decimal>.Argument);
            chartControl1.Series[0].ValueDataMembers.AddRange(nameof(ChartDataPoint<string, decimal>.Value));
        }
    }
}
