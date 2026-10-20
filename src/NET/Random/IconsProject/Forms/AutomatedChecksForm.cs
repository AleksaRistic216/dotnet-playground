using DevExpress.IconLibrary;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using IconsProject.Infrastructure;
using DxIcon = DevExpress.IconLibrary.Icon;

namespace IconsProject.Forms {
    public class AutomatedChecksForm : TestFormBase {
        readonly GridControl grid;
        readonly GridView view;
        readonly List<CheckResult> results = new List<CheckResult>();

        public class CheckResult {
            public string Area { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Outcome { get; set; } = string.Empty;
            public string Details { get; set; } = string.Empty;
        }

        public AutomatedChecksForm()
            : base("Automated checks",
                  "Assertions over the public surface: Icon ToString/Parse/TryParse, Icon → DxImageUri/string conversions, DxImageUri parsing of set/style/color/size tokens, provider resolution, IconSetContext, " +
                  "WindowsFormsSettings.Set*IconStyle → LookAndFeelHelper.GetActiveIconSet + StyleChanged, size providers, and the #48050 no-reparse contract. INFO rows record behaviour worth eyeballing rather than a pass/fail rule.") {
            grid = new GridControl { DataSource = results };
            view = new GridView(grid);
            grid.MainView = view;
            view.OptionsBehavior.Editable = false;
            view.OptionsView.ShowGroupPanel = true;
            view.RowCellStyle += (s, e) => {
                if(e.Column.FieldName != nameof(CheckResult.Outcome))
                    return;
                string outcome = (string)view.GetRowCellValue(e.RowHandle, e.Column);
                e.Appearance.ForeColor = outcome == "FAIL" || outcome == "ERROR" ? Color.Firebrick : outcome == "PASS" ? Color.SeaGreen : Color.DimGray;
                e.Appearance.FontStyleDelta = FontStyle.Bold;
            };
            var actions = new FlowLayoutPanel();
            AddToolbarButton(actions, "Run all checks", (s, e) => RunAll());
            AddToolbarButton(actions, "Copy results", (s, e) => {
                Clipboard.SetText(string.Join(Environment.NewLine, results.Select(r => $"{r.Outcome}\t{r.Area}\t{r.Name}\t{r.Details}")));
                IconLog.Write($"Copied {results.Count} results");
            });
            AddSections(Section("Actions", actions, 60), Section("Results", grid, 640));
            Shown += (s, e) => RunAll();
        }

        void Add(string area, string name, string outcome, string details) {
            results.Add(new CheckResult { Area = area, Name = name, Outcome = outcome, Details = details });
            IconLog.Write($"{outcome,-5} {area}/{name} {details}");
        }

        void Check(string area, string name, Func<(bool ok, string details)> body) {
            try {
                var (ok, details) = body();
                Add(area, name, ok ? "PASS" : "FAIL", details);
            }
            catch(Exception ex) {
                Add(area, name, "ERROR", $"{ex.GetType().Name}: {ex.Message}");
            }
        }

        void Info(string area, string name, Func<string> body) {
            try {
                Add(area, name, "INFO", body());
            }
            catch(Exception ex) {
                Add(area, name, "INFO", $"threw {ex.GetType().Name}: {ex.Message}");
            }
        }

        static bool Throws<T>(Action action) where T : Exception {
            try {
                action();
                return false;
            }
            catch(T) {
                return true;
            }
        }

        void RunAll() {
            results.Clear();
            IconMode originalMode = IconModeSwitch.Mode;
            try {
                IconChecks();
                ConversionChecks();
                ParserChecks();
                ProviderChecks();
                ContextChecks();
                SettingsChecks();
                SizeProviderChecks();
                Bugfix48050Checks();
            }
            finally {
                IconModeSwitch.Apply(originalMode);
            }
            grid.RefreshDataSource();
            int failed = results.Count(r => r.Outcome == "FAIL" || r.Outcome == "ERROR");
            Text = $"Automated checks — {results.Count(r => r.Outcome == "PASS")} pass, {failed} fail, {results.Count(r => r.Outcome == "INFO")} info";
            IconLog.Write(Text);
        }

