using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraNavBar;

namespace FW.RibbonForm.WinFormsFW {
    public partial class IconSizeNavBarForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public IconSizeNavBarForm() {
            InitializeComponent();
            SetupNavBar();
        }

        void SetupNavBar() {
            // Group 1: Small icons view (default)
            navBarGroup1.Caption = "Small Icons Group";
            navBarGroup1.ImageOptions.ImageUri.Uri = "New";

            var item1 = new NavBarItem { Caption = "Customers" };
            item1.ImageOptions.ImageUri.Uri = "Open";
            navBarGroup1.ItemLinks.Add(new NavBarItemLink(item1));
            navBarControl1.Items.Add(item1);

            var item2 = new NavBarItem { Caption = "Orders" };
            item2.ImageOptions.ImageUri.Uri = "Save";
            navBarGroup1.ItemLinks.Add(new NavBarItemLink(item2));
            navBarControl1.Items.Add(item2);

            var item3 = new NavBarItem { Caption = "Reports" };
            item3.ImageOptions.ImageUri.Uri = "Print";
            navBarGroup1.ItemLinks.Add(new NavBarItemLink(item3));
            navBarControl1.Items.Add(item3);

            // Group 2: Large icons view
            var group2 = new NavBarGroup { Caption = "Large Icons Group" };
            group2.GroupStyle = NavBarGroupStyle.LargeIconsText;
            group2.ImageOptions.ImageUri.Uri = "New";
            navBarControl1.Groups.Add(group2);

            var item4 = new NavBarItem { Caption = "Statistics" };
            item4.ImageOptions.ImageUri.Uri = "Open";
            item4.ImageOptions.LargeImageSize = new Size(32, 32);
            group2.ItemLinks.Add(new NavBarItemLink(item4));
            navBarControl1.Items.Add(item4);

            var item5 = new NavBarItem { Caption = "Dashboard" };
            item5.ImageOptions.ImageUri.Uri = "Save";
            item5.ImageOptions.LargeImageSize = new Size(32, 32);
            group2.ItemLinks.Add(new NavBarItemLink(item5));
            navBarControl1.Items.Add(item5);

            var item6 = new NavBarItem { Caption = "Employees" };
            item6.ImageOptions.ImageUri.Uri = "Print";
            item6.ImageOptions.LargeImageSize = new Size(32, 32);
            group2.ItemLinks.Add(new NavBarItemLink(item6));
            navBarControl1.Items.Add(item6);

            // Group 3: Mixed sizes with SmallImageSize/LargeImageSize
            var group3 = new NavBarGroup { Caption = "Custom Sizes" };
            group3.ImageOptions.ImageUri.Uri = "New";
            group3.ImageOptions.SmallImageSize = new Size(20, 20);
            navBarControl1.Groups.Add(group3);

            var item7 = new NavBarItem { Caption = "Small 12x12" };
            item7.ImageOptions.ImageUri.Uri = "Open";
            item7.ImageOptions.SmallImageSize = new Size(12, 12);
            group3.ItemLinks.Add(new NavBarItemLink(item7));
            navBarControl1.Items.Add(item7);

            var item8 = new NavBarItem { Caption = "Default size" };
            item8.ImageOptions.ImageUri.Uri = "Save";
            group3.ItemLinks.Add(new NavBarItemLink(item8));
            navBarControl1.Items.Add(item8);

            var item9 = new NavBarItem { Caption = "Large 24x24" };
            item9.ImageOptions.ImageUri.Uri = "Print";
            item9.ImageOptions.SmallImageSize = new Size(24, 24);
            group3.ItemLinks.Add(new NavBarItemLink(item9));
            navBarControl1.Items.Add(item9);
        }
    }
}
