namespace Mnemonic.WinForms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) { }

		private void barButtonItem3_ItemClick(
			object sender,
			DevExpress.XtraBars.ItemClickEventArgs e
		) { }

		private void barCheckItem1_CheckedChanged(
			object sender,
			DevExpress.XtraBars.ItemClickEventArgs e
		)
		{
			MessageBox.Show("Hello");
		}

		private void barButtonItem9_ItemClick(
			object sender,
			DevExpress.XtraBars.ItemClickEventArgs e
		)
		{
			MessageBox.Show("Hello");
		}

		private void barButtonItem10_ItemClick(
			object sender,
			DevExpress.XtraBars.ItemClickEventArgs e
		)
		{
			MessageBox.Show("Hello");
		}
	}
}