        void IconChecks() {
            const string area = "Icon";
            Check(area, "ToString omits Default parts", () => (new DxIcon("add").ToString() == "add", new DxIcon("add").ToString()));
            Check(area, "ToString full", () => {
                string text = new DxIcon("add", IconSet.Fluent, IconStyle.Filled, IconPalette.Neutral, IconSize.Size24).ToString();
                return (text == "add;Fluent;Filled;Neutral;Size24", text);
            });
            Check(area, "Parse round-trips all 288 combinations", () => {
                int bad = 0;
                foreach(var set in IconCatalog.Sets)
                    foreach(var style in IconCatalog.Styles)
                        foreach(var color in IconCatalog.Colors)
                            foreach(var size in IconCatalog.Sizes) {
                                var icon = new DxIcon("x", set, style, color, size);
                                var parsed = DxIcon.Parse(icon.ToString());
                                if(parsed.Set != set || parsed.Style != style || parsed.Palette != color || parsed.Size != size)
                                    bad++;
                            }
                return (bad == 0, $"{bad} mismatches");
            });
            Check(area, "Parse is case-insensitive", () => {
                var icon = DxIcon.Parse("add;fluent;FILLED;Neutral;size16");
                return (icon.Set == IconSet.Fluent && icon.Style == IconStyle.Filled && icon.Palette == IconPalette.Neutral && icon.Size == IconSize.Size16, icon.ToString());
            });
            Check(area, "Parse throws FormatException on unknown token", () => (Throws<FormatException>(() => DxIcon.Parse("add;Bogus")), "add;Bogus"));
            Check(area, "Parse throws FormatException on empty id", () => (Throws<FormatException>(() => DxIcon.Parse(";Fluent")), ";Fluent"));
            Check(area, "Parse throws ArgumentNullException on null", () => (Throws<ArgumentNullException>(() => DxIcon.Parse(null!)), "null"));
            Check(area, "TryParse false on garbage", () => (!DxIcon.TryParse("add;Nope", out var icon) && icon == null, "add;Nope"));
            Check(area, "TryParse false on null", () => (!DxIcon.TryParse(null!, out _), "null"));
            Info(area, "Parse 'add,Fluent' (DxImageUri splits on ',' too)", () => DxIcon.TryParse("add,Fluent", out var icon) ? $"=> id-only Icon '{icon}' (Icon.Parse splits on ';' only)" : "TryParse false");
            Info(area, "Parse numeric token 'add;1'", () => $"=> '{DxIcon.Parse("add;1")}' (Enum.TryParse accepts numbers; 1 is a defined IconSet)");
            Info(area, "Parse duplicate category 'add;Fluent;DesktopClassic'", () => $"=> '{DxIcon.Parse("add;Fluent;DesktopClassic")}' (Icon.Parse: last wins; DxImageUriParser: first wins)");
            Info(area, "Parse whitespace 'add; Fluent'", () => DxIcon.TryParse("add; Fluent", out var icon) ? $"=> '{icon}'" : "TryParse false");
            Check(area, "Setters change ToString", () => {
                var icon = new DxIcon("add") { Set = IconSet.BlazorClassic, Size = IconSize.Size20 };
                return (icon.ToString() == "add;BlazorClassic;Size20", icon.ToString());
            });
            Check(area, "Generated Icons class exposes icons", () => {
                int count = IconCatalog.AllGeneratedIcons().Count();
                return (count > 1000, $"{count} properties");
            });
            Check(area, "Generated icons are unpinned ids", () => {
                var pinned = IconCatalog.AllGeneratedIcons().Where(i => i.Icon.ToString().Contains(';')).Select(i => i.Name).Take(5).ToArray();
                return (pinned.Length == 0, pinned.Length == 0 ? "all plain ids" : string.Join(", ", pinned));
            });
            Check(area, "Generated Icons return a new instance per read", () => {
                var a = Icons.Add;
                a.Set = IconSet.BlazorClassic;
                var b = Icons.Add;
                return (b.Set == IconSet.Default, "mutating one Icons.Add must not leak into the next read");
            });
        }

