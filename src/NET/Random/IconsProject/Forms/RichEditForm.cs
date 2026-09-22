using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraRichEdit;
using IconsProject.Infrastructure;

namespace IconsProject.Forms {
    public class RichEditForm : RibbonForm {
        readonly RichEditControl richEdit;
        RibbonControl? ribbon;

        public RichEditForm() {
            Text = "RichEdit: command bars (CommandBasedBarItemGlyphHelper) + Fluent ruler";
            Size = new Size(1400, 900);
            StartPosition = FormStartPosition.CenterScreen;
            richEdit = new RichEditControl { Dock = DockStyle.Fill, ActiveViewType = RichEditViewType.PrintLayout };
            richEdit.Options.HorizontalRuler.Visibility = RichEditRulerVisibility.Visible;
            richEdit.Options.VerticalRuler.Visibility = RichEditRulerVisibility.Visible;
            richEdit.Text = "Command-based bar items resolve DefaultSvgImage through CommandBasedBarItemGlyphHelper.UpdateDefaultSvgImage: " +
                "when the active icon set changes, the helper reloads each item's SVG from the image provider by Command.ImageName. " +
                "Switch the icon mode from the 'Icon test' page and watch every tab of this ribbon. The ruler uses dedicated Fluent PNGs (Images/RulerFluent) — drag indents and tab stops.\r\n\r\n" +
                "Insert a table to see the table column/row border markers on the ruler.";
            Controls.Add(richEdit);
            BuildRibbon();
            IconModeSwitch.Changed += OnIconModeChanged;
        }

        void BuildRibbon() {
            if(ribbon != null) {
                Controls.Remove(ribbon);
                ribbon.Dispose();
            }
            ribbon = richEdit.CreateRibbon();
            Ribbon = ribbon;
            Controls.Add(ribbon);
            var page = new RibbonPage { Text = "Icon test" };
            var group = new RibbonPageGroup { Text = "Icon mode" };
            page.Groups.Add(group);
            foreach(IconMode mode in Enum.GetValues(typeof(IconMode))) {
                var item = new BarButtonItem { Caption = mode.ToString(), RibbonStyle = RibbonItemStyles.Large };
                item.ImageOptions.ImageUri = mode == IconMode.Fluent ? "star;Fluent" : mode == IconMode.Classic ? "star;Classic" : "star";
                item.ItemClick += (s, e) => IconModeSwitch.Apply(mode);
                ribbon.Items.Add(item);
                group.ItemLinks.Add(item);
            }
            var tools = new RibbonPageGroup { Text = "Tools" };
            page.Groups.Add(tools);
            var recreate = new BarButtonItem { Caption = "Recreate ribbon", RibbonStyle = RibbonItemStyles.Large };
            recreate.ImageOptions.ImageUri = "arrow_right";
            recreate.ItemClick += (s, e) => BeginInvoke(new Action(BuildRibbon));
            var dump = new BarButtonItem { Caption = "Dump command glyphs", RibbonStyle = RibbonItemStyles.Large };
            dump.ImageOptions.ImageUri = "info";
            dump.ItemClick += (s, e) => DumpGlyphs();
            var rtl = new BarButtonItem { Caption = "RTL", RibbonStyle = RibbonItemStyles.Large };
            rtl.ImageOptions.ImageUri = "arrow_left";
            rtl.ItemClick += (s, e) => {
                RightToLeft = RightToLeft == RightToLeft.Yes ? RightToLeft.No : RightToLeft.Yes;
                RightToLeftLayout = RightToLeft == RightToLeft.Yes;
            };
            ribbon.Items.AddRange(new BarItem[] { recreate, dump, rtl });
            tools.ItemLinks.Add(recreate);
            tools.ItemLinks.Add(dump);
            tools.ItemLinks.Add(rtl);
            ribbon.Pages.Insert(0, page);
            IconLog.Write($"RichEdit ribbon created: {ribbon.Items.Count} items | {IconModeSwitch.Describe()}");
        }

        void DumpGlyphs() {
            if(ribbon == null)
                return;
            int withDefaultSvg = 0, withSvg = 0, withImage = 0, none = 0;
            foreach(BarItem item in ribbon.Items) {
                var options = item.ImageOptions;
                if(options.DefaultSvgImage != null)
                    withDefaultSvg++;
                else if(options.SvgImage != null)
                    withSvg++;
                else if(options.Image != null || options.LargeImage != null)
                    withImage++;
                else
                    none++;
            }
            IconLog.Write($"RichEdit ribbon glyphs: DefaultSvgImage={withDefaultSvg} SvgImage={withSvg} raster={withImage} none={none} | {IconModeSwitch.Describe()}");
        }

        void OnIconModeChanged(object? sender, EventArgs e) {
            if(IsDisposed)
                return;
            richEdit.Refresh();
            ribbon?.Refresh();
        }

        protected override void Dispose(bool disposing) {
            if(disposing)
                IconModeSwitch.Changed -= OnIconModeChanged;
            base.Dispose(disposing);
        }
    }
}
