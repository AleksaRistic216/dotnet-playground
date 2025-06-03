using DevExpress.XtraEditors;

namespace T1293782.WinForms
{
	public partial class Form1 : XtraForm
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			documentManager1.MdiParent = this;
			documentManager1.View.AddDocument(new Form2());
			documentManager1.View.AddDocument(new Form3());
		}
	}
}
