using DevExpress.Data.Utils.Images;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using IconsProject.Infrastructure;
using DxIcon = DevExpress.Data.Utils.Images.Icon;

namespace IconsProject.Forms {
    public class IconMatrixForm : TestFormBase {
        readonly ComboBoxEdit idEdit;
        readonly CheckEdit directCheck;
        readonly CheckEdit autoRebuildCheck;
        readonly TableLayoutPanel table;
        readonly LabelControl summary;

        public IconMatrixForm()
            : base("Set x Style x Color x Size matrix",
                  "Every combination of the four axes for one icon id. Default mode renders through SimpleButton.ImageOptions.ImageUri = new Icon(...), which exercises DxImageUri parsing and size resolution. " +
                  "'Provider direct' renders provider.GetSvgImage(...) into a PictureEdit. A pink cell means nothing resolved. Nearest-size snapping and fallbacks are visible on rows where a size is not published.") {
            var top = new FlowLayoutPanel();
            idEdit = new ComboBoxEdit { Width = 200, EditValue = "add" };
            idEdit.Properties.Items.AddRange(IconCatalog.Metaphors);
            idEdit.Properties.Items.AddRange(IconCatalog.MetaphorsWithGaps);
            directCheck = new CheckEdit { Text = "Provider direct", Width = 140 };
            top.Controls.Add(Caption("Icon id", 60));
            top.Controls.Add(idEdit);
            top.Controls.Add(directCheck);
            autoRebuildCheck = new CheckEdit { Text = "Rebuild on icon mode change (off = watch live controls update)", Width = 380 };
            top.Controls.Add(autoRebuildCheck);
            AddToolbarButton(top, "Rebuild", (s, e) => Rebuild());
            summary = Caption(string.Empty, 600);
            top.Controls.Add(summary);

            table = new TableLayoutPanel { AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink, CellBorderStyle = TableLayoutPanelCellBorderStyle.Single, Dock = DockStyle.Top };
            var host = new XtraScrollableControl();
            host.Controls.Add(table);

            AddSections(Section("Icon", top, 90), Section("Matrix", host, 640));
            Rebuild();
        }

        void Rebuild() {
            table.SuspendLayout();
            foreach(Control c in table.Controls.Cast<Control>().ToArray())
                c.Dispose();
            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();
            string id = idEdit.Text;
            var sets = new[] { IconSet.Default, IconSet.Fluent, IconSet.Classic, IconSet.Blazor };
            var styles = new[] { IconStyle.Regular, IconStyle.Filled };
            var colors = new[] { IconColor.Multicolor, IconColor.Monochrome };
            table.ColumnCount = IconCatalog.Sizes.Length + 1;
            table.Controls.Add(Caption("set / style / color", 190), 0, 0);
            for(int c = 0; c < IconCatalog.Sizes.Length; c++)
                table.Controls.Add(Caption(IconCatalog.Sizes[c].ToString(), 70), c + 1, 0);
            int row = 1, resolved = 0, missing = 0;
            var provider = DxImageAssemblyUtil.ImageProvider;
            foreach(var set in sets)
                foreach(var style in styles)
                    foreach(var color in colors) {
                        table.Controls.Add(Caption($"{set} / {style} / {color}", 190), 0, row);
                        for(int c = 0; c < IconCatalog.Sizes.Length; c++) {
                            var size = IconCatalog.Sizes[c];
                            var icon = new DxIcon(id, set, style, color, size);
                            Control cell;
                            bool ok;
                            if(directCheck.Checked) {
                                var svg = provider.GetSvgImage(id, set, IconCatalog.PixelSize(size), color, style);
                                ok = svg != null;
                                var picture = new PictureEdit { Size = new Size(64, 64), SvgImage = svg, ToolTip = icon.ToString() };
                                picture.Properties.SizeMode = PictureSizeMode.Clip;
                                picture.Properties.SvgImageSize = IconCatalog.PixelSize(size);
                                cell = picture;
                            }
                            else {
                                var button = new SimpleButton { Size = new Size(64, 64), PaintStyle = PaintStyles.Light, ToolTip = icon.ToString(), AllowFocus = false };
                                button.ImageOptions.Location = ImageLocation.MiddleCenter;
                                button.ImageOptions.ImageUri = icon;
                                ok = button.ImageOptions.ImageUri.HasSvgImage || button.ImageOptions.ImageUri.HasImage;
                                Track(button.ImageOptions);
                                cell = button;
                            }
                            if(ok)
                                resolved++;
                            else {
                                missing++;
                                cell.BackColor = Color.MistyRose;
                            }
                            table.Controls.Add(cell, c + 1, row);
                        }
                        row++;
                    }
            table.RowCount = row;
            table.ResumeLayout();
            summary.Text = $"'{id}': {resolved} resolved, {missing} unresolved (pink)";
            IconLog.Write($"Matrix '{id}' direct={directCheck.Checked}: {resolved} resolved, {missing} unresolved | {IconModeSwitch.Describe()}");
        }

        protected override void OnIconModeChanged() {
            if(autoRebuildCheck.Checked)
                Rebuild();
        }
    }
}
