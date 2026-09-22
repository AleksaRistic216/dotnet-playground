using DevExpress.Data.Utils.Images;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using IconsProject.Infrastructure;
using DxIcon = DevExpress.Data.Utils.Images.Icon;

namespace IconsProject.Forms {
    public class IconBuilderForm : TestFormBase {
        readonly ComboBoxEdit idEdit;
        readonly ImageComboBoxEdit setEdit, styleEdit, colorEdit, sizeEdit;
        readonly TextEdit rawEdit;
        readonly MemoEdit resultMemo;
        readonly FlowLayoutPanel previewPanel;

        public IconBuilderForm()
            : base("Icon builder / parser",
                  "Compose an Icon from the four axes, or type a raw uri. Shows Icon.ToString(), Parse/TryParse round-trips, what DxImageUri reports and what the image provider resolves. " +
                  "Preview row renders the same uri through SimpleButton, LabelControl, PictureEdit(GetImage/GetLargeImage/GetSvgImage) and the provider directly.") {
            var editors = new FlowLayoutPanel { AutoSize = false, WrapContents = true };
            idEdit = new ComboBoxEdit { Width = 180, EditValue = "add" };
            idEdit.Properties.Items.AddRange(IconCatalog.Metaphors);
            setEdit = EnumEditor(IconCatalog.Sets);
            styleEdit = EnumEditor(IconCatalog.Styles);
            colorEdit = EnumEditor(IconCatalog.Colors);
            sizeEdit = EnumEditor(IconCatalog.Sizes);
            editors.Controls.AddRange(new Control[] { Caption("Id", 30), idEdit, Caption("Set", 30), setEdit, Caption("Style", 40), styleEdit, Caption("Color", 40), colorEdit, Caption("Size", 30), sizeEdit });
            AddToolbarButton(editors, "Build Icon", (s, e) => ShowUri(BuildIcon().ToString(), BuildIcon()));

            rawEdit = new TextEdit { Width = 420, EditValue = "add;Fluent;Filled;Monochrome;Size24" };
            var rawCombo = new ComboBoxEdit { Width = 260 };
            foreach(var entry in IconCatalog.AllUris())
                rawCombo.Properties.Items.Add(entry.Uri);
            rawCombo.SelectedIndexChanged += (s, e) => rawEdit.EditValue = rawCombo.EditValue;
            editors.Controls.AddRange(new Control[] { Caption("Raw uri", 60), rawEdit, rawCombo });
            AddToolbarButton(editors, "Use raw uri", (s, e) => ShowUri(rawEdit.Text, null));
            AddToolbarButton(editors, "Icon.Parse(raw)", (s, e) => ParseRaw(false));
            AddToolbarButton(editors, "Icon.TryParse(raw)", (s, e) => ParseRaw(true));
            AddToolbarButton(editors, "Parse every combination", (s, e) => ParseEverything());

            previewPanel = new FlowLayoutPanel { AutoScroll = true };
            resultMemo = new MemoEdit();
            resultMemo.Properties.ReadOnly = true;
            resultMemo.Properties.WordWrap = false;
            resultMemo.Properties.ScrollBars = ScrollBars.Both;
            resultMemo.Font = new Font("Consolas", 9f);

            AddSections(
                Section("Compose", editors, 130),
                Section("Preview", previewPanel, 150),
                Section("Result", resultMemo, 360));
            ShowUri(BuildIcon().ToString(), BuildIcon());
        }

        static ImageComboBoxEdit EnumEditor<T>(T[] values) where T : struct, Enum {
            var editor = new ImageComboBoxEdit { Width = 120 };
            foreach(var value in values)
                editor.Properties.Items.Add(new ImageComboBoxItem(value.ToString(), value));
            editor.EditValue = values[0];
            return editor;
        }

        DxIcon BuildIcon() {
            return new DxIcon(idEdit.Text, (IconSet)setEdit.EditValue, (IconStyle)styleEdit.EditValue, (IconColor)colorEdit.EditValue, (IconSize)sizeEdit.EditValue);
        }

