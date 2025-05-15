using Common.Contracts.Interfaces.IRepositories;

namespace SSGL.WinForms
{
	public partial class Form1 : Form
	{
		public Form1(IUserRepository userRepository)
		{
			InitializeComponent();
			var data = userRepository.GetMultiple().OrderBy(x => Guid.NewGuid()).Take(1000);
			var datSource = new BindingSource();
			datSource.DataSource = data.ToList();
			gridControl1.DataSource = datSource;
			//gridView1.OptionsFind.Behavior = FindPanelBehavior.Search;
		}

		private void Form1_Load(object sender, EventArgs e) { }
	}
}
