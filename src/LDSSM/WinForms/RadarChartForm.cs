using Common.Contracts.Interfaces.IRepositories;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace LDSSM.WinForms;

public partial class RadarChartForm : XtraForm
{
    private readonly IUserRepository userRepository;

    public RadarChartForm(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        InitializeComponent();
    }

    private void RadarChartForm_Load(object sender, EventArgs e)
    {
        var allUsers = userRepository
            .GetMultiple()
            .Select(u => new { u.Country, u.Age })
            .ToList();

        var topCountries = allUsers
            .GroupBy(u => u.Country)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key)
            .ToList();

        var ageGroups = new[] { "18-25", "26-35", "36-45", "46-55", "56+" };

        foreach (var country in topCountries)
        {
            var countryUsers = allUsers.Where(u => u.Country == country).ToList();
            var total = countryUsers.Count;
            if (total == 0) continue;

            var profileData = ageGroups.Select(ag => new
            {
                AgeGroup = ag,
                Percentage = (double)countryUsers.Count(u => GetAgeGroup(u.Age) == ag) / total * 100
            }).ToList();

            var series = new Series(country, ViewType.RadarLine);
            series.DataSource = profileData;
            series.ArgumentDataMember = "AgeGroup";
            series.ValueDataMembers.AddRange("Percentage");
            series.ArgumentScaleType = ScaleType.Qualitative;
            series.Label.TextPattern = "{V:f0}%";
            series.LabelsVisibility = DefaultBoolean.False;
            chartControl.Series.Add(series);

            if (series.View is RadarLineSeriesView radarView)
            {
                radarView.MarkerVisibility = DefaultBoolean.True;
                radarView.LineStyle.Thickness = 2;
            }
        }

        if (chartControl.Diagram is RadarDiagram radarDiagram)
        {
            radarDiagram.AxisY.Label.TextPattern = "{V:f0}%";
        }

        chartControl.Titles.Add(new ChartTitle { Text = "Age Profile Comparison (Top 5 Countries)" });
        chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.RightOutside;
        chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.Center;

        // Enable selection to highlight a country
        chartControl.SelectionMode = ElementSelectionMode.Single;
        chartControl.SeriesSelectionMode = SeriesSelectionMode.Series;
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
