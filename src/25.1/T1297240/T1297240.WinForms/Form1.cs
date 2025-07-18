using System.Data;
using DevExpress.LookAndFeel;

namespace T1297240.WinForms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			//textEdit1.Text = "See what's hidden in your string… or be​hind﻿";
			//memoEdit1.Text = "See what's hidden in your string… or be​hind﻿";

			DataTable table = new DataTable();
			table.Columns.Add("text");
			table.Rows.Add("See what's hidden in your string… or be​hind﻿");

			gridControl1.DataSource = table;
		}

		private void textEdit1_CustomHighlightText(
			object sender,
			DevExpress.XtraEditors.TextEditCustomHighlightTextEventArgs e
		)
		{
			foreach (var item in Constants.HiddenCharsMap)
			{
				e.HighlightRanges(
					item.Key,
					(block) =>
					{
						block.Painter = new DevHiddenCharPainter(
							DXSkinColors.ForeColors.DisabledText,
							item.Value
						);
						block.Length = 1;
						block.AllowNavigation = false;
						block.ContentSize = new Size(100, 10);

						//block.Painter = new DevHiddenCharPainter(
						//	DXSkinColors.ForeColors.DisabledText,
						//	item.Value
						//);
						//block.Length = 1;
						//block.AllowNavigation = false;

						//var settings = sender is TextEdit edit
						//	? edit.Properties
						//	: sender as RepositoryItemTextEdit;
						//if (settings is null)
						//	throw new InvalidOperationException();

						//using var cache = gridControl1.CreateGraphicsCache();
						//block.ContentSize = settings.Appearance.CalcTextSizeInt(
						//	cache,
						//	item.Value,
						//	10000
						//);
					},
					System.Globalization.CompareOptions.OrdinalIgnoreCase
				);
			}
		}
	}
}
