using DevExpress.IconLibrary;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using IconsProject.Infrastructure;
using DxIcon = DevExpress.IconLibrary.Icon;

namespace IconsProject.Forms {
    public class NavigationForm : TestFormBase {
        public NavigationForm()
            : base("Navigation & layout: Accordion, NavBar, XtraTabControl, TabPane, LayoutControl",
                  "Each container uses ImageOptions.ImageUri with unpinned generated icons (follow the active set), plus one pinned element per container. " +
                  "Open LayoutControl customization (right-click) to see mapped XtraLayout SVGs. Collapse/expand the accordion and switch NavBar paint styles to exercise different glyph sizes.") {
            var split = new SplitContainerControl { Horizontal = true, SplitterPosition = 300 };
            split.Panel1.Controls.Add(BuildAccordion());
            split.Panel2.Controls.Add(BuildNavBar());
            var tabs = new SplitContainerControl { Horizontal = true, SplitterPosition = 620 };
            tabs.Panel1.Controls.Add(BuildTabControl());
            tabs.Panel2.Controls.Add(BuildTabPane());
            AddSections(
                Section("AccordionControl | NavBarControl", split, 330),
                Section("XtraTabControl | TabPane", tabs, 200),
                Section("LayoutControl (right-click → Customize Layout)", BuildLayout(), 280));
        }

        Control BuildAccordion() {
            var accordion = new AccordionControl { Dock = DockStyle.Fill, AllowItemSelection = true };
            int index = 0;
            foreach(var chunk in IconCatalog.TypedIcons.Chunk(6)) {
                var group = new AccordionControlElement { Text = $"Group {index}", Expanded = index == 0 };
                group.ImageOptions.ImageUri = chunk[0].Icon;
                Track(group.ImageOptions);
                foreach(var (caption, icon) in chunk) {
                    var item = new AccordionControlElement { Text = caption, Style = ElementStyle.Item };
                    item.ImageOptions.ImageUri = icon;
                    Track(item.ImageOptions);
                    group.Elements.Add(item);
                }
                accordion.Elements.Add(group);
                index++;
            }
            var pinned = new AccordionControlElement { Text = "Pinned Classic / Filled", Style = ElementStyle.Group, Expanded = true };
            pinned.ImageOptions.ImageUri = new DxIcon("folder", IconSet.DesktopClassic);
            var filled = new AccordionControlElement { Text = "Filled star", Style = ElementStyle.Item };
            filled.ImageOptions.ImageUri = new DxIcon("star", style: IconStyle.Filled);
            var legacy = new AccordionControlElement { Text = "Legacy DXImages.Home", Style = ElementStyle.Item };
            legacy.ImageOptions.ImageUri = DevExpress.Images.DXImages.Home;
            pinned.Elements.AddRange(new[] { filled, legacy });
            accordion.Elements.Add(pinned);
            accordion.ElementClick += (s, e) => IconLog.Write($"Accordion '{e.Element.Text}': '{e.Element.ImageOptions.ImageUri.Uri}' HasSvgImage={e.Element.ImageOptions.ImageUri.HasSvgImage}");
            return accordion;
        }

        Control BuildNavBar() {
            var navBar = new NavBarControl { Dock = DockStyle.Fill };
            var styleCombo = new ComboBoxEdit { Dock = DockStyle.Top };
            styleCombo.Properties.Items.AddRange(new object[] { "NavigationPane", "ExplorerBar", "SideBar", "SkinExplorerBarView", "SkinNavigationPane", "SkinSideBar" });
            styleCombo.EditValueChanged += (s, e) => {
                navBar.PaintStyleName = (string)styleCombo.EditValue;
                IconLog.Write($"NavBar PaintStyleName -> {navBar.PaintStyleName}");
            };
            int index = 0;
            foreach(var chunk in IconCatalog.TypedIcons.Chunk(8)) {
                var group = navBar.Groups.Add();
                group.Caption = $"NavBar group {index++}";
                group.Expanded = true;
                group.ImageOptions.ImageUri = chunk[0].Icon;
                group.GroupStyle = index % 2 == 0 ? NavBarGroupStyle.LargeIconsText : NavBarGroupStyle.SmallIconsText;
                foreach(var (caption, icon) in chunk) {
                    var item = navBar.Items.Add();
                    item.Caption = caption;
                    item.ImageOptions.ImageUri = icon;
                    Track(item.ImageOptions);
                    group.ItemLinks.Add(item);
                }
            }
            var host = new PanelControl { Dock = DockStyle.Fill };
            host.Controls.Add(navBar);
            host.Controls.Add(styleCombo);
            return host;
        }

        Control BuildTabControl() {
            var tabs = new XtraTabControl { Dock = DockStyle.Fill };
            foreach(var (caption, icon) in IconCatalog.TypedIcons.Take(6)) {
                var page = new XtraTabPage { Text = caption };
                page.ImageOptions.ImageUri = icon;
                Track(page.ImageOptions);
                page.Controls.Add(new LabelControl { Text = $"Tab page '{caption}' → ImageOptions.ImageUri = '{icon}'", Location = new Point(10, 10) });
                tabs.TabPages.Add(page);
            }
            var pinned = new XtraTabPage { Text = "Pinned Blazor" };
            pinned.ImageOptions.ImageUri = new DxIcon("home", IconSet.BlazorClassic);
            tabs.TabPages.Add(pinned);
            var legacy = new XtraTabPage { Text = "Legacy Add;Size16x16" };
            legacy.ImageOptions.ImageUri = "Add;Size16x16";
            tabs.TabPages.Add(legacy);
            return tabs;
        }

        Control BuildTabPane() {
            var pane = new TabPane { Dock = DockStyle.Fill };
            foreach(var (caption, icon) in IconCatalog.TypedIcons.Skip(6).Take(4)) {
                var page = new TabNavigationPage { Caption = caption };
                page.ImageOptions.ImageUri = icon;
                Track(page.ImageOptions);
                pane.Pages.Add(page);
            }
            return pane;
        }

        Control BuildLayout() {
            var layout = new LayoutControl();
            var root = layout.Root;
            root.GroupBordersVisible = true;
            root.Text = "Root";
            root.CaptionImageOptions.ImageUri = new DxIcon("table");
            int index = 0;
            foreach(var (caption, icon) in IconCatalog.TypedIcons.Take(8)) {
                var editor = new TextEdit { EditValue = caption };
                var item = root.AddItem(caption, editor);
                item.ImageOptions.ImageUri = icon;
                Track(item.ImageOptions);
                if(index++ % 2 == 1)
                    item.Move(root.Items[root.Items.Count - 2] as LayoutControlItem, DevExpress.XtraLayout.Utils.InsertType.Right);
            }
            var group = root.AddGroup("Group with caption image");
            group.CaptionImageOptions.ImageUri = new DxIcon("folder", IconSet.DesktopClassic);
            var button = new SimpleButton { Text = "Button in layout" };
            button.ImageOptions.ImageUri = new DxIcon("save");
            group.AddItem("Button", button).TextVisible = false;
            return layout;
        }
    }
}
