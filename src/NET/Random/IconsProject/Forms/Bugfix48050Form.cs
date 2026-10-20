using System.Diagnostics;
using DevExpress.IconLibrary;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using IconsProject.Infrastructure;

namespace IconsProject.Forms {
    public class Bugfix48050Form : TestFormBase, IAutoRunnable {
        static readonly string[] ProbeUris = {
            "Add;Size16x16",
            "Add;Size32x32",
            "Add;Size16x16;GrayScaled",
            "Add;Size16x16;Colored",
            "add",
            "add;Fluent",
            "add;DesktopClassic",
            "doesnotexist",
            "doesnotexist;Fluent",
            "fluentxaf/action_edit;Fluent",
            DevExpress.Images.DXImages.Add
        };

        readonly FlowLayoutPanel stressHost;
        readonly SpinEdit countEdit;
        readonly LabelControl verdict;
        int failures;

        public Bugfix48050Form()
            : base("dxvcs#48050 — OnChanged usage in DxImageUri (HasSvgImage StackOverflow)",
                  "Before the fix, DxImageUri.HasSvgImage called OnChanged() when IconSetContext had a value different from the parsed set; OnChanged → SetClientGlyphSkinning → GetGlyphSkinningValue → HasSvgImage → OnChanged … overflowed the stack for non-SVG uris under a Gray-appearance skin. " +
                  "Now HasSvgImage is a plain read of UriData. These scenarios assert: no OnChanged from reads, no re-entry, and real controls survive icon-set/skin churn. A StackOverflow cannot be caught — if it regresses, this process dies.") {
            var actions = new FlowLayoutPanel();
            countEdit = new SpinEdit { Width = 80 };
            countEdit.Properties.MinValue = 1;
            countEdit.Properties.MaxValue = 5000;
            countEdit.EditValue = 150;
            AddToolbarButton(actions, "1. Probe: HasSvgImage reads never call OnChanged", (s, e) => ScenarioReadsDoNotReparse());
            AddToolbarButton(actions, "2. Probe: set changed after construction", (s, e) => ScenarioSetChangedAfterConstruction());
            AddToolbarButton(actions, "3. Probe: glyph skinning path, every Gray skin", (s, e) => ScenarioGlyphSkinningAllGraySkins());
            AddToolbarButton(actions, "4. Refresh() re-parses exactly once", (s, e) => ScenarioRefresh());
            AddToolbarButton(actions, "5. Stale HasSvgImage after mode switch (informational)", (s, e) => ScenarioStaleAfterSwitch());
            actions.Controls.Add(Caption("controls:", 60));
            actions.Controls.Add(countEdit);
            AddToolbarButton(actions, "6. Real controls: churn modes × Gray skins", (s, e) => ScenarioRealControls());
            AddToolbarButton(actions, "7. Uri reassignment loop on live buttons", (s, e) => ScenarioReassign());
            AddToolbarButton(actions, "8. Open original Form1 in each mode", (s, e) => ScenarioForm1());
            AddToolbarButton(actions, "Run 1–7", (s, e) => RunAll());
            verdict = new LabelControl { Text = "not run", AutoSizeMode = LabelAutoSizeMode.None, Width = 600, Height = 28 };
            verdict.Appearance.Font = new Font(verdict.Appearance.Font.FontFamily, 12f, FontStyle.Bold);
            actions.Controls.Add(verdict);
            stressHost = new FlowLayoutPanel { AutoScroll = true };
            AddSections(Section("Scenarios", actions, 170), Section("Stress controls", stressHost, 460));
        }

        void Check(bool condition, string name, string details) {
            if(condition)
                IconLog.Pass(name, details);
            else {
                failures++;
                IconLog.Fail(name, details);
            }
            verdict.Text = failures == 0 ? "no failures so far" : $"{failures} FAILURE(S) — see log";
            verdict.Appearance.ForeColor = failures == 0 ? Color.SeaGreen : Color.Firebrick;
        }

        static string[] GraySkins() {
            var result = new List<string>();
            foreach(SkinContainer skin in SkinManager.Default.Skins) {
                using var lookAndFeel = new UserLookAndFeel(null) { UseDefaultLookAndFeel = false };
                lookAndFeel.SetSkinStyle(skin.SkinName);
                if(DxImageUriUtils.GetAppearanceType(lookAndFeel) == SkinAppearanceType.Gray)
                    result.Add(skin.SkinName);
            }
            return result.ToArray();
        }

