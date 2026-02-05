namespace FW.RTL.WinForms.TestForms.Bars {
    [TestForm("Bars", "Ribbon Gallery")]
    public partial class FormWithRibbonGallery : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithRibbonGallery() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateGallery();
        }

        private void PopulateGallery() {
            var group = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            for (int i = 1; i <= 12; i++) {
                group.Items.Add(new DevExpress.XtraBars.Ribbon.GalleryItem { Caption = $"Style {i}" });
            }
            galleryControl1.Gallery.Groups.Add(group);
        }
    }
}
