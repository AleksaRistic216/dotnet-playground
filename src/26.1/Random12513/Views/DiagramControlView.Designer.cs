namespace Random12513.Views {
    partial class DiagramControlView {
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
            DevExpress.Diagram.Core.DiagramBinding diagramBinding2 = new DevExpress.Diagram.Core.DiagramBinding();
            DevExpress.Diagram.Core.DiagramBinding diagramBinding3 = new DevExpress.Diagram.Core.DiagramBinding();
            DevExpress.Diagram.Core.DiagramBinding diagramBinding4 = new DevExpress.Diagram.Core.DiagramBinding();
            DevExpress.Diagram.Core.DiagramBinding diagramBinding5 = new DevExpress.Diagram.Core.DiagramBinding();
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            roundedSkinPanel1 = new DevExpress.XtraEditors.RoundedSkinPanel();
            diagramControl1 = new DevExpress.XtraDiagram.DiagramControl();
            diagramOrgChartController1 = new DevExpress.XtraDiagram.DiagramOrgChartController(components);
            diagramBindingSource = new BindingSource(components);
            diagramContainer1 = new DevExpress.XtraDiagram.DiagramContainer();
            diagramImage1 = new DevExpress.XtraDiagram.DiagramImage();
            diagramShape1 = new DevExpress.XtraDiagram.DiagramShape();
            diagramShape2 = new DevExpress.XtraDiagram.DiagramShape();
            diagramShape3 = new DevExpress.XtraDiagram.DiagramShape();
            diagramShape4 = new DevExpress.XtraDiagram.DiagramShape();
            diagramConnector1 = new DevExpress.XtraDiagram.DiagramConnector();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).BeginInit();
            roundedSkinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)diagramControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)diagramOrgChartController1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)diagramOrgChartController1.TemplateDiagram).BeginInit();
            ((System.ComponentModel.ISupportInitialize)diagramBindingSource).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.AccessibleName = "";
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new Padding(21, 18, 21, 18);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, barButtonItem1 });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.Margin = new Padding(2);
            ribbonControl1.MaxItemId = 2;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 231;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(757, 150);
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "Export to SVG";
            barButtonItem1.Id = 1;
            barButtonItem1.ImageOptions.ImageUri.Uri = "diagramicons/exporttosvg";
            barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Diagram Control";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonItem1);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Actions";
            // 
            // roundedSkinPanel1
            // 
            roundedSkinPanel1.Controls.Add(diagramControl1);
            roundedSkinPanel1.Dock = DockStyle.Fill;
            roundedSkinPanel1.Location = new Point(0, 150);
            roundedSkinPanel1.Name = "roundedSkinPanel1";
            roundedSkinPanel1.Size = new Size(757, 238);
            roundedSkinPanel1.TabIndex = 1;
            roundedSkinPanel1.Text = "roundedSkinPanel1";
            // 
            // diagramControl1
            // 
            diagramControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            diagramControl1.Dock = DockStyle.Fill;
            diagramControl1.Location = new Point(0, 0);
            diagramControl1.Name = "diagramControl1";
            diagramControl1.OptionsOrgChartLayout.IsCompact = false;
            diagramControl1.OptionsOrgChartLayout.TreeLevelCount = 4;
            diagramControl1.OptionsView.CanvasSizeMode = DevExpress.Diagram.Core.CanvasSizeMode.Fill;
            diagramControl1.OptionsView.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            diagramControl1.OptionsView.ShowGrid = false;
            diagramControl1.OptionsView.ShowPageBreaks = false;
            diagramControl1.OptionsView.ShowRulers = false;
            diagramControl1.Size = new Size(757, 238);
            diagramControl1.TabIndex = 0;
            diagramControl1.Text = "diagramControl1";
            // 
            // diagramOrgChartController1
            // 
            diagramOrgChartController1.DataSource = diagramBindingSource;
            diagramOrgChartController1.Diagram = diagramControl1;
            diagramOrgChartController1.KeyMember = "Id";
            diagramOrgChartController1.LayoutKind = DevExpress.Diagram.Core.DiagramLayoutKind.OrgChart;
            diagramOrgChartController1.ParentMember = "ParentId";
            // 
            // 
            // 
            diagramOrgChartController1.TemplateDiagram.Items.AddRange(new DevExpress.XtraDiagram.DiagramItem[] { diagramContainer1, diagramConnector1 });
            diagramOrgChartController1.TemplateDiagram.Location = new Point(0, 0);
            diagramOrgChartController1.TemplateDiagram.Name = "";
            diagramOrgChartController1.TemplateDiagram.OptionsView.CanvasSizeMode = DevExpress.Diagram.Core.CanvasSizeMode.Fill;
            diagramOrgChartController1.TemplateDiagram.OptionsView.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            diagramOrgChartController1.TemplateDiagram.OptionsView.ShowPageBreaks = false;
            diagramOrgChartController1.TemplateDiagram.TabIndex = 0;
            diagramOrgChartController1.ItemsGenerated += diagramOrgChartController1_ItemsGenerated;
            // 
            // diagramBindingSource
            // 
            diagramBindingSource.DataSource = typeof(Model.CompanyUser);
            // 
            // diagramContainer1
            // 
            diagramContainer1.Anchors = DevExpress.Diagram.Core.Sides.Left | DevExpress.Diagram.Core.Sides.Top;
            diagramContainer1.Appearance.BackColor = Color.FromArgb(0, 120, 215);
            diagramContainer1.CanAddItems = false;
            diagramContainer1.CanCopyWithoutParent = true;
            diagramContainer1.DragMode = DevExpress.Diagram.Core.ContainerDragMode.ByAnyPoint;
            diagramContainer1.Items.AddRange(new DevExpress.XtraDiagram.DiagramItem[] { diagramImage1, diagramShape1, diagramShape2, diagramShape3, diagramShape4 });
            diagramContainer1.ItemsCanAttachConnectorBeginPoint = false;
            diagramContainer1.ItemsCanAttachConnectorEndPoint = false;
            diagramContainer1.ItemsCanChangeParent = false;
            diagramContainer1.ItemsCanCopyWithoutParent = false;
            diagramContainer1.ItemsCanDeleteWithoutParent = false;
            diagramContainer1.ItemsCanEdit = false;
            diagramContainer1.ItemsCanMove = false;
            diagramContainer1.ItemsCanResize = false;
            diagramContainer1.ItemsCanRotate = false;
            diagramContainer1.ItemsCanSelect = false;
            diagramContainer1.ItemsCanSnapToOtherItems = false;
            diagramContainer1.ItemsCanSnapToThisItem = false;
            diagramContainer1.MoveWithSubordinates = true;
            diagramContainer1.Position = new DevExpress.Utils.PointFloat(241.8353F, 140F);
            diagramContainer1.Shape = DevExpress.Diagram.Core.StandardContainers.Alternating;
            diagramContainer1.Size = new SizeF(368.1647F, 170F);
            diagramContainer1.TemplateName = "EmployeeCard";
            diagramContainer1.ThemeStyleId = DevExpress.Diagram.Core.DiagramShapeStyleId.Variant1;
            // 
            // diagramImage1
            // 
            diagramImage1.Anchors = DevExpress.Diagram.Core.Sides.Left | DevExpress.Diagram.Core.Sides.Top;
            diagramImage1.Appearance.BackColor = Color.FromArgb(0, 255, 255, 255);
            diagramImage1.Appearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            diagramImage1.CanCopy = false;
            diagramImage1.CanCopyWithoutParent = false;
            diagramImage1.CanMove = false;
            diagramImage1.CanResize = false;
            diagramImage1.CanRotate = false;
            diagramImage1.CanSelect = false;
            diagramImage1.CanSnapToOtherItems = false;
            diagramImage1.CanSnapToThisItem = false;
            diagramImage1.ForegroundId = DevExpress.Diagram.Core.DiagramThemeColorId.Accent1;
            diagramImage1.Position = new DevExpress.Utils.PointFloat(14.1647034F, 8F);
            diagramImage1.Size = new SizeF(119.333328F, 119.333328F);
            diagramImage1.StretchMode = DevExpress.Diagram.Core.StretchMode.UniformToFill;
            diagramImage1.ThemeStyleId = DevExpress.Diagram.Core.DiagramShapeStyleId.Variant1;
            // 
            // diagramShape1
            // 
            diagramShape1.Anchors = DevExpress.Diagram.Core.Sides.Left | DevExpress.Diagram.Core.Sides.Top;
            diagramShape1.Appearance.BackColor = Color.FromArgb(0, 91, 155, 213);
            diagramShape1.Appearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            diagramShape1.Appearance.BorderSize = 0;
            diagramShape1.Appearance.Font = new Font("Segoe UI", 18F);
            diagramShape1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            diagramShape1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            diagramBinding2.Expression = "FullName";
            diagramBinding2.PropertyName = "Content";
            diagramShape1.Bindings.Add(diagramBinding2);
            diagramShape1.CanCopy = false;
            diagramShape1.CanCopyWithoutParent = false;
            diagramShape1.CanEdit = false;
            diagramShape1.CanMove = false;
            diagramShape1.CanResize = false;
            diagramShape1.CanRotate = false;
            diagramShape1.CanSelect = false;
            diagramShape1.CanSnapToOtherItems = false;
            diagramShape1.CanSnapToThisItem = false;
            diagramShape1.ForegroundId = DevExpress.Diagram.Core.DiagramThemeColorId.White;
            diagramShape1.Position = new DevExpress.Utils.PointFloat(132.164719F, 19.8353062F);
            diagramShape1.Size = new SizeF(210F, 35F);
            diagramShape1.ThemeStyleId = DevExpress.Diagram.Core.DiagramShapeStyleId.Subtle1;
            // 
            // diagramShape2
            // 
            diagramShape2.Anchors = DevExpress.Diagram.Core.Sides.Left | DevExpress.Diagram.Core.Sides.Top;
            diagramShape2.Appearance.BackColor = Color.FromArgb(0, 91, 155, 213);
            diagramShape2.Appearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            diagramShape2.Appearance.BorderSize = 0;
            diagramShape2.Appearance.Font = new Font("Segoe UI", 14F);
            diagramShape2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            diagramShape2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            diagramBinding3.Expression = "JobTitle";
            diagramBinding3.PropertyName = "Content";
            diagramShape2.Bindings.Add(diagramBinding3);
            diagramShape2.CanCopy = false;
            diagramShape2.CanCopyWithoutParent = false;
            diagramShape2.CanEdit = false;
            diagramShape2.CanMove = false;
            diagramShape2.CanResize = false;
            diagramShape2.CanRotate = false;
            diagramShape2.CanSelect = false;
            diagramShape2.CanSnapToOtherItems = false;
            diagramShape2.CanSnapToThisItem = false;
            diagramShape2.ForegroundId = DevExpress.Diagram.Core.DiagramThemeColorId.White;
            diagramShape2.Position = new DevExpress.Utils.PointFloat(132.164719F, 61.83529F);
            diagramShape2.Size = new SizeF(210F, 24F);
            diagramShape2.ThemeStyleId = DevExpress.Diagram.Core.DiagramShapeStyleId.Subtle1;
            // 
            // diagramShape3
            // 
            diagramShape3.Anchors = DevExpress.Diagram.Core.Sides.Left | DevExpress.Diagram.Core.Sides.Top;
            diagramShape3.Appearance.BackColor = Color.FromArgb(0, 91, 155, 213);
            diagramShape3.Appearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            diagramShape3.Appearance.BorderSize = 0;
            diagramShape3.Appearance.Font = new Font("Segoe UI", 14F);
            diagramShape3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            diagramShape3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            diagramBinding4.Expression = "Email";
            diagramBinding4.PropertyName = "Content";
            diagramShape3.Bindings.Add(diagramBinding4);
            diagramShape3.CanCopy = false;
            diagramShape3.CanCopyWithoutParent = false;
            diagramShape3.CanEdit = false;
            diagramShape3.CanMove = false;
            diagramShape3.CanResize = false;
            diagramShape3.CanRotate = false;
            diagramShape3.CanSelect = false;
            diagramShape3.CanSnapToOtherItems = false;
            diagramShape3.CanSnapToThisItem = false;
            diagramShape3.ForegroundId = DevExpress.Diagram.Core.DiagramThemeColorId.White;
            diagramShape3.Position = new DevExpress.Utils.PointFloat(24.1647034F, 127.835327F);
            diagramShape3.Size = new SizeF(320F, 24F);
            diagramShape3.ThemeStyleId = DevExpress.Diagram.Core.DiagramShapeStyleId.Subtle1;
            // 
            // diagramShape4
            // 
            diagramShape4.Anchors = DevExpress.Diagram.Core.Sides.Left | DevExpress.Diagram.Core.Sides.Top;
            diagramShape4.Appearance.BackColor = Color.FromArgb(0, 91, 155, 213);
            diagramShape4.Appearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            diagramShape4.Appearance.BorderSize = 0;
            diagramShape4.Appearance.Font = new Font("Segoe UI", 14F);
            diagramShape4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            diagramShape4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            diagramBinding5.Expression = "Phone";
            diagramBinding5.PropertyName = "Content";
            diagramShape4.Bindings.Add(diagramBinding5);
            diagramShape4.CanCopy = false;
            diagramShape4.CanCopyWithoutParent = false;
            diagramShape4.CanEdit = false;
            diagramShape4.CanMove = false;
            diagramShape4.CanResize = false;
            diagramShape4.CanRotate = false;
            diagramShape4.CanSelect = false;
            diagramShape4.CanSnapToOtherItems = false;
            diagramShape4.CanSnapToThisItem = false;
            diagramShape4.ForegroundId = DevExpress.Diagram.Core.DiagramThemeColorId.White;
            diagramShape4.Position = new DevExpress.Utils.PointFloat(132.164719F, 91.83533F);
            diagramShape4.Size = new SizeF(210F, 24F);
            diagramShape4.ThemeStyleId = DevExpress.Diagram.Core.DiagramShapeStyleId.Subtle1;
            // 
            // diagramConnector1
            // 
            diagramConnector1.Appearance.BorderSize = 2;
            diagramConnector1.Appearance.ContentBackground = Color.White;
            diagramConnector1.BeginPoint = new DevExpress.Utils.PointFloat(-10F, 130F);
            diagramConnector1.CanChangeRoute = false;
            diagramConnector1.CanDragBeginPoint = false;
            diagramConnector1.CanDragEndPoint = false;
            diagramConnector1.EndPoint = new DevExpress.Utils.PointFloat(80F, 220F);
            // 
            // DiagramControlView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundedSkinPanel1);
            Controls.Add(ribbonControl1);
            Margin = new Padding(2);
            Name = "DiagramControlView";
            Size = new Size(757, 388);
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).EndInit();
            roundedSkinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)diagramControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)diagramOrgChartController1.TemplateDiagram).EndInit();
            ((System.ComponentModel.ISupportInitialize)diagramOrgChartController1).EndInit();
            ((System.ComponentModel.ISupportInitialize)diagramBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.RoundedSkinPanel roundedSkinPanel1;
        private DevExpress.XtraDiagram.DiagramControl diagramControl1;
        private DevExpress.XtraDiagram.DiagramOrgChartController diagramOrgChartController1;
        private BindingSource diagramBindingSource;
        private DevExpress.XtraDiagram.DiagramContainer diagramContainer1;
        private DevExpress.XtraDiagram.DiagramImage diagramImage1;
        private DevExpress.XtraDiagram.DiagramShape diagramShape1;
        private DevExpress.XtraDiagram.DiagramShape diagramShape2;
        private DevExpress.XtraDiagram.DiagramShape diagramShape3;
        private DevExpress.XtraDiagram.DiagramShape diagramShape4;
        private DevExpress.XtraDiagram.DiagramConnector diagramConnector1;
    }
}
