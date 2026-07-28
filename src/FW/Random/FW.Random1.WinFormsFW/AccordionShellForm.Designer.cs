namespace FW.Random1.WinFormsFW {
    partial class AccordionShellForm {
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
            skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            skinPaletteDropDownButtonItem1 = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            bciOriginalPalette = new DevExpress.XtraBars.BarCheckItem();
            bciTrackWindowsAccentColor = new DevExpress.XtraBars.BarCheckItem();
            bbiCustomColors = new DevExpress.XtraBars.BarButtonItem();
            bbiCustomColors2 = new DevExpress.XtraBars.BarButtonItem();
            bciTrackWindowsAppMode = new DevExpress.XtraBars.BarCheckItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ribbonPageAppearance = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroupAppearance = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroupAccentColors = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            navigationAccordion = new DevExpress.XtraBars.Navigation.AccordionControl();
            navigationAccordionViewsGroup = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            dataGridViewAccordionElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            dataGridViewPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            viewNavigationFrame = new DevExpress.XtraBars.Navigation.NavigationFrame();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)navigationAccordion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)viewNavigationFrame).BeginInit();
            viewNavigationFrame.SuspendLayout();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, skinDropDownButtonItem1, skinPaletteDropDownButtonItem1, bciOriginalPalette, bciTrackWindowsAccentColor, bbiCustomColors, bbiCustomColors2, bciTrackWindowsAppMode, barButtonItem1 });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.MaxItemId = 9;
            ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPageAppearance });
            ribbonControl1.ShowToolbarCustomizeItem = false;
            ribbonControl1.Size = new Size(998, 201);
            ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // skinDropDownButtonItem1
            // 
            skinDropDownButtonItem1.Id = 1;
            skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            // 
            // skinPaletteDropDownButtonItem1
            // 
            skinPaletteDropDownButtonItem1.ActAsDropDown = true;
            skinPaletteDropDownButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            skinPaletteDropDownButtonItem1.Id = 2;
            skinPaletteDropDownButtonItem1.Name = "skinPaletteDropDownButtonItem1";
            // 
            // bciOriginalPalette
            // 
            bciOriginalPalette.Caption = "Original Palette";
            bciOriginalPalette.Id = 3;
            bciOriginalPalette.ImageOptions.ImageUri.Uri = "arrows/stop";
            bciOriginalPalette.Name = "bciOriginalPalette";
            // 
            // bciTrackWindowsAccentColor
            // 
            bciTrackWindowsAccentColor.Caption = "Track Window Accent Color";
            bciTrackWindowsAccentColor.Id = 4;
            bciTrackWindowsAccentColor.ImageOptions.ImageUri.Uri = "arrows/stop";
            bciTrackWindowsAccentColor.Name = "bciTrackWindowsAccentColor";
            // 
            // bbiCustomColors
            // 
            bbiCustomColors.Caption = "Custom Colors";
            bbiCustomColors.Id = 5;
            bbiCustomColors.ImageOptions.ImageUri.Uri = "arrows/stop";
            bbiCustomColors.Name = "bbiCustomColors";
            // 
            // bbiCustomColors2
            // 
            bbiCustomColors2.Caption = "Custom Colors 2";
            bbiCustomColors2.Id = 6;
            bbiCustomColors2.ImageOptions.ImageUri.Uri = "arrows/stop";
            bbiCustomColors2.Name = "bbiCustomColors2";
            // 
            // bciTrackWindowsAppMode
            // 
            bciTrackWindowsAppMode.Caption = "Track Window App Mode";
            bciTrackWindowsAppMode.Id = 7;
            bciTrackWindowsAppMode.ImageOptions.ImageUri.Uri = "arrows/stop";
            bciTrackWindowsAppMode.Name = "bciTrackWindowsAppMode";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "barButtonItem1";
            barButtonItem1.Id = 8;
            barButtonItem1.Name = "barButtonItem1";
            barButtonItem1.ItemClick += barButtonItem1_ItemClick;
            // 
            // ribbonPageAppearance
            // 
            ribbonPageAppearance.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroupAppearance, ribbonPageGroupAccentColors, ribbonPageGroup1 });
            ribbonPageAppearance.Name = "ribbonPageAppearance";
            ribbonPageAppearance.Text = "Appearance";
            // 
            // ribbonPageGroupAppearance
            // 
            ribbonPageGroupAppearance.ItemLinks.Add(skinDropDownButtonItem1);
            ribbonPageGroupAppearance.ItemLinks.Add(skinPaletteDropDownButtonItem1);
            ribbonPageGroupAppearance.Name = "ribbonPageGroupAppearance";
            ribbonPageGroupAppearance.Text = "Appearance";
            // 
            // ribbonPageGroupAccentColors
            // 
            ribbonPageGroupAccentColors.ItemLinks.Add(bciTrackWindowsAppMode);
            ribbonPageGroupAccentColors.ItemLinks.Add(bciOriginalPalette);
            ribbonPageGroupAccentColors.ItemLinks.Add(bciTrackWindowsAccentColor);
            ribbonPageGroupAccentColors.ItemLinks.Add(bbiCustomColors);
            ribbonPageGroupAccentColors.ItemLinks.Add(bbiCustomColors2);
            ribbonPageGroupAccentColors.Name = "ribbonPageGroupAccentColors";
            ribbonPageGroupAccentColors.Text = "Accent Colors";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonItem1);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPage2
            // 
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "ribbonPage2";
            // 
            // navigationAccordion
            // 
            navigationAccordion.AllowItemSelection = true;
            navigationAccordion.Dock = DockStyle.Left;
            navigationAccordion.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { navigationAccordionViewsGroup });
            navigationAccordion.Location = new Point(0, 49);
            navigationAccordion.Margin = new Padding(2);
            navigationAccordion.MinimumSize = new Size(0, 751);
            navigationAccordion.Name = "navigationAccordion";
            navigationAccordion.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            navigationAccordion.Size = new Size(255, 751);
            navigationAccordion.TabIndex = 2;
            navigationAccordion.SelectedElementChanged += OnSelectedAccordionElementChanged;
            // 
            // navigationAccordionViewsGroup
            // 
            navigationAccordionViewsGroup.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { dataGridViewAccordionElement });
            navigationAccordionViewsGroup.Expanded = true;
            navigationAccordionViewsGroup.Name = "navigationAccordionViewsGroup";
            navigationAccordionViewsGroup.Text = "Views";
            // 
            // dataGridViewAccordionElement
            // 
            dataGridViewAccordionElement.Name = "dataGridViewAccordionElement";
            dataGridViewAccordionElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            dataGridViewAccordionElement.Text = "Data Grid";
            // 
            // dataGridViewPage
            // 
            dataGridViewPage.Caption = "navigationPage0";
            dataGridViewPage.Name = "dataGridViewPage";
            dataGridViewPage.Size = new Size(743, 598);
            // 
            // viewNavigationFrame
            // 
            viewNavigationFrame.Controls.Add(dataGridViewPage);
            viewNavigationFrame.Dock = DockStyle.Fill;
            viewNavigationFrame.Location = new Point(255, 201);
            viewNavigationFrame.Name = "viewNavigationFrame";
            viewNavigationFrame.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { dataGridViewPage });
            viewNavigationFrame.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
            viewNavigationFrame.SelectedPage = dataGridViewPage;
            viewNavigationFrame.Size = new Size(743, 598);
            viewNavigationFrame.TabIndex = 4;
            viewNavigationFrame.Text = "navigationFrame1";
            viewNavigationFrame.QueryControl += OnNavigationFrameQueryControl;
            // 
            // AccordionShellForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 799);
            Controls.Add(viewNavigationFrame);
            Controls.Add(navigationAccordion);
            Controls.Add(ribbonControl1);
            Name = "AccordionShellForm";
            NavigationControl = navigationAccordion;
            NavigationControlLayoutMode = DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToFormTitle;
            Ribbon = ribbonControl1;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)navigationAccordion).EndInit();
            ((System.ComponentModel.ISupportInitialize)viewNavigationFrame).EndInit();
            viewNavigationFrame.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Navigation.AccordionControl navigationAccordion;
        private DevExpress.XtraBars.Navigation.NavigationFrame viewNavigationFrame;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem skinPaletteDropDownButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageAppearance;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAppearance;
        private DevExpress.XtraBars.BarCheckItem bciOriginalPalette;
        private DevExpress.XtraBars.BarCheckItem bciTrackWindowsAccentColor;
        private DevExpress.XtraBars.BarButtonItem bbiCustomColors;
        private DevExpress.XtraBars.BarButtonItem bbiCustomColors2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAccentColors;
        private DevExpress.XtraBars.BarCheckItem bciTrackWindowsAppMode;
        private DevExpress.XtraBars.Navigation.AccordionControlElement navigationAccordionViewsGroup;
        private DevExpress.XtraBars.Navigation.AccordionControlElement dataGridViewAccordionElement;
        private DevExpress.XtraBars.Navigation.NavigationPage dataGridViewPage;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}