using DevExpress.Data.Utils.Images;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using IconsProject.Infrastructure;
using DxIcon = DevExpress.Data.Utils.Images.Icon;

namespace IconsProject.Forms {
    public class HubForm : RibbonForm {
        public sealed class Entry {
            public Entry(string title, string description, DxIcon icon, Func<Form> create) {
                Title = title;
                Description = description;
                Icon = icon;
                Create = create;
            }
            public string Title { get; }
            public string Description { get; }
            public DxIcon Icon { get; }
            public Func<Form> Create { get; }
        }

        public static readonly Entry[] Entries = {
            new Entry("Automated checks", "Pass/fail grid over the public API and the #48050 contract", new DxIcon("checkmark"), () => new AutomatedChecksForm()),
            new Entry("#48050 HasSvgImage", "StackOverflow regression scenarios and control stress", new DxIcon("alert"), () => new Bugfix48050Form()),
            new Entry("Icon builder", "Compose / parse an Icon, see what DxImageUri and the provider resolve", new DxIcon("key"), () => new IconBuilderForm()),
            new Entry("Axis matrix", "Set × Style × Color × Size for one id", new DxIcon("table"), () => new IconMatrixForm()),
            new Entry("Icons browser", "All generated Icons in a GalleryControl, size from Gallery.ImageSize", new DxIcon("image"), () => new IconBrowserForm()),
            new Entry("Ribbon & bars", "Ribbon pages of typed/pinned/legacy/edge uris, menus, galleries, BarManager", new DxIcon("home"), () => new RibbonBarsForm()),
            new Entry("Editors", "SimpleButton, ButtonEdit, CheckEdit SVG styles, context images, per-editor skins", new DxIcon("document"), () => new EditorsForm()),
            new Entry("Tiles & lists", "TileControl and ImageListBox size providers", new DxIcon("calendar"), () => new TileAndListsForm()),
            new Entry("SVG resources", "SvgImageCollection tracking and IResourceSvgImageFactory", new DxIcon("folder"), () => new SvgResourcesForm()),
            new Entry("Grid & TreeList", "Built-in menus, filter editor, formatting, print preview", new DxIcon("filter_funnel"), () => new GridTreeForm()),
            new Entry("RichEdit", "Command-based ribbon glyphs and the Fluent ruler", new DxIcon("document"), () => new RichEditForm()),
            new Entry("Navigation & layout", "Accordion, NavBar, tabs, TabPane, LayoutControl", new DxIcon("arrow_right"), () => new NavigationForm()),
            new Entry("Context & threads", "IconSetContext scopes, per-control LookAndFeel, UI/background threads", new DxIcon("globe"), () => new ContextAndThreadsForm()),
            new Entry("Original Form1", "The designer-made form this project started with", new DxIcon("star"), () => new Form1())
        };

        readonly RibbonControl ribbon;
        readonly BarStaticItem statusItem;
        readonly MemoEdit logMemo;
        readonly BarCheckItem[] modeItems;

