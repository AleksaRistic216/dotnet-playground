using Common.Contracts.Interfaces.IRepositories;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace LDSSM.WinForms;

public partial class StackedBarChartForm : XtraForm
{
    private readonly IUserRepository userRepository;

    public StackedBarChartForm(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        InitializeComponent();
    }

    private void StackedBarChartForm_Load(object sender, EventArgs e)
    {
        var topCountries = userRepository
            .GetMultiple()
            .GroupBy(u => u.Country)
            .Select(g => new { Country = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(10)
            .Select(x => x.Country)
            .ToList();

        var users = userRepository
            .GetMultiple()
            .Where(u => topCountries.Contains(u.Country))
            .Select(u => new { u.Country, u.Age })
            .ToList();

        var data = users
            .Select(u => new { u.Country, AgeGroup = GetAgeGroup(u.Age) })
            .GroupBy(x => new { x.Country, x.AgeGroup })
            .Select(g => new AgeGroupData
            {
                Country = g.Key.Country,
                AgeGroup = g.Key.AgeGroup,
                Count = g.Count()
            })
            .ToList();

        var ageGroups = new[] { "18-25", "26-35", "36-45", "46-55", "56+" };

        foreach (var ageGroup in ageGroups)
        {
            var series = new Series(ageGroup, ViewType.StackedBar);
            var groupData = data.Where(d => d.AgeGroup == ageGroup).ToList();
            series.DataSource = groupData;
            series.ArgumentDataMember = nameof(AgeGroupData.Country);
            series.ValueDataMembers.AddRange(nameof(AgeGroupData.Count));
            series.ArgumentScaleType = ScaleType.Qualitative;
            series.Label.TextPattern = "{V:#,0}";
            series.LabelsVisibility = DefaultBoolean.True;
            chartControl.Series.Add(series);
        }

        if (chartControl.Diagram is XYDiagram diagram)
        {
            diagram.AxisX.Label.Angle = -45;
            diagram.AxisY.Label.TextPattern = "{V:#,0}";
            diagram.AxisY.Title.Text = "Number of Users";
            diagram.AxisY.Title.Visibility = DefaultBoolean.True;
            diagram.EnableAxisXZooming = true;
            diagram.EnableAxisXScrolling = true;
        }

        chartControl.Titles.Add(new ChartTitle { Text = "Age Distribution by Country (Stacked)" });
        chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.RightOutside;
        chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.Center;

        // Crosshair for XYDiagram
        chartControl.CrosshairOptions.ShowArgumentLine = true;
        chartControl.CrosshairOptions.ShowValueLine = true;
        chartControl.CrosshairOptions.GroupHeaderPattern = "{A}";
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

public class AgeGroupData
{
    public string Country { get; set; } = null!;
    public string AgeGroup { get; set; } = null!;
    public int Count { get; set; }
}