        void ConversionChecks() {
            const string area = "Conversion";
            Check(area, "Icon → DxImageUri keeps text", () => {
                DxImageUri uri = new DxIcon("add", IconSet.Fluent, IconStyle.Filled);
                return (uri.Uri == "add;Fluent;Filled", uri.Uri);
            });
            Check(area, "null Icon → empty DxImageUri", () => {
                DxIcon? icon = null;
                DxImageUri uri = icon!;
                return (uri != null && uri.Uri == string.Empty, $"'{uri?.Uri}'");
            });
            Check(area, "Icon → string", () => {
                string text = new DxIcon("add", size: IconSize.Size16);
                return (text == "add;Size16", text);
            });
            Check(area, "ImageOptions.ImageUri = Icon", () => {
                using var button = new SimpleButton();
                button.ImageOptions.ImageUri = Icons.Search;
                return (button.ImageOptions.ImageUri.Uri == "search", button.ImageOptions.ImageUri.Uri);
            });
            Check(area, "DxImageUri.Clone/Assign keeps uri", () => {
                var source = new DxImageUri("add;Fluent;Size24");
                var clone = (DxImageUri)((ICloneable)source).Clone();
                var target = new DxImageUri();
                target.Assign(source);
                return (clone.Uri == source.Uri && target.Uri == source.Uri && clone.HasSvgImage == source.HasSvgImage, $"clone='{clone.Uri}' assign='{target.Uri}' HasSvgImage={clone.HasSvgImage}/{target.HasSvgImage}");
            });
        }

        void ParserChecks() {
            const string area = "DxImageUri";
            foreach(var (uri, expectSvg) in new[] { ("add;Fluent", true), ("add;DesktopClassic", true), ("add;BlazorClassic", true), ("alert;Fluent", true), ("filter_funnel;BlazorClassic;Filled", true), ("add,Fluent,Filled", true), ("doesnotexist;Fluent", false) }) {
                Check(area, $"HasSvgImage '{uri}'", () => {
                    var u = new DxImageUri(uri);
                    return (u.HasSvgImage == expectSvg, $"HasSvgImage={u.HasSvgImage} ImageType={u.ImageType}");
                });
            }
            foreach(var (uri, type) in new[] { ("add;Fluent", ImageType.Fluent), ("add;DesktopClassic", ImageType.DesktopClassic), ("add;BlazorClassic", ImageType.Blazor), ("Add;Size16x16;GrayScaled", ImageType.GrayScaled), ("Save;Svg", ImageType.Svg) }) {
                Check(area, $"ImageType '{uri}'", () => {
                    var u = new DxImageUri(uri);
                    return (u.ImageType == type, $"{u.ImageType}");
                });
            }
            foreach(var (uri, px) in new[] { ("add;Fluent;Size16", 16), ("add;Fluent;Size20", 20), ("add;Fluent;Size24", 24), ("add;Fluent;Size32", 32), ("delete;Fluent;Size48", 48), ("delete;Fluent;Size12", 12) }) {
                Check(area, $"GetImage size '{uri}'", () => {
                    var u = new DxImageUri(uri);
                    Image? image = u.GetImage();
                    return (image != null && image.Width == px, image == null ? "null" : $"{image.Width}x{image.Height}");
                });
            }
            Check(area, "GetLargeImage defaults to 32 when size not pinned", () => {
                var image = new DxImageUri("add;Fluent").GetLargeImage();
                return (image != null && image.Width == 32, image == null ? "null" : $"{image.Width}x{image.Height}");
            });
            Check(area, "GetImage defaults to 16 when size not pinned", () => {
                var image = new DxImageUri("add;Fluent").GetImage();
                return (image != null && image.Width == 16, image == null ? "null" : $"{image.Width}x{image.Height}");
            });
            Check(area, "Legacy 'Add;Size16x16' yields an image", () => {
                var u = new DxImageUri("Add;Size16x16");
                return (u.HasImage, $"HasImage={u.HasImage} HasSvgImage={u.HasSvgImage} ImageType={u.ImageType} AllowDefaultSvgImages={WindowsFormsSettings.AllowDefaultSvgImages}/{WindowsFormsSettings.GetAllowDefaultSvgImages()}");
            });
            Check(area, "Legacy 'Add;Size16x16;GrayScaled' stays raster", () => {
                var u = new DxImageUri("Add;Size16x16;GrayScaled");
                return (u.HasImage && !u.HasSvgImage, $"HasImage={u.HasImage} HasSvgImage={u.HasSvgImage} ImageType={u.ImageType}");
            });
            Info(area, "Blazor forces Regular style", () => {
                var filled = new DxImageUri("filter_funnel;BlazorClassic;Filled").GetSvgImage(new Size(16, 16), null);
                var regular = new DxImageUri("filter_funnel;BlazorClassic;Regular").GetSvgImage(new Size(16, 16), null);
                return $"filled={(filled == null ? "null" : "img")} regular={(regular == null ? "null" : "img")} (compare visually in the matrix form)";
            });
            Info(area, "Unknown token 'add;Fluent;Bogus'", () => {
                var u = new DxImageUri("add;Fluent;Bogus");
                return $"HasSvgImage={u.HasSvgImage} ImageType={u.ImageType} (DxImageUriParser ignores unknown tokens, Icon.Parse throws)";
            });
            Info(area, "Whitespace token 'add; Fluent'", () => {
                var u = new DxImageUri("add; Fluent");
                return $"HasSvgImage={u.HasSvgImage} ImageType={u.ImageType}";
            });
        }

