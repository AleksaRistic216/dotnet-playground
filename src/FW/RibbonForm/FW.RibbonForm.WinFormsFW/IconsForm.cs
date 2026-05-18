using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Images;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace FW.RibbonForm.WinFormsFW {
    public partial class IconsForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public IconsForm() {
            InitializeComponent();
            //BuildUI();
        }

        //void BuildUI() {
        //    Text = "Icons Test — ActiveIconSet = " + WindowsFormsSettings.ActiveIconSet;
        //    ClientSize = new Size(1100, 750);

        //    // --- Ribbon with icon buttons ---
        //    var ribbon = new RibbonControl();
        //    ribbon.ShowApplicationButton = DefaultBoolean.False;
        //    Controls.Add(ribbon);
        //    Ribbon = ribbon;

        //    var page = new RibbonPage("Icons Test");
        //    ribbon.Pages.Add(page);

        //    // Group 1: icons that exist in BOTH classic and fluent
        //    var groupBoth = new RibbonPageGroup("All Sets (Classic + Fluent + DxDesktop)");
        //    string[] bothIcons = { "edit", "save", "filter", "print", "copy", "cut", "delete", "calendar", "link", "warning", "alert" };
        //    foreach(var name in bothIcons) {
        //        var item = new BarButtonItem { Caption = name };
        //        item.ImageOptions.ImageUri.Uri = name;
        //        ribbon.Items.Add(item);
        //        groupBoth.ItemLinks.Add(item);
        //    }
        //    page.Groups.Add(groupBoth);

        //    // Group 2: fluent-only icons (no classic SVG equivalent)
        //    var groupFluent = new RibbonPageGroup("Fluent Only");
        //    string[] fluentIcons = { "add_circle", "arrow_down", "arrow_up", "checkbox", "clipboard", "cloud", "document", "eye", "heart", "home" };
        //    foreach(var name in fluentIcons) {
        //        var item = new BarButtonItem { Caption = name };
        //        item.ImageOptions.ImageUri.Uri = name;
        //        ribbon.Items.Add(item);
        //        groupFluent.ItemLinks.Add(item);
        //    }
        //    page.Groups.Add(groupFluent);

        //    // Group 3: more fluent icons
        //    var groupFluent2 = new RibbonPageGroup("Fluent Actions");
        //    string[] fluentIcons2 = { "lock_closed", "mail", "people", "person", "search", "settings", "share", "star", "weather_sunny", "globe" };
        //    foreach(var name in fluentIcons2) {
        //        var item = new BarButtonItem { Caption = name };
        //        item.ImageOptions.ImageUri.Uri = name;
        //        ribbon.Items.Add(item);
        //        groupFluent2.ItemLinks.Add(item);
        //    }
        //    page.Groups.Add(groupFluent2);

        //    // --- Panel with SimpleButtons ---
        //    var scrollPanel = new PanelControl { Dock = DockStyle.Fill, AutoScroll = true };
        //    Controls.Add(scrollPanel);
        //    scrollPanel.BringToFront();

        //    var layout = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, Padding = new Padding(10) };
        //    scrollPanel.Controls.Add(layout);

        //    // Section label
        //    layout.Controls.Add(CreateLabel("SimpleButtons — Fluent Icons"));

        //    string[] buttonIcons = {
        //        "add", "add_circle", "arrow_down", "arrow_up", "bookmark", "calendar",
        //        "camera", "chat", "checkmark", "clipboard", "clock", "cloud",
        //        "code", "comment", "copy", "cut", "delete", "document",
        //        "edit", "eye", "filter", "flag", "folder", "heart",
        //        "home", "image", "info", "link", "lock_closed", "mail"
        //    };
        //    foreach(var name in buttonIcons) {
        //        var btn = new SimpleButton {
        //            Text = name,
        //            Width = 140,
        //            Height = 40,
        //            ImageLocation = ImageLocation.MiddleLeft
        //        };
        //        btn.ImageOptions.ImageUri.Uri = name;
        //        btn.ImageOptions.SvgImageSize = new Size(20, 20);
        //        layout.Controls.Add(btn);
        //    }

        //    // Section: larger buttons
        //    layout.Controls.Add(CreateLabel("Large Buttons (32×32)"));
        //    string[] largeIcons = { "people", "person", "save", "search", "settings", "share", "star", "warning", "print", "globe" };
        //    foreach(var name in largeIcons) {
        //        var btn = new SimpleButton {
        //            Text = name,
        //            Width = 160,
        //            Height = 55,
        //            ImageLocation = ImageLocation.MiddleLeft
        //        };
        //        btn.ImageOptions.ImageUri.Uri = name;
        //        btn.ImageOptions.SvgImageSize = new Size(32, 32);
        //        layout.Controls.Add(btn);
        //    }

        //    // Section: same icon at different sizes
        //    layout.Controls.Add(CreateLabel("Size Variants — same icon at 16, 20, 24, 28, 32, 48"));
        //    int[] sizes = { 16, 20, 24, 28, 32, 48 };
        //    string[] sizeTestIcons = { "save", "add_circle", "arrow_down", "calendar", "star", "home" };
        //    foreach(var name in sizeTestIcons) {
        //        var row = new FlowLayoutPanel { AutoSize = true, WrapContents = false, Margin = new Padding(0, 2, 0, 2) };
        //        foreach(var sz in sizes) {
        //            var btn = new SimpleButton {
        //                Text = sz.ToString(),
        //                Width = sz + 50,
        //                Height = sz + 20,
        //                ImageLocation = ImageLocation.MiddleLeft
        //            };
        //            btn.ImageOptions.ImageUri.Uri = name;
        //            btn.ImageOptions.SvgImageSize = new Size(sz, sz);
        //            row.Controls.Add(btn);
        //        }
        //        var lbl = new LabelControl { Text = name, AutoSizeMode = LabelAutoSizeMode.Default, Padding = new Padding(5, 8, 0, 0) };
        //        row.Controls.Add(lbl);
        //        layout.Controls.Add(row);
        //    }

        //    // Section: IDXImageUriIconSizeProvider — control tells preferred icon size
        //    layout.Controls.Add(CreateLabel("IconSizeButton (IDXImageUriIconSizeProvider)"));
        //    string[] providerIcons = { "save", "add_circle", "arrow_down", "calendar", "star", "home" };
        //    int[] providerSizes = { 16, 20, 24, 28, 32, 48 };
        //    foreach(var name in providerIcons) {
        //        var row = new FlowLayoutPanel { AutoSize = true, WrapContents = false, Margin = new Padding(0, 2, 0, 2) };
        //        foreach(var sz in providerSizes) {
        //            var btn = new IconSizeButton(sz) {
        //                Text = sz.ToString(),
        //                Width = sz + 50,
        //                Height = sz + 20,
        //                ImageLocation = ImageLocation.MiddleLeft
        //            };
        //            btn.ImageOptions.ImageUri.Uri = name;
        //            row.Controls.Add(btn);
        //        }
        //        var lbl = new LabelControl { Text = name, AutoSizeMode = LabelAutoSizeMode.Default, Padding = new Padding(5, 8, 0, 0) };
        //        row.Controls.Add(lbl);
        //        layout.Controls.Add(row);
        //    }

        //    // Section: toggle switches
        //    layout.Controls.Add(CreateLabel("Toggle Settings at Runtime"));
        //    var toggleBtn = new SimpleButton {
        //        Text = "IconSet: " + WindowsFormsSettings.ActiveIconSet,
        //        Width = 200,
        //        Height = 40
        //    };
        //    toggleBtn.Click += (s, e) => {
        //        WindowsFormsSettings.ActiveIconSet = NextIconSet(WindowsFormsSettings.ActiveIconSet);
        //        toggleBtn.Text = "IconSet: " + WindowsFormsSettings.ActiveIconSet;
        //        Text = "Icons Test — " + WindowsFormsSettings.ActiveIconSet + " / " + WindowsFormsSettings.IconStyle;
        //        RefreshAllIcons(ribbon);
        //    };
        //    layout.Controls.Add(toggleBtn);

        //    var styleBtn = new SimpleButton {
        //        Text = "Style: " + WindowsFormsSettings.IconStyle + " → switch",
        //        Width = 250,
        //        Height = 40
        //    };
        //    styleBtn.Click += (s, e) => {
        //        WindowsFormsSettings.IconStyle =
        //            WindowsFormsSettings.IconStyle == "regular" ? "filled" : "regular";
        //        styleBtn.Text = "Style: " + WindowsFormsSettings.IconStyle + " → switch";
        //        Text = "Icons Test — " + WindowsFormsSettings.ActiveIconSet + " / " + WindowsFormsSettings.IconStyle;
        //        RefreshAllIcons(ribbon);
        //    };
        //    layout.Controls.Add(styleBtn);

        //    var colorBtn = new SimpleButton {
        //        Text = "Color: " + WindowsFormsSettings.IconColor + " → switch",
        //        Width = 320,
        //        Height = 40
        //    };
        //    colorBtn.Click += (s, e) => {
        //        WindowsFormsSettings.IconColor =
        //            WindowsFormsSettings.IconColor == "no_color" ? "colored" : "no_color";
        //        colorBtn.Text = "Color: " + WindowsFormsSettings.IconColor + " → switch";
        //        RefreshAllIcons(ribbon);
        //    };
        //    layout.Controls.Add(colorBtn);

        //    var diagBtn = new SimpleButton {
        //        Text = "Dump DxDesktop diagnostics",
        //        Width = 320,
        //        Height = 40
        //    };
        //    diagBtn.Click += (s, e) => {
        //        var cache = ImageResourceCache.Default;
        //        var type = cache.GetType();
        //        // Check fluent index too
        //        var fluentField = type.GetField("fluentMetaphorSizes", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //        var fluentDict = fluentField?.GetValue(cache) as Dictionary<string, List<int>>;
        //        var field = type.GetField("dxDesktopMetaphorSizes", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //        var dict = field?.GetValue(cache) as Dictionary<string, List<int>>;
        //        // Check actual resource keys
        //        var resField = type.GetField("resources", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        //        var resDict = resField?.GetValue(cache) as Dictionary<string, System.IO.Stream>;
        //        var msg = "Fluent index: " + (fluentDict?.Count ?? 0) + "\nDxDesktop index: " + (dict?.Count ?? 0) + "\nTotal resources: " + (resDict?.Count ?? 0) + "\n\n";
        //        if(resDict != null) {
        //            msg += "dx_desktop resource keys:\n";
        //            int i = 0;
        //            foreach(var k in resDict.Keys) {
        //                if(k.IndexOf("dx_desktop", StringComparison.OrdinalIgnoreCase) >= 0) {
        //                    msg += k + "\n";
        //                    if(++i >= 10) { msg += "..."; break; }
        //                }
        //            }
        //            if(i == 0) {
        //                msg += "(none found)\n\nFirst 10 'icons' keys:\n";
        //                foreach(var k in resDict.Keys) {
        //                    if(k.IndexOf("icons", StringComparison.OrdinalIgnoreCase) >= 0) {
        //                        msg += k + "\n";
        //                        if(++i >= 10) { msg += "..."; break; }
        //                    }
        //                }
        //            }
        //        }
        //        MessageBox.Show(msg, "Diagnostics");
        //    };
        //    layout.Controls.Add(diagBtn);
        //}

        //static IconSet NextIconSet(IconSet current) {
        //    var values = (IconSet[])Enum.GetValues(typeof(IconSet));
        //    int index = Array.IndexOf(values, current);
        //    return values[(index + 1) % values.Length];
        //}

        //LabelControl CreateLabel(string text) {
        //    return new LabelControl {
        //        Text = text,
        //        AutoSizeMode = LabelAutoSizeMode.None,
        //        Width = 1050,
        //        Height = 30,
        //        Appearance = { Font = new Font("Segoe UI", 12, FontStyle.Bold) }
        //    };
        //}

        //void RefreshAllIcons(RibbonControl ribbon) {
        //    // Refresh ribbon bar items
        //    foreach(BarItem item in ribbon.Items) {
        //        if(!string.IsNullOrEmpty(item.ImageOptions.ImageUri.Uri))
        //            item.ImageOptions.ImageUri.Refresh();
        //    }
        //    // Refresh all SimpleButtons on the form
        //    RefreshControlIcons(this);
        //    Refresh();
        //}

        //void RefreshControlIcons(Control parent) {
        //    foreach(Control c in parent.Controls) {
        //        var btn = c as SimpleButton;
        //        if(btn != null && !string.IsNullOrEmpty(btn.ImageOptions.ImageUri.Uri))
        //            btn.ImageOptions.ImageUri.Refresh();
        //        var iconBtn = c as IconSizeButton;
        //        if(iconBtn != null && !string.IsNullOrEmpty(iconBtn.ImageOptions.ImageUri.Uri))
        //            iconBtn.ImageOptions.ImageUri.Refresh();
        //        if(c.HasChildren)
        //            RefreshControlIcons(c);
        //    }
        //}
    }

    //public class IconSizeButton : SimpleButton, IDXImageUriIconSizeProvider {
    //    readonly Size preferredIconSize;

    //    public IconSizeButton(int iconSize) {
    //        preferredIconSize = new Size(iconSize, iconSize);
    //        ImageOptions.SetImageUriClient(this);
    //    }

    //    public Size GetPreferredIconSize() {
    //        return preferredIconSize;
    //    }
    //}
}
