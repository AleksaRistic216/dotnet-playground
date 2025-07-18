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
			foreach (var segment in block.Segments)
				if (TextArea.Contains(segment.Bounds))
					DrawString(Draw, segment.TextBounds, Color);
			return true;
		}
	}
}