        void ProviderChecks() {
            const string area = "Provider";
            var provider = DxImageAssemblyUtil.ImageProvider;
            Check(area, "ImageProvider is IDXImagesProviderEx", () => (provider != null, provider?.GetType().FullName ?? "null"));
            foreach(var set in new[] { IconSet.Fluent, IconSet.DesktopClassic, IconSet.BlazorClassic }) {
                foreach(int px in new[] { 16, 32 }) {
                    var missing = IconCatalog.Metaphors.Where(id => provider.GetSvgImage(id, set, new Size(px, px)) == null).ToArray();
                    Add(area, $"{set} {px}px resolves catalog", missing.Length == 0 ? "PASS" : "INFO", missing.Length == 0 ? $"{IconCatalog.Metaphors.Length}/{IconCatalog.Metaphors.Length}" : $"missing (fallback expected for sets without that file): {string.Join(", ", missing)}");
                }
            }
            Check(area, "Unknown id resolves to null", () => (provider.GetSvgImage("doesnotexist", IconSet.Fluent, new Size(16, 16)) == null, "doesnotexist"));
            Info(area, "Nearest-size snapping (add has 16/20/24/32 Fluent)", () => {
                var parts = new List<string>();
                foreach(int px in new[] { 12, 18, 28, 40, 48, 64 }) {
                    var svg = provider.GetSvgImage("add", IconSet.Fluent, new Size(px, px));
                    parts.Add($"{px}→{(svg == null ? "null" : $"{svg.Width:0}")}");
                }
                return string.Join("  ", parts);
            });
            Info(area, "Default color per set", () => {
                var parts = new List<string>();
                foreach(var set in new[] { IconSet.Fluent, IconSet.DesktopClassic, IconSet.BlazorClassic }) {
                    var d = provider.GetSvgImage("add", set, new Size(16, 16), IconPalette.Default);
                    var mono = provider.GetSvgImage("add", set, new Size(16, 16), IconPalette.Neutral);
                    var multi = provider.GetSvgImage("add", set, new Size(16, 16), IconPalette.Colored);
                    parts.Add($"{set}: default={(d == null ? "null" : d.GetHashCode().ToString("x"))} mono={(mono == null ? "null" : mono.GetHashCode().ToString("x"))} multi={(multi == null ? "null" : multi.GetHashCode().ToString("x"))}");
                }
                return string.Join(" | ", parts) + " (instances are cached; equal hash → same resource)";
            });
            Info(area, "Mapped legacy ids", () => string.Join("  ", new[] { "Add", "Save", "Actions/Add", "fluentxaf/action_edit" }.Select(id => $"{id}→'{provider.GetMappedSvgImageId(id) ?? "null"}'")));
            Info(area, "Browsable SVG image count", () => $"{provider.GetBrowsableSvgImages().Count()} browsable, {provider.GetSvgImages().Count()} total");
        }

