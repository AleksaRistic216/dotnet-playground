using System.Drawing.Drawing2D;
using DevExpress.Charts.Native;
using DevExpress.Spreadsheet.Charts;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using Chart = DevExpress.Spreadsheet.Charts.Chart;
using ChartTitle = DevExpress.XtraCharts.ChartTitle;
using Series = DevExpress.XtraCharts.Series;

namespace Charts.WinForms
{
	public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public Form1()
		{
			InitializeComponent();
			InitializeChart();
			chartControl1.Paint += ChartControl1_Paint;
			chartControl1.CustomPaint += ChartControl1_CustomPaint;
		}

		private void ChartControl1_CustomPaint(object sender, CustomPaintEventArgs e)
		{
			var pieCenter = GetChartCenter();
			var x = pieCenter.X;
			var y = pieCenter.Y;
			var radius = 20;
			x -= radius / 2;
			y -= radius / 2;
			e.Graphics.FillEllipse(Brushes.GreenYellow, x, y, radius, radius);
		}

		private Point GetChartCenter()
		{
			ISupportVisibilityControlElement legend = chartControl1.Legend;
			var x = (chartControl1.Bounds.Width - (int)legend.Bounds.Width) / 2;
			var y = chartControl1.Bounds.Height / 2;
			x -= chartControl1.Padding.Right;
			x -= chartControl1.Margin.Right;
			return new Point(x, y);
		}

		private void ChartControl1_Paint(object? sender, PaintEventArgs e) { }

		void InitializeChart()
		{
			var pieChart = chartControl1;
			//pieChart.Titles.Add(new ChartTitle());

			// Create a pie series.
			var series1 = new Series("Land Area by Country", ViewType.Pie);

			// Bind the series to data.
			series1.DataSource = DataPoint.GetDataPoints();
			series1.ArgumentDataMember = "Argument";
			series1.ValueDataMembers.AddRange(new string[] { "Value" });

			// Add the series to the chart.
			pieChart.Series.Add(series1);

			// Format the the series labels.
			series1.Label.TextPattern = "{VP:p0} ({V:.##}M km²)";

			// Format the series legend items.
			series1.LegendTextPattern = "{A}";

			// Adjust the position of series labels.
			((PieSeriesLabel)series1.Label).Position = PieSeriesLabelPosition.TwoColumns;

			// Detect overlapping of series labels.
			((PieSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

			// Access the view-type-specific options of the series.
			PieSeriesView myView = (PieSeriesView)series1.View;

			// Specify a data filter to explode points.
			myView.ExplodedPointsFilters.Add(
				new SeriesPointFilter(
					SeriesPointKey.Value_1,
					DataFilterCondition.GreaterThanOrEqual,
					9
				)
			);
			myView.ExplodedPointsFilters.Add(
				new SeriesPointFilter(
					SeriesPointKey.Argument,
					DataFilterCondition.NotEqual,
					"Others"
				)
			);
			myView.ExplodeMode = PieExplodeMode.UseFilters;
			myView.ExplodedDistancePercentage = 30;
			myView.RuntimeExploding = true;

			// Customize the legend.
			pieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
		}

		private void Form1_Load(object sender, EventArgs e) { }

		private void accordionControlElement1_Click(object sender, EventArgs e) { }
	}

	public class MyChart : ChartControl { }

	public class DataPoint
	{
		public string Argument { get; set; }
		public double Value { get; set; }

		public static List<DataPoint> GetDataPoints()
		{
			return new List<DataPoint>
			{
				new DataPoint { Argument = "Russia", Value = 17.0752 },
				new DataPoint { Argument = "Canada", Value = 9.98467 },
				new DataPoint { Argument = "USA", Value = 9.63142 },
				new DataPoint { Argument = "China", Value = 9.59696 },
				new DataPoint { Argument = "Brazil", Value = 8.511965 },
				new DataPoint { Argument = "Australia", Value = 7.68685 },
				new DataPoint { Argument = "India", Value = 3.28759 },
				new DataPoint { Argument = "Others", Value = 81.2 },
			};
		}
	}
}
