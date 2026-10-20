using DevExpress.IconLibrary;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using IconsProject.Infrastructure;
using DxIcon = DevExpress.IconLibrary.Icon;

namespace IconsProject.Forms {
    public class RibbonBarsForm : TestFormBase {
        readonly RibbonControl ribbon;
        readonly RibbonStatusBar statusBar;
        readonly PopupMenu popupMenu;
        int styleIndex;
        readonly HashSet<BarItem> builtInItems;

        public RibbonBarsForm()
            : base("Ribbon, bar items, menus, galleries",
                  "RibbonControl hosted in a regular form. Pages: generated Icons (unpinned: follow the active set), pinned sets/styles/colors/sizes, legacy DXImages/ImageUri strings, edge-case uris, and menus/galleries/edit items. " +
                  "Switch icon mode and skins (esp. gray-appearance skins like 'DevExpress Dark Style' and 'Office 2010 Black') and watch which glyphs change live. Right-click the empty area for a PopupMenu. Minimize/Simplified/other RibbonStyles change glyph sizes.") {
            ribbon = new RibbonControl { ShowApplicationButton = DefaultBoolean.False };
            popupMenu = new PopupMenu { Ribbon = ribbon };
            statusBar = new RibbonStatusBar { Ribbon = ribbon };
            builtInItems = ribbon.Items.Cast<BarItem>().ToHashSet();
            Build();
            Controls.Add(statusBar);
            Controls.Add(ribbon);

            var actions = new FlowLayoutPanel();
            AddToolbarButton(actions, "Rebuild all items", (s, e) => Build());
            AddToolbarButton(actions, "Cycle RibbonStyle", (s, e) => {
                var styles = new[] { RibbonControlStyle.Office2019, RibbonControlStyle.OfficeUniversal, RibbonControlStyle.Office2013, RibbonControlStyle.Office2010, RibbonControlStyle.TabletOffice, RibbonControlStyle.Office2007 };
                styleIndex = (styleIndex + 1) % styles.Length;
                ribbon.RibbonStyle = styles[styleIndex];
                IconLog.Write($"RibbonStyle -> {ribbon.RibbonStyle}");
            });
            AddToolbarButton(actions, "Toggle minimized", (s, e) => ribbon.Minimized = !ribbon.Minimized);
            AddToolbarButton(actions, "Classic BarManager form", (s, e) => new BarManagerForm().Show(this));
            AddToolbarButton(actions, "Dump every item uri", (s, e) => {
                foreach(BarItem item in ribbon.Items) {
                    var uri = item.ImageOptions.ImageUri;
                    if(uri == null || string.IsNullOrEmpty(uri.Uri))
                        continue;
                    IconLog.Write($"  {item.Caption,-40} '{uri.Uri}' HasSvgImage={uri.HasSvgImage} HasImage={uri.HasImage} HasLargeImage={uri.HasLargeImage} ImageType={uri.ImageType}");
                }
            });
            var popupTarget = new LabelControl { Text = "Right-click here for a PopupMenu with icon uris", AutoSizeMode = LabelAutoSizeMode.None, Width = 400, Height = 60, BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple };
            popupTarget.MouseUp += (s, e) => {
                if(e.Button == MouseButtons.Right)
                    popupMenu.ShowPopup(popupTarget.PointToScreen(e.Location));
            };
            actions.Controls.Add(popupTarget);
            AddSections(Section("Actions", actions, 120));
        }

