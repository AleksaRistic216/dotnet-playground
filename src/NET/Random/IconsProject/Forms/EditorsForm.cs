using DevExpress.Data.Utils.Images;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using IconsProject.Infrastructure;
using DxIcon = DevExpress.Data.Utils.Images.Icon;

namespace IconsProject.Forms {
    public class EditorsForm : TestFormBase {
        public EditorsForm()
            : base("Editors: SimpleButton, ButtonEdit, CheckEdit, context images, drop-downs",
                  "SimpleButton and EditorButtonImageOptions implement IDXImageUriIconStyleProvider (filled-on-hover). The feature flag WindowsFormsSettings.UseFilledIconsOnHover is compiled to false, so hovering must NOT switch to Filled; the status line shows the flag. " +
                  "CheckEdit SVG styles load their glyphs through ResourceImageHelper → IResourceSvgImageFactory, which substitutes mapped Fluent/Classic resources. Buttons with a private LookAndFeel exercise BaseEdit/IDXControl IconSetContext.Set.") {
            AddSections(
                Section("SimpleButton", BuildSimpleButtons(), 200),
                Section("ButtonEdit / editor buttons", BuildButtonEdits(), 150),
                Section("CheckEdit SVG styles (built-in resources through the factory)", BuildCheckEdits(), 190),
                Section("Context images, labels, drop-downs, ToggleSwitch", BuildMisc(), 160),
                Section("Private LookAndFeel per editor", BuildPrivateLookAndFeel(), 110));
        }

        Control BuildSimpleButtons() {
            var flow = new FlowLayoutPanel();
            foreach(var (caption, icon) in IconCatalog.TypedIcons.Take(8)) {
                var button = new SimpleButton { Text = caption, Size = new Size(120, 40) };
                button.ImageOptions.ImageUri = icon;
                button.MouseEnter += (s, e) => LogHover(button);
                Track(button.ImageOptions);
                flow.Controls.Add(button);
            }
            var alignments = new[] { ImageLocation.MiddleLeft, ImageLocation.TopCenter, ImageLocation.MiddleRight, ImageLocation.BottomCenter, ImageLocation.MiddleCenter };
            foreach(var location in alignments) {
                var button = new SimpleButton { Text = location == ImageLocation.MiddleCenter ? string.Empty : location.ToString(), Size = new Size(110, 64) };
                button.ImageOptions.Location = location;
                button.ImageOptions.ImageUri = new DxIcon("save", size: IconSize.Size24);
                Track(button.ImageOptions);
                flow.Controls.Add(button);
            }
            var pinnedFilled = new SimpleButton { Text = "Pinned Filled", Size = new Size(130, 40) };
            pinnedFilled.ImageOptions.ImageUri = new DxIcon("star", style: IconStyle.Filled);
            flow.Controls.Add(pinnedFilled);
            var pinnedClassic = new SimpleButton { Text = "Pinned Classic", Size = new Size(130, 40) };
            pinnedClassic.ImageOptions.ImageUri = new DxIcon("star", IconSet.Classic);
            flow.Controls.Add(pinnedClassic);
            var svgSizeOverride = new SimpleButton { Text = "SvgImageSize 32", Size = new Size(150, 48) };
            svgSizeOverride.ImageOptions.ImageUri = Icons("delete");
            svgSizeOverride.ImageOptions.SvgImageSize = new Size(32, 32);
            flow.Controls.Add(svgSizeOverride);
            var disabled = new SimpleButton { Text = "Disabled", Size = new Size(110, 40), Enabled = false };
            disabled.ImageOptions.ImageUri = Icons("delete");
            flow.Controls.Add(disabled);
            var legacy = new SimpleButton { Text = "Add;Size16x16", Size = new Size(140, 40) };
            legacy.ImageOptions.ImageUri = "Add;Size16x16";
            flow.Controls.Add(legacy);
            var grayLegacy = new SimpleButton { Text = "GrayScaled legacy", Size = new Size(150, 40) };
            grayLegacy.ImageOptions.ImageUri = "Add;Size16x16;GrayScaled";
            flow.Controls.Add(grayLegacy);
            var reassign = new SimpleButton { Text = "Click: cycle uri", Size = new Size(150, 40) };
            int cycle = 0;
            var uris = IconCatalog.AllUris().Select(u => u.Uri).ToArray();
            reassign.Click += (s, e) => {
                string next = uris[cycle++ % uris.Length];
                reassign.ImageOptions.ImageUri.Uri = next;
                reassign.Text = next.Length == 0 ? "(empty)" : next;
                IconLog.Write($"SimpleButton.ImageOptions.ImageUri.Uri = '{next}' HasSvgImage={reassign.ImageOptions.ImageUri.HasSvgImage}");
            };
            flow.Controls.Add(reassign);
            foreach(var c in new Control[] { pinnedFilled, pinnedClassic, svgSizeOverride, disabled, legacy, grayLegacy, reassign })
                Track(((SimpleButton)c).ImageOptions);
            return flow;
        }

