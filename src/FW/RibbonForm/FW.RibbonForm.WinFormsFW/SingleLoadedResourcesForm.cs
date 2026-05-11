using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Images;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace FW.RibbonForm.WinFormsFW {
    public partial class SingleLoadedResourcesForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        PanelControl scrollPanelRef;

        static readonly Assembly utilsAsm = typeof(ResourceImageHelper).Assembly;
        static readonly Assembly barsAsm = typeof(RibbonControl).Assembly;
        static readonly Assembly editorsAsm = typeof(SimpleButton).Assembly;
        static readonly Assembly dataDesktopAsm = typeof(DevExpress.Data.Images.AIImageResources).Assembly;

        // Resources with known fluent mappings (Search→search, Settings→settings-gear)
        static readonly ResourceEntry[] mappedResources = {
            new ResourceEntry("DevExpress.XtraBars.Images.SkinSearch.svg", "Search", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.Settings.svg", "Settings", () => barsAsm),
        };

        // Resources WITHOUT fluent mappings — should always show classic
        static readonly ResourceEntry[] unmappedResources = {
            new ResourceEntry("DevExpress.Data.Images.SVG.AI.AI.svg", "AI", () => dataDesktopAsm),
            new ResourceEntry("DevExpress.Data.Images.SVG.AI.AISparkle.svg", "AISparkle", () => dataDesktopAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.ApplicationButton2007.svg", "AppBtn07", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.RibbonApplication.svg", "RibbonApp", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.AddPage.svg", "AddPage", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.AddPageGroup.svg", "AddGroup", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Ribbon.Images.FullScreen.svg", "FullScreen", () => barsAsm),
            new ResourceEntry("DevExpress.XtraEditors.Images.SVG.SecurityNotice.svg", "Security", () => editorsAsm),
        };

        // All resources combined
        static ResourceEntry[] AllResources {
            get {
                var all = new ResourceEntry[mappedResources.Length + unmappedResources.Length];
                mappedResources.CopyTo(all, 0);
                unmappedResources.CopyTo(all, mappedResources.Length);
                return all;
            }
        }

        public SingleLoadedResourcesForm() {
            InitializeComponent();
            BuildUI();
        }

        void BuildUI() {
            Text = "Single-Loaded Resources Test — " + WindowsFormsSettings.ActiveIconSet;
            ClientSize = new Size(1400, 900);

            var ribbon = new RibbonControl();
            ribbon.ShowApplicationButton = DefaultBoolean.False;
            Controls.Add(ribbon);
            Ribbon = ribbon;

            var page = new RibbonPage("Loading Approaches");
            ribbon.Pages.Add(page);

            var groupUri = new RibbonPageGroup("DxImageUri (baseline)");
            string[] uriIcons = { "save", "edit", "delete", "copy", "print", "filter" };
            foreach(var name in uriIcons) {
                var item = new BarButtonItem { Caption = "Uri:" + name };
                item.ImageOptions.ImageUri.Uri = name;
                ribbon.Items.Add(item);
                groupUri.ItemLinks.Add(item);
            }
            page.Groups.Add(groupUri);

            var groupActions = new RibbonPageGroup("Actions");
            var screenshotItem = new BarButtonItem { Caption = "Screenshot All" };
            screenshotItem.ImageOptions.ImageUri.Uri = "print";
            screenshotItem.ItemClick += (s, e) => CaptureFullScreenshot();
            ribbon.Items.Add(screenshotItem);
            groupActions.ItemLinks.Add(screenshotItem);
            page.Groups.Add(groupActions);

            scrollPanelRef = new PanelControl { Dock = DockStyle.Fill, AutoScroll = true };
            Controls.Add(scrollPanelRef);
            scrollPanelRef.BringToFront();

            RebuildContent(ribbon);
        }

        void CaptureFullScreenshot() {
            if(scrollPanelRef.Controls.Count == 0) return;
            var layout = scrollPanelRef.Controls[0] as FlowLayoutPanel;
            if(layout == null) return;

            // Temporarily expand layout to full preferred size to render all content
            var originalDock = layout.Dock;
            var originalAutoScroll = layout.AutoScroll;
            var originalSize = layout.Size;

            layout.AutoScroll = false;
            layout.Dock = DockStyle.None;
            var fullSize = layout.GetPreferredSize(new Size(layout.Width, 0));
            fullSize.Width = Math.Max(fullSize.Width, layout.Width);
            layout.Size = fullSize;

            using(var bmp = new Bitmap(fullSize.Width, fullSize.Height)) {
                layout.DrawToBitmap(bmp, new Rectangle(Point.Empty, fullSize));

                // Restore layout
                layout.Dock = originalDock;
                layout.AutoScroll = originalAutoScroll;
                layout.Size = originalSize;

                var path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"SingleLoadedResources_{WindowsFormsSettings.ActiveIconSet}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                MessageBox.Show($"Screenshot saved to:\n{path}", "Screenshot", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void RebuildContent(RibbonControl ribbon) {
            scrollPanelRef.Controls.Clear();
            var layout = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(10) };
            scrollPanelRef.Controls.Add(layout);

            AddSettingsControls(layout, ribbon);
            AddSeparator(layout);

            // === SECTION 1: DxImageUri ===
            AddSectionLabel(layout, "1. DxImageUri — gold standard pipeline (ImageResourceCache)");
            AddInfoLabel(layout, "OLD: fluent | NEW: fluent | No change needed.");
            AddDxImageUriSection(layout);
            AddSeparator(layout);

            // === SECTION 2: SvgImageCollection.FromResources ===
            AddSectionLabel(layout, "2. SvgImageCollection.FromResources — bulk load from assembly prefix");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent if mapped (ShouldTrackImages + LoadFromProvider)");
            AddSvgImageCollectionSection(layout);
            AddSeparator(layout);

            // === SECTION 3: SvgImage.FromResources — MAPPED icons ===
            AddSectionLabel(layout, "3a. SvgImage.FromResources — MAPPED icons (Search, Settings)");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent (factory intercepts → MappedOthersSvg.cs lookup)");
            AddFromResourcesMappedSection(layout);
            AddSeparator(layout);

            // === SECTION 3b: SvgImage.FromResources — UNMAPPED icons ===
            AddSectionLabel(layout, "3b. SvgImage.FromResources — UNMAPPED icons (no fluent equivalent)");
            AddInfoLabel(layout, "OLD: classic | NEW: classic (factory returns null → fallback to raw resource)");
            AddFromResourcesUnmappedSection(layout);
            AddSeparator(layout);

            // === SECTION 4a: FromStream(ref cache, name, asm) — already intercepted ===
            AddSectionLabel(layout, "4a. FromStream(ref cache, name, asm) — 7 sites, already intercepted");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent if mapped (Approach C patches this variant)");
            AddFromStreamRefCacheSection(layout);
            AddSeparator(layout);

            // === SECTION 4b: FromStream(stream) — refactored to FromResources ===
            AddSectionLabel(layout, "4b. Raw FromStream → refactored to FromResources — 12 sites");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent if mapped (call sites changed to FromResources)");
            AddInfoLabel(layout, "Pattern: asm.GetManifestResourceStream(name) → FromStream(stream) BECAME FromResources(name, asm)");
            AddFromStreamRefactoredSection(layout);
            AddSeparator(layout);

            // === SECTION 4c: FromStream(stream) — still raw (un-interceptable) ===
            AddSectionLabel(layout, "4c. Raw FromStream — still un-intercepted (14 dynamic + 10 remaining)");
            AddInfoLabel(layout, "OLD: classic | NEW: classic (no name context, raw stream always bypasses factory)");
            AddFromStreamRawSection(layout);
            AddSeparator(layout);

            // === SECTION 5: new SvgImage(type, resource) ===
            AddSectionLabel(layout, "5. new SvgImage(type, resource) — 3 sites, manually fixed");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent if mapped (Approach C converts to ResourceImageHelper)");
            AddDirectConstructorSection(layout);
            AddSeparator(layout);

            // === SECTION 6: ResourceImageHelper.CreateSvgImageFromResources ===
            AddSectionLabel(layout, "6. ResourceImageHelper.CreateSvgImageFromResources — factory-based");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent if mapped (WindowsSvgImageFactory registered)");
            AddResourceImageHelperSection(layout);
            AddSeparator(layout);

            // === SECTION 7: SvgBitmap comparison ===
            AddSectionLabel(layout, "7. SvgBitmap — upstream-dependent rendering");
            AddInfoLabel(layout, "Renders whatever SvgImage it gets. Compare FromResources (patched) vs FromStream (raw).");
            AddSvgBitmapSection(layout);
            AddSeparator(layout);

            // === SECTION 8: ImageResourceCache ===
            AddSectionLabel(layout, "8. ImageResourceCache.GetSvgImageById — packed DX.Images");
            AddInfoLabel(layout, "OLD: fluent | NEW: fluent | Same pipeline as DxImageUri.");
            AddImageCacheSection(layout);
        }

        // ========== 1. DxImageUri ==========
        void AddDxImageUriSection(FlowLayoutPanel layout) {
            string[] icons = { "save", "edit", "delete", "copy", "print", "filter", "calendar", "link", "search", "settings-gear" };
            foreach(var name in icons) {
                var btn = CreateButton(name, 140);
                btn.ImageOptions.ImageUri.Uri = name;
                btn.ImageOptions.SvgImageSize = new Size(20, 20);
                layout.Controls.Add(btn);
            }
        }

        // ========== 2. SvgImageCollection.FromResources ==========
        void AddSvgImageCollectionSection(FlowLayoutPanel layout) {
            try {
                var collection = SvgImageCollection.FromResources("DevExpress.XtraBars.Images", barsAsm);
                AddInfoLabel(layout, "Loaded " + collection.Count + " from XtraBars.Images");
                int count = 0;
                foreach(string key in collection.Keys) {
                    if(count >= 10) break;
                    var btn = CreateButton("Col:" + key, 160);
                    btn.ImageOptions.SvgImage = collection[key];
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                    layout.Controls.Add(btn);
                    count++;
                }
            }
            catch(Exception ex) {
                AddInfoLabel(layout, "ERROR: " + ex.Message);
            }
        }

        // ========== 3a. FromResources — MAPPED ==========
        void AddFromResourcesMappedSection(FlowLayoutPanel layout) {
            foreach(var entry in mappedResources) {
                var btn = CreateButton("FR:" + entry.ShortName, 150);
                SvgImage svg = SvgImage.FromResources(entry.ResourceName, entry.Assembly);
                if(svg != null) {
                    btn.ImageOptions.SvgImage = svg;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
            AddInfoLabel(layout, "↑ With new build: should show FLUENT icons (thin lines, different shape than section 4c)");
        }

        // ========== 3b. FromResources — UNMAPPED ==========
        void AddFromResourcesUnmappedSection(FlowLayoutPanel layout) {
            foreach(var entry in unmappedResources) {
                var btn = CreateButton("FR:" + entry.ShortName, 150);
                SvgImage svg = SvgImage.FromResources(entry.ResourceName, entry.Assembly);
                if(svg != null) {
                    btn.ImageOptions.SvgImage = svg;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
            AddInfoLabel(layout, "↑ Always classic — no fluent mapping exists for these icons.");
        }

        // ========== 4a. FromStream(ref cache) — intercepted ==========
        void AddFromStreamRefCacheSection(FlowLayoutPanel layout) {
            // Simulates: SvgImage.FromStream(ref svgImageCache, resourceName, assembly)
            // This is the pattern used by DashboardCommand, PdfViewerCommand, ChartCommand, etc.
            Dictionary<string, ISvgImage> cache = null;
            foreach(var entry in mappedResources) {
                var btn = CreateButton("RefCache:" + entry.ShortName, 180);
                ISvgImage svg = SvgImage.FromStream(ref cache, entry.ResourceName, entry.Assembly);
                if(svg != null) {
                    btn.ImageOptions.SvgImage = svg as SvgImage;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
            foreach(var entry in unmappedResources) {
                var btn = CreateButton("RefCache:" + entry.ShortName, 180);
                ISvgImage svg = SvgImage.FromStream(ref cache, entry.ResourceName, entry.Assembly);
                if(svg != null) {
                    btn.ImageOptions.SvgImage = svg as SvgImage;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
            AddInfoLabel(layout, "↑ With new build: mapped icons should be FLUENT (factory intercepts before stream load)");
        }

        // ========== 4b. FromStream refactored (simulates the fix) ==========
        void AddFromStreamRefactoredSection(FlowLayoutPanel layout) {
            // BEFORE: stream = asm.GetManifestResourceStream(name); svg = SvgImage.FromStream(stream);
            // AFTER:  svg = SvgImage.FromResources(name, asm);
            // Here we show BOTH so you can compare:
            AddInfoLabel(layout, "LEFT = old pattern (FromStream), RIGHT = new pattern (FromResources):");
            foreach(var entry in mappedResources) {
                // OLD way
                var btnOld = CreateButton("OLD:" + entry.ShortName, 150);
                Stream stream = entry.Assembly.GetManifestResourceStream(entry.ResourceName);
                if(stream != null) {
                    SvgImage svg = SvgImage.FromStream(stream);
                    btnOld.ImageOptions.SvgImage = svg;
                    btnOld.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                else btnOld.Text += " ✗";
                layout.Controls.Add(btnOld);

                // NEW way
                var btnNew = CreateButton("NEW:" + entry.ShortName, 150);
                SvgImage svgNew = SvgImage.FromResources(entry.ResourceName, entry.Assembly);
                if(svgNew != null) {
                    btnNew.ImageOptions.SvgImage = svgNew;
                    btnNew.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                else btnNew.Text += " ✗";
                layout.Controls.Add(btnNew);
            }
            AddInfoLabel(layout, "↑ With new build: OLD=classic, NEW=fluent (proves the refactoring works)");
        }

        // ========== 4c. FromStream — still raw ==========
        void AddFromStreamRawSection(FlowLayoutPanel layout) {
            // This pattern CANNOT be intercepted — raw stream, no name context
            foreach(var entry in AllResources) {
                var btn = CreateButton("Raw:" + entry.ShortName, 150);
                Stream stream = entry.Assembly.GetManifestResourceStream(entry.ResourceName);
                if(stream != null) {
                    SvgImage svg = SvgImage.FromStream(stream);
                    btn.ImageOptions.SvgImage = svg;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
            AddInfoLabel(layout, "↑ ALWAYS classic — no way to intercept raw stream. Compare with 3a to see the difference.");
        }

        // ========== 5. new SvgImage(type, resource) ==========
        void AddDirectConstructorSection(FlowLayoutPanel layout) {
            string[][] pairs = {
                new[] { "Images.SkinSearch.svg", "Search" },
                new[] { "Images.Settings.svg", "Settings" },
                new[] { "Images.AddPage.svg", "AddPage" },
            };
            foreach(var pair in pairs) {
                // OLD: new SvgImage(type, resource)
                var btnOld = CreateButton("Ctor:" + pair[1], 150);
                try {
                    SvgImage svg = new SvgImage(typeof(RibbonControl), pair[0]);
                    btnOld.ImageOptions.SvgImage = svg;
                    btnOld.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                catch { btnOld.Text += " ✗"; btnOld.Appearance.ForeColor = Color.Red; }
                layout.Controls.Add(btnOld);

                // NEW: ResourceImageHelper (what Approach C converts these to)
                string fullName = "DevExpress.XtraBars." + pair[0];
                var btnNew = CreateButton("Fixed:" + pair[1], 150);
                SvgImage svgNew = ResourceImageHelper.CreateSvgImageFromResources(fullName, barsAsm);
                if(svgNew != null) {
                    btnNew.ImageOptions.SvgImage = svgNew;
                    btnNew.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                else { btnNew.Text += " ✗"; btnNew.Appearance.ForeColor = Color.Red; }
                layout.Controls.Add(btnNew);
            }
            AddInfoLabel(layout, "↑ Ctor = always classic. Fixed = fluent if mapped (Search, Settings should differ).");
        }

        // ========== 6. ResourceImageHelper ==========
        void AddResourceImageHelperSection(FlowLayoutPanel layout) {
            foreach(var entry in AllResources) {
                var btn = CreateButton("RIH:" + entry.ShortName, 150);
                SvgImage svg = ResourceImageHelper.CreateSvgImageFromResources(entry.ResourceName, entry.Assembly);
                if(svg != null) {
                    btn.ImageOptions.SvgImage = svg;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
            AddInfoLabel(layout, "↑ Same behavior as 3a/3b — goes through WindowsSvgImageFactory.");
        }

        // ========== 7. SvgBitmap comparison ==========
        void AddSvgBitmapSection(FlowLayoutPanel layout) {
            // Compare rendered bitmaps for mapped icon (Search)
            var entry = mappedResources[0]; // SkinSearch
            
            // Via FromResources (patched path)
            SvgImage svgPatched = SvgImage.FromResources(entry.ResourceName, entry.Assembly);
            if(svgPatched != null) {
                var bmp = new SvgBitmap(svgPatched);
                var rendered = bmp.Render(new Size(32, 32), null);
                var btn = CreateButton("Patched:" + entry.ShortName, 200);
                btn.ImageOptions.Image = rendered;
                layout.Controls.Add(btn);
            }

            // Via raw stream (always classic)
            Stream stream = entry.Assembly.GetManifestResourceStream(entry.ResourceName);
            if(stream != null) {
                SvgImage svgRaw = SvgImage.FromStream(stream);
                var bmp = new SvgBitmap(svgRaw);
                var rendered = bmp.Render(new Size(32, 32), null);
                var btn = CreateButton("Raw:" + entry.ShortName, 200);
                btn.ImageOptions.Image = rendered;
                layout.Controls.Add(btn);
            }

            // Via DxImageUri equivalent (gold standard)
            SvgImage svgCache = DxImageAssemblyUtil.ImageProvider.GetSvgImage("search");
            if(svgCache != null) {
                var bmp = new SvgBitmap(svgCache);
                var rendered = bmp.Render(new Size(32, 32), null);
                var btn = CreateButton("Cache:search", 200);
                btn.ImageOptions.Image = rendered;
                layout.Controls.Add(btn);
            }

            AddInfoLabel(layout, "↑ With new build: Patched should match Cache (both fluent). Raw = classic.");
        }

        // ========== 8. ImageResourceCache ==========
        void AddImageCacheSection(FlowLayoutPanel layout) {
            string[] imageIds = { "save", "edit", "delete", "copy", "print", "filter", "search", "settings-gear", "find", "undo" };
            foreach(var id in imageIds) {
                var btn = CreateButton("Cache:" + id, 140);
                SvgImage svg = DxImageAssemblyUtil.ImageProvider.GetSvgImage(id);
                if(svg != null) {
                    btn.ImageOptions.SvgImage = svg;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
        }

        // ========== Settings controls ==========
        void AddSettingsControls(FlowLayoutPanel layout, RibbonControl ribbon) {
            AddSectionLabel(layout, "Runtime Settings");

            var toggleBtn = new SimpleButton {
                Text = "IconSet: " + WindowsFormsSettings.ActiveIconSet,
                Width = 200, Height = 40
            };
            toggleBtn.Click += (s, e) => {
                var values = (IconSet[])Enum.GetValues(typeof(IconSet));
                int idx = Array.IndexOf(values, WindowsFormsSettings.ActiveIconSet);
                WindowsFormsSettings.ActiveIconSet = values[(idx + 1) % values.Length];
                toggleBtn.Text = "IconSet: " + WindowsFormsSettings.ActiveIconSet;
                Text = "Single-Loaded Resources Test — " + WindowsFormsSettings.ActiveIconSet
                    + " / " + WindowsFormsSettings.IconStyle;
                RefreshAllIcons(ribbon);
            };
            layout.Controls.Add(toggleBtn);

            var styleBtn = new SimpleButton {
                Text = "Style: " + WindowsFormsSettings.IconStyle,
                Width = 200, Height = 40
            };
            styleBtn.Click += (s, e) => {
                WindowsFormsSettings.IconStyle =
                    WindowsFormsSettings.IconStyle == "regular" ? "filled" : "regular";
                styleBtn.Text = "Style: " + WindowsFormsSettings.IconStyle;
                RefreshAllIcons(ribbon);
            };
            layout.Controls.Add(styleBtn);

            var reloadBtn = new SimpleButton {
                Text = "Reload Form (full rebuild)",
                Width = 250, Height = 40
            };
            reloadBtn.Click += (s, e) => {
                RebuildContent(ribbon);
            };
            layout.Controls.Add(reloadBtn);
        }

        // ========== Helpers ==========
        SimpleButton CreateButton(string text, int width) {
            return new SimpleButton {
                Text = text,
                Width = width,
                Height = 40,
                ImageLocation = ImageLocation.MiddleLeft
            };
        }

        void AddSectionLabel(FlowLayoutPanel layout, string text) {
            var lbl = new LabelControl {
                Text = text,
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 10000,
                Height = 30,
                Appearance = { Font = new Font("Segoe UI", 11, FontStyle.Bold) }
            };
            layout.Controls.Add(lbl);
            layout.SetFlowBreak(lbl, true);
        }

        void AddInfoLabel(FlowLayoutPanel layout, string text) {
            var lbl = new LabelControl {
                Text = text,
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 10000,
                Height = 22,
                Appearance = { ForeColor = Color.Gray, Font = new Font("Segoe UI", 9, FontStyle.Italic) }
            };
            layout.Controls.Add(lbl);
            layout.SetFlowBreak(lbl, true);
        }

        void AddSeparator(FlowLayoutPanel layout) {
            var sep = new PanelControl { Width = 10000, Height = 2, BackColor = Color.LightGray };
            sep.Margin = new Padding(0, 5, 0, 5);
            layout.Controls.Add(sep);
            layout.SetFlowBreak(sep, true);
        }

        void RefreshAllIcons(RibbonControl ribbon) {
            foreach(BarItem item in ribbon.Items) {
                if(!string.IsNullOrEmpty(item.ImageOptions.ImageUri.Uri))
                    item.ImageOptions.ImageUri.Refresh();
            }
            RefreshControlIcons(this);
            Refresh();
        }

        void RefreshControlIcons(Control parent) {
            foreach(Control c in parent.Controls) {
                var btn = c as SimpleButton;
                if(btn != null && !string.IsNullOrEmpty(btn.ImageOptions.ImageUri.Uri))
                    btn.ImageOptions.ImageUri.Refresh();
                if(c.HasChildren)
                    RefreshControlIcons(c);
            }
        }
    }

    class ResourceEntry {
        public string ResourceName { get; }
        public string ShortName { get; }
        Func<Assembly> asmFunc;
        public Assembly Assembly { get { return asmFunc(); } }

        public ResourceEntry(string resourceName, string shortName, Func<Assembly> asmFunc) {
            ResourceName = resourceName;
            ShortName = shortName;
            this.asmFunc = asmFunc;
        }
    }
}
