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
	}
}