        void ParseRaw(bool useTryParse) {
            string raw = rawEdit.Text;
            if(useTryParse) {
                bool ok = DxIcon.TryParse(raw, out DxIcon parsed);
                IconLog.Write($"Icon.TryParse('{raw}') -> {ok}{(ok ? " => '" + parsed + "'" : string.Empty)}");
                if(ok)
                    ShowUri(parsed.ToString(), parsed);
                return;
            }
            try {
                DxIcon parsed = DxIcon.Parse(raw);
                IconLog.Write($"Icon.Parse('{raw}') => '{parsed}' (Set={parsed.Set}, Style={parsed.Style}, Color={parsed.Color}, Size={parsed.Size})");
                ShowUri(parsed.ToString(), parsed);
            }
            catch(Exception ex) {
                IconLog.Write($"Icon.Parse('{raw}') threw {ex.GetType().Name}: {ex.Message}");
            }
        }

        void ParseEverything() {
            int total = 0, failures = 0;
            foreach(var set in IconCatalog.Sets)
                foreach(var style in IconCatalog.Styles)
                    foreach(var color in IconCatalog.Colors)
                        foreach(var size in IconCatalog.Sizes) {
                            total++;
                            var icon = new DxIcon("add", set, style, color, size);
                            string text = icon.ToString();
                            var parsed = DxIcon.Parse(text);
                            bool same = parsed.Set == set && parsed.Style == style && parsed.Color == color && parsed.Size == size && parsed.ToString() == text;
                            DxImageUri uri = icon;
                            bool uriSame = uri.Uri == text;
                            if(!same || !uriSame) {
                                failures++;
                                IconLog.Fail("round-trip", $"'{text}' parsed='{parsed}' uri='{uri.Uri}'");
                            }
                        }
            if(failures == 0)
                IconLog.Pass("round-trip", $"{total} combinations: Icon -> string -> Icon.Parse -> string, and Icon -> DxImageUri.Uri");
        }

        string lastUri = string.Empty;
        DxIcon? lastIcon;

