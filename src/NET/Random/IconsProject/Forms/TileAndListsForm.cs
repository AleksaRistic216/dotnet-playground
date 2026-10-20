using DevExpress.IconLibrary;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using IconsProject.Infrastructure;
using DxIcon = DevExpress.IconLibrary.Icon;

namespace IconsProject.Forms {
    public class TileAndListsForm : TestFormBase {
        readonly TileControl tileControl;
        readonly List<TileItem> tiles = new List<TileItem>();

        public TileAndListsForm()
            : base("TileControl, ImageListBox (IDXImageUriIconSizeProvider)",
                  "TileItemElement asks its tile for a preferred icon size: Small 16, Medium 24, Default/Wide/Large 32, then TileItemImageScaleMode scales it into the item bounds (logical px). " +
                  "BaseListBoxControl returns 16 from the protected virtual GetPreferredIconSizeCore; the right-hand list overrides it to return 32. Uris here are unpinned, so size comes only from the provider.") {
            tileControl = new TileControl { AllowDrag = true, ItemSize = 90, Orientation = Orientation.Horizontal };
            BuildTiles();

            var tileActions = new FlowLayoutPanel();
            AddToolbarButton(tileActions, "Rebuild tiles", (s, e) => BuildTiles());
            AddToolbarButton(tileActions, "Cycle every tile's ItemSize", (s, e) => {
                foreach(var tile in tiles)
                    tile.ItemSize = (TileItemSize)(((int)tile.ItemSize + 1) % 5);
                LogTileSizes();
            });
            AddToolbarButton(tileActions, "Cycle ImageScaleMode", (s, e) => {
                foreach(var tile in tiles)
                    tile.ImageScaleMode = (TileItemImageScaleMode)(((int)tile.ImageScaleMode + 1) % 8);
                IconLog.Write($"ImageScaleMode -> {tiles.FirstOrDefault()?.ImageScaleMode}");
                LogTileSizes();
            });
            AddToolbarButton(tileActions, "TileControl.ItemSize 60/90/140", (s, e) => {
                tileControl.ItemSize = tileControl.ItemSize == 90 ? 140 : tileControl.ItemSize == 140 ? 60 : 90;
                IconLog.Write($"TileControl.ItemSize -> {tileControl.ItemSize}");
                LogTileSizes();
            });
            AddToolbarButton(tileActions, "Log preferred sizes", (s, e) => LogTileSizes());

            var lists = new TableLayoutPanel { ColumnCount = 3 };
            lists.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            lists.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            lists.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34));
            lists.Controls.Add(BuildImageListBox(new ImageListBoxControl(), "ImageListBox (preferred 16)", 0), 0, 0);
            lists.Controls.Add(BuildImageListBox(new ImageListBoxControl { ItemHeight = 44 }, "ImageListBox, ItemHeight 44 (still 16)", 0), 1, 0);
            lists.Controls.Add(BuildImageListBox(new LargeIconImageListBox { ItemHeight = 44 }, "Subclass: GetPreferredIconSizeCore = 32", 0), 2, 0);

