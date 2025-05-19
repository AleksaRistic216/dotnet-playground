namespace NCSTTB.WinForms
{
	public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void barButtonItem1_ItemClick(
			object sender,
			DevExpress.XtraBars.ItemClickEventArgs e
		)
		{
			using (var f = new Form2())
				f.ShowDialog();
		}

		private void panel1_Paint(object sender, PaintEventArgs e) { }

		private void Form1_Load(object sender, EventArgs e)
		{
			var a = accordionControl2.Parent;
		}
	}
}
