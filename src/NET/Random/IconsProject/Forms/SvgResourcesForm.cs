using DevExpress.IconLibrary;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using IconsProject.Infrastructure;

namespace IconsProject.Forms {
    public class SvgResourcesForm : TestFormBase {
        const string CheckEditBase = "DevExpress.XtraEditors.Images.SVG.CheckEdit";
        const string EditorsSvgBase = "DevExpress.XtraEditors.Images.SVG";
        readonly ImageListBoxControl collectionList;
        readonly ImageComboBoxEdit collectionSizeEdit;
        readonly ComboBoxEdit baseNameEdit;
        readonly TableLayoutPanel factoryTable;
        SvgImageCollection? collection;

        public SvgResourcesForm()
            : base("SvgImageCollection tracking + IResourceSvgImageFactory",
                  "SvgImageCollection.FromResources(base, assembly) on a DevExpress assembly while the active set is not Default loads every image through the provider and remembers the resource name; changing ImageSize re-resolves them (OnSizeChanged). " +
                  "Under Theme-based mode the collection is NOT tracked (plain manifest load). The factory table calls ResourceImageHelper.CreateSvgImageFromResources(name, asm[, iconSet], sizeProvider) for mapped built-in resources.") {
            var top = new FlowLayoutPanel();
            baseNameEdit = new ComboBoxEdit { Width = 360, EditValue = CheckEditBase };
            baseNameEdit.Properties.Items.AddRange(new[] { CheckEditBase, EditorsSvgBase, "DevExpress.XtraEditors.FormatRule.SVG.MenuImages", "DevExpress.XtraEditors.FilterEditor.Images.ClauseSvgImages" });
            collectionSizeEdit = new ImageComboBoxEdit { Width = 90 };
            foreach(int s in new[] { 12, 16, 20, 24, 32, 48 })
                collectionSizeEdit.Properties.Items.Add(new ImageComboBoxItem($"{s}px", s));
            collectionSizeEdit.EditValue = 16;
            collectionSizeEdit.EditValueChanged += (s, e) => ApplyCollectionSize();
            top.Controls.AddRange(new Control[] { Caption("Resource base", 90), baseNameEdit, Caption("ImageSize", 70), collectionSizeEdit });
            AddToolbarButton(top, "Create collection (FromResources)", (s, e) => CreateCollection());
            AddToolbarButton(top, "Create (whole assembly)", (s, e) => CreateCollection(wholeAssembly: true));

            collectionList = new ImageListBoxControl { ItemHeight = 52 };

            factoryTable = new TableLayoutPanel { AutoSize = true, CellBorderStyle = TableLayoutPanelCellBorderStyle.Single, Dock = DockStyle.Top };
            var factoryHost = new XtraScrollableControl();
            factoryHost.Controls.Add(factoryTable);
            var factoryActions = new FlowLayoutPanel();
            AddToolbarButton(factoryActions, "Rebuild factory table", (s, e) => BuildFactoryTable());

            AddSections(
                Section("SvgImageCollection", top, 80),
                Section("Collection contents", collectionList, 280),
                Section("Factory", factoryActions, 60),
                Section("ResourceImageHelper.CreateSvgImageFromResources", factoryHost, 360));
            CreateCollection();
            BuildFactoryTable();
        }

        void CreateCollection(bool wholeAssembly = false) {
            var assembly = typeof(CheckEdit).Assembly;
            collection?.Dispose();
            collection = wholeAssembly ? SvgImageCollection.FromResources(assembly) : SvgImageCollection.FromResources(baseNameEdit.Text, assembly);
            collectionList.Items.Clear();
            collectionList.ImageList = collection;
            for(int i = 0; i < collection.Count && i < 400; i++)
                collectionList.Items.Add(new ImageListBoxItem(collection.ImageInfos[i].Name ?? i.ToString(), i));
            IconLog.Write($"SvgImageCollection.FromResources({(wholeAssembly ? "assembly" : baseNameEdit.Text)}): {collection.Count} images, ImageSize={collection.ImageSize} | active set={IconModeSwitch.ActiveForDefaultLookAndFeel} => tracked={IconModeSwitch.ActiveForDefaultLookAndFeel != IconSet.Default}");
            ApplyCollectionSize();
        }

