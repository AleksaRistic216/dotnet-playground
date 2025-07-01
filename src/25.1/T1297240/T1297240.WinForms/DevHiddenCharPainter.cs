using DevExpress.XtraEditors;

namespace T1297240.WinForms
{
	internal class DevHiddenCharPainter : TextEdit.TextEditBlockPainter
	{
		string Draw { get; set; }
		Color Color { get; set; }

		public DevHiddenCharPainter(Color color, string draw)
		{
			Color = color;
			Draw = draw;
		}

		public override bool DrawForeground(TextEdit.Block block)
		{
			DrawString(Draw, block.Segments[0].TextBounds, Color);
			return true;
		}
	}
}
