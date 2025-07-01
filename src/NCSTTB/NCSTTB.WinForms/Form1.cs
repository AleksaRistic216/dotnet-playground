using DevExpress.XtraBars.Navigation;

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
			PopulateNavigationControl();
		}

		void PopulateNavigationControl()
		{
			var itemsCount = 20;
			var existingGroupitem = accordionControl1.Elements.First(x =>
				x.Style == ElementStyle.Group
			);
			for (var i = 0; i < itemsCount; i++)
			{
				var item = new AccordionControlElement();
				item.Text = $"Item {i}";
				item.Style = ElementStyle.Item;
				item.Click += (s, e) => MessageBox.Show($"Item {i} clicked");
				existingGroupitem.Elements.Add(item);
			}
		}

		private void barButtonItem2_ItemClick(
			object sender,
			DevExpress.XtraBars.ItemClickEventArgs e
		)
		{
			using var af = new AccordionForm();
			af.ShowDialog();
		}

		private void barButtonItem3_ItemClick(
			object sender,
			DevExpress.XtraBars.ItemClickEventArgs e
		)
		{
			using var np = new NavigationPane();
			np.ShowDialog();
		}

		private void barButtonItem4_ItemClick(
			object sender,
			DevExpress.XtraBars.ItemClickEventArgs e
		)
		{
			using var f = new WindowsButtonsForm();
			f.ShowDialog();
		}

		private void barButtonItem5_ItemClick(
			object sender,
			DevExpress.XtraBars.ItemClickEventArgs e
		)
		{
			using var f = new ToolBoxForm();
			f.ShowDialog();
		}
	}
}
