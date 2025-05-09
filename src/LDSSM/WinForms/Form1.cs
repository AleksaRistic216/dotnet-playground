using Repository;

namespace WinForms
{
	public partial class Form1 : Form
	{
		public Form1(LDSSMDbContext context)
		{
			InitializeComponent();
			gridControl1.DataSource = context.Users.ToList();
		}

		private void Form1_Load(object sender, EventArgs e) { }
	}
}