        void ScenarioReadsDoNotReparse() {
            foreach(var set in new[] { IconSet.Fluent, IconSet.DesktopClassic, IconSet.BlazorClassic }) {
                using(IconSetContext.Use(set))
                using(var client = new ProbeClient("DevExpress Dark Style")) {
                    foreach(string uri in ProbeUris) {
                        var probe = new CountingDxImageUri(uri);
                        probe.SetClient(client);
                        bool reentered = probe.IsChangedReentered;
                        probe.ResetCounters();
                        for(int i = 0; i < 1000; i++) {
                            _ = probe.HasSvgImage;
                            _ = probe.HasImage;
                            _ = probe.HasLargeImage;
                        }
                        Check(!reentered && probe.ChangedCount == 0,
                            "reads-do-not-reparse",
                            $"Use({set}) '{uri}': SetClient reentered={reentered}, OnChanged after 3000 reads={probe.ChangedCount}, glyphSkinning calls={client.SetGlyphSkinningValueCount}, HasSvgImage={probe.HasSvgImage}");
                        probe.Dispose();
                    }
                }
            }
        }

        void ScenarioSetChangedAfterConstruction() {
            foreach(var (from, to) in new[] { (IconSet.DesktopClassic, IconSet.Fluent), (IconSet.Fluent, IconSet.DesktopClassic), (IconSet.Fluent, IconSet.BlazorClassic), (IconSet.BlazorClassic, IconSet.Fluent) }) {
                foreach(string uri in ProbeUris) {
                    CountingDxImageUri probe;
                    bool before;
                    using(IconSetContext.Use(from)) {
                        probe = new CountingDxImageUri(uri);
                        before = probe.HasSvgImage;
                    }
                    using(IconSetContext.Use(to)) {
                        probe.ResetCounters();
                        bool after = probe.HasSvgImage;
                        _ = probe.HasImage;
                        _ = probe.HasLargeImage;
                        Check(probe.ChangedCount == 0 && !probe.IsChangedReentered,
                            "set-changed-after-construction",
                            $"'{uri}' built under {from}, read under {to}: OnChanged={probe.ChangedCount}, HasSvgImage {before}->{after}");
                    }
                    probe.Dispose();
                }
            }
        }

        void ScenarioGlyphSkinningAllGraySkins() {
            string[] graySkins = GraySkins();
            IconLog.Info("gray skins", string.Join(", ", graySkins));
            foreach(string skin in graySkins) {
                using(IconSetContext.Use(IconSet.Fluent))
                using(var client = new ProbeClient(skin)) {
                    foreach(string uri in ProbeUris) {
                        var probe = new CountingDxImageUri(uri);
                        probe.SetClient(client);
                        client.LookAndFeel.SetSkinStyle(skin == "DevExpress Dark Style" ? "Office 2010 Black" : "DevExpress Dark Style");
                        client.LookAndFeel.SetSkinStyle(skin);
                        Check(!probe.IsChangedReentered && probe.MaxDepth <= 1,
                            "glyph-skinning-no-reentry",
                            $"{skin} '{uri}': OnChanged={probe.ChangedCount} maxDepth={probe.MaxDepth} glyphSkinning={client.GlyphSkinningValue} ({client.SetGlyphSkinningValueCount} calls)");
                        probe.Dispose();
                    }
                }
            }
        }

        void ScenarioRefresh() {
            using(IconSetContext.Use(IconSet.Fluent)) {
                foreach(string uri in ProbeUris) {
                    var probe = new CountingDxImageUri(uri);
                    int raised = 0;
                    probe.Changed += (s, e) => raised++;
                    probe.ResetCounters();
                    probe.Refresh();
                    bool expectNoOp = string.IsNullOrEmpty(uri);
                    Check(expectNoOp ? probe.ChangedCount == 0 : probe.ChangedCount == 1 && !probe.IsChangedReentered,
                        "refresh-reparses-once",
                        $"'{uri}': Refresh() → OnChanged={probe.ChangedCount}, Changed events={raised}, HasSvgImage={probe.HasSvgImage}");
                    probe.Dispose();
                    probe.Refresh();
                    Check(true, "refresh-after-dispose", $"'{uri}': Refresh() on a disposed uri did not throw");
                }
            }
        }

        void ScenarioStaleAfterSwitch() {
            IconMode original = IconModeSwitch.Mode;
            var previousDefault = WindowsFormsSettings.AllowDefaultSvgImages;
            try {
                WindowsFormsSettings.AllowDefaultSvgImages = DefaultBoolean.True;
                foreach(string uri in new[] { "add", "share", "star", "Add;Size16x16" }) {
                    IconModeSwitch.Apply(IconMode.Classic);
                    var probe = new CountingDxImageUri(uri);
                    bool underClassic = probe.HasSvgImage;
                    IconModeSwitch.Apply(IconMode.Fluent);
                    probe.ResetCounters();
                    bool readAfterSwitch = probe.HasSvgImage;
                    int changedByRead = probe.ChangedCount;
                    probe.Refresh();
                    bool afterRefresh = probe.HasSvgImage;
                    IconLog.Info("stale-after-switch",
                        $"'{uri}' AllowDefaultSvgImages=True: Classic={underClassic}, read after switch to Fluent={readAfterSwitch} (OnChanged={changedByRead}), after Refresh()={afterRefresh}. A difference means only an explicit Changed/Refresh updates HasSvgImage now.");
                    probe.Dispose();
                }
            }
            finally {
                WindowsFormsSettings.AllowDefaultSvgImages = previousDefault;
                IconModeSwitch.Apply(original);
            }
        }

