using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Images;
using DevExpress.LookAndFeel;
using DevExpress.Data.Utils.Images;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace FW.FluentIcons.WinFormsFW {
    public partial class MainForm : RibbonForm {
        BarButtonItem btnIconSet;
        BarButtonItem btnIconStyle;
        BarButtonItem btnIconColor;
        BarStaticItem lblStatus;

        public MainForm() {
            InitializeComponent();
            BuildUI();
            UpdateStatusBar();
        }

        void BuildUI() {
            Text = "Fluent Icons Demo — System Loading";
            ClientSize = new Size(1200, 800);

            var ribbon = new RibbonControl();
            ribbon.ShowApplicationButton = DefaultBoolean.False;
            Controls.Add(ribbon);
            Ribbon = ribbon;

            // Skin selectors in quick toolbar
            var skinDropDown = new SkinDropDownButtonItem();
            var skinPaletteDropDown = new SkinPaletteDropDownButtonItem();
            ribbon.Items.AddRange(new BarItem[] { skinDropDown, skinPaletteDropDown });
            ribbon.QuickToolbarItemLinks.Add(skinDropDown);
            ribbon.QuickToolbarItemLinks.Add(skinPaletteDropDown);

            // Page 1: Navigation
            var pageNav = new RibbonPage("Navigation");
            ribbon.Pages.Add(pageNav);

            var groupForms = new RibbonPageGroup("Open Forms");
            pageNav.Groups.Add(groupForms);

            var btnBrowser = new BarButtonItem { Caption = "Icon Browser" };
            btnBrowser.ImageOptions.ImageUri.Uri = "search";
            btnBrowser.ItemClick += (s, e) => { using (var f = new IconBrowserForm()) f.ShowDialog(this); };
            ribbon.Items.Add(btnBrowser);
            groupForms.ItemLinks.Add(btnBrowser);

            var btnSettings = new BarButtonItem { Caption = "Icon Settings" };
            btnSettings.ImageOptions.ImageUri.Uri = "preferences";
            btnSettings.ItemClick += (s, e) => { using (var f = new IconSettingsForm()) f.ShowDialog(this); };
            ribbon.Items.Add(btnSettings);
            groupForms.ItemLinks.Add(btnSettings);

            var btnApproaches = new BarButtonItem { Caption = "Loading Approaches" };
            btnApproaches.ImageOptions.ImageUri.Uri = "open";
            btnApproaches.ItemClick += (s, e) => { using(var f = new IconLoadingApproachesForm()) f.ShowDialog(this); };
            ribbon.Items.Add(btnApproaches);
            groupForms.ItemLinks.Add(btnApproaches);

            var btnCompare = new BarButtonItem { Caption = "Icon Comparison" };
            btnCompare.ImageOptions.ImageUri.Uri = "zoom";
            btnCompare.ItemClick += (s, e) => { using (var f = new IconComparisonForm()) f.ShowDialog(this); };
            ribbon.Items.Add(btnCompare);
            groupForms.ItemLinks.Add(btnCompare);

            // Page 2: Icon Settings (switches)
            var pageSettings = new RibbonPage("Icon Settings");
            ribbon.Pages.Add(pageSettings);

            var groupSwitch = new RibbonPageGroup("Toggle");
            pageSettings.Groups.Add(groupSwitch);

            btnIconSet = new BarButtonItem { Caption = "IconSet: " + WindowsFormsSettings.ActiveIconSet };
            btnIconSet.ImageOptions.ImageUri.Uri = "convert";
            btnIconSet.ItemClick += (s, e) => {
                var values = (IconSet[])Enum.GetValues(typeof(IconSet));
                int idx = Array.IndexOf(values, WindowsFormsSettings.ActiveIconSet);
                WindowsFormsSettings.ActiveIconSet = values[(idx + 1) % values.Length];
                btnIconSet.Caption = "IconSet: " + WindowsFormsSettings.ActiveIconSet;
                UpdateStatusBar();
                RefreshAllIcons(ribbon);
            };
            ribbon.Items.Add(btnIconSet);
            groupSwitch.ItemLinks.Add(btnIconSet);

            btnIconStyle = new BarButtonItem { Caption = "Style: " + IconSetSettings.IconStyle };
            btnIconStyle.ImageOptions.ImageUri.Uri = "edit";
            btnIconStyle.ItemClick += (s, e) => {
                IconSetSettings.IconStyle = IconSetSettings.IconStyle == IconStyle.Regular ? IconStyle.Filled : IconStyle.Regular;
                btnIconStyle.Caption = "Style: " + IconSetSettings.IconStyle;
                UpdateStatusBar();
                RefreshAllIcons(ribbon);
            };
            ribbon.Items.Add(btnIconStyle);
            groupSwitch.ItemLinks.Add(btnIconStyle);

            btnIconColor = new BarButtonItem { Caption = "Color: " + IconSetSettings.IconColor };
            btnIconColor.ImageOptions.ImageUri.Uri = "filter";
            btnIconColor.ItemClick += (s, e) => {
                IconSetSettings.IconColor = IconSetSettings.IconColor == IconColor.Monochrome ? IconColor.Multicolor : IconColor.Monochrome;
                btnIconColor.Caption = "Color: " + IconSetSettings.IconColor;
                UpdateStatusBar();
                RefreshAllIcons(ribbon);
            };
            ribbon.Items.Add(btnIconColor);
            groupSwitch.ItemLinks.Add(btnIconColor);

            // Sample icons group
            var groupSample = new RibbonPageGroup("Sample Icons");
            pageSettings.Groups.Add(groupSample);

            string[] sampleIcons = { "save", "copy", "cut", "delete", "print", "calendar", "link", "warning", "find", "undo", "redo", "new" };
            foreach (var icon in sampleIcons) {
                var item = new BarButtonItem { Caption = icon };
                item.ImageOptions.ImageUri.Uri = icon;
                ribbon.Items.Add(item);
                groupSample.ItemLinks.Add(item);
            }

            // Status bar
            ribbon.ShowToolbarCustomizeItem = false;
            var statusBar = new RibbonStatusBar();
            statusBar.Ribbon = ribbon;
            Controls.Add(statusBar);

            lblStatus = new BarStaticItem { Caption = "" };
            ribbon.Items.Add(lblStatus);
            statusBar.ItemLinks.Add(lblStatus);

            // Content panel with welcome info
            var panel = new PanelControl { Dock = DockStyle.Fill };
            Controls.Add(panel);
            panel.BringToFront();
            contentPanel = panel;

            BuildContentPanel();
        }

        PanelControl contentPanel;

        void BuildContentPanel() {
            contentPanel.Controls.Clear();
            var layout = new FlowLayoutPanel {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };
            contentPanel.Controls.Add(layout);

            Assembly barsAsm = typeof(RibbonControl).Assembly;
            Assembly editorsAsm = typeof(SimpleButton).Assembly;

            // SvgImage.FromResources — mapped icons
            var svgResources = new[] {
                ("Search", "DevExpress.XtraBars.Images.SkinSearch.svg", barsAsm),
                ("Settings", "DevExpress.XtraBars.Images.Settings.svg", barsAsm),
                ("AddPage", "DevExpress.XtraBars.Images.AddPage.svg", barsAsm),
                ("AddPageGroup", "DevExpress.XtraBars.Images.AddPageGroup.svg", barsAsm),
                ("AppBtn07", "DevExpress.XtraBars.Images.ApplicationButton2007.svg", barsAsm),
                ("RibbonApp", "DevExpress.XtraBars.Images.RibbonApplication.svg", barsAsm),
                ("FullScreen", "DevExpress.XtraBars.Ribbon.Images.FullScreen.svg", barsAsm),
                ("Security", "DevExpress.XtraEditors.Images.SVG.SecurityNotice.svg", editorsAsm),
            };

            foreach (var (label, resourceName, asm) in svgResources) {
                var svgImage = SvgImage.FromResources(resourceName, asm);
                var btn = new SimpleButton {
                    Text = label,
                    Width = 140,
                    Height = 44,
                    ImageLocation = ImageLocation.MiddleLeft
                };
                if (svgImage != null)
                    btn.ImageOptions.SvgImage = svgImage;
                btn.ImageOptions.SvgImageSize = new Size(24, 24);
                layout.Controls.Add(btn);
            }

            // DxImageUri
            string[] uriIcons = { "save", "edit", "delete", "copy", "cut", "print", "filter", "find", "new", "open", "undo", "redo", "refresh", "cancel" };
            foreach (var name in uriIcons) {
                var btn = new SimpleButton {
                    Text = name,
                    Width = 110,
                    Height = 44,
                    ImageLocation = ImageLocation.MiddleLeft
                };
                btn.ImageOptions.ImageUri.Uri = name;
                btn.ImageOptions.SvgImageSize = new Size(24, 24);
                layout.Controls.Add(btn);
            }

            // ResourceImageHelper.CreateSvgImageFromResources
            var helperResources = new[] {
                ("Search (Helper)", "DevExpress.XtraBars.Images.SkinSearch.svg", barsAsm),
                ("Settings (Helper)", "DevExpress.XtraBars.Images.Settings.svg", barsAsm),
            };
            foreach (var (label, resourceName, asm) in helperResources) {
                var svgImage = ResourceImageHelper.CreateSvgImageFromResources(resourceName, asm);
                var btn = new SimpleButton {
                    Text = label,
                    Width = 170,
                    Height = 44,
                    ImageLocation = ImageLocation.MiddleLeft
                };
                if (svgImage != null)
                    btn.ImageOptions.SvgImage = svgImage;
                btn.ImageOptions.SvgImageSize = new Size(24, 24);
                layout.Controls.Add(btn);
            }
        }

        void UpdateStatusBar() {
            if (lblStatus != null)
                lblStatus.Caption = $"IconSet: {WindowsFormsSettings.ActiveIconSet}  |  Style: {IconSetSettings.IconStyle}  |  Color: {IconSetSettings.IconColor}";
        }

        void RefreshAllIcons(RibbonControl ribbon) {
            foreach (BarItem item in ribbon.Items) {
                if (!string.IsNullOrEmpty(item.ImageOptions.ImageUri.Uri))
                    item.ImageOptions.ImageUri.Refresh();
            }
            BuildContentPanel();
            Refresh();
        }
    }
}
