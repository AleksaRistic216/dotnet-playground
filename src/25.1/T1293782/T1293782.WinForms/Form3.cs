using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.VisualEffects;

namespace T1293782.WinForms
{
	public partial class Form3 : Form
	{
		public Form3()
		{
			InitializeComponent();
		}

		private void Form3_Load(object sender, EventArgs e)
		{
			CreateBadges();
		}

		private void CreateBadges()
		{
			int index = 1;
			foreach (DevExpress.XtraTab.XtraTabPage page in xtraTabControl1.TabPages)
			{
				var b = new Badge();

				b.Properties.Location = System.Drawing.ContentAlignment.MiddleRight;
				b.Properties.Text = $"B{index++}";
				b.TargetElement = page;
				b.TargetElementRegion = TargetElementRegion.Header;
				b.Properties.Offset = new System.Drawing.Point(-15, 0);

				this.adorneruiManager1.Elements.Add(b);
			}
		}
	}
}
