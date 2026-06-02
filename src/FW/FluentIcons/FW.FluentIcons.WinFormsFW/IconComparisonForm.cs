using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace FW.FluentIcons.WinFormsFW {
    public partial class IconComparisonForm : RibbonForm {
        public IconComparisonForm() {
            InitializeComponent();
            BuildUI();
        }

        void BuildUI() {
            Text = "Icon Comparison — Size Variants & IDXImageUriIconSizeProvider";
            ClientSize = new Size(1200, 800);

            var ribbon = new RibbonControl();
            ribbon.ShowApplicationButton = DefaultBoolean.False;
            Controls.Add(ribbon);
            Ribbon = ribbon;

            var page = new RibbonPage("Comparison");
            ribbon.Pages.Add(page);

            var groupIcons = new RibbonPageGroup("Ribbon Icons");
            page.Groups.Add(groupIcons);
            string[] ribbonIcons = { "save", "edit", "delete", "copy", "print", "find", "undo", "redo" };
            foreach (var icon in ribbonIcons) {
                var item = new BarButtonItem { Caption = icon };
                item.ImageOptions.ImageUri.Uri = icon;
                ribbon.Items.Add(item);
                groupIcons.ItemLinks.Add(item);
            }

            // Content
            var scrollPanel = new PanelControl { Dock = DockStyle.Fill, AutoScroll = true };
            Controls.Add(scrollPanel);
            scrollPanel.BringToFront();

            var layout = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(15), FlowDirection = FlowDirection.TopDown };
            scrollPanel.Controls.Add(layout);

            // Section 1: Same icon at different sizes (using SvgImageSize)
            layout.Controls.Add(CreateHeader("Size Variants — SvgImageSize (16, 20, 24, 28, 32, 48)"));

            int[] sizes = { 16, 20, 24, 28, 32, 48 };
            string[] testIcons = { "save", "edit", "calendar", "delete", "copy", "print", "filter", "find" };

            foreach (var name in testIcons) {
                var row = new FlowLayoutPanel { AutoSize = true, WrapContents = false, Margin = new Padding(0, 4, 0, 4) };
                var lbl = new LabelControl { Text = name, Width = 90, Padding = new Padding(0, 8, 5, 0) };
                row.Controls.Add(lbl);

                foreach (var sz in sizes) {
                    var btn = new SimpleButton {
                        Text = sz.ToString(),
                        Width = sz + 55,
                        Height = sz + 20,
                        ImageLocation = ImageLocation.MiddleLeft
                    };
                    btn.ImageOptions.ImageUri.Uri = name;
                    btn.ImageOptions.SvgImageSize = new Size(sz, sz);
                    row.Controls.Add(btn);
                }
                layout.Controls.Add(row);
            }

            // Section 2: IDXImageUriIconSizeProvider
            layout.Controls.Add(CreateHeader("IDXImageUriIconSizeProvider — Control Reports Preferred Size"));

            foreach (var name in testIcons) {
                var row = new FlowLayoutPanel { AutoSize = true, WrapContents = false, Margin = new Padding(0, 4, 0, 4) };
                var lbl = new LabelControl { Text = name, Width = 90, Padding = new Padding(0, 8, 5, 0) };
                row.Controls.Add(lbl);

                foreach (var sz in sizes) {
                    var btn = new IconSizeButton(sz) {
                        Text = sz.ToString(),
                        Width = sz + 55,
                        Height = sz + 20,
                        ImageLocation = ImageLocation.MiddleLeft
                    };
                    btn.ImageOptions.ImageUri.Uri = name;
                    row.Controls.Add(btn);
                }
                layout.Controls.Add(row);
            }

            // Section 3: Large icons showcase
            layout.Controls.Add(CreateHeader("Large Icons (48px) Showcase"));
            var largeRow = new FlowLayoutPanel { AutoSize = true, WrapContents = true, Width = 1100 };
            string[] allIcons = { "save", "edit", "delete", "copy", "cut", "print",
                "filter", "find", "new", "open", "undo", "redo",
                "refresh", "calendar", "link", "warning", "export", "import",
                "zoom", "close", "bold", "italic", "underline",
                "sort-ascending", "sort-descending", "align-left", "align-center",
                "align-right", "group", "ungroup" };
            foreach (var name in allIcons) {
                var btn = new SimpleButton {
                    Text = name,
                    Width = 130,
                    Height = 65,
                    ImageLocation = ImageLocation.TopCenter
                };
                btn.ImageOptions.ImageUri.Uri = name;
                btn.ImageOptions.SvgImageSize = new Size(48, 48);
                largeRow.Controls.Add(btn);
            }
            layout.Controls.Add(largeRow);
        }

        LabelControl CreateHeader(string text) {
            return new LabelControl {
                Text = text,
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 1100,
                Height = 35,
                Appearance = { Font = new Font("Segoe UI", 12, FontStyle.Bold) },
                Padding = new Padding(0, 10, 0, 0)
            };
        }
    }

    public class IconSizeButton : SimpleButton, IDXImageUriIconSizeProvider {
        readonly Size preferredIconSize;

        public IconSizeButton(int iconSize) {
            preferredIconSize = new Size(iconSize, iconSize);
            ImageOptions.SetImageUriClient(this);
        }

        public Size GetPreferredIconSize() {
            return preferredIconSize;
        }
    }
}