        void ShowUri(string uriText, DxIcon? icon) {
            lastUri = uriText;
            lastIcon = icon;
            previewPanel.Controls.Clear();
            var lines = new List<string>();
            lines.Add($"uri text        : '{uriText}'");
            if(icon != null) {
                string asString = icon;
                lines.Add($"Icon.ToString() : '{icon}'   implicit string: '{asString}'");
                lines.Add($"Icon axes       : Set={icon.Set} Style={icon.Style} Color={icon.Color} Size={icon.Size}");
                lines.Add($"expected file   : {IconCatalog.ExpectedFileName(idEdit.Text, icon.Set == IconSet.Default ? IconModeSwitch.ActiveForDefaultLookAndFeel : icon.Set, icon.Style, icon.Color, icon.Size)} (informational; Default parts resolved by the cache)");
            }
            lines.Add($"Icon.TryParse   : {(DxIcon.TryParse(uriText, out var reparsed) ? "'" + reparsed + "'" : "false")}");

            var probe = new CountingDxImageUri(uriText);
            lines.Add($"DxImageUri      : HasSvgImage={probe.HasSvgImage} HasImage={probe.HasImage} HasLargeImage={probe.HasLargeImage} HasDefaultImage={probe.HasDefaultImage}");
            lines.Add($"                  ImageType={probe.ImageType} ImageSize={probe.ImageSize} IsInitialized={probe.IsInitialized} GetSizeProviderPreferredIconSize={probe.GetSizeProviderPreferredIconSize()}");
            Image? small = SafeGet(() => probe.GetImage());
            Image? large = SafeGet(() => probe.GetLargeImage());
            Image? svg24 = SafeGet(() => probe.GetSvgImage(new Size(24, 24), null));
            Image? scaled = SafeGet(() => probe.GetScaledSvgImage(null));
            lines.Add($"GetImage()      : {Describe(small)}");
            lines.Add($"GetLargeImage() : {Describe(large)}");
            lines.Add($"GetSvgImage(24) : {Describe(svg24)}");
            lines.Add($"GetScaledSvg    : {Describe(scaled)}");
            lines.Add($"OnChanged calls : {probe.ChangedCount} (reentered={probe.IsChangedReentered})");

            string id = uriText.Split(';', ',')[0];
            var provider = DxImageAssemblyUtil.ImageProvider;
            lines.Add($"mapped id       : '{SafeGet(() => provider.GetMappedSvgImageId(id)) ?? "(null)"}'");
            foreach(var set in IconCatalog.Sets) {
                var row = new List<string>();
                foreach(var size in new[] { IconSize.Size16, IconSize.Size24, IconSize.Size32 }) {
                    SvgImage? found = SafeGet(() => provider.GetSvgImage(id, set, IconCatalog.PixelSize(size)));
                    row.Add($"{IconCatalog.PixelSize(size).Width}:{(found == null ? "-" : $"{found.Width:0}x{found.Height:0}")}");
                }
                lines.Add($"provider {set,-8}: {string.Join("  ", row)}");
            }
            resultMemo.Text = string.Join(Environment.NewLine, lines);

            var button = new SimpleButton { Text = "SimpleButton", Size = new Size(150, 60) };
            button.ImageOptions.ImageUri = uriText;
            var iconOnly = new SimpleButton { Size = new Size(60, 60), PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light };
            iconOnly.ImageOptions.ImageUri = uriText;
            iconOnly.ImageOptions.Location = ImageLocation.MiddleCenter;
            var label = new LabelControl { Text = "LabelControl", ImageAlignToText = ImageAlignToText.LeftCenter, Margin = new Padding(10, 20, 10, 0) };
            label.ImageOptions.ImageUri = uriText;
            previewPanel.Controls.Add(button);
            previewPanel.Controls.Add(iconOnly);
            previewPanel.Controls.Add(label);
            AddPicture("GetImage", small);
            AddPicture("GetLargeImage", large);
            AddPicture("GetSvgImage 24", svg24);
            AddPicture("Scaled", scaled);
            SvgImage? direct = SafeGet(() => provider.GetSvgImage(id, icon?.Set ?? IconSet.Default, IconCatalog.PixelSize(icon?.Size ?? IconSize.Size32), icon?.Color ?? IconColor.Default, icon?.Style ?? IconStyle.Default));
            var directPicture = new PictureEdit { Size = new Size(90, 90), SvgImage = direct, ToolTip = "provider.GetSvgImage(id, set, size, color, style)" };
            directPicture.Properties.SizeMode = PictureSizeMode.Squeeze;
            previewPanel.Controls.Add(directPicture);
            Track(button.ImageOptions);
            Track(iconOnly.ImageOptions);
            Track(label.ImageOptions);
            IconLog.Write($"Builder: '{uriText}' HasSvgImage={probe.HasSvgImage} small={Describe(small)} direct={(direct == null ? "null" : "svg")}");
        }

        void AddPicture(string caption, Image? image) {
            var picture = new PictureEdit { Size = new Size(90, 90), Image = image, ToolTip = caption };
            picture.Properties.SizeMode = PictureSizeMode.Clip;
            picture.Properties.PictureAlignment = ContentAlignment.MiddleCenter;
            previewPanel.Controls.Add(picture);
        }

        static string Describe(Image? image) => image == null ? "null" : $"{image.Width}x{image.Height} {image.GetType().Name}";

        static T? SafeGet<T>(Func<T> getter) where T : class {
            try {
                return getter();
            }
            catch(Exception ex) {
                IconLog.Error("IconBuilder", ex);
                return null;
            }
        }

        protected override void OnIconModeChanged() {
            ShowUri(lastUri, lastIcon);
        }
    }
}
