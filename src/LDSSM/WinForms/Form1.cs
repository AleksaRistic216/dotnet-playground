using LDSSM.Contracts.Interfaces.IRepositories;
using LDSSM.Repository;

namespace LDSSM.WinForms
{
	public partial class Form1 : Form
	{
		public Form1(IUserRepository userRepository)
		{
			InitializeComponent();
			gridControl1.DataSource = userRepository.GetMultiple().ToList();
		}

		private void Form1_Load(object sender, EventArgs e) { }
	}
}
