namespace FW.RTL.WinForms.TestForms.Progress {
    partial class FormWithRatingControl {
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
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ratingControl1 = new DevExpress.XtraEditors.RatingControl();
            this.ratingControl2 = new DevExpress.XtraEditors.RatingControl();
            this.ratingControl3 = new DevExpress.XtraEditors.RatingControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            //
            // ribbonControl1
            //
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(800, 158);
            //
            // ribbonPage1
            //
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            //
            // ribbonPageGroup1
            //
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Options";
            //
            // layoutControl1
            //
            this.layoutControl1.Controls.Add(this.ratingControl1);
            this.layoutControl1.Controls.Add(this.ratingControl2);
            this.layoutControl1.Controls.Add(this.ratingControl3);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 158);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(800, 292);
            this.layoutControl1.TabIndex = 1;
            //
            // layoutControlGroup1
            //
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 292);
            //
            // ratingControl1
            //
            this.ratingControl1.Location = new System.Drawing.Point(12, 28);
            this.ratingControl1.Name = "ratingControl1";
            this.ratingControl1.Properties.ItemCount = 5;
            this.ratingControl1.Rating = 0M;
            this.ratingControl1.Size = new System.Drawing.Size(776, 24);
            this.ratingControl1.StyleController = this.layoutControl1;
            this.ratingControl1.TabIndex = 4;
            //
            // ratingControl2
            //
            this.ratingControl2.Location = new System.Drawing.Point(12, 68);
            this.ratingControl2.Name = "ratingControl2";
            this.ratingControl2.Properties.ItemCount = 10;
            this.ratingControl2.Rating = 0M;
            this.ratingControl2.Size = new System.Drawing.Size(776, 24);
            this.ratingControl2.StyleController = this.layoutControl1;
            this.ratingControl2.TabIndex = 5;
            //
            // ratingControl3
            //
            this.ratingControl3.Location = new System.Drawing.Point(12, 108);
            this.ratingControl3.Name = "ratingControl3";
            this.ratingControl3.Properties.ItemCount = 5;
            this.ratingControl3.Properties.FillPrecision = DevExpress.XtraEditors.RatingItemFillPrecision.Half;
            this.ratingControl3.Rating = 0M;
            this.ratingControl3.Size = new System.Drawing.Size(776, 24);
            this.ratingControl3.StyleController = this.layoutControl1;
            this.ratingControl3.TabIndex = 6;
            //
            // layoutControlItem1
            //
            this.layoutControlItem1.Control = this.ratingControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 40);
            this.layoutControlItem1.Text = "5 Stars";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 13);
            //
            // layoutControlItem2
            //
            this.layoutControlItem2.Control = this.ratingControl2;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(780, 40);
            this.layoutControlItem2.Text = "10 Stars";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(80, 13);
            //
            // layoutControlItem3
            //
            this.layoutControlItem3.Control = this.ratingControl3;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(780, 40);
            this.layoutControlItem3.Text = "Half Precision";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(80, 13);
            //
            // FormWithRatingControl
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormWithRatingControl";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Rating Control";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.RatingControl ratingControl1;
        private DevExpress.XtraEditors.RatingControl ratingControl2;
        private DevExpress.XtraEditors.RatingControl ratingControl3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
