using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace FW.RibbonForm.WinFormsFW {
    public partial class IconSizeTileForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public IconSizeTileForm() {
            InitializeComponent();
            SetupTileControl();
        }

        void SetupTileControl() {
            var group1 = new TileGroup { Text = "Default Size" };
            tileControl1.Groups.Add(group1);

            // TileItemElement with default size
            var tile1 = new TileItem { Text = "Default" };
            var elem1 = new TileItemElement {
                Text = "Default size",
                ImageAlignment = TileItemContentAlignment.MiddleCenter
            };
            elem1.ImageOptions.ImageUri.Uri = "New";
            tile1.Elements.Add(elem1);
            group1.Items.Add(tile1);

            // TileItemElement with 16x16
            var tile2 = new TileItem { Text = "16x16" };
            var elem2 = new TileItemElement {
                Text = "16x16",
                ImageAlignment = TileItemContentAlignment.MiddleCenter
            };
            elem2.ImageOptions.ImageUri.Uri = "Open";
            elem2.ImageOptions.ImageSize = new Size(16, 16);
            tile2.Elements.Add(elem2);
            group1.Items.Add(tile2);

            // TileItemElement with 32x32
            var tile3 = new TileItem { Text = "32x32" };
            var elem3 = new TileItemElement {
                Text = "32x32",
                ImageAlignment = TileItemContentAlignment.MiddleCenter
            };
            elem3.ImageOptions.ImageUri.Uri = "Save";
            elem3.ImageOptions.ImageSize = new Size(32, 32);
            tile3.Elements.Add(elem3);
            group1.Items.Add(tile3);

            var group2 = new TileGroup { Text = "Large Sizes" };
            tileControl1.Groups.Add(group2);

            // TileItemElement with 48x48
            var tile4 = new TileItem { Text = "48x48" };
            var elem4 = new TileItemElement {
                Text = "48x48",
                ImageAlignment = TileItemContentAlignment.MiddleCenter
            };
            elem4.ImageOptions.ImageUri.Uri = "Print";
            elem4.ImageOptions.ImageSize = new Size(48, 48);
            tile4.Elements.Add(elem4);
            group2.Items.Add(tile4);

            // TileItemElement with 64x64
            var tile5 = new TileItem { Text = "64x64" };
            var elem5 = new TileItemElement {
                Text = "64x64",
                ImageAlignment = TileItemContentAlignment.MiddleCenter
            };
            elem5.ImageOptions.ImageUri.Uri = "New";
            elem5.ImageOptions.ImageSize = new Size(64, 64);
            tile5.Elements.Add(elem5);
            group2.Items.Add(tile5);

            // TileItemElement with 96x96
            var tile6 = new TileItem { Text = "96x96" };
            tile6.ItemSize = TileItemSize.Wide;
            var elem6 = new TileItemElement {
                Text = "96x96",
                ImageAlignment = TileItemContentAlignment.MiddleCenter
            };
            elem6.ImageOptions.ImageUri.Uri = "Open";
            elem6.ImageOptions.ImageSize = new Size(96, 96);
            tile6.Elements.Add(elem6);
            group2.Items.Add(tile6);
        }
    }
}
