using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace FW.FluentIcons.WinFormsFW {
    public partial class IconBrowserForm : RibbonForm {
        FlowLayoutPanel iconPanel;
        TextEdit searchBox;

        static readonly string[] AllFluentIcons = {
            "save", "edit", "delete", "copy", "cut", "print", "filter",
            "find", "new", "open", "undo", "redo", "refresh",
            "calendar", "link", "warning", "export", "import",
            "zoom", "close", "bold", "italic", "underline",
            "sort-ascending", "sort-descending", "align-left", "align-center", "align-right",
            "group", "ungroup", "font-size", "strikethrough",
            "convert", "highlight", "clear-formatting", "spell-check",
            "insert-header", "insert-footer", "page-setup", "margins",
            "merge-cells", "freeze-panes", "conditional-formatting",
            "pivot-table", "chart", "sparkline"
        };

        public IconBrowserForm() {
            InitializeComponent();
            BuildUI();
        }

        void BuildUI() {
            Text = "Icon Browser — Fluent Icons Gallery";
            ClientSize = new Size(1100, 750);

            var ribbon = new RibbonControl();
            ribbon.ShowApplicationButton = DefaultBoolean.False;
            Controls.Add(ribbon);
            Ribbon = ribbon;

            var page = new RibbonPage("Browser");
            ribbon.Pages.Add(page);

            var groupSize = new RibbonPageGroup("Icon Size");
            page.Groups.Add(groupSize);

            int[] sizes = { 16, 20, 24, 32, 48 };
            foreach (var sz in sizes) {
                var btn = new BarButtonItem { Caption = sz + "px" };
                btn.ItemClick += (s, e) => RebuildIcons(sz);
                ribbon.Items.Add(btn);
                groupSize.ItemLinks.Add(btn);
            }

            // Search panel
            var searchPanel = new PanelControl { Dock = DockStyle.Top, Height = 45, Padding = new Padding(10, 8, 10, 8) };
            Controls.Add(searchPanel);
            searchPanel.BringToFront();

            searchBox = new TextEdit { Dock = DockStyle.Fill };
            searchBox.Properties.NullValuePrompt = "Search icons...";
            searchBox.EditValueChanged += (s, e) => FilterIcons();
            searchPanel.Controls.Add(searchBox);

            // Icon gallery panel
            var scrollPanel = new PanelControl { Dock = DockStyle.Fill, AutoScroll = true };
            Controls.Add(scrollPanel);
            scrollPanel.BringToFront();

            iconPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(10) };
            scrollPanel.Controls.Add(iconPanel);

            RebuildIcons(24);
        }

        void RebuildIcons(int iconSize) {
            iconPanel.SuspendLayout();
            iconPanel.Controls.Clear();

            foreach (var name in AllFluentIcons) {
                var btn = new SimpleButton {
                    Text = name,
                    Width = Math.Max(120, iconSize + 100),
                    Height = Math.Max(40, iconSize + 20),
                    ImageLocation = ImageLocation.MiddleLeft,
                    Tag = name
                };
                btn.ImageOptions.ImageUri.Uri = name;
                btn.ImageOptions.SvgImageSize = new Size(iconSize, iconSize);
                btn.Click += (s, e) => {
                    Clipboard.SetText(((SimpleButton)s).Tag.ToString());
                    XtraMessageBox.Show($"Copied '{((SimpleButton)s).Tag}' to clipboard!", "Icon Browser", MessageBoxButtons.OK);
                };
                iconPanel.Controls.Add(btn);
            }

            iconPanel.ResumeLayout();
        }

        void FilterIcons() {
            var filter = (searchBox.EditValue?.ToString() ?? "").ToLowerInvariant();
            iconPanel.SuspendLayout();
            foreach (Control c in iconPanel.Controls) {
                if (c is SimpleButton btn)
                    btn.Visible = string.IsNullOrEmpty(filter) || btn.Tag.ToString().Contains(filter);
            }
            iconPanel.ResumeLayout();
        }
    }
}
