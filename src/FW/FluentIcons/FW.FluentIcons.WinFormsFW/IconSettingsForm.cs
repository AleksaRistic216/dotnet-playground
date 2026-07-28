using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Images;
using DevExpress.Data.Utils.Images;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace FW.FluentIcons.WinFormsFW {
    public partial class IconSettingsForm : RibbonForm {
        FlowLayoutPanel previewPanel;
        LabelControl statusLabel;

        public IconSettingsForm() {
            InitializeComponent();
            BuildUI();
        }

        void BuildUI() {
            Text = "Icon Settings — Live Configuration";
            ClientSize = new Size(1000, 700);

            var ribbon = new RibbonControl();
            ribbon.ShowApplicationButton = DefaultBoolean.False;
            Controls.Add(ribbon);
            Ribbon = ribbon;

            var page = new RibbonPage("Settings");
            ribbon.Pages.Add(page);
            var group = new RibbonPageGroup("Actions");
            page.Groups.Add(group);

            var btnReset = new BarButtonItem { Caption = "Reset to Fluent" };
            btnReset.ImageOptions.ImageUri.Uri = "refresh";
            btnReset.ItemClick += (s, e) => {
                WindowsFormsSettings.ActiveIconSet = IconSet.Fluent;
                IconSetSettings.IconStyle = IconStyle.Regular;
                IconSetSettings.IconColor = IconColor.Monochrome;
                RefreshAll();
            };
            ribbon.Items.Add(btnReset);
            group.ItemLinks.Add(btnReset);

            // Split panel: left = settings, right = preview
            var splitContainer = new SplitContainerControl { Dock = DockStyle.Fill, SplitterPosition = 350 };
            Controls.Add(splitContainer);
            splitContainer.BringToFront();

            // Left panel - settings
            var settingsLayout = new FlowLayoutPanel {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                Padding = new Padding(15)
            };
            splitContainer.Panel1.Controls.Add(settingsLayout);

            var headerLabel = new LabelControl {
                Text = "Icon Configuration",
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 300, Height = 35,
                Appearance = { Font = new Font("Segoe UI", 14, FontStyle.Bold) }
            };
            settingsLayout.Controls.Add(headerLabel);

            // IconSet toggle
            settingsLayout.Controls.Add(CreateSectionLabel("Active Icon Set"));
            var iconSetCombo = new ComboBoxEdit { Width = 280 };
            foreach (var val in Enum.GetValues(typeof(IconSet)))
                iconSetCombo.Properties.Items.Add(val);
            iconSetCombo.EditValue = WindowsFormsSettings.ActiveIconSet;
            iconSetCombo.SelectedIndexChanged += (s, e) => {
                WindowsFormsSettings.ActiveIconSet = (IconSet)iconSetCombo.EditValue;
                RefreshAll();
            };
            settingsLayout.Controls.Add(iconSetCombo);

            // IconStyle toggle
            settingsLayout.Controls.Add(CreateSectionLabel("Icon Style"));
            var styleToggle = new ToggleSwitch { Width = 280 };
            styleToggle.Properties.OffText = "Regular";
            styleToggle.Properties.OnText = "Filled";
            styleToggle.IsOn = IconSetSettings.IconStyle == IconStyle.Filled;
            styleToggle.Toggled += (s, e) => {
                IconSetSettings.IconStyle = styleToggle.IsOn ? IconStyle.Filled : IconStyle.Regular;
                RefreshAll();
            };
            settingsLayout.Controls.Add(styleToggle);

            // IconColor toggle
            settingsLayout.Controls.Add(CreateSectionLabel("Icon Color Mode"));
            var colorCombo = new ComboBoxEdit { Width = 280 };
            colorCombo.Properties.Items.AddRange(new object[] { IconColor.Monochrome, IconColor.Multicolor });
            colorCombo.EditValue = IconSetSettings.IconColor;
            colorCombo.SelectedIndexChanged += (s, e) => {
                if(colorCombo.EditValue is IconColor c) IconSetSettings.IconColor = c;
                RefreshAll();
            };
            settingsLayout.Controls.Add(colorCombo);

            // Status
            settingsLayout.Controls.Add(CreateSectionLabel("Current Status"));
            statusLabel = new LabelControl {
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 300, Height = 60,
                Appearance = { Font = new Font("Segoe UI", 9) }
            };
            settingsLayout.Controls.Add(statusLabel);

            // Right panel - preview
            previewPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(10) };
            splitContainer.Panel2.Controls.Add(previewPanel);

            RefreshAll();
        }

        LabelControl CreateSectionLabel(string text) {
            return new LabelControl {
                Text = text,
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 300, Height = 28,
                Appearance = { Font = new Font("Segoe UI", 10, FontStyle.Bold) },
                Padding = new Padding(0, 10, 0, 0)
            };
        }

        void RefreshAll() {
            statusLabel.Text = $"IconSet: {WindowsFormsSettings.ActiveIconSet}\nStyle: {IconSetSettings.IconStyle}\nColor: {IconSetSettings.IconColor}";
            RebuildPreview();

            if (Ribbon != null) {
                foreach (BarItem item in Ribbon.Items) {
                    if (!string.IsNullOrEmpty(item.ImageOptions.ImageUri.Uri))
                        item.ImageOptions.ImageUri.Refresh();
                }
            }
        }

        void RebuildPreview() {
            previewPanel.SuspendLayout();
            previewPanel.Controls.Clear();

            var titleLbl = new LabelControl {
                Text = "Live Preview",
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 500, Height = 30,
                Appearance = { Font = new Font("Segoe UI", 12, FontStyle.Bold) }
            };
            previewPanel.Controls.Add(titleLbl);

            string[] icons = { "save", "edit", "delete", "copy", "cut", "print", "filter",
                "find", "new", "open", "undo", "redo", "refresh", "calendar",
                "link", "warning", "export", "import", "zoom", "close",
                "align-left", "align-center", "align-right",
                "bold", "italic", "underline", "font-size",
                "sort-ascending", "sort-descending", "group", "ungroup" };

            foreach (var name in icons) {
                var btn = new SimpleButton {
                    Text = name,
                    Width = 130,
                    Height = 40,
                    ImageLocation = ImageLocation.MiddleLeft
                };
                btn.ImageOptions.ImageUri.Uri = name;
                btn.ImageOptions.SvgImageSize = new Size(20, 20);
                previewPanel.Controls.Add(btn);
            }

            previewPanel.ResumeLayout();
        }
    }
}
