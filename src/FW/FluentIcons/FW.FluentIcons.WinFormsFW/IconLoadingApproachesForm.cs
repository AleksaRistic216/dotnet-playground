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

namespace FW.FluentIcons.WinFormsFW {
    public partial class IconLoadingApproachesForm : RibbonForm {
        PanelControl scrollPanelRef;

        static readonly Assembly utilsAsm = typeof(ResourceImageHelper).Assembly;
        static readonly Assembly barsAsm = typeof(RibbonControl).Assembly;
        static readonly Assembly editorsAsm = typeof(SimpleButton).Assembly;
        static readonly Assembly dataDesktopAsm = typeof(DevExpress.Data.Images.AIImageResources).Assembly;

        static readonly ResourceEntry[] mappedResources = {
            // XtraBars mapped icons
            new ResourceEntry("DevExpress.XtraBars.Images.SkinSearch.svg", "Search", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.Settings.svg", "Settings", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.CaptureWorkspace.svg", "CaptureWS", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.SvgIcons.AddCategory.svg", "AddCategory", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.SvgIcons.DeleteCommand.svg", "DeleteCmd", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.SvgIcons.MoveDown.svg", "MoveDown", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.SvgIcons.MoveUp.svg", "MoveUp", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.SvgIcons.RenameCategory.svg", "Rename", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.SvgIcons.ClearCommand.svg", "Clear", () => barsAsm),
            // Utils mapped icons
            new ResourceEntry("DevExpress.Utils.Images.CloseButton.svg", "Close", () => utilsAsm),
            new ResourceEntry("DevExpress.Utils.Images.Error.svg", "Error", () => utilsAsm),
            new ResourceEntry("DevExpress.Utils.Images.Information.svg", "Info", () => utilsAsm),
            new ResourceEntry("DevExpress.Utils.Images.Question.svg", "Question", () => utilsAsm),
            new ResourceEntry("DevExpress.Utils.Images.Warning.svg", "Warning", () => utilsAsm),
            // XtraEditors mapped icons (filter editor)
            new ResourceEntry("DevExpress.XtraEditors.FilterEditor.Images.ClauseSvgImages.Equals.svg", "Equals", () => editorsAsm),
            new ResourceEntry("DevExpress.XtraEditors.FilterEditor.Images.ClauseSvgImages.Contains.svg", "Contains", () => editorsAsm),
            new ResourceEntry("DevExpress.XtraEditors.FilterEditor.Images.ClauseSvgImages.Greater.svg", "Greater", () => editorsAsm),
            new ResourceEntry("DevExpress.XtraEditors.FilterEditor.Images.AIInputSvgImages.Submit.svg", "Submit", () => editorsAsm),
        };

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

        static ResourceEntry[] AllResources {
            get {
                var all = new ResourceEntry[mappedResources.Length + unmappedResources.Length];
                mappedResources.CopyTo(all, 0);
                unmappedResources.CopyTo(all, mappedResources.Length);
                return all;
            }
        }

        public IconLoadingApproachesForm() {
            InitializeComponent();
            BuildUI();
        }

