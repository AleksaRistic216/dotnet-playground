using Repository;

namespace WinForms
{
	public partial class Form1 : Form
	{
		public Form1(LDSSMDbContext context)
		{
			InitializeComponent();
			var users = context.Users.ToList();
			dataGridView1.DataSource = users;
		}

		private void Form1_Load(object sender, EventArgs e) { }
	}
}
