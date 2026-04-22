using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Images;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace FW.RibbonForm.WinFormsFW {
    public partial class IconsForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public IconsForm() {
            InitializeComponent();
            BuildUI();
        }

        void BuildUI() {
            Text = "Fluent Icons Test — ActiveIconSet = " + ImageResourceCache.ActiveIconSet;
            ClientSize = new Size(1100, 750);

            // --- Ribbon with icon buttons ---
            var ribbon = new RibbonControl();
            ribbon.ShowApplicationButton = DefaultBoolean.False;
            Controls.Add(ribbon);
            Ribbon = ribbon;

            var page = new RibbonPage("Icons Test");
            ribbon.Pages.Add(page);

            // Group 1: icons that exist in BOTH classic and fluent
            var groupBoth = new RibbonPageGroup("Both Sets (Classic + Fluent)");
            string[] bothIcons = { "edit", "save", "filter", "print", "copy", "cut", "delete", "calendar", "link", "warning" };
            foreach(var name in bothIcons) {
                var item = new BarButtonItem { Caption = name };
                item.ImageOptions.ImageUri.Uri = name;
                ribbon.Items.Add(item);
                groupBoth.ItemLinks.Add(item);
            }
            page.Groups.Add(groupBoth);

            // Group 2: fluent-only icons (no classic SVG equivalent)
            var groupFluent = new RibbonPageGroup("Fluent Only");
            string[] fluentIcons = { "add-circle", "arrow-down", "arrow-up", "checkbox", "clipboard", "cloud", "document", "eye", "heart", "home" };
            foreach(var name in fluentIcons) {
                var item = new BarButtonItem { Caption = name };
                item.ImageOptions.ImageUri.Uri = name;
                ribbon.Items.Add(item);
                groupFluent.ItemLinks.Add(item);
            }
            page.Groups.Add(groupFluent);

            // Group 3: more fluent icons
            var groupFluent2 = new RibbonPageGroup("Fluent Actions");
            string[] fluentIcons2 = { "lock-closed", "mail", "people", "person", "search", "settings", "share", "star", "weather-sunny", "globe" };
            foreach(var name in fluentIcons2) {
                var item = new BarButtonItem { Caption = name };
                item.ImageOptions.ImageUri.Uri = name;
                ribbon.Items.Add(item);
                groupFluent2.ItemLinks.Add(item);
            }
            page.Groups.Add(groupFluent2);

            // --- Panel with SimpleButtons ---
            var scrollPanel = new PanelControl { Dock = DockStyle.Fill, AutoScroll = true };
            Controls.Add(scrollPanel);
            scrollPanel.BringToFront();

            var layout = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(10) };
            scrollPanel.Controls.Add(layout);

            // Section label
            layout.Controls.Add(CreateLabel("SimpleButtons — Fluent Icons"));

            string[] buttonIcons = {
                "add", "add-circle", "arrow-down", "arrow-up", "bookmark", "calendar",
                "camera", "chat", "checkmark", "clipboard", "clock", "cloud",
                "code", "comment", "copy", "cut", "delete", "document",
                "edit", "eye", "filter", "flag", "folder", "heart",
                "home", "image", "info", "link", "lock-closed", "mail"
            };
            foreach(var name in buttonIcons) {
                var btn = new SimpleButton {
                    Text = name,
                    Width = 140,
                    Height = 40,
                    ImageLocation = ImageLocation.MiddleLeft
                };
                btn.ImageOptions.ImageUri.Uri = name;
                btn.ImageOptions.SvgImageSize = new Size(20, 20);
                layout.Controls.Add(btn);
            }

            // Section: larger buttons
            layout.Controls.Add(CreateLabel("Large Buttons (32×32)"));
            string[] largeIcons = { "people", "person", "save", "search", "settings", "share", "star", "warning", "print", "globe" };
            foreach(var name in largeIcons) {
                var btn = new SimpleButton {
                    Text = name,
                    Width = 160,
                    Height = 55,
                    ImageLocation = ImageLocation.MiddleLeft
                };
                btn.ImageOptions.ImageUri.Uri = name;
                btn.ImageOptions.SvgImageSize = new Size(32, 32);
                layout.Controls.Add(btn);
            }

            // Section: toggle switches
            layout.Controls.Add(CreateLabel("Toggle Settings at Runtime"));
            var toggleBtn = new SimpleButton {
                Text = "Switch to " + (ImageResourceCache.ActiveIconSet == IconSet.Fluent ? "Default" : "Fluent"),
                Width = 200,
                Height = 40
            };
            toggleBtn.Click += (s, e) => {
                ImageResourceCache.ActiveIconSet =
                    ImageResourceCache.ActiveIconSet == IconSet.Fluent ? IconSet.Default : IconSet.Fluent;
                toggleBtn.Text = "Switch to " + (ImageResourceCache.ActiveIconSet == IconSet.Fluent ? "Default" : "Fluent");
                Text = "Fluent Icons Test — " + ImageResourceCache.ActiveIconSet + " / " + ImageResourceCache.FluentIconStyle;
                RefreshAllIcons(ribbon);
            };
            layout.Controls.Add(toggleBtn);

            var styleBtn = new SimpleButton {
                Text = "Style: " + ImageResourceCache.FluentIconStyle + " → switch",
                Width = 250,
                Height = 40
            };
            styleBtn.Click += (s, e) => {
                ImageResourceCache.FluentIconStyle =
                    ImageResourceCache.FluentIconStyle == "regular" ? "filled" : "regular";
                styleBtn.Text = "Style: " + ImageResourceCache.FluentIconStyle + " → switch";
                Text = "Fluent Icons Test — " + ImageResourceCache.ActiveIconSet + " / " + ImageResourceCache.FluentIconStyle;
                RefreshAllIcons(ribbon);
            };
            layout.Controls.Add(styleBtn);
        }

        LabelControl CreateLabel(string text) {
            return new LabelControl {
                Text = text,
                AutoSizeMode = LabelAutoSizeMode.None,
                Width = 1050,
                Height = 30,
                Appearance = { Font = new Font("Segoe UI", 12, FontStyle.Bold) }
            };
        }

        void RefreshAllIcons(RibbonControl ribbon) {
            // Refresh ribbon bar items
            foreach(BarItem item in ribbon.Items) {
                if(!string.IsNullOrEmpty(item.ImageOptions.ImageUri.Uri))
                    item.ImageOptions.ImageUri.Refresh();
            }
            // Refresh all SimpleButtons on the form
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
}
