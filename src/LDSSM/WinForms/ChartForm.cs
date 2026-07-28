using Common.Contracts.Interfaces.IRepositories;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace LDSSM.WinForms;

public partial class ChartForm : XtraForm
{
    private readonly IUserRepository userRepository;

    public ChartForm(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        InitializeComponent();
    }

    private void ChartForm_Load(object sender, EventArgs e)
    {
        var data = userRepository
            .GetMultiple()
            .GroupBy(u => u.Country)
            .Select(g => new CountryStats
            {
                Country = g.Key,
                UserCount = g.Count(),
                AverageAge = g.Average(u => u.Age)
            })
            .OrderByDescending(x => x.UserCount)
            .Take(15)
            .ToList();

        // Compute cumulative totals
        int runningTotal = 0;
        foreach (var item in data)
        {
            runningTotal += item.UserCount;
            item.CumulativeUsers = runningTotal;
        }

        // Top pane: Users bar + Avg Age line
        var userCountSeries = new Series("Users", ViewType.Bar);
        userCountSeries.DataSource = data;
        userCountSeries.ArgumentDataMember = nameof(CountryStats.Country);
        userCountSeries.ValueDataMembers.AddRange(nameof(CountryStats.UserCount));
        userCountSeries.ArgumentScaleType = ScaleType.Qualitative;
        userCountSeries.Label.TextPattern = "{V:#,0}";
        userCountSeries.LabelsVisibility = DefaultBoolean.True;
        chartControl.Series.Add(userCountSeries);

        var ageSeries = new Series("Avg Age", ViewType.Line);
        ageSeries.DataSource = data;
        ageSeries.ArgumentDataMember = nameof(CountryStats.Country);
        ageSeries.ValueDataMembers.AddRange(nameof(CountryStats.AverageAge));
        ageSeries.ArgumentScaleType = ScaleType.Qualitative;
        ageSeries.Label.TextPattern = "{V:f1}";
        ageSeries.LabelsVisibility = DefaultBoolean.True;
        chartControl.Series.Add(ageSeries);

        // Bottom pane: Cumulative users area
        var cumulativeSeries = new Series("Cumulative Users", ViewType.Area);
        cumulativeSeries.DataSource = data;
        cumulativeSeries.ArgumentDataMember = nameof(CountryStats.Country);
        cumulativeSeries.ValueDataMembers.AddRange(nameof(CountryStats.CumulativeUsers));
        cumulativeSeries.ArgumentScaleType = ScaleType.Qualitative;
        cumulativeSeries.Label.TextPattern = "{V:#,0}";
        cumulativeSeries.LabelsVisibility = DefaultBoolean.True;
        chartControl.Series.Add(cumulativeSeries);

        if (chartControl.Diagram is XYDiagram diagram)
        {
            // Top pane axis config
            diagram.AxisX.Label.Angle = -45;
            diagram.AxisY.Label.TextPattern = "{V:#,0}";
            diagram.AxisY.Title.Text = "Number of Users";
            diagram.AxisY.Title.Visibility = DefaultBoolean.True;

            var secondaryY = new SecondaryAxisY("age");
            secondaryY.Title.Text = "Average Age";
            secondaryY.Title.Visibility = DefaultBoolean.True;
            secondaryY.Label.TextPattern = "{V:f1}";
            diagram.SecondaryAxesY.Add(secondaryY);
            ((LineSeriesView)ageSeries.View).AxisY = secondaryY;

            // Bottom pane
            var bottomPane = new XYDiagramPane("BottomPane");
            diagram.Panes.Add(bottomPane);

            var bottomAxisY = new SecondaryAxisY("cumulative");
            bottomAxisY.Title.Text = "Cumulative Users";
            bottomAxisY.Title.Visibility = DefaultBoolean.True;
            bottomAxisY.Label.TextPattern = "{V:#,0}";
            diagram.SecondaryAxesY.Add(bottomAxisY);

            var areaView = (AreaSeriesView)cumulativeSeries.View;
            areaView.Pane = bottomPane;
            areaView.AxisY = bottomAxisY;
        }

        chartControl.Titles.Add(new ChartTitle { Text = "Users by Country (Top 15)" });
        chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
        chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
    }
}

public class CountryStats
{
    public string Country { get; set; } = null!;
    public int UserCount { get; set; }
    public double AverageAge { get; set; }
    public int CumulativeUsers { get; set; }
}