        void ScenarioRealControls() {
            string[] graySkins = GraySkins();
            string originalSkin = UserLookAndFeel.Default.ActiveSkinName;
            IconMode originalMode = IconModeSwitch.Mode;
            int count = Convert.ToInt32(countEdit.EditValue);
            var watch = Stopwatch.StartNew();
            stressHost.SuspendLayout();
            foreach(Control c in stressHost.Controls.Cast<Control>().ToArray())
                c.Dispose();
            var ribbon = new RibbonControl { Dock = DockStyle.None, Size = new Size(1100, 160), ShowApplicationButton = DefaultBoolean.False };
            var page = new RibbonPage { Text = "Stress" };
            var group = new RibbonPageGroup { Text = "Items" };
            page.Groups.Add(group);
            ribbon.Pages.Add(page);
            for(int i = 0; i < count; i++) {
                string uri = ProbeUris[i % ProbeUris.Length];
                var button = new SimpleButton { Text = uri, Size = new Size(170, 32) };
                button.ImageOptions.ImageUri = uri;
                stressHost.Controls.Add(button);
                if(i < 40) {
                    var item = new BarButtonItem { Caption = uri };
                    item.ImageOptions.ImageUri = uri;
                    ribbon.Items.Add(item);
                    group.ItemLinks.Add(item);
                }
            }
            stressHost.Controls.Add(ribbon);
            stressHost.ResumeLayout();
            Application.DoEvents();
            int cycles = 0;
            try {
                foreach(string skin in graySkins.Concat(new[] { "WXI", "Basic" })) {
                    UserLookAndFeel.Default.SetSkinStyle(skin);
                    foreach(IconMode mode in new[] { IconMode.Fluent, IconMode.Classic, IconMode.ThemeBased, IconMode.Fluent }) {
                        IconModeSwitch.Apply(mode);
                        using(IconSetContext.Use(mode == IconMode.Classic ? IconSet.DesktopClassic : IconSet.Fluent)) {
                            foreach(var button in stressHost.Controls.OfType<SimpleButton>()) {
                                _ = button.ImageOptions.ImageUri.HasSvgImage;
                                button.Invalidate();
                            }
                        }
                        stressHost.Refresh();
                        Application.DoEvents();
                        cycles++;
                    }
                }
                Check(true, "real-controls-survive", $"{count} SimpleButtons + {Math.Min(count, 40)} BarButtonItems, {cycles} mode/skin cycles over [{string.Join(", ", graySkins)}, WXI, Basic] in {watch.ElapsedMilliseconds} ms");
            }
            catch(Exception ex) {
                failures++;
                IconLog.Error("real-controls-survive", ex);
            }
            finally {
                UserLookAndFeel.Default.SetSkinStyle(originalSkin);
                IconModeSwitch.Apply(originalMode);
            }
        }

        void ScenarioReassign() {
            var buttons = stressHost.Controls.OfType<SimpleButton>().Take(30).ToArray();
            if(buttons.Length == 0) {
                IconLog.Info("reassign", "run scenario 6 first to create live buttons");
                return;
            }
            var watch = Stopwatch.StartNew();
            string[] all = ProbeUris.Concat(IconCatalog.EdgeUris.Select(e => e.Uri)).ToArray();
            using(IconSetContext.Use(IconSet.Fluent)) {
                for(int round = 0; round < 20; round++) {
                    for(int i = 0; i < buttons.Length; i++) {
                        buttons[i].ImageOptions.ImageUri.Uri = all[(round + i) % all.Length];
                        _ = buttons[i].ImageOptions.ImageUri.HasSvgImage;
                    }
                    Application.DoEvents();
                }
            }
            Check(true, "uri-reassign-loop", $"{buttons.Length} live buttons × 20 rounds of Uri reassignment under Use(Fluent) in {watch.ElapsedMilliseconds} ms");
        }

        void ScenarioForm1() {
            IconMode original = IconModeSwitch.Mode;
            foreach(IconMode mode in Enum.GetValues(typeof(IconMode))) {
                IconModeSwitch.Apply(mode);
                using var form = new Form1();
                form.Text = $"Form1 under {mode}";
                form.Show(this);
                Application.DoEvents();
                form.Refresh();
                Application.DoEvents();
                form.Close();
                Check(true, "form1-opens", $"Form1 created, shown and closed under {mode}");
            }
            IconModeSwitch.Apply(original);
        }

        public void RunAll() {
            failures = 0;
            ScenarioReadsDoNotReparse();
            ScenarioSetChangedAfterConstruction();
            ScenarioGlyphSkinningAllGraySkins();
            ScenarioRefresh();
            ScenarioStaleAfterSwitch();
            ScenarioRealControls();
            ScenarioReassign();
            IconLog.Write(failures == 0 ? "#48050: all scenarios passed" : $"#48050: {failures} failure(s)");
        }
    }
}