        void ContextChecks() {
            const string area = "IconSetContext";
            IconSet original = IconSetContext.Current;
            Check(area, "Use(Default) → HasValue false", () => {
                using(IconSetContext.Use(IconSet.Default))
                    return (!IconSetContext.HasValue, Describe());
            });
            Check(area, "Nested Use restores", () => {
                IconSet a, b, c;
                using(IconSetContext.Use(IconSet.Fluent)) {
                    a = IconSetContext.Current;
                    using(IconSetContext.Use(IconSet.DesktopClassic))
                        b = IconSetContext.Current;
                    c = IconSetContext.Current;
                }
                return (a == IconSet.Fluent && b == IconSet.DesktopClassic && c == IconSet.Fluent, $"{a}/{b}/{c}");
            });
            Check(area, "Set ignored inside scope", () => {
                using(IconSetContext.Use(IconSet.Fluent)) {
                    IconSetContext.Set(IconSet.BlazorClassic);
                    return (IconSetContext.Current == IconSet.Fluent, Describe());
                }
            });
            Check(area, "Double Dispose is harmless", () => {
                using(IconSetContext.Use(IconSet.Fluent)) {
                    var inner = IconSetContext.Use(IconSet.DesktopClassic);
                    inner.Dispose();
                    inner.Dispose();
                    return (IconSetContext.Current == IconSet.Fluent, Describe());
                }
            });
            Check(area, "Context is thread-static", () => {
                IconSet seen = IconSet.Default;
                using(IconSetContext.Use(IconSet.BlazorClassic)) {
                    var thread = new Thread(() => seen = IconSetContext.Current);
                    thread.Start();
                    thread.Join();
                }
                return (seen == IconSet.Default, $"other thread saw {seen}");
            });
            Check(area, "Context steers unpinned uri", () => {
                Image? fluent, classic;
                using(IconSetContext.Use(IconSet.Fluent))
                    fluent = new DxImageUri("add;Size16").GetSvgImage(new Size(16, 16), null);
                using(IconSetContext.Use(IconSet.DesktopClassic))
                    classic = new DxImageUri("add;Size16").GetSvgImage(new Size(16, 16), null);
                return (fluent != null && classic != null, $"fluent={(fluent == null ? "null" : "img")} classic={(classic == null ? "null" : "img")}");
            });
            IconSetContext.Set(original);
        }

        static string Describe() => $"HasValue={IconSetContext.HasValue} Current={IconSetContext.Current}";

        void SettingsChecks() {
            const string area = "Settings";
            int styleChanged = 0;
            var reasons = new List<string>();
            EventHandler handler = (s, e) => {
                styleChanged++;
                if(e is LookAndFeelChangedEventArgs args)
                    reasons.Add(args.Reason.ToString());
            };
            UserLookAndFeel.Default.StyleChanged += handler;
            try {
                IconModeSwitch.Apply(IconMode.ThemeBased);
                styleChanged = 0;
                reasons.Clear();
                IconModeSwitch.Apply(IconMode.Fluent);
                Check(area, "SetFluentIconStyle → active Fluent", () => (LookAndFeelHelper.GetActiveIconSet(UserLookAndFeel.Default) == IconSet.Fluent && IconSetSettings.ActiveIconSet == IconSet.Fluent, IconModeSwitch.Describe()));
                Check(area, "Mode switch raises StyleChanged(ActiveIconSetChanged)", () => (styleChanged >= 1 && reasons.Contains(nameof(LookAndFeelChangeReason.ActiveIconSetChanged)), $"{styleChanged} events: {string.Join(",", reasons)}"));
                styleChanged = 0;
                IconModeSwitch.Apply(IconMode.Fluent);
                Check(area, "Same mode twice raises nothing", () => (styleChanged == 0, $"{styleChanged} events"));
                IconModeSwitch.Apply(IconMode.Classic);
                Check(area, "SetDesktopClassicIconStyle → active Classic", () => (LookAndFeelHelper.GetActiveIconSet(UserLookAndFeel.Default) == IconSet.DesktopClassic, IconModeSwitch.Describe()));
                IconModeSwitch.Apply(IconMode.ThemeBased);
                Check(area, "SetThemeBasedIconStyle → settings Default", () => (IconSetSettings.ActiveIconSet == IconSet.Default, IconModeSwitch.Describe()));
                Info(area, "Theme-based set per skin", () => {
                    string original = UserLookAndFeel.Default.ActiveSkinName;
                    var parts = new List<string>();
                    foreach(string skin in new[] { "WXI", "The Bezier", "Basic", "Office 2019 Colorful", "DevExpress Style", "DevExpress Dark Style" }) {
                        using var lnf = new UserLookAndFeel(null) { UseDefaultLookAndFeel = false };
                        lnf.SetSkinStyle(skin);
                        parts.Add($"{skin}={LookAndFeelHelper.GetActiveIconSet(lnf)}");
                    }
                    return string.Join(", ", parts) + " (skins without an IconSet property resolve to Default)";
                });
                Check(area, "UseFilledIconsOnHover is off", () => (!WindowsFormsSettings.UseFilledIconsOnHover, "feature flag compiled false"));
                Check(area, "SimpleButton hover style null while flag off", () => {
                    using var button = new SimpleButton();
                    var style = ((IDXImageUriIconStyleProvider)button).GetPreferredIconStyle();
                    return (style == null, style?.ToString() ?? "null");
                });
                Check(area, "EditorButton hover style null while flag off", () => {
                    var button = new DevExpress.XtraEditors.Controls.EditorButton();
                    var style = ((IDXImageUriIconStyleProvider)button.ImageOptions).GetPreferredIconStyle();
                    return (style == null, style?.ToString() ?? "null");
                });
            }
            finally {
                UserLookAndFeel.Default.StyleChanged -= handler;
            }
        }

