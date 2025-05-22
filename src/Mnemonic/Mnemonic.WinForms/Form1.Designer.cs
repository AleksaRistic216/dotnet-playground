namespace Mnemonic.WinForms {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            bar2 = new DevExpress.XtraBars.Bar();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar2, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItem1, barButtonItem2, barSubItem1, barButtonItem3, barButtonItem4, barButtonItem5, barButtonItem6, barButtonItem7, barButtonItem8, barCheckItem1, barButtonItem9, barButtonItem10, barButtonItem11, barButtonItem12, barButtonItem13 });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 15;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 1;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItem11), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem12), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem13) });
            bar1.Text = "Tools";
            // 
            // bar2
            // 
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItem1), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem2), new DevExpress.XtraBars.LinkPersistInfo(barSubItem1) });
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "First Item";
            barButtonItem1.Id = 0;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "Second Item";
            barButtonItem2.Id = 1;
            barButtonItem2.Name = "barButtonItem2";
            // 
            // barSubItem1
            // 
            barSubItem1.Caption = "&Sub Menu";
            barSubItem1.Id = 2;
            barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItem3), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem4), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem5), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem6), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem7), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem8), new DevExpress.XtraBars.LinkPersistInfo(barCheckItem1), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem9), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem10) });
            barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "Item1";
            barButtonItem3.Id = 3;
            barButtonItem3.Name = "barButtonItem3";
            barButtonItem3.ItemClick += barButtonItem3_ItemClick;
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "Item2";
            barButtonItem4.Id = 4;
            barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            barButtonItem5.Caption = "Item3";
            barButtonItem5.Id = 5;
            barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            barButtonItem6.Caption = "Item4";
            barButtonItem6.Id = 6;
            barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            barButtonItem7.Caption = "Item5";
            barButtonItem7.Id = 7;
            barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            barButtonItem8.Caption = "Item6";
            barButtonItem8.Id = 8;
            barButtonItem8.Name = "barButtonItem8";
            // 
            // barCheckItem1
            // 
            barCheckItem1.Caption = "Actionable Item";
            barCheckItem1.Id = 9;
            barCheckItem1.Name = "barCheckItem1";
            barCheckItem1.CheckedChanged += barCheckItem1_CheckedChanged;
            // 
            // barButtonItem9
            // 
            barButtonItem9.Caption = "&Some other";
            barButtonItem9.Id = 10;
            barButtonItem9.Name = "barButtonItem9";
            barButtonItem9.ItemClick += barButtonItem9_ItemClick;
            // 
            // barButtonItem10
            // 
            barButtonItem10.Caption = "&1 Numeric one";
            barButtonItem10.Id = 11;
            barButtonItem10.Name = "barButtonItem10";
            barButtonItem10.ItemClick += barButtonItem10_ItemClick;
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new Size(1873, 92);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new Point(0, 840);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new Size(1873, 22);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new Point(0, 92);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new Size(0, 748);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new Point(1873, 92);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new Size(0, 748);
            // 
            // gridControl1
            // 
            gridControl1.Dock = DockStyle.Fill;
            gridControl1.Location = new Point(0, 92);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(1873, 748);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            // 
            // barButtonItem11
            // 
            barButtonItem11.Caption = "Second Row";
            barButtonItem11.Id = 12;
            barButtonItem11.Name = "barButtonItem11";
            // 
            // barButtonItem12
            // 
            barButtonItem12.Caption = "&Another One";
            barButtonItem12.Id = 13;
            barButtonItem12.Name = "barButtonItem12";
            // 
            // barButtonItem13
            // 
            barButtonItem13.Caption = "&And Another One";
            barButtonItem13.Id = 14;
            barButtonItem13.Name = "barButtonItem13";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1873, 862);
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private DevExpress.XtraBars.BarButtonItem barButtonItem13;
    }
}