        void Build() {
            ribbon.BeginInit();
            try {
                ribbon.Pages.Clear();
                ribbon.PageCategories.Clear();
                foreach(var item in ribbon.Items.Cast<BarItem>().Where(i => !builtInItems.Contains(i)).ToArray()) {
                    ribbon.Items.Remove(item);
                    item.Dispose();
                }
                popupMenu.ItemLinks.Clear();
                statusBar.ItemLinks.Clear();
                ribbon.Toolbar.ItemLinks.Clear();

                var typedPage = Page("Generated Icons");
                var large = Group(typedPage, "Large (unpinned)");
                var small = Group(typedPage, "Small (unpinned)");
                int index = 0;
                foreach(var (caption, icon) in IconCatalog.TypedIcons) {
                    if(index++ < 10)
                        large.ItemLinks.Add(Item(caption, icon, RibbonItemStyles.Large));
                    else
                        small.ItemLinks.Add(Item(caption, icon, RibbonItemStyles.SmallWithText));
                }

                var pinnedPage = Page("Pinned");
                foreach(var set in new[] { IconSet.Fluent, IconSet.DesktopClassic, IconSet.BlazorClassic }) {
                    var group = Group(pinnedPage, $"Set = {set}");
                    foreach(string id in new[] { "add", "delete", "save", "search", "share", "star" })
                        group.ItemLinks.Add(Item($"{id} {set}", new DxIcon(id, set), RibbonItemStyles.Large));
                }
                var stylesGroup = Group(pinnedPage, "Style / color");
                stylesGroup.ItemLinks.Add(Item("Filled", new DxIcon("add", style: IconStyle.Filled), RibbonItemStyles.Large));
                stylesGroup.ItemLinks.Add(Item("Regular", new DxIcon("add", style: IconStyle.Regular), RibbonItemStyles.Large));
                stylesGroup.ItemLinks.Add(Item("Neutral", new DxIcon("add", palette: IconPalette.Neutral), RibbonItemStyles.Large));
                stylesGroup.ItemLinks.Add(Item("Colored", new DxIcon("add", palette: IconPalette.Colored), RibbonItemStyles.Large));
                stylesGroup.ItemLinks.Add(Item("Fluent Filled Neutral", new DxIcon("add", IconSet.Fluent, IconStyle.Filled, IconPalette.Neutral), RibbonItemStyles.Large));
                var sizesGroup = Group(pinnedPage, "Pinned sizes (large items)");
                foreach(var size in IconCatalog.Sizes)
                    sizesGroup.ItemLinks.Add(Item(size.ToString(), new DxIcon("delete", size: size), RibbonItemStyles.Large));
                var smallSizesGroup = Group(pinnedPage, "Pinned sizes (small items)");
                foreach(var size in IconCatalog.Sizes)
                    smallSizesGroup.ItemLinks.Add(Item(size.ToString(), new DxIcon("delete", size: size), RibbonItemStyles.SmallWithText));

                var legacyPage = Page("Legacy strings");
                var legacyLarge = Group(legacyPage, "Large");
                var legacySmall = Group(legacyPage, "Small");
                foreach(var (caption, uri) in IconCatalog.LegacyUris) {
                    legacyLarge.ItemLinks.Add(Item(caption, uri, RibbonItemStyles.Large));
                    legacySmall.ItemLinks.Add(Item(caption, uri, RibbonItemStyles.SmallWithText));
                }
                var setUriGroup = Group(legacyPage, "Icon-set uri strings");
                foreach(var (caption, uri) in IconCatalog.IconSetUris)
                    setUriGroup.ItemLinks.Add(Item(caption, uri, RibbonItemStyles.SmallWithText));

                var edgePage = Page("Edge uris");
                var edgeLarge = Group(edgePage, "Large");
                var edgeSmall = Group(edgePage, "Small");
                foreach(var (caption, uri) in IconCatalog.EdgeUris) {
                    edgeLarge.ItemLinks.Add(Item(caption, uri, RibbonItemStyles.Large));
                    edgeSmall.ItemLinks.Add(Item(caption, uri, RibbonItemStyles.SmallWithText));
                }

                BuildMenusPage();

                ribbon.Toolbar.ItemLinks.Add(Item("QAT save", Icons("save"), RibbonItemStyles.Default));
                ribbon.Toolbar.ItemLinks.Add(Item("QAT copy", Icons("copy"), RibbonItemStyles.Default));
                ribbon.Toolbar.ItemLinks.Add(Item("QAT legacy", DevExpress.Images.DXImages.Undo, RibbonItemStyles.Default));
                statusBar.ItemLinks.Add(Item("Status info", Icons("info"), RibbonItemStyles.Default));
                statusBar.ItemLinks.Add(Item("Status warning", Icons("warning"), RibbonItemStyles.Default));
                statusBar.ItemLinks.Add(Item("Status pinned classic", new DxIcon("alert", IconSet.DesktopClassic), RibbonItemStyles.Default));
            }
            finally {
                ribbon.EndInit();
            }
            IconLog.Write($"Ribbon rebuilt: {ribbon.Items.Count} items | {IconModeSwitch.Describe()}");
        }