            AddSections(
                Section("Tile actions", tileActions, 70),
                Section("TileControl", tileControl, 420),
                Section("Lists", lists, 300));
        }

        void BuildTiles() {
            tileControl.BeginUpdate();
            tileControl.Groups.Clear();
            tiles.Clear();
            var sizesGroup = new TileGroup { Text = "One per TileItemSize" };
            foreach(TileItemSize size in Enum.GetValues(typeof(TileItemSize)))
                sizesGroup.Items.Add(Tile(size.ToString(), new DxIcon("calendar"), size, TileItemImageScaleMode.Default));
            var scaleGroup = new TileGroup { Text = "ImageScaleMode (Medium)" };
            foreach(TileItemImageScaleMode mode in Enum.GetValues(typeof(TileItemImageScaleMode)))
                scaleGroup.Items.Add(Tile(mode.ToString(), new DxIcon("globe"), TileItemSize.Medium, mode));
            var pinnedGroup = new TileGroup { Text = "Pinned sizes / sets (provider ignored)" };
            pinnedGroup.Items.Add(Tile("Size12", new DxIcon("delete", size: IconSize.Size12), TileItemSize.Wide, TileItemImageScaleMode.NoScale));
            pinnedGroup.Items.Add(Tile("Size48", new DxIcon("delete", size: IconSize.Size48), TileItemSize.Small, TileItemImageScaleMode.NoScale));
            pinnedGroup.Items.Add(Tile("Classic", new DxIcon("mail", IconSet.DesktopClassic), TileItemSize.Medium, TileItemImageScaleMode.Default));
            pinnedGroup.Items.Add(Tile("Blazor", new DxIcon("mail", IconSet.BlazorClassic), TileItemSize.Medium, TileItemImageScaleMode.Default));
            pinnedGroup.Items.Add(Tile("Legacy", "Add;Size32x32", TileItemSize.Medium, TileItemImageScaleMode.Default));
            var multiGroup = new TileGroup { Text = "Multiple elements" };
            var multi = new TileItem { ItemSize = TileItemSize.Large };
            int index = 0;
            foreach(var (caption, icon) in IconCatalog.TypedIcons.Take(4)) {
                var element = new TileItemElement { Text = caption, ImageAlignment = TileItemContentAlignment.Manual, ImageLocation = new Point(10 + index * 50, 20), TextAlignment = TileItemContentAlignment.Manual, TextLocation = new Point(10 + index * 50, 70) };
                element.ImageUri = icon;
                multi.Elements.Add(element);
                index++;
            }
            tiles.Add(multi);
            multiGroup.Items.Add(multi);
            tileControl.Groups.Add(sizesGroup);
            tileControl.Groups.Add(scaleGroup);
            tileControl.Groups.Add(pinnedGroup);
            tileControl.Groups.Add(multiGroup);
            tileControl.EndUpdate();
            IconLog.Write($"Tiles rebuilt: {tiles.Count}");
        }

        TileItem Tile(string text, DxImageUri uri, TileItemSize size, TileItemImageScaleMode mode) {
            var tile = new TileItem { ItemSize = size, ImageScaleMode = mode };
            var element = new TileItemElement { Text = text, ImageAlignment = TileItemContentAlignment.MiddleCenter, TextAlignment = TileItemContentAlignment.BottomLeft };
            element.ImageUri = uri;
            tile.Elements.Add(element);
            tile.ItemClick += (s, e) => LogTile(tile);
            tiles.Add(tile);
            return tile;
        }

        static void LogTile(TileItem tile) {
            foreach(TileItemElement element in tile.Elements) {
                var provider = (IDXImageUriIconSizeProvider)element;
                IconLog.Write($"  tile {tile.ItemSize,-8} scale={tile.ImageScaleMode,-17} '{element.Text}': uri='{element.ImageUri.Uri}' preferred={provider.GetPreferredIconSize()} uri.GetSizeProviderPreferredIconSize={element.ImageUri.GetSizeProviderPreferredIconSize()} HasSvgImage={element.ImageUri.HasSvgImage}");
            }
        }

        void LogTileSizes() {
            foreach(var tile in tiles)
                LogTile(tile);
        }

        Control BuildImageListBox(ImageListBoxControl list, string caption, int unused) {
            foreach(var (name, icon) in IconCatalog.TypedIcons) {
                var item = new ImageListBoxItem(name);
                item.ImageOptions.ImageUri = icon;
                list.Items.Add(item);
            }
            var pinned = new ImageListBoxItem("pinned Size24");
            pinned.ImageOptions.ImageUri = new DxIcon("star", size: IconSize.Size24);
            list.Items.Insert(0, pinned);
            var legacy = new ImageListBoxItem("legacy Add;Size16x16");
            legacy.ImageOptions.ImageUri = "Add;Size16x16";
            list.Items.Insert(1, legacy);
            list.SelectedIndexChanged += (s, e) => {
                if(list.SelectedItem is ImageListBoxItem selected)
                    IconLog.Write($"{caption}: '{selected.Value}' uri='{selected.ImageOptions.ImageUri.Uri}' preferred={((IDXImageUriIconSizeProvider)list).GetPreferredIconSize()} HasSvgImage={selected.ImageOptions.ImageUri.HasSvgImage}");
            };
            return Section(caption, list, 280);
        }
    }

    public class LargeIconImageListBox : ImageListBoxControl {
        protected override Size GetPreferredIconSizeCore() => new Size(32, 32);
    }
}
