using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace T1291564.WindowsForms
{
	public partial class Form1 : Form
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
			var frm = new XtraForm();
			frm.MdiParent = this;
			frm.WindowState = FormWindowState.Maximized;
			frm.Show();
		}
	}
}
