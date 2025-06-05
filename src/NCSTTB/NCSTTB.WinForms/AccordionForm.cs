using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Navigation;

namespace NCSTTB.WinForms
{
	public partial class AccordionForm : Form
	{
		public AccordionForm()
		{
			InitializeComponent();
		}

		private void AccordionForm_Load(object sender, EventArgs e)
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
	}
}