        void BuildMenusPage() {
            var page = Page("Menus / galleries / editors");
            var menus = Group(page, "Menus");
            var sub = new BarSubItem { Caption = "BarSubItem" };
            sub.ImageOptions.ImageUri = Icons("folder");
            ribbon.Items.Add(sub);
            foreach(string id in new[] { "document", "table", "image", "link" })
                sub.AddItem(Item($"sub {id}", Icons(id), RibbonItemStyles.Default));
            var nested = new BarSubItem { Caption = "Nested (pinned Classic)" };
            nested.ImageOptions.ImageUri = new DxIcon("folder", IconSet.DesktopClassic);
            ribbon.Items.Add(nested);
            nested.AddItem(Item("nested legacy", DevExpress.Images.DXImages.Find, RibbonItemStyles.Default));
            nested.AddItem(Item("nested fluent filled", new DxIcon("search", IconSet.Fluent, IconStyle.Filled), RibbonItemStyles.Default));
            sub.AddItem(nested);
            menus.ItemLinks.Add(sub);

            var dropDown = Item("Split + PopupMenu", Icons("mail"), RibbonItemStyles.Large);
            dropDown.ButtonStyle = BarButtonStyle.DropDown;
            dropDown.DropDownControl = popupMenu;
            menus.ItemLinks.Add(dropDown);
            foreach(var (caption, uri) in IconCatalog.IconSetUris.Take(8))
                popupMenu.ItemLinks.Add(Item($"popup {caption}", uri, RibbonItemStyles.Default));
            popupMenu.ItemLinks.Add(Item("popup legacy", "Add;Size16x16", RibbonItemStyles.Default), true);

            var check = new BarCheckItem { Caption = "BarCheckItem" };
            check.ImageOptions.ImageUri = Icons("checkmark");
            ribbon.Items.Add(check);
            menus.ItemLinks.Add(check);
            var buttonGroup = new BarButtonGroup();
            ribbon.Items.Add(buttonGroup);
            foreach(string id in new[] { "arrow_left", "home", "arrow_right" })
                buttonGroup.ItemLinks.Add(Item(id, Icons(id), RibbonItemStyles.SmallWithoutText));
            menus.ItemLinks.Add(buttonGroup);
            var header = new BarHeaderItem { Caption = "BarHeaderItem" };
            ribbon.Items.Add(header);
            popupMenu.ItemLinks.Add(header);
            var staticItem = new BarStaticItem { Caption = "BarStaticItem" };
            staticItem.ImageOptions.ImageUri = Icons("info");
            ribbon.Items.Add(staticItem);
            menus.ItemLinks.Add(staticItem);
            var large = new BarLargeButtonItem { Caption = "BarLargeButtonItem" };
            large.ImageOptions.ImageUri = Icons("globe");
            ribbon.Items.Add(large);
            menus.ItemLinks.Add(large);

            var galleryGroup = Group(page, "RibbonGalleryBarItem");
            var galleryItem = new RibbonGalleryBarItem { Caption = "Gallery" };
            galleryItem.Gallery.ImageSize = new Size(32, 32);
            galleryItem.Gallery.ColumnCount = 6;
            galleryItem.Gallery.ShowItemText = true;
            var galleryItemGroup = new GalleryItemGroup { Caption = "Icons (size from Gallery.ImageSize)" };
            foreach(var (caption, icon) in IconCatalog.TypedIcons) {
                var item = new GalleryItem { Caption = caption };
                item.ImageOptions.ImageUri = icon;
                galleryItemGroup.Items.Add(item);
            }
            var pinnedGroup = new GalleryItemGroup { Caption = "Pinned size 16 inside a 32 gallery" };
            foreach(var (caption, icon) in IconCatalog.TypedIcons.Take(8)) {
                var item = new GalleryItem { Caption = caption };
                item.ImageOptions.ImageUri = new DxIcon(icon.ToString(), size: IconSize.Size16);
                pinnedGroup.Items.Add(item);
            }
            galleryItem.Gallery.Groups.Add(galleryItemGroup);
            galleryItem.Gallery.Groups.Add(pinnedGroup);
            ribbon.Items.Add(galleryItem);
            galleryGroup.ItemLinks.Add(galleryItem);
            var gallerySize = new BarEditItem { Caption = "Gallery size", Edit = new RepositoryItemSpinEdit(), EditValue = 32, EditWidth = 60 };
            gallerySize.EditValueChanged += (s, e) => {
                int size = Convert.ToInt32(gallerySize.EditValue);
                galleryItem.Gallery.ImageSize = new Size(size, size);
                IconLog.Write($"RibbonGallery.ImageSize -> {size}");
            };
            ribbon.Items.Add(gallerySize);
            galleryGroup.ItemLinks.Add(gallerySize);

            var editors = Group(page, "BarEditItem");
            var buttonEdit = new RepositoryItemButtonEdit();
            buttonEdit.Buttons.Clear();
            foreach(string id in new[] { "search", "filter_funnel", "delete" }) {
                var button = new EditorButton(ButtonPredefines.Glyph);
                button.ImageOptions.ImageUri = Icons(id);
                buttonEdit.Buttons.Add(button);
            }
            var legacyButton = new EditorButton(ButtonPredefines.Glyph);
            legacyButton.ImageOptions.ImageUri = "Add;Size16x16";
            buttonEdit.Buttons.Add(legacyButton);
            var editItem = new BarEditItem { Caption = "ButtonEdit", Edit = buttonEdit, EditWidth = 200 };
            editItem.ImageOptions.ImageUri = Icons("key");
            ribbon.Items.Add(editItem);
            editors.ItemLinks.Add(editItem);
            var skinItem = new SkinDropDownButtonItem();
            ribbon.Items.Add(skinItem);
            editors.ItemLinks.Add(skinItem);
            var paletteItem = new SkinPaletteDropDownButtonItem();
            ribbon.Items.Add(paletteItem);
            editors.ItemLinks.Add(paletteItem);

            var category = new RibbonPageCategory { Text = "Contextual", Color = Color.SeaGreen, Visible = true };
            ribbon.PageCategories.Add(category);
            var contextual = new RibbonPage { Text = "Contextual page" };
            contextual.ImageOptions.ImageUri = Icons("star");
            category.Pages.Add(contextual);
            var contextualGroup = new RibbonPageGroup { Text = "Group with glyph" };
            contextualGroup.ImageOptions.ImageUri = Icons("calendar");
            contextual.Groups.Add(contextualGroup);
            contextualGroup.ItemLinks.Add(Item("Contextual", Icons("calendar"), RibbonItemStyles.Large));
        }

