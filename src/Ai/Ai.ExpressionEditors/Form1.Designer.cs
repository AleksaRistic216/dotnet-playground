namespace Ai.ExpressionEditors {
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
            ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            skinRibbonGalleryBarItem = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            skinDropDownButtonItem = new DevExpress.XtraBars.SkinDropDownButtonItem();
            skinPaletteRibbonGalleryBarItem = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            rpgSkins = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            gridControl = new DevExpress.XtraGrid.GridControl();
            behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(components);
            sidePanel1 = new DevExpress.XtraEditors.SidePanel();
            ((System.ComponentModel.ISupportInitialize)ribbonControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl
            // 
            ribbonControl.ExpandCollapseItem.Id = 0;
            ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl.ExpandCollapseItem, skinRibbonGalleryBarItem, skinDropDownButtonItem, skinPaletteRibbonGalleryBarItem, barEditItem1, barEditItem2 });
            ribbonControl.Location = new Point(0, 0);
            ribbonControl.MaxItemId = 6;
            ribbonControl.Name = "ribbonControl";
            ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage });
            ribbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemComboBox1, repositoryItemComboBox2 });
            ribbonControl.Size = new Size(905, 158);
            // 
            // skinRibbonGalleryBarItem
            // 
            skinRibbonGalleryBarItem.Caption = "skinRibbonGalleryBarItem";
            skinRibbonGalleryBarItem.Id = 1;
            skinRibbonGalleryBarItem.Name = "skinRibbonGalleryBarItem";
            // 
            // skinDropDownButtonItem
            // 
            skinDropDownButtonItem.Id = 2;
            skinDropDownButtonItem.Name = "skinDropDownButtonItem";
            // 
            // skinPaletteRibbonGalleryBarItem
            // 
            skinPaletteRibbonGalleryBarItem.Caption = "skinPaletteRibbonGalleryBarItem";
            skinPaletteRibbonGalleryBarItem.Id = 3;
            skinPaletteRibbonGalleryBarItem.Name = "skinPaletteRibbonGalleryBarItem";
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "Model";
            barEditItem1.Edit = repositoryItemComboBox1;
            barEditItem1.Id = 3;
            barEditItem1.Name = "barEditItem1";
            barEditItem1.EditValueChanged += barEditItem1_EditValueChanged;
            barEditItem1.ItemClick += barEditItem1_ItemClick;
            // 
            // repositoryItemComboBox1
            // 
            repositoryItemComboBox1.AutoHeight = false;
            repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // barEditItem2
            // 
            barEditItem2.Caption = "Provider";
            barEditItem2.Edit = repositoryItemComboBox2;
            barEditItem2.Id = 5;
            barEditItem2.Name = "barEditItem2";
            barEditItem2.EditValueChanged += barEditItem2_EditValueChanged;
            // 
            // repositoryItemComboBox2
            // 
            repositoryItemComboBox2.AutoHeight = false;
            repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // ribbonPage
            // 
            ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { rpgSkins, ribbonPageGroup1 });
            ribbonPage.Name = "ribbonPage";
            ribbonPage.Text = "ribbonPage";
            // 
            // rpgSkins
            // 
            rpgSkins.ItemLinks.Add(skinDropDownButtonItem);
            rpgSkins.ItemLinks.Add(skinPaletteRibbonGalleryBarItem);
            rpgSkins.Name = "rpgSkins";
            rpgSkins.Text = "Skins";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barEditItem2);
            ribbonPageGroup1.ItemLinks.Add(barEditItem1);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded;
            ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // gridView
            // 
            behaviorManager1.SetBehaviors(gridView, new DevExpress.Utils.Behaviors.Behavior[] { DevExpress.AIIntegration.WinForms.ExpressionFromPromptBehavior.Create(typeof(DevExpress.AIIntegration.WinForms.ExpressionFromPromptGridBehaviorSource)) });
            gridView.GridControl = gridControl;
            gridView.Name = "gridView";
            // 
            // gridControl
            // 
            gridControl.Dock = DockStyle.Fill;
            gridControl.Location = new Point(0, 158);
            gridControl.MainView = gridView;
            gridControl.Name = "gridControl";
            gridControl.Size = new Size(705, 333);
            gridControl.TabIndex = 0;
            gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });
            gridControl.Click += gridControl_Click;
            // 
            // sidePanel1
            // 
            sidePanel1.Dock = DockStyle.Right;
            sidePanel1.Location = new Point(705, 32);
            sidePanel1.MinimumSize = new Size(0, 460);
            sidePanel1.Name = "sidePanel1";
            sidePanel1.Size = new Size(200, 460);
            sidePanel1.TabIndex = 2;
            sidePanel1.Text = "sidePanel1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 491);
            Controls.Add(gridControl);
            Controls.Add(sidePanel1);
            Controls.Add(ribbonControl);
            Name = "Form1";
            Ribbon = ribbonControl;
            SidePane = sidePanel1;
            Text = "Form";
            ((System.ComponentModel.ISupportInitialize)ribbonControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSkins;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.SidePanel sidePanel1;
    }
}
