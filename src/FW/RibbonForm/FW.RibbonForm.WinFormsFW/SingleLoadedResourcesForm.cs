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

        // Real embedded SVG resources from DevExpress assemblies
        static readonly Assembly utilsAsm = typeof(ResourceImageHelper).Assembly;
        static readonly Assembly barsAsm = typeof(RibbonControl).Assembly;
        static readonly Assembly editorsAsm = typeof(SimpleButton).Assembly;

        // Resource names that actually exist as embedded manifest resources
        static readonly ResourceEntry[] testResources = {
            new ResourceEntry("DevExpress.Data.Images.SVG.AI.AI.svg", "AI", () => utilsAsm),
            new ResourceEntry("DevExpress.Data.Images.SVG.AI.AISparkle.svg", "AISparkle", () => utilsAsm),
            new ResourceEntry("DevExpress.Data.Utils.Html.Resources.PlaceholderImage.svg", "Placeholder", () => utilsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.SkinSearch.svg", "Search", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.Settings.svg", "Settings", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.ApplicationButton2007.svg", "AppBtn07", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.RibbonApplication.svg", "RibbonApp", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.AddPage.svg", "AddPage", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.AddPageGroup.svg", "AddGroup", () => barsAsm),
            new ResourceEntry("DevExpress.XtraBars.Images.AddRibbonCategory.svg", "AddCat", () => barsAsm),
            new ResourceEntry("DevExpress.XtraEditors.Images.SVG.Magnifier.svg", "Magnifier", () => editorsAsm),
        };

        public SingleLoadedResourcesForm() {
            InitializeComponent();
            BuildUI();
        }

        void BuildUI() {
            Text = "Single-Loaded Resources Test — " + WindowsFormsSettings.ActiveIconSet;
            ClientSize = new Size(1200, 850);

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

            scrollPanelRef = new PanelControl { Dock = DockStyle.Fill, AutoScroll = true };
            Controls.Add(scrollPanelRef);
            scrollPanelRef.BringToFront();

            RebuildContent(ribbon);
        }

        void RebuildContent(RibbonControl ribbon) {
            scrollPanelRef.Controls.Clear();
            var layout = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(10) };
            scrollPanelRef.Controls.Add(layout);

            AddSettingsControls(layout, ribbon);
            AddSeparator(layout);

            // Enumerate all available manifest resources for diagnostics
            AddSectionLabel(layout, "0. Available SVG manifest resources (first 5 per assembly)");
            AddManifestDiagnostics(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "1. DxImageUri (baseline — goes through ImageResourceCache pipeline)");
            AddInfoLabel(layout, "Expected: shows fluent icons when IconSet=Fluent. This is the gold standard.");
            AddDxImageUriSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "2. SvgImageCollection.FromResources (patched in branch)");
            AddInfoLabel(layout, "Loads all SVGs from an assembly namespace prefix into a collection.");
            AddSvgImageCollectionSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "3. SvgImage.FromResources(name, assembly) — 63 call sites in product");
            AddInfoLabel(layout, "Expected: classic icons UNLESS Approach A/C factory patch is applied.");
            AddFromResourcesSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "4. SvgImage.FromStream(stream) — 43 call sites, always raw");
            AddInfoLabel(layout, "Expected: ALWAYS classic. This bypasses everything — raw stream → SVG parse.");
            AddFromStreamSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "5. new SvgImage(type, resource) — 3 call sites, direct constructor");
            AddInfoLabel(layout, "Expected: ALWAYS classic. Direct assembly resource → SVG parse.");
            AddDirectConstructorSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "6. ResourceImageHelper.CreateSvgImageFromResources — factory-based");
            AddInfoLabel(layout, "Expected: shows fluent IF WindowsSvgImageFactory is registered (it is on this branch).");
            AddResourceImageHelperSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "7. SvgBitmap — render comparison (FromResources vs raw stream)");
            AddInfoLabel(layout, "Compares rendered output: upstream-dependent vs always-classic.");
            AddSvgBitmapSection(layout);
            AddSeparator(layout);

            AddSectionLabel(layout, "8. ImageResourceCache.GetSvgImageById — packed DX.Images format");
            AddInfoLabel(layout, "Uses the DevExpress.Images packed cache directly. Should match DxImageUri.");
            AddImageCacheSection(layout);
        }

        // ========== 0. Diagnostics ==========
        void AddManifestDiagnostics(FlowLayoutPanel layout) {
            Assembly[] assemblies = { utilsAsm, barsAsm, editorsAsm };
            string[] asmNames = { "DevExpress.Utils", "DevExpress.XtraBars", "DevExpress.XtraEditors" };
            for(int i = 0; i < assemblies.Length; i++) {
                int count = 0;
                string names = "";
                foreach(var name in assemblies[i].GetManifestResourceNames()) {
                    if(!name.EndsWith(".svg", StringComparison.OrdinalIgnoreCase)) continue;
                    if(count < 5) names += (count > 0 ? ", " : "") + name;
                    count++;
                }
                AddInfoLabel(layout, asmNames[i] + ": " + count + " SVGs — " + names + (count > 5 ? " ..." : ""));
            }
        }

        // ========== 1. DxImageUri ==========
        void AddDxImageUriSection(FlowLayoutPanel layout) {
            string[] icons = { "save", "edit", "delete", "copy", "print", "filter", "calendar", "link" };
            foreach(var name in icons) {
                var btn = CreateButton(name, 130);
                btn.ImageOptions.ImageUri.Uri = name;
                btn.ImageOptions.SvgImageSize = new Size(20, 20);
                layout.Controls.Add(btn);
            }
        }

        // ========== 2. SvgImageCollection.FromResources ==========
        void AddSvgImageCollectionSection(FlowLayoutPanel layout) {
            try {
                var collection = SvgImageCollection.FromResources(
                    "DevExpress.XtraBars.Images", barsAsm);
                AddInfoLabel(layout, "Loaded " + collection.Count + " from XtraBars.Images");
                int count = 0;
                foreach(string key in collection.Keys) {
                    if(count >= 8) break;
                    var btn = CreateButton("Col:" + key, 150);
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

        // ========== 3. SvgImage.FromResources ==========
        void AddFromResourcesSection(FlowLayoutPanel layout) {
            foreach(var entry in testResources) {
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
        }

        // ========== 4. SvgImage.FromStream ==========
        void AddFromStreamSection(FlowLayoutPanel layout) {
            foreach(var entry in testResources) {
                var btn = CreateButton("FS:" + entry.ShortName, 150);
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
        }

        // ========== 5. new SvgImage(type, resource) ==========
        void AddDirectConstructorSection(FlowLayoutPanel layout) {
            // SvgImage(Type, string) resolves: type.Assembly.GetManifestResourceStream(type, resource)
            // which means type.Namespace + "." + resource
            // Use XtraBars types with relative resource names
            string[][] pairs = {
                new[] { "Images.SkinSearch.svg", "Search" },
                new[] { "Images.Settings.svg", "Settings" },
                new[] { "Images.AddPage.svg", "AddPage" },
            };
            foreach(var pair in pairs) {
                var btn = CreateButton("Ctor:" + pair[1], 150);
                try {
                    SvgImage svg = new SvgImage(typeof(RibbonControl), pair[0]);
                    btn.ImageOptions.SvgImage = svg;
                    btn.ImageOptions.SvgImageSize = new Size(20, 20);
                }
                catch {
                    btn.Text += " ✗";
                    btn.Appearance.ForeColor = Color.Red;
                }
                layout.Controls.Add(btn);
            }
        }

        // ========== 6. ResourceImageHelper.CreateSvgImageFromResources ==========
        void AddResourceImageHelperSection(FlowLayoutPanel layout) {
            foreach(var entry in testResources) {
                var btn = CreateButton("RIH:" + entry.ShortName, 150);
                SvgImage svg = ResourceImageHelper.CreateSvgImageFromResources(
                    entry.ResourceName, entry.Assembly);
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

        // ========== 7. SvgBitmap ==========
        void AddSvgBitmapSection(FlowLayoutPanel layout) {
            var entry = testResources[3]; // SkinSearch
            // Via FromResources (should be patched)
            SvgImage svgFromRes = SvgImage.FromResources(entry.ResourceName, entry.Assembly);
            if(svgFromRes != null) {
                var bmp = new SvgBitmap(svgFromRes);
                var rendered = bmp.Render(new Size(32, 32), null);
                var btn = CreateButton("Bitmap(FromRes): " + entry.ShortName, 250);
                btn.ImageOptions.Image = rendered;
                layout.Controls.Add(btn);
            }
            else {
                AddInfoLabel(layout, "SvgBitmap(FromRes) — source was null for " + entry.ResourceName);
            }

            // Via raw stream (always classic)
            Stream stream = entry.Assembly.GetManifestResourceStream(entry.ResourceName);
            if(stream != null) {
                SvgImage svgRaw = SvgImage.FromStream(stream);
                var bmp = new SvgBitmap(svgRaw);
                var rendered = bmp.Render(new Size(32, 32), null);
                var btn = CreateButton("Bitmap(Stream): " + entry.ShortName, 250);
                btn.ImageOptions.Image = rendered;
                layout.Controls.Add(btn);
            }
        }

        // ========== 8. ImageResourceCache (packed DX.Images) ==========
        void AddImageCacheSection(FlowLayoutPanel layout) {
            string[] imageIds = { "save", "edit", "delete", "copy", "print", "filter", "calendar", "link" };
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