        static DxIcon Icons(string id) => new DxIcon(id);

        RibbonPage Page(string text) {
            var page = new RibbonPage { Text = text };
            ribbon.Pages.Add(page);
            return page;
        }

        static RibbonPageGroup Group(RibbonPage page, string text) {
            var group = new RibbonPageGroup { Text = text, AllowTextClipping = false };
            page.Groups.Add(group);
            return group;
        }

        BarButtonItem Item(string caption, DxImageUri uri, RibbonItemStyles style) {
            var item = new BarButtonItem { Caption = caption, RibbonStyle = style };
            item.ImageOptions.ImageUri = uri;
            item.SuperTip = new SuperToolTip();
            item.SuperTip.Items.AddTitle(caption);
            item.SuperTip.Items.Add($"ImageUri = '{uri.Uri}'");
            item.ItemClick += (s, e) => {
                var current = e.Item.ImageOptions.ImageUri;
                IconLog.Write($"Click '{caption}': '{current.Uri}' HasSvgImage={current.HasSvgImage} HasImage={current.HasImage} HasLargeImage={current.HasLargeImage}");
            };
            ribbon.Items.Add(item);
            Track(item.ImageOptions);
            return item;
        }
    }

    public class BarManagerForm : XtraForm {
        public BarManagerForm() {
            Text = "Classic BarManager: main menu, toolbar, status bar";
            Size = new Size(900, 500);
            var manager = new BarManager { Form = this };
            manager.BeginUpdate();
            var mainMenu = new Bar(manager, "Main menu") { DockStyle = BarDockStyle.Top };
            mainMenu.OptionsBar.MultiLine = true;
            mainMenu.OptionsBar.UseWholeRow = true;
            manager.MainMenu = mainMenu;
            var toolbar = new Bar(manager, "Toolbar") { DockStyle = BarDockStyle.Top, DockRow = 1 };
            var status = new Bar(manager, "Status") { DockStyle = BarDockStyle.Bottom };
            manager.StatusBar = status;
            var file = new BarSubItem(manager, "File");
            mainMenu.AddItem(file);
            foreach(var (caption, icon) in IconCatalog.TypedIcons.Take(10)) {
                var item = new BarButtonItem(manager, caption);
                item.ImageOptions.ImageUri = icon;
                file.AddItem(item);
                var toolItem = new BarButtonItem(manager, caption) { PaintStyle = BarItemPaintStyle.Standard };
                toolItem.ImageOptions.ImageUri = icon;
                toolbar.AddItem(toolItem);
            }
            foreach(var (caption, uri) in IconCatalog.LegacyUris.Take(6)) {
                var item = new BarButtonItem(manager, caption) { PaintStyle = BarItemPaintStyle.CaptionGlyph };
                item.ImageOptions.ImageUri = uri;
                toolbar.AddItem(item);
            }
            var statusItem = new BarStaticItem { Caption = "Status" };
            statusItem.ImageOptions.ImageUri = new DxIcon("info");
            manager.Items.Add(statusItem);
            status.AddItem(statusItem);
            var largeToggle = new BarCheckItem(manager) { Caption = "Large icons" };
            largeToggle.CheckedChanged += (s, e) => manager.LargeIcons = largeToggle.Checked;
            toolbar.AddItem(largeToggle);
            manager.EndUpdate();
        }
    }
}
