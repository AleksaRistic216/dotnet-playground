using System.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace FW.RibbonForm.WinFormsFW {
    public partial class IconSizeBarItemsForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public IconSizeBarItemsForm() {
            this.LookAndFeel.SetSkinStyle(SkinStyle.WXI);
            InitializeComponent();
            SetupGallery16();
            SetupGallery32();
        }

        void SetupGallery16() {
            // Gallery with ImageSize 16x16 — GetPreferredIconSize() returns 16x16
            // so FindNearestSize() picks the 16px icon variant.
            var gallery = ribbonGalleryBarItem16.Gallery;
            gallery.ItemSize = new Size(70, 50);
            gallery.ImageSize = new Size(16, 16);
            gallery.ShowItemText = true;
            gallery.ColumnCount = 4;

            var group = new GalleryItemGroup { Caption = "ImageSize = 16×16" };
            gallery.Groups.Add(group);

            string[] icons = { "New", "Open", "Save", "Print" };
            foreach (var icon in icons) {
                var item = new GalleryItem { Caption = icon };
                item.ImageOptions.ImageUri.Uri = icon;
                group.Items.Add(item);
            }
        }

        void SetupGallery32() {
            // Gallery with ImageSize 32x32 — GetPreferredIconSize() returns 32x32
            // so FindNearestSize() picks the 32px icon variant (more detail).
            var gallery = ribbonGalleryBarItem32.Gallery;
            gallery.ItemSize = new Size(70, 50);
            gallery.ImageSize = new Size(32, 32);
            gallery.ShowItemText = true;
            gallery.ColumnCount = 4;

            var group = new GalleryItemGroup { Caption = "ImageSize = 32×32" };
            gallery.Groups.Add(group);

            string[] icons = { "New", "Open", "Save", "Print" };
            foreach (var icon in icons) {
                var item = new GalleryItem { Caption = icon };
                item.ImageOptions.ImageUri.Uri = icon;
                group.Items.Add(item);
            }
        }
    }
}
