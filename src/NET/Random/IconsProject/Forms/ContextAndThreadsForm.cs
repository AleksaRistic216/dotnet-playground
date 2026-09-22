using DevExpress.Data.Utils.Images;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using IconsProject.Infrastructure;

namespace IconsProject.Forms {
    public class ContextAndThreadsForm : TestFormBase {
        readonly FlowLayoutPanel scopePreview;
        readonly FlowLayoutPanel panelsHost;

        public ContextAndThreadsForm()
            : base("IconSetContext scopes, per-control LookAndFeel, threads",
                  "IconSetContext is [ThreadStatic]: Use() pushes a scope, Set() is ignored while any scope is open, HasValue is false for Default. Controls call IconSetContext.Set(active set of their LookAndFeel) when their LookAndFeel changes. " +
                  "The thread buttons open a second UI thread with its own context, and render on a thread-pool thread (the SvgImage cache in ImageResourceCache is [ThreadStatic] too).") {
            var actions = new FlowLayoutPanel();
            AddToolbarButton(actions, "Nested scopes", (s, e) => NestedScopes());
            AddToolbarButton(actions, "Set() outside / inside scope", (s, e) => SetSemantics());
            AddToolbarButton(actions, "Render the same uri in each scope", (s, e) => RenderInScopes());
            AddToolbarButton(actions, "Open EditorsForm on new UI thread (Use Fluent)", (s, e) => OpenOnThread(IconSet.Fluent, useScope: true));
            AddToolbarButton(actions, "Open EditorsForm on new UI thread (Set Blazor)", (s, e) => OpenOnThread(IconSet.Blazor, useScope: false));
            AddToolbarButton(actions, "Render on thread pool x8", (s, e) => RenderOnThreadPool());
            AddToolbarButton(actions, "Reset this thread's context to Default", (s, e) => {
                IconSetContext.Set(IconSet.Default);
                IconLog.Write($"IconSetContext.Set(Default) -> HasValue={IconSetContext.HasValue} Current={IconSetContext.Current}");
            });
            scopePreview = new FlowLayoutPanel();
            panelsHost = new FlowLayoutPanel();
            BuildPanels();
            AddToolbarButton(actions, "Cycle panel skins x20", (s, e) => CyclePanelSkins());
            AddSections(
                Section("Actions", actions, 110),
                Section("Scope render results", scopePreview, 130),
                Section("Panels with private LookAndFeel (same uris, different skins)", panelsHost, 330));
        }

        static string Ctx() => $"HasValue={IconSetContext.HasValue} Current={IconSetContext.Current}";

        void NestedScopes() {
            IconLog.Write($"outside: {Ctx()}");
            using(IconSetContext.Use(IconSet.Fluent)) {
                IconLog.Write($"  Use(Fluent): {Ctx()}");
                using(IconSetContext.Use(IconSet.Classic)) {
                    IconLog.Write($"    Use(Classic): {Ctx()}");
                    using(IconSetContext.Use(IconSet.Default))
                        IconLog.Write($"      Use(Default): {Ctx()} (HasValue must be false for Default)");
                    IconLog.Write($"    back in Classic: {Ctx()}");
                }
                IconLog.Write($"  back in Fluent: {Ctx()}");
                var scope = IconSetContext.Use(IconSet.Blazor);
                scope.Dispose();
                scope.Dispose();
                IconLog.Write($"  after double Dispose of a Blazor scope: {Ctx()} (must still be Fluent)");
            }
            IconLog.Write($"outside again: {Ctx()}");
        }

        void SetSemantics() {
            IconSet before = IconSetContext.Current;
            IconSetContext.Set(IconSet.Classic);
            IconLog.Write($"Set(Classic) outside a scope: {Ctx()}");
            using(IconSetContext.Use(IconSet.Fluent)) {
                IconSetContext.Set(IconSet.Blazor);
                IconLog.Write($"Set(Blazor) inside Use(Fluent): {Ctx()} (expected Fluent: Set is ignored inside a scope)");
            }
            IconLog.Write($"after scope: {Ctx()} (expected Classic)");
            IconSetContext.Set(before);
        }

        void RenderInScopes() {
            scopePreview.Controls.Clear();
            foreach(var set in IconCatalog.Sets) {
                using(IconSetContext.Use(set)) {
                    foreach(string uri in new[] { "add", "share", "Add;Size16x16" }) {
                        var probe = new CountingDxImageUri(uri);
                        Image? image = probe.GetImage();
                        var picture = new PictureEdit { Size = new Size(70, 70), Image = image, ToolTip = $"Use({set}) '{uri}'" };
                        picture.Properties.SizeMode = PictureSizeMode.Clip;
                        picture.Properties.PictureAlignment = ContentAlignment.MiddleCenter;
                        scopePreview.Controls.Add(picture);
                        IconLog.Write($"Use({set}) '{uri}': HasSvgImage={probe.HasSvgImage} image={(image == null ? "null" : $"{image.Width}x{image.Height}")} OnChanged={probe.ChangedCount}");
                    }
                }
                scopePreview.Controls.Add(new LabelControl { Text = "|", Width = 10 });
            }
        }