        static void LogHover(SimpleButton button) {
            var provider = (IDXImageUriIconStyleProvider)button;
            IconLog.Write($"Hover '{button.Text}': GetPreferredIconStyle()={provider.GetPreferredIconStyle()?.ToString() ?? "null"} (flag={WindowsFormsSettings.UseFilledIconsOnHover}, set={LookAndFeelHelper.GetActiveIconSet(button.LookAndFeel)})");
        }

        Control BuildButtonEdits() {
            var flow = new FlowLayoutPanel();
            var edit = new ButtonEdit { Width = 360 };
            edit.Properties.Buttons.Clear();
            foreach(string id in new[] { "search", "filter_funnel", "delete", "calendar" }) {
                var button = new EditorButton(ButtonPredefines.Glyph) { ToolTip = id };
                button.ImageOptions.ImageUri = Icons(id);
                Track(button.ImageOptions);
                edit.Properties.Buttons.Add(button);
            }
            var filled = new EditorButton(ButtonPredefines.Glyph) { ToolTip = "pinned Filled" };
            filled.ImageOptions.ImageUri = new DxIcon("star", style: IconStyle.Filled);
            edit.Properties.Buttons.Add(filled);
            var legacy = new EditorButton(ButtonPredefines.Glyph) { ToolTip = "legacy Add;Size16x16" };
            legacy.ImageOptions.ImageUri = "Add;Size16x16";
            edit.Properties.Buttons.Add(legacy);
            var missing = new EditorButton(ButtonPredefines.Glyph) { ToolTip = "missing icon (null image must not crash painting)" };
            missing.ImageOptions.ImageUri = "doesnotexist;Fluent";
            edit.Properties.Buttons.Add(missing);
            edit.ButtonClick += (s, e) => IconLog.Write($"ButtonEdit click '{e.Button.ToolTip}': '{e.Button.ImageOptions.ImageUri.Uri}' HasSvgImage={e.Button.ImageOptions.ImageUri.HasSvgImage} preferredStyle={((IDXImageUriIconStyleProvider)e.Button.ImageOptions).GetPreferredIconStyle()?.ToString() ?? "null"}");
            flow.Controls.Add(edit);

            var predefined = new ButtonEdit { Width = 300 };
            predefined.Properties.Buttons.Clear();
            foreach(ButtonPredefines kind in new[] { ButtonPredefines.Ellipsis, ButtonPredefines.Search, ButtonPredefines.Clear, ButtonPredefines.Delete, ButtonPredefines.Plus, ButtonPredefines.Minus, ButtonPredefines.Undo, ButtonPredefines.Redo, ButtonPredefines.OK })
                predefined.Properties.Buttons.Add(new EditorButton(kind));
            flow.Controls.Add(Caption("Predefined kinds:", 110));
            flow.Controls.Add(predefined);

            var captioned = new ButtonEdit { Width = 360 };
            captioned.Properties.Buttons.Clear();
            var withText = new EditorButton(ButtonPredefines.Glyph) { Caption = "Find", ImageOptions = { Location = ImageLocation.MiddleLeft } };
            withText.ImageOptions.ImageUri = Icons("search");
            captioned.Properties.Buttons.Add(withText);
            var date = new DateEdit { Width = 160 };
            var combo = new ComboBoxEdit { Width = 160 };
            combo.Properties.Items.AddRange(new[] { "one", "two" });
            var spin = new SpinEdit { Width = 100 };
            var memoEx = new MemoExEdit { Width = 160 };
            var color = new ColorPickEdit { Width = 160 };
            flow.Controls.AddRange(new Control[] { captioned, date, combo, spin, memoEx, color });
            return flow;
        }

        Control BuildCheckEdits() {
            var flow = new FlowLayoutPanel();
            foreach(CheckBoxStyle style in Enum.GetValues(typeof(CheckBoxStyle))) {
                if(!style.ToString().StartsWith("Svg", StringComparison.Ordinal))
                    continue;
                var check = new CheckEdit { Text = style.ToString(), Width = 150, Checked = flow.Controls.Count % 2 == 0 };
                check.Properties.CheckBoxOptions.Style = style;
                check.Properties.AllowGrayed = true;
                flow.Controls.Add(check);
                var disabled = new CheckEdit { Text = style + " (disabled)", Width = 190, Checked = true, Enabled = false };
                disabled.Properties.CheckBoxOptions.Style = style;
                flow.Controls.Add(disabled);
            }
            var radio = new RadioGroup { Width = 400, Height = 60 };
            radio.Properties.Items.AddRange(new[] { new RadioGroupItem(1, "One"), new RadioGroupItem(2, "Two"), new RadioGroupItem(3, "Three") });
            radio.Properties.Columns = 3;
            radio.SelectedIndex = 1;
            flow.Controls.Add(radio);
            AddToolbarButton(flow, "Recreate check edits", (s, e) => {
                foreach(var check in flow.Controls.OfType<CheckEdit>()) {
                    var style = check.Properties.CheckBoxOptions.Style;
                    check.Properties.CheckBoxOptions.Style = CheckBoxStyle.Default;
                    check.Properties.CheckBoxOptions.Style = style;
                }
                IconLog.Write("CheckEdit styles re-applied (forces the style images to be reloaded through the factory)");
            });
            return flow;
        }

