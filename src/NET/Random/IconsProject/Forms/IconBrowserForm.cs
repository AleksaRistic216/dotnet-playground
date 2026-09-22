using System.Diagnostics;
using DevExpress.Data.Utils.Images;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using IconsProject.Infrastructure;
using DxIcon = DevExpress.Data.Utils.Images.Icon;

namespace IconsProject.Forms {
    public class IconBrowserForm : TestFormBase {
        readonly GalleryControl gallery;
        readonly TextEdit searchEdit;
        readonly SpinEdit limitEdit;
        readonly ImageComboBoxEdit sizeEdit;
        readonly ImageComboBoxEdit setEdit, styleEdit, colorEdit;
        readonly (string Name, DxIcon Icon)[] allIcons;

        public IconBrowserForm()
            : base("Generated Icons browser (GalleryControl)",
                  "Every public static property of DevExpress.Images.Icons, rendered by GalleryItems. Size is NOT pinned in the uri, so GalleryItem's IDXImageUriIconSizeProvider decides it from Gallery.ImageSize. " +
                  "Change the gallery image size and watch the provider pick 16/20/24/32/48 variants. Set/Style/Color overrides rebuild the uris. Click an item to log its uri and resolution.") {
            allIcons = IconCatalog.AllGeneratedIcons().ToArray();
            var top = new FlowLayoutPanel();
            searchEdit = new TextEdit { Width = 200 };
            searchEdit.Properties.NullValuePrompt = "filter by name";
            limitEdit = new SpinEdit { Width = 80 };
            limitEdit.Properties.MinValue = 1;
            limitEdit.Properties.MaxValue = 5000;
            limitEdit.EditValue = 400;
            sizeEdit = new ImageComboBoxEdit { Width = 90 };
            foreach(int s in new[] { 12, 16, 20, 24, 28, 32, 40, 48, 64 })
                sizeEdit.Properties.Items.Add(new ImageComboBoxItem($"{s}px", s));
            sizeEdit.EditValue = 32;
            setEdit = Editor(IconCatalog.Sets);
            styleEdit = Editor(IconCatalog.Styles);
            colorEdit = Editor(IconCatalog.Colors);
            top.Controls.AddRange(new Control[] {
                Caption("Search", 50), searchEdit, Caption("Limit", 40), limitEdit, Caption("Gallery.ImageSize", 110), sizeEdit,
                Caption("Set", 30), setEdit, Caption("Style", 40), styleEdit, Caption("Color", 40), colorEdit });
            AddToolbarButton(top, "Rebuild", (s, e) => Rebuild());
            AddToolbarButton(top, "Apply size only", (s, e) => ApplySize());
            AddToolbarButton(top, $"Count ({allIcons.Length} icons)", (s, e) => IconLog.Info("Icons", $"{allIcons.Length} generated Icon properties"));

            gallery = new GalleryControl();
            gallery.Gallery.ShowItemText = true;
            gallery.Gallery.ShowGroupCaption = true;
            gallery.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.Default;
            gallery.Gallery.ItemClick += (s, e) => {
                var uri = e.Item.ImageOptions.ImageUri;
                IconLog.Write($"Gallery item '{e.Item.Caption}': uri='{uri.Uri}' HasSvgImage={uri.HasSvgImage} preferred={uri.GetSizeProviderPreferredIconSize()} ImageType={uri.ImageType}");
            };
            searchEdit.EditValueChanged += (s, e) => Rebuild();

            AddSections(Section("Options", top, 90), Section("Icons", gallery, 620));
            Rebuild();
        }

        static ImageComboBoxEdit Editor<T>(T[] values) where T : struct, Enum {
            var editor = new ImageComboBoxEdit { Width = 110 };
            foreach(var v in values)
                editor.Properties.Items.Add(new ImageComboBoxItem(v.ToString(), v));
            editor.EditValue = values[0];
            return editor;
        }

        void ApplySize() {
            int size = (int)sizeEdit.EditValue;
            gallery.Gallery.ImageSize = new Size(size, size);
            IconLog.Write($"Gallery.ImageSize -> {size} (no rebuild; items must ask their size provider again)");
        }

        void Rebuild() {
            var watch = Stopwatch.StartNew();
            string filter = searchEdit.Text?.Trim() ?? string.Empty;
            int limit = Convert.ToInt32(limitEdit.EditValue);
            int size = (int)sizeEdit.EditValue;
            var set = (IconSet)setEdit.EditValue;
            var style = (IconStyle)styleEdit.EditValue;
            var color = (IconColor)colorEdit.EditValue;
            gallery.Gallery.BeginUpdate();
            try {
                gallery.Gallery.Groups.Clear();
                gallery.Gallery.ImageSize = new Size(size, size);
                var matches = allIcons.Where(i => filter.Length == 0 || i.Name.Contains(filter, StringComparison.OrdinalIgnoreCase) || i.Icon.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase)).Take(limit);
                foreach(var byLetter in matches.GroupBy(i => char.ToUpperInvariant(i.Name[0]))) {
                    var group = new GalleryItemGroup { Caption = byLetter.Key.ToString() };
                    foreach(var entry in byLetter) {
                        var icon = new DxIcon(entry.Icon.ToString(), set, style, color);
                        var item = new GalleryItem { Caption = entry.Name, Hint = icon.ToString() };
                        item.ImageOptions.ImageUri = icon;
                        group.Items.Add(item);
                    }
                    gallery.Gallery.Groups.Add(group);
                }
            }
            finally {
                gallery.Gallery.EndUpdate();
            }
            int count = gallery.Gallery.Groups.Cast<GalleryItemGroup>().Sum(g => g.Items.Count);
            IconLog.Write($"Gallery rebuilt: {count} items, size {size}, set={set} style={style} color={color} in {watch.ElapsedMilliseconds} ms");
        }
    }
}
