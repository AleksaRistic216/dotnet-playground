namespace RibbonForm.WinForms {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            skinDropDownButtonItem3 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            skinPaletteDropDownButtonItem3 = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            skinRibbonGalleryBarItem2 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            skinPaletteRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            skinPaletteDropDownButtonItem1 = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.CaptionBarItemLinks.Add(barButtonItem4);
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new Padding(26);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, skinRibbonGalleryBarItem1, barButtonItem1, skinDropDownButtonItem3, skinPaletteDropDownButtonItem3, skinRibbonGalleryBarItem2, skinPaletteRibbonGalleryBarItem1, barButtonItem3, barButtonItem5, barButtonItem7, skinDropDownButtonItem1, skinPaletteDropDownButtonItem1 });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 27;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 283;
            ribbonControl1.PageHeaderItemLinks.Add(skinDropDownButtonItem3);
            ribbonControl1.PageHeaderItemLinks.Add(skinPaletteDropDownButtonItem3);
            ribbonControl1.PageHeaderItemLinks.Add(skinRibbonGalleryBarItem2);
            ribbonControl1.PageHeaderItemLinks.Add(skinPaletteRibbonGalleryBarItem1);
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1, ribbonPage2 });
            ribbonControl1.QuickToolbarItemLinks.Add(barButtonItem5);
            ribbonControl1.QuickToolbarItemLinks.Add(skinDropDownButtonItem1);
            ribbonControl1.QuickToolbarItemLinks.Add(skinPaletteDropDownButtonItem1);
            ribbonControl1.Size = new Size(686, 158);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "barButtonItem4";
            barButtonItem4.Id = 21;
            barButtonItem4.ImageOptions.SvgImage = Properties.Resources.CheckboxFill5;
            barButtonItem4.Name = "barButtonItem4";
            // 
            // skinRibbonGalleryBarItem1
            // 
            skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            skinRibbonGalleryBarItem1.Id = 1;
            skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "Simple Form With Ribbon Control";
            barButtonItem1.Id = 2;
            barButtonItem1.Name = "barButtonItem1";
            barButtonItem1.ItemClick += barButtonItem1_ItemClick;
            // 
            // skinDropDownButtonItem3
            // 
            skinDropDownButtonItem3.Id = 8;
            skinDropDownButtonItem3.Name = "skinDropDownButtonItem3";
            // 
            // skinPaletteDropDownButtonItem3
            // 
            skinPaletteDropDownButtonItem3.ActAsDropDown = true;
            skinPaletteDropDownButtonItem3.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            skinPaletteDropDownButtonItem3.Id = 9;
            skinPaletteDropDownButtonItem3.Name = "skinPaletteDropDownButtonItem3";
            // 
            // skinRibbonGalleryBarItem2
            // 
            skinRibbonGalleryBarItem2.Caption = "skinRibbonGalleryBarItem2";
            skinRibbonGalleryBarItem2.Id = 10;
            skinRibbonGalleryBarItem2.Name = "skinRibbonGalleryBarItem2";
            // 
            // skinPaletteRibbonGalleryBarItem1
            // 
            skinPaletteRibbonGalleryBarItem1.Caption = "skinPaletteRibbonGalleryBarItem1";
            skinPaletteRibbonGalleryBarItem1.Id = 11;
            skinPaletteRibbonGalleryBarItem1.Name = "skinPaletteRibbonGalleryBarItem1";
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "barButtonItem3";
            barButtonItem3.Id = 16;
            barButtonItem3.Name = "barButtonItem3";
            barButtonItem3.ItemClick += barButtonItem3_ItemClick_1;
            // 
            // barButtonItem5
            // 
            barButtonItem5.Caption = "barButtonItem5";
            barButtonItem5.Id = 22;
            barButtonItem5.ImageOptions.SvgImage = Properties.Resources.CheckboxFill10;
            barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem7
            // 
            barButtonItem7.Caption = "Toggle Icon";
            barButtonItem7.Id = 24;
            barButtonItem7.Name = "barButtonItem7";
            barButtonItem7.ItemClick += barButtonItem7_ItemClick;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1, ribbonPageGroup3 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonItem1);
            ribbonPageGroup1.ItemLinks.Add(barButtonItem3);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(barButtonItem7);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonPage2
            // 
            ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup5 });
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPageGroup5
            // 
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = "ribbonPageGroup5";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.ItemLinks.Add(skinRibbonGalleryBarItem1);
            ribbonStatusBar1.Location = new Point(0, 366);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(686, 24);
            // 
            // textEdit1
            // 
            textEdit1.Location = new Point(252, 217);
            textEdit1.MenuManager = ribbonControl1;
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new Size(295, 20);
            textEdit1.TabIndex = 2;
            // 
            // skinDropDownButtonItem1
            // 
            skinDropDownButtonItem1.Id = 25;
            skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            // 
            // skinPaletteDropDownButtonItem1
            // 
            skinPaletteDropDownButtonItem1.ActAsDropDown = true;
            skinPaletteDropDownButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            skinPaletteDropDownButtonItem1.Id = 26;
            skinPaletteDropDownButtonItem1.Name = "skinPaletteDropDownButtonItem1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 390);
            Controls.Add(textEdit1);
            Controls.Add(ribbonControl1);
            Controls.Add(ribbonStatusBar1);
            IconOptions.ShowIcon = false;
            Name = "Form1";
            Ribbon = ribbonControl1;
            StatusBar = ribbonStatusBar1;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem3;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem skinPaletteDropDownButtonItem3;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem skinPaletteDropDownButtonItem1;
    }
}