        void SizeProviderChecks() {
            const string area = "Size providers";
            Check(area, "ListBox preferred 16", () => {
                using var list = new ImageListBoxControl();
                var size = ((IDXImageUriIconSizeProvider)list).GetPreferredIconSize();
                return (size == new Size(16, 16), size.ToString());
            });
            Check(area, "ListBox subclass override", () => {
                using var list = new Forms.LargeIconImageListBox();
                var size = ((IDXImageUriIconSizeProvider)list).GetPreferredIconSize();
                return (size == new Size(32, 32), size.ToString());
            });
            Check(area, "Detached TileItemElement → Empty", () => {
                var element = new TileItemElement();
                var size = ((IDXImageUriIconSizeProvider)element).GetPreferredIconSize();
                return (size.IsEmpty, size.ToString());
            });
            Check(area, "GalleryItem uses SvgImageSize first", () => {
                var item = new DevExpress.XtraBars.Ribbon.GalleryItem();
                item.ImageOptions.SvgImageSize = new Size(20, 20);
                var size = ((IDXImageUriIconSizeProvider)item).GetPreferredIconSize();
                return (size == new Size(20, 20), size.ToString());
            });
            Check(area, "Probe client size provider drives GetImage", () => {
                using var client = new ProbeClient("WXI", new Size(24, 24));
                var uri = new DxImageUri("add;Fluent");
                uri.SetClient(client);
                var image = uri.GetImage();
                return (image != null && image.Width == 24 && uri.GetSizeProviderPreferredIconSize() == new Size(24, 24), $"{(image == null ? "null" : $"{image.Width}x{image.Height}")}, provider asked {client.PreferredIconSizeRequests}x");
            });
            Check(area, "Pinned size beats provider", () => {
                using var client = new ProbeClient("WXI", new Size(24, 24));
                var uri = new DxImageUri("add;Fluent;Size16");
                uri.SetClient(client);
                var image = uri.GetImage();
                return (image != null && image.Width == 16, image == null ? "null" : $"{image.Width}x{image.Height}");
            });
        }

        void Bugfix48050Checks() {
            const string area = "#48050";
            foreach(string uri in new[] { "Add;Size16x16", "Add;Size16x16;GrayScaled", "doesnotexist", "add;Fluent" }) {
                Check(area, $"HasSvgImage read does not re-parse '{uri}'", () => {
                    using(IconSetContext.Use(IconSet.Fluent))
                    using(var client = new ProbeClient("DevExpress Dark Style")) {
                        var probe = new CountingDxImageUri(uri);
                        probe.SetClient(client);
                        bool reentered = probe.IsChangedReentered;
                        probe.ResetCounters();
                        for(int i = 0; i < 100; i++)
                            _ = probe.HasSvgImage;
                        return (!reentered && probe.ChangedCount == 0, $"reentered={reentered} OnChanged after reads={probe.ChangedCount} glyphSkinning calls={client.SetGlyphSkinningValueCount}");
                    }
                });
            }
            Check(area, "Built under Classic, read under Fluent", () => {
                CountingDxImageUri probe;
                using(IconSetContext.Use(IconSet.DesktopClassic))
                    probe = new CountingDxImageUri("Add;Size16x16");
                using(IconSetContext.Use(IconSet.Fluent)) {
                    probe.ResetCounters();
                    _ = probe.HasSvgImage;
                    _ = probe.HasImage;
                    _ = probe.HasLargeImage;
                    return (probe.ChangedCount == 0, $"OnChanged={probe.ChangedCount}");
                }
            });
        }
    }
}