        void ApplyCollectionSize() {
            if(collection == null)
                return;
            int size = (int)collectionSizeEdit.EditValue;
            collection.ImageSize = new Size(size, size);
            collectionList.Refresh();
            IconLog.Write($"SvgImageCollection.ImageSize -> {size} (tracked collections re-resolve through the provider)");
        }

        void BuildFactoryTable() {
            factoryTable.SuspendLayout();
            foreach(Control c in factoryTable.Controls.Cast<Control>().ToArray())
                c.Dispose();
            factoryTable.Controls.Clear();
            var assembly = typeof(CheckEdit).Assembly;
            string[] names = assembly.GetManifestResourceNames()
                .Where(n => n.EndsWith(".svg", StringComparison.OrdinalIgnoreCase) && (n.StartsWith(CheckEditBase + ".SvgStar1", StringComparison.Ordinal) || n.StartsWith(CheckEditBase + ".SvgLock1", StringComparison.Ordinal) || n.StartsWith(EditorsSvgBase + ".Find", StringComparison.Ordinal) || n.StartsWith(EditorsSvgBase + ".Info", StringComparison.Ordinal) || n.StartsWith(EditorsSvgBase + ".Warning", StringComparison.Ordinal)))
                .Take(10)
                .ToArray();
            var variants = new (string Caption, Func<string, SvgImage?> Load)[] {
                ("(name, asm)", n => ResourceImageHelper.CreateSvgImageFromResources(n, assembly)),
                ("size 16", n => ResourceImageHelper.CreateSvgImageFromResources(n, assembly, new FixedSize(16))),
                ("size 32", n => ResourceImageHelper.CreateSvgImageFromResources(n, assembly, new FixedSize(32))),
                ("Fluent", n => ResourceImageHelper.CreateSvgImageFromResources(n, assembly, IconSet.Fluent, new FixedSize(16))),
                ("Classic", n => ResourceImageHelper.CreateSvgImageFromResources(n, assembly, IconSet.DesktopClassic, new FixedSize(16))),
                ("Blazor", n => ResourceImageHelper.CreateSvgImageFromResources(n, assembly, IconSet.BlazorClassic, new FixedSize(16))),
                ("Default", n => ResourceImageHelper.CreateSvgImageFromResources(n, assembly, IconSet.Default, new FixedSize(16))),
                ("raw stream", n => {
                    using var stream = assembly.GetManifestResourceStream(n);
                    return stream == null ? null : SvgImage.FromStream(stream);
                })
            };
            factoryTable.ColumnCount = variants.Length + 1;
            factoryTable.Controls.Add(Caption("resource", 330), 0, 0);
            for(int c = 0; c < variants.Length; c++)
                factoryTable.Controls.Add(Caption(variants[c].Caption, 70), c + 1, 0);
            int row = 1;
            foreach(string name in names) {
                factoryTable.Controls.Add(Caption(name.Replace("DevExpress.XtraEditors.Images.SVG.", string.Empty), 330), 0, row);
                for(int c = 0; c < variants.Length; c++) {
                    SvgImage? svg = null;
                    try {
                        svg = variants[c].Load(name);
                    }
                    catch(Exception ex) {
                        IconLog.Error($"factory {variants[c].Caption} {name}", ex);
                    }
                    var picture = new PictureEdit { Size = new Size(60, 44), SvgImage = svg, ToolTip = svg == null ? "null" : $"{svg.Width:0}x{svg.Height:0}" };
                    picture.Properties.SizeMode = PictureSizeMode.Clip;
                    picture.Properties.SvgImageSize = new Size(24, 24);
                    if(svg == null)
                        picture.BackColor = Color.MistyRose;
                    factoryTable.Controls.Add(picture, c + 1, row);
                }
                row++;
            }
            factoryTable.RowCount = row;
            factoryTable.ResumeLayout();
            IconLog.Write($"Factory table: {names.Length} resources x {variants.Length} variants | {IconModeSwitch.Describe()}");
        }

        protected override void OnIconModeChanged() {
            IconLog.Write("Icon mode changed: the existing collection keeps its tracking decision; press 'Create collection' to re-evaluate, or change ImageSize to re-resolve a tracked one.");
        }

        sealed class FixedSize : IDXImageUriIconSizeProvider {
            readonly int size;
            public FixedSize(int size) {
                this.size = size;
            }
            public Size GetPreferredIconSize() => new Size(size, size);
        }
    }
}
