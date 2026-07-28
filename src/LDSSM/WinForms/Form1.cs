using Common.Contracts.Interfaces.IRepositories;

namespace LDSSM.WinForms
{
	public partial class Form1 : Form
	{
		private readonly IUserRepository userRepository;
		private readonly IServiceProvider serviceProvider;

		public Form1(IUserRepository userRepository, IServiceProvider serviceProvider)
		{
			this.userRepository = userRepository;
			this.serviceProvider = serviceProvider;
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) { }

		private void button1_Click(object sender, EventArgs e)
		{
			using var dxForm = (DXGridForm)serviceProvider.GetService(typeof(DXGridForm));
			dxForm.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using var chartForm = (ChartForm)serviceProvider.GetService(typeof(ChartForm))!;
			chartForm.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using var chart3DForm = (Chart3DForm)serviceProvider.GetService(typeof(Chart3DForm))!;
			chart3DForm.ShowDialog();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			using var form = (StackedBarChartForm)serviceProvider.GetService(typeof(StackedBarChartForm))!;
			form.ShowDialog();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			using var form = (DoughnutChartForm)serviceProvider.GetService(typeof(DoughnutChartForm))!;
			form.ShowDialog();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			using var form = (RadarChartForm)serviceProvider.GetService(typeof(RadarChartForm))!;
			form.ShowDialog();
		}
	}
}