        public HubForm() {
            Text = "Fluent icons test hub";
            Size = new Size(1200, 760);
            StartPosition = FormStartPosition.CenterScreen;
            ribbon = new RibbonControl { ShowApplicationButton = DefaultBoolean.False };
            Ribbon = ribbon;
            var statusBar = new RibbonStatusBar { Ribbon = ribbon };
            StatusBar = statusBar;

            var page = new RibbonPage { Text = "Icons" };
            ribbon.Pages.Add(page);
            var modeGroup = new RibbonPageGroup { Text = "Icon mode (WindowsFormsSettings)" };
            page.Groups.Add(modeGroup);
            modeItems = Enum.GetValues(typeof(IconMode)).Cast<IconMode>().Select(mode => {
                var item = new BarCheckItem { Caption = mode.ToString(), GroupIndex = 1, RibbonStyle = RibbonItemStyles.Large, Checked = mode == IconModeSwitch.Mode, Tag = mode };
                item.ImageOptions.ImageUri = mode == IconMode.Fluent ? new DxIcon("star", IconSet.Fluent) : mode == IconMode.Classic ? new DxIcon("star", IconSet.Classic) : new DxIcon("star");
                item.ItemClick += (s, e) => IconModeSwitch.Apply(mode);
                ribbon.Items.Add(item);
                modeGroup.ItemLinks.Add(item);
                return item;
            }).ToArray();

            var skinGroup = new RibbonPageGroup { Text = "Skin" };
            page.Groups.Add(skinGroup);
            var skinGallery = new SkinRibbonGalleryBarItem();
            ribbon.Items.Add(skinGallery);
            skinGroup.ItemLinks.Add(skinGallery);
            var paletteGallery = new SkinPaletteRibbonGalleryBarItem();
            ribbon.Items.Add(paletteGallery);
            skinGroup.ItemLinks.Add(paletteGallery);

            var formsGroup = new RibbonPageGroup { Text = "Test forms" };
            page.Groups.Add(formsGroup);
            foreach(var entry in Entries) {
                var item = new BarButtonItem { Caption = entry.Title, RibbonStyle = RibbonItemStyles.Large };
                item.ImageOptions.ImageUri = entry.Icon;
                item.SuperTip = new SuperToolTip();
                item.SuperTip.Items.AddTitle(entry.Title);
                item.SuperTip.Items.Add(entry.Description);
                item.ItemClick += (s, e) => Open(entry);
                ribbon.Items.Add(item);
                formsGroup.ItemLinks.Add(item);
            }
            var allGroup = new RibbonPageGroup { Text = "Batch" };
            page.Groups.Add(allGroup);
            var openAll = new BarButtonItem { Caption = "Open all", RibbonStyle = RibbonItemStyles.Large };
            openAll.ImageOptions.ImageUri = new DxIcon("copy");
            openAll.ItemClick += (s, e) => {
                foreach(var entry in Entries.Where(x => x.Title != "Original Form1"))
                    Open(entry);
            };
            var cycleAll = new BarButtonItem { Caption = "Cycle modes on all open forms", RibbonStyle = RibbonItemStyles.Large };
            cycleAll.ImageOptions.ImageUri = new DxIcon("arrow_right");
            cycleAll.ItemClick += (s, e) => CycleModes();
            ribbon.Items.AddRange(new BarItem[] { openAll, cycleAll });
            allGroup.ItemLinks.Add(openAll);
            allGroup.ItemLinks.Add(cycleAll);

            statusItem = new BarStaticItem();
            ribbon.Items.Add(statusItem);
            statusBar.ItemLinks.Add(statusItem);

            logMemo = new MemoEdit { Dock = DockStyle.Fill };
            logMemo.Properties.ReadOnly = true;
            logMemo.Properties.WordWrap = false;
            logMemo.Properties.ScrollBars = ScrollBars.Both;
            logMemo.Font = new Font("Consolas", 9f);
            Controls.Add(logMemo);
            Controls.Add(statusBar);
            Controls.Add(ribbon);

            IconLog.Logged += OnLogged;
            IconModeSwitch.Changed += OnModeChanged;
            UserLookAndFeel.Default.StyleChanged += OnModeChanged;
            Shown += (s, e) => {
                foreach(string line in IconLog.Snapshot())
                    logMemo.MaskBox.AppendText(line + Environment.NewLine);
            };
            UpdateStatus();
        }

        void Open(Entry entry) {
            try {
                var form = entry.Create();
                form.Show();
                IconLog.Write($"Opened '{entry.Title}'");
            }
            catch(Exception ex) {
                IconLog.Error($"open {entry.Title}", ex);
            }
        }

        static void CycleModes() {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            IconMode original = IconModeSwitch.Mode;
            foreach(IconMode mode in new[] { IconMode.Fluent, IconMode.Classic, IconMode.ThemeBased, IconMode.Fluent, IconMode.Classic }) {
                IconModeSwitch.Apply(mode);
                foreach(Form form in Application.OpenForms.Cast<Form>().ToArray())
                    form.Refresh();
                Application.DoEvents();
            }
            IconModeSwitch.Apply(original);
            IconLog.Write($"Cycled 5 modes over {Application.OpenForms.Count} open forms in {watch.ElapsedMilliseconds} ms");
        }

        void OnModeChanged(object? sender, EventArgs e) {
            foreach(var item in modeItems)
                item.Checked = (IconMode)item.Tag == IconModeSwitch.Mode;
            UpdateStatus();
        }

        void UpdateStatus() {
            statusItem.Caption = $"Mode={IconModeSwitch.Mode} | {IconModeSwitch.Describe()}";
        }

        void OnLogged(string line) {
            if(IsDisposed || !IsHandleCreated)
                return;
            BeginInvoke(new Action(() => logMemo.MaskBox.AppendText(line + Environment.NewLine)));
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                IconLog.Logged -= OnLogged;
                IconModeSwitch.Changed -= OnModeChanged;
                UserLookAndFeel.Default.StyleChanged -= OnModeChanged;
            }
            base.Dispose(disposing);
        }
    }
}
