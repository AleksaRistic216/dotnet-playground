namespace LDSSM.WinForms {
    partial class DXGridForm {
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
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            barToggleSwitchItem1 = new DevExpress.XtraBars.BarToggleSwitchItem();
            barToggleSwitchItem2 = new DevExpress.XtraBars.BarToggleSwitchItem();
            barToggleSwitchItem3 = new DevExpress.XtraBars.BarToggleSwitchItem();
            barToggleSwitchItem4 = new DevExpress.XtraBars.BarToggleSwitchItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new Padding(28, 23, 28, 23);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, barToggleSwitchItem1, barToggleSwitchItem2, barToggleSwitchItem3, barToggleSwitchItem4 });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.Margin = new Padding(3, 2, 3, 2);
            ribbonControl1.MaxItemId = 7;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 305;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(1650, 308);
            // 
            // barToggleSwitchItem1
            // 
            barToggleSwitchItem1.Caption = "DbContext - Server Mode";
            barToggleSwitchItem1.Id = 3;
            barToggleSwitchItem1.Name = "barToggleSwitchItem1";
            barToggleSwitchItem1.CheckedChanged += barToggleSwitchItem_CheckedChanged;
            // 
            // barToggleSwitchItem2
            // 
            barToggleSwitchItem2.Caption = "DbContext - Instant Feedback Mode";
            barToggleSwitchItem2.Id = 4;
            barToggleSwitchItem2.Name = "barToggleSwitchItem2";
            barToggleSwitchItem2.CheckedChanged += barToggleSwitchItem_CheckedChanged;
            // 
            // barToggleSwitchItem3
            // 
            barToggleSwitchItem3.Caption = "IQueryable - Server Mode";
            barToggleSwitchItem3.Id = 5;
            barToggleSwitchItem3.Name = "barToggleSwitchItem3";
            barToggleSwitchItem3.CheckedChanged += barToggleSwitchItem_CheckedChanged;
            // 
            // barToggleSwitchItem4
            // 
            barToggleSwitchItem4.Caption = "IQueryable - Instant Feedback Mode";
            barToggleSwitchItem4.Id = 6;
            barToggleSwitchItem4.Name = "barToggleSwitchItem4";
            barToggleSwitchItem4.CheckedChanged += barToggleSwitchItem_CheckedChanged;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barToggleSwitchItem1);
            ribbonPageGroup1.ItemLinks.Add(barToggleSwitchItem2);
            ribbonPageGroup1.ItemLinks.Add(barToggleSwitchItem3);
            ribbonPageGroup1.ItemLinks.Add(barToggleSwitchItem4);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 308);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = ribbonControl1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1650, 550);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            // 
            // DXGridForm
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1650, 858);
            Controls.Add(gridControl1);
            Controls.Add(ribbonControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DXGridForm";
            Ribbon = ribbonControl1;
            Text = "DXGridForm";
            Load += DXGridForm_Load;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchItem1;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchItem2;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchItem3;
        private DevExpress.XtraBars.BarToggleSwitchItem barToggleSwitchItem4;
    }
}