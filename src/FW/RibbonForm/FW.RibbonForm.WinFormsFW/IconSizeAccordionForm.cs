using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;

namespace FW.RibbonForm.WinFormsFW {
    public partial class IconSizeAccordionForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public IconSizeAccordionForm() {
            InitializeComponent();
            SetupAccordion();
        }

        void SetupAccordion() {
            // AccordionControl does NOT need IDXImageUriIconSizeProvider.
            // It always passes explicit sizes via GetSvgImageSize() -> ImageOptions.GetImage(size, ...).
            // Root groups default to 32x32, child items to 16x16 (or accordion-level SvgImageSize).

            // Group with default icon (renders at 32x32 - root group default)
            accordionGroup1.ImageOptions.ImageUri.Uri = "New";

            // Items with default sizes (16x16)
            var item1 = new AccordionControlElement {
                Text = "Add (default)",
                Style = ElementStyle.Item
            };
            item1.ImageOptions.ImageUri.Uri = "Open";
            accordionGroup1.Elements.Add(item1);

            var item2 = new AccordionControlElement {
                Text = "Edit (default)",
                Style = ElementStyle.Item
            };
            item2.ImageOptions.ImageUri.Uri = "Save";
            accordionGroup1.Elements.Add(item2);

            var item3 = new AccordionControlElement {
                Text = "Delete (default)",
                Style = ElementStyle.Item
            };
            item3.ImageOptions.ImageUri.Uri = "Print";
            accordionGroup1.Elements.Add(item3);

            // Items with explicit SvgImageSize (24x24)
            var group2 = new AccordionControlElement {
                Text = "24x24 Icons",
                Style = ElementStyle.Group
            };
            group2.ImageOptions.ImageUri.Uri = "New";
            accordionControl1.Elements.Add(group2);

            var item4 = new AccordionControlElement {
                Text = "Save (24x24)",
                Style = ElementStyle.Item
            };
            item4.ImageOptions.ImageUri.Uri = "Open";
            item4.ImageOptions.SvgImageSize = new Size(24, 24);
            group2.Elements.Add(item4);

            var item5 = new AccordionControlElement {
                Text = "Open (24x24)",
                Style = ElementStyle.Item
            };
            item5.ImageOptions.ImageUri.Uri = "Save";
            item5.ImageOptions.SvgImageSize = new Size(24, 24);
            group2.Elements.Add(item5);

            var item6 = new AccordionControlElement {
                Text = "Print (24x24)",
                Style = ElementStyle.Item
            };
            item6.ImageOptions.ImageUri.Uri = "Print";
            item6.ImageOptions.SvgImageSize = new Size(24, 24);
            group2.Elements.Add(item6);

            // Items with explicit SvgImageSize (32x32)
            var group3 = new AccordionControlElement {
                Text = "32x32 Icons",
                Style = ElementStyle.Group
            };
            group3.ImageOptions.ImageUri.Uri = "New";
            group3.ImageOptions.SvgImageSize = new Size(32, 32);
            accordionControl1.Elements.Add(group3);

            var item7 = new AccordionControlElement {
                Text = "Print (32x32)",
                Style = ElementStyle.Item
            };
            item7.ImageOptions.ImageUri.Uri = "Open";
            item7.ImageOptions.SvgImageSize = new Size(32, 32);
            group3.Elements.Add(item7);

            var item8 = new AccordionControlElement {
                Text = "Find (32x32)",
                Style = ElementStyle.Item
            };
            item8.ImageOptions.ImageUri.Uri = "Save";
            item8.ImageOptions.SvgImageSize = new Size(32, 32);
            group3.Elements.Add(item8);

            var item9 = new AccordionControlElement {
                Text = "Print (32x32)",
                Style = ElementStyle.Item
            };
            item9.ImageOptions.ImageUri.Uri = "Print";
            item9.ImageOptions.SvgImageSize = new Size(32, 32);
            group3.Elements.Add(item9);
        }
    }
}
