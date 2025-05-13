using Common.Contracts.Interfaces.IRepositories;

namespace SSGL.WinForms
{
	public partial class Form1 : Form
	{
		public Form1(IUserRepository userRepository)
		{
			InitializeComponent();
			var data = userRepository.GetMultiple().OrderBy(x => Guid.NewGuid()).Take(1000);
			gridControl1.DataSource = data.ToList();
		}

		private void Populate() { }

		private void Form1_Load(object sender, EventArgs e) { }
	}
}