        static void OpenOnThread(IconSet set, bool useScope) {
            var thread = new Thread(() => {
                try {
                    IDisposable? scope = null;
                    if(useScope)
                        scope = IconSetContext.Use(set);
                    else
                        IconSetContext.Set(set);
                    IconLog.Write($"UI thread started, {(useScope ? "Use" : "Set")}({set}): {Ctx()}");
                    using(scope) {
                        var form = new EditorsForm();
                        form.Text += $"  [thread {Environment.CurrentManagedThreadId}, context {set}]";
                        Application.Run(form);
                    }
                    IconLog.Write($"UI thread finished: {Ctx()}");
                }
                catch(Exception ex) {
                    IconLog.Error("second UI thread", ex);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
            IconLog.Write($"Main thread after starting the second one: {Ctx()} (must be unaffected)");
        }

        void RenderOnThreadPool() {
            var sets = new[] { IconSet.Fluent, IconSet.Classic, IconSet.Blazor, IconSet.Default };
            var tasks = Enumerable.Range(0, 8).Select(i => Task.Run(() => {
                var set = sets[i % sets.Length];
                using(IconSetContext.Use(set)) {
                    var provider = DxImageAssemblyUtil.ImageProvider;
                    int found = 0;
                    foreach(string id in IconCatalog.Metaphors)
                        if(provider.GetSvgImage(id, set, new Size(16, 16)) != null)
                            found++;
                    var uri = new DxImageUri("add");
                    Image? image = uri.GetImage();
                    return $"thread {Environment.CurrentManagedThreadId} Use({set}): provider resolved {found}/{IconCatalog.Metaphors.Length}, DxImageUri('add').GetImage()={(image == null ? "null" : $"{image.Width}x{image.Height}")}";
                }
            })).ToArray();
            Task.WhenAll(tasks).ContinueWith(t => {
                if(t.IsFaulted) {
                    IconLog.Error("thread pool render", t.Exception!);
                    return;
                }
                foreach(string line in t.Result)
                    IconLog.Write(line);
                IconLog.Write($"UI thread context after pool renders: {Ctx()}");
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        readonly List<GroupControl> panels = new List<GroupControl>();

        void BuildPanels() {
            foreach(string skin in new[] { "WXI", "DevExpress Dark Style", "Office 2010 Black", "Basic" }) {
                var group = new GroupControl { Text = skin, Size = new Size(290, 300) };
                group.LookAndFeel.UseDefaultLookAndFeel = false;
                group.LookAndFeel.SetSkinStyle(skin);
                var info = new LabelControl { Dock = DockStyle.Top, AutoSizeMode = LabelAutoSizeMode.None, Height = 36 };
                info.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                var flow = new FlowLayoutPanel { Dock = DockStyle.Fill };
                foreach(var (caption, uri) in new[] { ("unpinned", "add"), ("legacy", "Add;Size16x16"), ("gray legacy", "Add;Size16x16;GrayScaled"), ("pinned Fluent", "add;Fluent"), ("pinned Classic", "add;Classic"), ("missing", "doesnotexist") }) {
                    var button = new SimpleButton { Text = caption, Size = new Size(125, 36) };
                    button.ImageOptions.ImageUri = uri;
                    Track(button.ImageOptions);
                    flow.Controls.Add(button);
                }
                var edit = new ButtonEdit { Width = 250 };
                edit.Properties.Buttons[0].Kind = ButtonPredefines.Glyph;
                edit.Properties.Buttons[0].ImageOptions.ImageUri = "search";
                flow.Controls.Add(edit);
                group.Controls.Add(flow);
                group.Controls.Add(info);
                group.LookAndFeel.StyleChanged += (s, e) => UpdatePanelInfo(group, info);
                UpdatePanelInfo(group, info);
                panels.Add(group);
                panelsHost.Controls.Add(group);
            }
        }

        static void UpdatePanelInfo(GroupControl group, LabelControl info) {
            info.Text = $"active set={LookAndFeelHelper.GetActiveIconSet(group.LookAndFeel)}, glyph appearance={DxImageUriUtils.GetAppearanceType(group.LookAndFeel)}";
        }

        void CyclePanelSkins() {
            string[] skins = { "WXI", "DevExpress Dark Style", "Office 2010 Black", "Basic", "The Bezier", "Office 2019 Colorful" };
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for(int i = 0; i < 20; i++) {
                foreach(var (group, index) in panels.Select((g, idx) => (g, idx)))
                    group.LookAndFeel.SetSkinStyle(skins[(i + index) % skins.Length]);
                Application.DoEvents();
            }
            IconLog.Write($"Cycled panel skins 20x in {watch.ElapsedMilliseconds} ms, no crash | UI thread {Ctx()}");
        }
    }
}