        Control BuildMisc() {
            var flow = new FlowLayoutPanel();
            var contextText = new TextEdit { Width = 200, EditValue = "ContextImageOptions" };
            contextText.Properties.ContextImageOptions.ImageUri = Icons("mail");
            Track(contextText.Properties.ContextImageOptions);
            var contextPinned = new TextEdit { Width = 200, EditValue = "Context pinned Classic" };
            contextPinned.Properties.ContextImageOptions.ImageUri = new DxIcon("mail", IconSet.Classic);
            var label = new LabelControl { Text = "LabelControl + uri", ImageAlignToText = ImageAlignToText.LeftCenter };
            label.ImageOptions.ImageUri = Icons("info");
            Track(label.ImageOptions);
            var labelTop = new LabelControl { Text = "Top", ImageAlignToText = ImageAlignToText.TopCenter };
            labelTop.ImageOptions.ImageUri = new DxIcon("warning", size: IconSize.Size32);
            Track(labelTop.ImageOptions);
            var dropDown = new DropDownButton { Text = "DropDownButton", Size = new Size(170, 40) };
            dropDown.ImageOptions.ImageUri = Icons("share");
            Track(dropDown.ImageOptions);
            var menu = new DXPopupMenu();
            foreach(var (caption, uri) in IconCatalog.IconSetUris.Take(6)) {
                var item = new DXMenuItem(caption);
                item.ImageOptions.ImageUri = uri;
                menu.Items.Add(item);
            }
            var legacyMenuItem = new DXMenuItem("legacy DXImages.Print") { BeginGroup = true };
            legacyMenuItem.ImageOptions.ImageUri = DevExpress.Images.DXImages.Print;
            menu.Items.Add(legacyMenuItem);
            dropDown.DropDownControl = menu;
            var toggle = new ToggleSwitch { Width = 160, IsOn = true };
            var checkButton = new CheckButton { Text = "CheckButton", Size = new Size(150, 40), Checked = true };
            checkButton.ImageOptions.ImageUri = Icons("checkmark");
            Track(checkButton.ImageOptions);
            var hyperlink = new HyperlinkLabelControl { Text = "<href=x>Hyperlink</href>" };
            var imageCombo = new ImageComboBoxEdit { Width = 200 };
            var collection = new SvgImageCollection { ImageSize = new Size(16, 16) };
            var provider = DxImageAssemblyUtil.ImageProvider;
            foreach(string id in new[] { "add", "delete", "save", "search" }) {
                var svg = provider.GetSvgImage(id, IconModeSwitch.ActiveForDefaultLookAndFeel, new Size(16, 16));
                if(svg != null)
                    collection.Add(id, svg);
            }
            imageCombo.Properties.SmallImages = collection;
            for(int i = 0; i < collection.Count; i++)
                imageCombo.Properties.Items.Add(new ImageComboBoxItem(collection[i].ToString() ?? i.ToString(), i, i));
            imageCombo.SelectedIndex = 0;
            flow.Controls.AddRange(new Control[] { contextText, contextPinned, label, labelTop, dropDown, toggle, checkButton, hyperlink, Caption("ImageComboBox (static snapshot of active set at open):", 300), imageCombo });
            return flow;
        }

        Control BuildPrivateLookAndFeel() {
            var flow = new FlowLayoutPanel();
            foreach(string skin in new[] { "WXI", "The Bezier", "DevExpress Dark Style", "Office 2010 Black", "Office 2019 Colorful", "Basic" }) {
                var button = new SimpleButton { Text = skin, Size = new Size(190, 40) };
                button.LookAndFeel.UseDefaultLookAndFeel = false;
                button.LookAndFeel.SetSkinStyle(skin);
                button.ImageOptions.ImageUri = "Add;Size16x16";
                button.Click += (s, e) => IconLog.Write($"'{skin}' button: set={LookAndFeelHelper.GetActiveIconSet(button.LookAndFeel)} appearance={DxImageUriUtils.GetAppearanceType(button.LookAndFeel)} HasSvgImage={button.ImageOptions.ImageUri.HasSvgImage} IconSetContext={IconSetContext()}");
                Track(button.ImageOptions);
                flow.Controls.Add(button);
                var edit = new ButtonEdit { Width = 120 };
                edit.LookAndFeel.UseDefaultLookAndFeel = false;
                edit.LookAndFeel.SetSkinStyle(skin);
                edit.Properties.Buttons[0].Kind = ButtonPredefines.Glyph;
                edit.Properties.Buttons[0].ImageOptions.ImageUri = Icons("search");
                flow.Controls.Add(edit);
            }
            return flow;
        }

        static string IconSetContext() => DevExpress.Utils.Design.IconSetContext.HasValue ? DevExpress.Utils.Design.IconSetContext.Current.ToString() : "none";

        static DxIcon Icons(string id) => new DxIcon(id);
    }
}
