namespace FW.RibbonForm.WinFormsFW {
    partial class IconSizeBarItemsForm {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonGalleryBarItem16 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.ribbonGalleryBarItem32 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.skinPaletteRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup16 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup32 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                this.ribbonControl1.ExpandCollapseItem,
                this.ribbonGalleryBarItem16,
                this.ribbonGalleryBarItem32,
                this.skinRibbonGalleryBarItem1,
                this.skinPaletteRibbonGalleryBarItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 10;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
                this.ribbonPage1,
                this.ribbonPage2});
            this.ribbonControl1.Size = new System.Drawing.Size(1000, 158);
            // 
            // ribbonGalleryBarItem16
            // 
            this.ribbonGalleryBarItem16.Caption = "Gallery 16px";
            this.ribbonGalleryBarItem16.Id = 6;
            this.ribbonGalleryBarItem16.Name = "ribbonGalleryBarItem16";
            // 
            // ribbonGalleryBarItem32
            // 
            this.ribbonGalleryBarItem32.Caption = "Gallery 32px";
            this.ribbonGalleryBarItem32.Id = 9;
            this.ribbonGalleryBarItem32.Name = "ribbonGalleryBarItem32";
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "Skins";
            this.skinRibbonGalleryBarItem1.Id = 7;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // skinPaletteRibbonGalleryBarItem1
            // 
            this.skinPaletteRibbonGalleryBarItem1.Caption = "Palettes";
            this.skinPaletteRibbonGalleryBarItem1.Id = 8;
            this.skinPaletteRibbonGalleryBarItem1.Name = "skinPaletteRibbonGalleryBarItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.ribbonPageGroup16,
                this.ribbonPageGroup32});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Gallery";
            // 
            // ribbonPageGroup16
            // 
            this.ribbonPageGroup16.ItemLinks.Add(this.ribbonGalleryBarItem16);
            this.ribbonPageGroup16.Name = "ribbonPageGroup16";
            this.ribbonPageGroup16.Text = "ImageSize = 16×16";
            // 
            // ribbonPageGroup32
            // 
            this.ribbonPageGroup32.ItemLinks.Add(this.ribbonGalleryBarItem32);
            this.ribbonPageGroup32.Name = "ribbonPageGroup32";
            this.ribbonPageGroup32.Text = "ImageSize = 32×32";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
                this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Appearance";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup3.ItemLinks.Add(this.skinPaletteRibbonGalleryBarItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Skins";
            // 
            // IconSizeBarItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "IconSizeBarItemsForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "GalleryItem - IDXImageUriIconSizeProvider (#34134)";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem16;
        private DevExpress.XtraBars.RibbonGalleryBarItem ribbonGalleryBarItem32;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup16;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup32;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}
