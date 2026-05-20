namespace Random12512.Views {
    partial class GanttView {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            roundedSkinPanel1 = new DevExpress.XtraEditors.RoundedSkinPanel();
            ganttControl1 = new DevExpress.XtraGantt.GanttControl();
            colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colStartDate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colDuration = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ganttBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).BeginInit();
            roundedSkinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ganttControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ganttBindingSource).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.AccessibleName = "";
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new Padding(18, 16, 18, 16);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, barButtonItem1 });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.Margin = new Padding(2);
            ribbonControl1.MaxItemId = 2;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 198;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(862, 150);
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "Print";
            barButtonItem1.Id = 1;
            barButtonItem1.ImageOptions.ImageUri.Uri = "Print";
            barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Gantt";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonItem1);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Actions";
            // 
            // roundedSkinPanel1
            // 
            roundedSkinPanel1.Controls.Add(ganttControl1);
            roundedSkinPanel1.Dock = DockStyle.Fill;
            roundedSkinPanel1.Location = new Point(0, 150);
            roundedSkinPanel1.Name = "roundedSkinPanel1";
            roundedSkinPanel1.Size = new Size(862, 342);
            roundedSkinPanel1.TabIndex = 1;
            roundedSkinPanel1.Text = "roundedSkinPanel1";
            // 
            // ganttControl1
            // 
            ganttControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            ganttControl1.ChartMappings.DurationFieldName = "Duration";
            ganttControl1.ChartMappings.FinishDateFieldName = "";
            ganttControl1.ChartMappings.TextFieldName = "Name";
            ganttControl1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colName, colStartDate, colDuration });
            ganttControl1.DataSource = ganttBindingSource;
            ganttControl1.Dock = DockStyle.Fill;
            ganttControl1.Location = new Point(0, 0);
            ganttControl1.MenuManager = ribbonControl1;
            ganttControl1.Name = "ganttControl1";
            ganttControl1.Size = new Size(862, 342);
            ganttControl1.SplitterPosition = 294;
            ganttControl1.TabIndex = 0;
            ganttControl1.TreeListMappings.KeyFieldName = "Id";
            ganttControl1.TreeListMappings.ParentFieldName = "ParentId";
            ganttControl1.ZoomMode = DevExpress.XtraGantt.GanttZoomMode.Smooth;
            ganttControl1.NodesReloaded += ganttControl1_NodesReloaded;
            // 
            // colName
            // 
            colName.FieldName = "Name";
            colName.Name = "colName";
            colName.OptionsColumn.AllowEdit = false;
            colName.Visible = true;
            colName.VisibleIndex = 0;
            colName.Width = 156;
            // 
            // colStartDate
            // 
            colStartDate.FieldName = "StartDate";
            colStartDate.Name = "colStartDate";
            colStartDate.OptionsColumn.AllowEdit = false;
            colStartDate.Visible = true;
            colStartDate.VisibleIndex = 1;
            colStartDate.Width = 80;
            // 
            // colDuration
            // 
            colDuration.Caption = "Duration (h)";
            colDuration.FieldName = "Duration";
            colDuration.Format.FormatString = "%h";
            colDuration.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            colDuration.Name = "colDuration";
            colDuration.OptionsColumn.AllowEdit = false;
            colDuration.Visible = true;
            colDuration.VisibleIndex = 2;
            colDuration.Width = 88;
            // 
            // ganttBindingSource
            // 
            ganttBindingSource.DataSource = typeof(Model.GanttTaskItem);
            // 
            // GanttView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundedSkinPanel1);
            Controls.Add(ribbonControl1);
            Margin = new Padding(2);
            Name = "GanttView";
            Size = new Size(862, 492);
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).EndInit();
            roundedSkinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ganttControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ganttBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.RoundedSkinPanel roundedSkinPanel1;
        private BindingSource ganttBindingSource;
        private DevExpress.XtraGantt.GanttControl ganttControl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStartDate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDuration;
    }
}