        void BuildUI() {
            Text = "Icon Loading Approaches — " + WindowsFormsSettings.ActiveIconSet;
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

            var originalDock = layout.Dock;
            var originalAutoScroll = layout.AutoScroll;
            var originalSize = layout.Size;

            layout.AutoScroll = false;
            layout.Dock = DockStyle.None;
            int captureWidth = originalSize.Width;
            var fullSize = layout.GetPreferredSize(new Size(captureWidth, 0));
            fullSize.Width = captureWidth;
            layout.Size = fullSize;

            using(var bmp = new Bitmap(fullSize.Width, fullSize.Height)) {
                layout.DrawToBitmap(bmp, new Rectangle(Point.Empty, fullSize));

                layout.Dock = originalDock;
                layout.AutoScroll = originalAutoScroll;
                layout.Size = originalSize;

                var path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"IconLoadingApproaches_{DateTime.Now:yyyyMMdd_HHmmss}.png");
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

            AddSectionLabel(layout, "1. DxImageUri — gold standard pipeline (ImageResourceCache)");
            AddInfoLabel(layout, "OLD: fluent | NEW: fluent | No change needed. This is the standard way to load icons.");
            AddDxImageUriSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "2. SvgImageCollection.FromResources — bulk load from assembly prefix");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent if mapped (ShouldTrackImages + LoadFromProvider)");
            AddSvgImageCollectionSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "3a. SvgImage.FromResources — MAPPED icons (Search, Settings)");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent (factory intercepts → MappedOthersSvg.cs lookup)");
            AddFromResourcesMappedSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "3b. SvgImage.FromResources — UNMAPPED icons (no fluent equivalent)");
            AddInfoLabel(layout, "OLD: classic | NEW: classic (factory returns null → fallback to raw resource)");
            AddFromResourcesUnmappedSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "4a. FromStream(ref cache, name, asm) — 7 sites, already intercepted");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent if mapped (Approach C patches this variant)");
            AddFromStreamRefCacheSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "4b. Raw FromStream → refactored to FromResources — 12 sites");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent if mapped (call sites changed to FromResources)");
            AddInfoLabel(layout, "Pattern: asm.GetManifestResourceStream(name) → FromStream(stream) BECAME FromResources(name, asm)");
            AddFromStreamRefactoredSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "4c. Raw FromStream — still un-intercepted (14 dynamic + 10 remaining)");
            AddInfoLabel(layout, "OLD: classic | NEW: classic (no name context, raw stream always bypasses factory)");
            AddFromStreamRawSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "5. new SvgImage(type, resource) — 3 sites, manually fixed");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent if mapped (Approach C converts to ResourceImageHelper)");
            AddDirectConstructorSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "6. ResourceImageHelper.CreateSvgImageFromResources — factory-based");
            AddInfoLabel(layout, "OLD: classic | NEW: fluent if mapped (WindowsSvgImageFactory registered)");
            AddResourceImageHelperSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "7. SvgBitmap — upstream-dependent rendering");
            AddInfoLabel(layout, "Renders whatever SvgImage it gets. Compare FromResources (patched) vs FromStream (raw).");
            AddSvgBitmapSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "8. ImageResourceCache.GetSvgImageById — packed DX.Images");
            AddInfoLabel(layout, "OLD: fluent | NEW: fluent | Same pipeline as DxImageUri.");
            AddImageCacheSection(layout);
        }

        void AddDxImageUriSection(FlowLayoutPanel layout) {
            string[] icons = { "save", "edit", "delete", "copy", "print", "filter", "calendar", "link", "search", "settings-gear" };
            foreach(var name in icons) {
                var btn = CreateButton(name, 140);
                btn.ImageOptions.ImageUri.Uri = name;
                btn.ImageOptions.SvgImageSize = new Size(20, 20);
                layout.Controls.Add(btn);
            }
        }

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
            } catch(Exception ex) {
                AddInfoLabel(layout, "ERROR: " + ex.Message);
            }
        }

        void AddFromResourcesMappedSection(FlowLayoutPanel layout) {
            foreach(var entry in mappedResources) {
                var btn = CreateButton("FR:" + entry.ShortName, 150);
                SvgImage svg = SvgImage.FromResources(entry.ResourceName, entry.Assembly);
                if(svg != null) {
                    btn.ImageOptions.SvgImage = svg;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                } else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
            AddInfoLabel(layout, "↑ With new build: should show FLUENT icons (thin lines, different shape than section 4c)");
        }

        void AddFromResourcesUnmappedSection(FlowLayoutPanel layout) {
            foreach(var entry in unmappedResources) {
                var btn = CreateButton("FR:" + entry.ShortName, 150);
                SvgImage svg = SvgImage.FromResources(entry.ResourceName, entry.Assembly);
                if(svg != null) {
                    btn.ImageOptions.SvgImage = svg;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                } else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
            AddInfoLabel(layout, "↑ Always classic — no fluent mapping exists for these icons.");
        }

        void AddFromStreamRefCacheSection(FlowLayoutPanel layout) {
            Dictionary<string, ISvgImage> cache = null;
            foreach(var entry in mappedResources) {
                var btn = CreateButton("RefCache:" + entry.ShortName, 180);
                ISvgImage svg = SvgImage.FromStream(ref cache, entry.ResourceName, entry.Assembly);
                if(svg != null) {
                    btn.ImageOptions.SvgImage = svg as SvgImage;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                } else {
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
                } else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
            AddInfoLabel(layout, "↑ With new build: mapped icons should be FLUENT (factory intercepts before stream load)");
        }

        void AddFromStreamRefactoredSection(FlowLayoutPanel layout) {
            AddInfoLabel(layout, "LEFT = old pattern (FromStream), RIGHT = new pattern (FromResources):");
            foreach(var entry in mappedResources) {
                var btnOld = CreateButton("OLD:" + entry.ShortName, 150);
                Stream stream = entry.Assembly.GetManifestResourceStream(entry.ResourceName);
                if(stream != null) {
                    SvgImage svg = SvgImage.FromStream(stream);
                    btnOld.ImageOptions.SvgImage = svg;
                    btnOld.ImageOptions.SvgImageSize = new Size(20, 20);
                } else btnOld.Text += " ✗";
                layout.Controls.Add(btnOld);

                var btnNew = CreateButton("NEW:" + entry.ShortName, 150);
                SvgImage svgNew = SvgImage.FromResources(entry.ResourceName, entry.Assembly);
                if(svgNew != null) {
                    btnNew.ImageOptions.SvgImage = svgNew;
                    btnNew.ImageOptions.SvgImageSize = new Size(20, 20);
                } else btnNew.Text += " ✗";
                layout.Controls.Add(btnNew);
            }
            AddInfoLabel(layout, "↑ With new build: OLD=classic, NEW=fluent (proves the refactoring works)");
        }

        void AddFromStreamRawSection(FlowLayoutPanel layout) {
            foreach(var entry in AllResources) {
                var btn = CreateButton("Raw:" + entry.ShortName, 150);
                Stream stream = entry.Assembly.GetManifestResourceStream(entry.ResourceName);
                if(stream != null) {
                    SvgImage svg = SvgImage.FromStream(stream);
                    btn.ImageOptions.SvgImage = svg;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                } else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
            AddInfoLabel(layout, "↑ ALWAYS classic — no way to intercept raw stream. Compare with 3a to see the difference.");
        }

        void AddDirectConstructorSection(FlowLayoutPanel layout) {
            string[][] pairs = {
                new[] { "Images.SkinSearch.svg", "Search" },
                new[] { "Images.Settings.svg", "Settings" },
                new[] { "Images.AddPage.svg", "AddPage" },
            };
            foreach(var pair in pairs) {
                var btnOld = CreateButton("Ctor:" + pair[1], 150);
                try {
                    SvgImage svg = new SvgImage(typeof(RibbonControl), pair[0]);
                    btnOld.ImageOptions.SvgImage = svg;
                    btnOld.ImageOptions.SvgImageSize = new Size(20, 20);
                } catch {
                    btnOld.Text += " ✗";
                    btnOld.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btnOld);

                string fullName = "DevExpress.XtraBars." + pair[0];
                var btnNew = CreateButton("Fixed:" + pair[1], 150);
                SvgImage svgNew = ResourceImageHelper.CreateSvgImageFromResources(fullName, barsAsm);
                if(svgNew != null) {
                    btnNew.ImageOptions.SvgImage = svgNew;
                    btnNew.ImageOptions.SvgImageSize = new Size(20, 20);
                } else {
                    btnNew.Text += " ✗";
                    btnNew.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btnNew);
            }
            AddInfoLabel(layout, "↑ Ctor = always classic. Fixed = fluent if mapped (Search, Settings should differ).");
        }

        void AddResourceImageHelperSection(FlowLayoutPanel layout) {
            foreach(var entry in AllResources) {
                var btn = CreateButton("RIH:" + entry.ShortName, 150);
                SvgImage svg = ResourceImageHelper.CreateSvgImageFromResources(entry.ResourceName, entry.Assembly);
                if(svg != null) {
                    btn.ImageOptions.SvgImage = svg;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                } else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
            AddInfoLabel(layout, "↑ Same behavior as 3a/3b — goes through WindowsSvgImageFactory.");
        }

        void AddSvgBitmapSection(FlowLayoutPanel layout) {
            var entry = mappedResources[0];

            SvgImage svgPatched = SvgImage.FromResources(entry.ResourceName, entry.Assembly);
            if(svgPatched != null) {
                var bmp = new SvgBitmap(svgPatched);
                var rendered = bmp.Render(new Size(32, 32), null);
                var btn = CreateButton("Patched:" + entry.ShortName, 200);
                btn.ImageOptions.Image = rendered;
                layout.Controls.Add(btn);
            }

            Stream stream = entry.Assembly.GetManifestResourceStream(entry.ResourceName);
            if(stream != null) {
                SvgImage svgRaw = SvgImage.FromStream(stream);
                var bmp = new SvgBitmap(svgRaw);
                var rendered = bmp.Render(new Size(32, 32), null);
                var btn = CreateButton("Raw:" + entry.ShortName, 200);
                btn.ImageOptions.Image = rendered;
                layout.Controls.Add(btn);
            }

            SvgImage svgCache = DxImageAssemblyUtil.ImageProvider.GetSvgImage("search", IconSetSettings.ActiveIconSet, new Size(32, 32));
            if(svgCache != null) {
                var bmp = new SvgBitmap(svgCache);
                var rendered = bmp.Render(new Size(32, 32), null);
                var btn = CreateButton("Cache:search", 200);
                btn.ImageOptions.Image = rendered;
                layout.Controls.Add(btn);
            }

            AddInfoLabel(layout, "↑ With new build: Patched should match Cache (both fluent). Raw = classic.");
        }

        void AddImageCacheSection(FlowLayoutPanel layout) {
            string[] imageIds = { "save", "edit", "delete", "copy", "print", "filter", "search", "settings-gear", "find", "undo" };
            foreach(var id in imageIds) {
                var btn = CreateButton("Cache:" + id, 140);
                SvgImage svg = DxImageAssemblyUtil.ImageProvider.GetSvgImage(id, IconSetSettings.ActiveIconSet, new Size(32, 32));
                if(svg != null) {
                    btn.ImageOptions.SvgImage = svg;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                } else {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
        }

        void AddSettingsControls(FlowLayoutPanel layout, RibbonControl ribbon) {
            AddSectionLabel(layout, "Runtime Settings");

            var toggleBtn = new SimpleButton {
                Text = "IconSet: " + WindowsFormsSettings.ActiveIconSet,
                Width = 200,
                Height = 40
            };
            toggleBtn.Click += (s, e) => {
                var values = (IconSet[])Enum.GetValues(typeof(IconSet));
                int idx = Array.IndexOf(values, WindowsFormsSettings.ActiveIconSet);
                WindowsFormsSettings.ActiveIconSet = values[(idx + 1) % values.Length];
                toggleBtn.Text = "IconSet: " + WindowsFormsSettings.ActiveIconSet;
                Text = "Icon Loading Approaches — " + WindowsFormsSettings.ActiveIconSet
                    + " / " + WindowsFormsSettings.IconStyle
                    + " / " + WindowsFormsSettings.IconColor;
                RebuildContent(ribbon);
            };
            layout.Controls.Add(toggleBtn);

            var styleBtn = new SimpleButton {
                Text = "Style: " + WindowsFormsSettings.IconStyle,
                Width = 200,
                Height = 40
            };
            styleBtn.Click += (s, e) => {
                string[] styles = { "regular", "light", "filled" };
                int idx = Array.IndexOf(styles, WindowsFormsSettings.IconStyle);
                if(idx < 0) idx = 0;
                WindowsFormsSettings.IconStyle = styles[(idx + 1) % styles.Length];
                styleBtn.Text = "Style: " + WindowsFormsSettings.IconStyle;
                RebuildContent(ribbon);
            };
            layout.Controls.Add(styleBtn);

            var colorBtn = new SimpleButton {
                Text = "Color: " + WindowsFormsSettings.IconColor,
                Width = 200,
                Height = 40
            };
            colorBtn.Click += (s, e) => {
                string[] colors = { "no_color", "monochrome", "multicolor" };
                int idx = Array.IndexOf(colors, WindowsFormsSettings.IconColor);
                if(idx < 0) idx = 0;
                WindowsFormsSettings.IconColor = colors[(idx + 1) % colors.Length];
                colorBtn.Text = "Color: " + WindowsFormsSettings.IconColor;
                RebuildContent(ribbon);
            };
            layout.Controls.Add(colorBtn);

            var reloadBtn = new SimpleButton {
                Text = "Reload Form (full rebuild)",
                Width = 250,
                Height = 40
            };
            reloadBtn.Click += (s, e) => RebuildContent(ribbon);
            layout.Controls.Add(reloadBtn);
        }

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
                Width = 1350,
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
                Width = 1350,
                Height = 22,
                Appearance = { ForeColor = Color.Gray, Font = new Font("Segoe UI", 9, FontStyle.Italic) }
            };
            layout.Controls.Add(lbl);
            layout.SetFlowBreak(lbl, true);
        }

        void AddSeparator(FlowLayoutPanel layout) {
            var sep = new PanelControl { Width = 1350, Height = 2, BackColor = Color.LightGray };
            sep.Margin = new Padding(0, 5, 0, 5);
            layout.Controls.Add(sep);
            layout.SetFlowBreak(sep, true);
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
