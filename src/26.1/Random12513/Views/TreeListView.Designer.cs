namespace Random12513.Views {
    partial class TreeListView {
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
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            roundedSkinPanel1 = new DevExpress.XtraEditors.RoundedSkinPanel();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            colFirstName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colLastName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colJobTitle = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colGroupName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colEmail = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colPhone = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            treeListBindingSource = new BindingSource(components);
            svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).BeginInit();
            roundedSkinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)treeListBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).BeginInit();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.AccessibleName = "";
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new Padding(18, 16, 18, 16);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, barButtonItem1, barButtonItem2 });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.Margin = new Padding(2);
            ribbonControl1.MaxItemId = 3;
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
            // barButtonItem2
            // 
            barButtonItem2.Caption = "Delete";
            barButtonItem2.Id = 2;
            barButtonItem2.ImageOptions.ImageUri.Uri = "Delete";
            barButtonItem2.Name = "barButtonItem2";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Tree List";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(barButtonItem1);
            ribbonPageGroup1.ItemLinks.Add(barButtonItem2);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "Actions";
            // 
            // roundedSkinPanel1
            // 
            roundedSkinPanel1.Controls.Add(treeList1);
            roundedSkinPanel1.Dock = DockStyle.Fill;
            roundedSkinPanel1.Location = new Point(0, 150);
            roundedSkinPanel1.Name = "roundedSkinPanel1";
            roundedSkinPanel1.Size = new Size(862, 342);
            roundedSkinPanel1.TabIndex = 1;
            roundedSkinPanel1.Text = "roundedSkinPanel1";
            // 
            // treeList1
            // 
            treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colFirstName, colLastName, colJobTitle, colGroupName, colEmail, colPhone });
            treeList1.DataSource = treeListBindingSource;
            treeList1.Dock = DockStyle.Fill;
            treeList1.KeyFieldName = "Id";
            treeList1.Location = new Point(0, 0);
            treeList1.MenuManager = ribbonControl1;
            treeList1.Name = "treeList1";
            treeList1.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
            treeList1.OptionsView.NewItemRowPosition = DevExpress.XtraTreeList.TreeListNewItemRowPosition.Top;
            treeList1.OptionsView.ShowSummaryFooter = true;
            treeList1.ParentFieldName = "ParentId";
            treeList1.Size = new Size(862, 342);
            treeList1.TabIndex = 0;
            treeList1.GetStateImage += treeList1_GetStateImage_1;
            treeList1.NodesReloaded += treeList1_NodesReloaded;
            // 
            // colFirstName
            // 
            colFirstName.AllNodesSummary = true;
            colFirstName.FieldName = "FirstName";
            colFirstName.Name = "colFirstName";
            colFirstName.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count;
            colFirstName.SummaryFooterStrFormat = "Count {0}";
            colFirstName.Visible = true;
            colFirstName.VisibleIndex = 0;
            // 
            // colLastName
            // 
            colLastName.FieldName = "LastName";
            colLastName.Name = "colLastName";
            colLastName.Visible = true;
            colLastName.VisibleIndex = 1;
            // 
            // colJobTitle
            // 
            colJobTitle.FieldName = "JobTitle";
            colJobTitle.Name = "colJobTitle";
            colJobTitle.Visible = true;
            colJobTitle.VisibleIndex = 2;
            // 
            // colGroupName
            // 
            colGroupName.FieldName = "GroupName";
            colGroupName.Name = "colGroupName";
            colGroupName.Visible = true;
            colGroupName.VisibleIndex = 3;
            // 
            // colEmail
            // 
            colEmail.FieldName = "Email";
            colEmail.Name = "colEmail";
            colEmail.Visible = true;
            colEmail.VisibleIndex = 4;
            // 
            // colPhone
            // 
            colPhone.FieldName = "Phone";
            colPhone.Name = "colPhone";
            colPhone.Visible = true;
            colPhone.VisibleIndex = 5;
            // 
            // treeListBindingSource
            // 
            treeListBindingSource.DataSource = typeof(Model.CompanyUser);
            // 
            // svgImageCollection1
            // 
            svgImageCollection1.Add("bo_employee", "image://svgimages/business objects/bo_employee.svg");
            // 
            // TreeListView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(roundedSkinPanel1);
            Controls.Add(ribbonControl1);
            Margin = new Padding(2);
            Name = "TreeListView";
            Size = new Size(862, 492);
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).EndInit();
            roundedSkinPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ((System.ComponentModel.ISupportInitialize)treeListBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImageCollection1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.RoundedSkinPanel roundedSkinPanel1;
        private BindingSource treeListBindingSource;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFirstName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLastName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colJobTitle;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGroupName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEmail;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPhone;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}
