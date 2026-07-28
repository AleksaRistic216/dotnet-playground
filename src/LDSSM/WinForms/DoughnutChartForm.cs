using Common.Contracts.Interfaces.IRepositories;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace LDSSM.WinForms;

public partial class DoughnutChartForm : XtraForm
{
    private readonly IUserRepository userRepository;

    public DoughnutChartForm(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        InitializeComponent();
    }

    private void DoughnutChartForm_Load(object sender, EventArgs e)
    {
        var data = userRepository
            .GetMultiple()
            .Select(u => u.Age)
            .ToList()
            .GroupBy(age => GetAgeGroup(age))
            .Select(g => new { AgeGroup = g.Key, Count = g.Count() })
            .OrderBy(x => x.AgeGroup)
            .ToList();

        var series = new Series("Age Groups", ViewType.Doughnut);
        series.DataSource = data;
        series.ArgumentDataMember = "AgeGroup";
        series.ValueDataMembers.AddRange("Count");
        series.ArgumentScaleType = ScaleType.Qualitative;
        series.Label.TextPattern = "{A}: {V:#,0} ({VP:f1}%)";
        series.LabelsVisibility = DefaultBoolean.True;
        series.LegendTextPattern = "{A}";
        chartControl.Series.Add(series);

        if (series.View is DoughnutSeriesView doughnutView)
        {
            doughnutView.ExplodeMode = PieExplodeMode.UsePoints;
            doughnutView.TotalLabel.Visible = true;
            doughnutView.TotalLabel.TextPattern = "Total: {TV:#,0}";
        }

        chartControl.Titles.Add(new ChartTitle { Text = "User Age Group Distribution" });
        chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.RightOutside;
        chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.Center;

        // Selection on doughnut
        chartControl.SelectionMode = ElementSelectionMode.Single;
        chartControl.SeriesSelectionMode = SeriesSelectionMode.Point;
    }

    private static string GetAgeGroup(int age) => age switch
    {
        < 26 => "18-25",
        < 36 => "26-35",
        < 46 => "36-45",
        < 56 => "46-55",
        _ => "56+"
    };
}
