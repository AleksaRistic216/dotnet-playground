using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace IconsProject.Infrastructure {
    public class TestFormBase : XtraForm {
        readonly List<ImageOptions> trackedOptions = new List<ImageOptions>();
        readonly LabelControl statusLabel;
        readonly MemoEdit logMemo;
        readonly PanelControl toolbar;

        public TestFormBase(string title, string hint) {
            Text = title;
            Size = new Size(1280, 860);
            StartPosition = FormStartPosition.CenterScreen;

            Body = new XtraScrollableControl { Dock = DockStyle.Fill };
            Controls.Add(Body);

            logMemo = new MemoEdit { Dock = DockStyle.Bottom, Height = 150 };
            logMemo.Properties.ReadOnly = true;
            logMemo.Properties.ScrollBars = ScrollBars.Both;
            logMemo.Properties.WordWrap = false;
            Controls.Add(new SplitterControl { Dock = DockStyle.Bottom });
            Controls.Add(logMemo);

            toolbar = new PanelControl { Dock = DockStyle.Top, Height = 96 };
            Controls.Add(toolbar);

            var flow = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 36, WrapContents = false, AutoScroll = true, BackColor = Color.Transparent };
            AddModeButton(flow, "Theme based", IconMode.ThemeBased);
            AddModeButton(flow, "Fluent", IconMode.Fluent);
            AddModeButton(flow, "Classic", IconMode.Classic);

            var skinCombo = new ComboBoxEdit { Width = 220 };
            skinCombo.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            foreach(SkinContainer skin in SkinManager.Default.Skins)
                skinCombo.Properties.Items.Add(skin.SkinName);
            skinCombo.EditValue = UserLookAndFeel.Default.ActiveSkinName;
            skinCombo.EditValueChanged += (s, e) => {
                UserLookAndFeel.Default.SetSkinStyle((string)skinCombo.EditValue);
                IconLog.Write($"Skin -> {skinCombo.EditValue} | {IconModeSwitch.Describe()}");
            };
            flow.Controls.Add(skinCombo);

            AddToolbarButton(flow, "Refresh() tracked URIs", (s, e) => RefreshTrackedUris());
            AddToolbarButton(flow, "Dump state", (s, e) => DumpState());
            AddToolbarButton(flow, "Clear log", (s, e) => logMemo.Text = string.Empty);
            AddToolbarButton(flow, "RTL toggle", (s, e) => {
                RightToLeft = RightToLeft == RightToLeft.Yes ? RightToLeft.No : RightToLeft.Yes;
                RightToLeftLayout = RightToLeft == RightToLeft.Yes;
                IconLog.Write($"{Text}: RightToLeft={RightToLeft}");
            });

            statusLabel = new LabelControl { Dock = DockStyle.Top, AutoSizeMode = LabelAutoSizeMode.None, Height = 22, Padding = new Padding(6, 3, 6, 0) };
            var hintLabel = new LabelControl { Dock = DockStyle.Fill, AutoSizeMode = LabelAutoSizeMode.None, Padding = new Padding(6, 2, 6, 2), Text = hint };
            hintLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            hintLabel.Appearance.ForeColor = Color.Gray;
            toolbar.Controls.Add(hintLabel);
            toolbar.Controls.Add(statusLabel);
            toolbar.Controls.Add(flow);

            IconLog.Logged += OnLogged;
            IconModeSwitch.Changed += OnIconModeChangedCore;
            UserLookAndFeel.Default.StyleChanged += OnDefaultLookAndFeelChanged;
            LookAndFeel.StyleChanged += OnDefaultLookAndFeelChanged;
            UpdateStatus();
        }

        protected XtraScrollableControl Body { get; }

        protected SimpleButton AddToolbarButton(Control parent, string caption, EventHandler click) {
            var button = new SimpleButton { Text = caption, AutoSize = true, Margin = new Padding(3) };
            button.Click += (s, e) => {
                try {
                    click(s, e);
                }
                catch(Exception ex) {
                    IconLog.Error($"{Text}/{caption}", ex);
                }
            };
            parent.Controls.Add(button);
            return button;
        }

        void AddModeButton(Control parent, string caption, IconMode mode) {
            var button = AddToolbarButton(parent, caption, (s, e) => IconModeSwitch.Apply(mode));
            button.ImageOptions.ImageUri = mode == IconMode.Fluent ? "star;Fluent" : mode == IconMode.Classic ? "star;Classic" : "star";
        }

        protected T Track<T>(T options) where T : ImageOptions {
            trackedOptions.Add(options);
            return options;
        }

        protected IEnumerable<ImageOptions> TrackedOptions => trackedOptions;

        protected virtual void RefreshTrackedUris() {
            int refreshed = 0;
            foreach(var options in trackedOptions) {
                if(options.ImageUri == null || string.IsNullOrEmpty(options.ImageUri.Uri))
                    continue;
                options.ImageUri.Refresh();
                refreshed++;
            }
            IconLog.Write($"{Text}: DxImageUri.Refresh() on {refreshed} tracked uris");
            Invalidate(true);
        }

        protected virtual void DumpState() {
            IconLog.Write($"{Text}: {IconModeSwitch.Describe()} | form active set={LookAndFeelHelper.GetActiveIconSet(LookAndFeel)} | UseFilledIconsOnHover={WindowsFormsSettings.UseFilledIconsOnHover}");
            foreach(var options in trackedOptions.Take(40)) {
                var uri = options.ImageUri;
                if(uri == null || string.IsNullOrEmpty(uri.Uri))
                    continue;
                IconLog.Write($"   '{uri.Uri}' HasSvgImage={uri.HasSvgImage} HasImage={uri.HasImage} HasLargeImage={uri.HasLargeImage} ImageType={uri.ImageType} ImageSize={uri.ImageSize}");
            }
        }

        protected virtual void OnIconModeChanged() {
        }

        void OnIconModeChangedCore(object? sender, EventArgs e) {
            if(IsDisposed)
                return;
            UpdateStatus();
            OnIconModeChanged();
        }

        void OnDefaultLookAndFeelChanged(object? sender, EventArgs e) {
            if(!IsDisposed)
                UpdateStatus();
        }

        protected void UpdateStatus() {
            statusLabel.Text = $"Mode={IconModeSwitch.Mode} | {IconModeSwitch.Describe()} | this form's set={LookAndFeelHelper.GetActiveIconSet(LookAndFeel)} | UseFilledIconsOnHover={WindowsFormsSettings.UseFilledIconsOnHover}";
        }

        void OnLogged(string line) {
            if(IsDisposed || !IsHandleCreated)
                return;
            BeginInvoke(new Action(() => {
                if(logMemo.IsDisposed)
                    return;
                logMemo.MaskBox.AppendText(line + Environment.NewLine);
            }));
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                IconLog.Logged -= OnLogged;
                IconModeSwitch.Changed -= OnIconModeChangedCore;
                UserLookAndFeel.Default.StyleChanged -= OnDefaultLookAndFeelChanged;
            }
            base.Dispose(disposing);
        }

        protected static LabelControl Caption(string text, int width = 260) {
            var label = new LabelControl { Text = text, AutoSizeMode = LabelAutoSizeMode.None, Width = width, Height = 20, Margin = new Padding(3, 8, 3, 3) };
            label.Appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
            return label;
        }

        protected static GroupControl Section(string text, Control content, int height) {
            var group = new GroupControl { Text = text, Dock = DockStyle.Top, Height = height };
            content.Dock = DockStyle.Fill;
            group.Controls.Add(content);
            return group;
        }

        protected void AddSections(params Control[] sections) {
            for(int i = sections.Length - 1; i >= 0; i--) {
                Body.Controls.Add(sections[i]);
            }
        }
    }
}
