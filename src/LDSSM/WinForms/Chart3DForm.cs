using Common.Contracts.Interfaces.IRepositories;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace LDSSM.WinForms;

public partial class Chart3DForm : XtraForm
{
    private readonly IUserRepository userRepository;

    public Chart3DForm(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        InitializeComponent();
    }

    private void Chart3DForm_Load(object sender, EventArgs e)
    {
        var data = userRepository
            .GetMultiple()
            .GroupBy(u => u.Country)
            .Select(g => new { Country = g.Key, UserCount = g.Count() })
            .OrderByDescending(x => x.UserCount)
            .Take(10)
            .ToList();

        var series = new Series("Users", ViewType.Pie3D);
        series.DataSource = data;
        series.ArgumentDataMember = "Country";
        series.ValueDataMembers.AddRange("UserCount");
        series.ArgumentScaleType = ScaleType.Qualitative;
        series.Label.TextPattern = "{A}: {VP:f1}%";
        series.LabelsVisibility = DefaultBoolean.True;
        series.LegendTextPattern = "{A}";
        chartControl.Series.Add(series);

        if (series.View is Pie3DSeriesView pieView)
        {
            pieView.ExplodeMode = PieExplodeMode.UseFilters;
        }

        chartControl.Titles.Add(new ChartTitle { Text = "User Distribution by Country (Top 10)" });
        chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.RightOutside;
        chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.Center;
    }
}
