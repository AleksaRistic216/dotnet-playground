namespace DocumentManger.WinForms {
    partial class Form2 {
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
            roundedSkinPanel1 = new DevExpress.XtraEditors.RoundedSkinPanel();
            xtraUserControl1 = new DevExpress.XtraEditors.XtraUserControl();
            dockManager1 = new DevExpress.XtraBars.Docking.DockManager(components);
            dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).BeginInit();
            roundedSkinPanel1.SuspendLayout();
            xtraUserControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dockManager1).BeginInit();
            dockPanel1.SuspendLayout();
            dockPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // roundedSkinPanel1
            // 
            roundedSkinPanel1.Controls.Add(xtraUserControl1);
            roundedSkinPanel1.Dock = DockStyle.Fill;
            roundedSkinPanel1.Location = new Point(0, 0);
            roundedSkinPanel1.Name = "roundedSkinPanel1";
            roundedSkinPanel1.Size = new Size(800, 450);
            roundedSkinPanel1.TabIndex = 0;
            roundedSkinPanel1.Text = "roundedSkinPanel1";
            // 
            // xtraUserControl1
            // 
            xtraUserControl1.Controls.Add(dockPanel2);
            xtraUserControl1.Controls.Add(dockPanel1);
            xtraUserControl1.Dock = DockStyle.Fill;
            xtraUserControl1.Location = new Point(0, 0);
            xtraUserControl1.Name = "xtraUserControl1";
            xtraUserControl1.Size = new Size(800, 450);
            xtraUserControl1.TabIndex = 0;
            // 
            // dockManager1
            // 
            dockManager1.Form = xtraUserControl1;
            dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] { dockPanel1, dockPanel2 });
            dockManager1.TopZIndexControls.AddRange(new string[] { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl" });
            // 
            // dockPanel1
            // 
            dockPanel1.Controls.Add(dockPanel1_Container);
            dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            dockPanel1.ID = new Guid("55bc9f70-b84d-4b0f-8c0a-f3886e65ff67");
            dockPanel1.Location = new Point(0, 0);
            dockPanel1.Name = "dockPanel1";
            dockPanel1.OriginalSize = new Size(200, 200);
            dockPanel1.Size = new Size(200, 450);
            dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            dockPanel1_Container.Location = new Point(3, 26);
            dockPanel1_Container.Name = "dockPanel1_Container";
            dockPanel1_Container.Size = new Size(193, 421);
            dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel2
            // 
            dockPanel2.Controls.Add(dockPanel2_Container);
            dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            dockPanel2.ID = new Guid("27d9a87d-8aec-4b3d-830a-35d0372e7d08");
            dockPanel2.Location = new Point(200, 0);
            dockPanel2.Name = "dockPanel2";
            dockPanel2.OriginalSize = new Size(200, 200);
            dockPanel2.Size = new Size(600, 200);
            dockPanel2.Text = "dockPanel2";
            // 
            // dockPanel2_Container
            // 
            dockPanel2_Container.Location = new Point(3, 26);
            dockPanel2_Container.Name = "dockPanel2_Container";
            dockPanel2_Container.Size = new Size(594, 170);
            dockPanel2_Container.TabIndex = 0;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(roundedSkinPanel1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)roundedSkinPanel1).EndInit();
            roundedSkinPanel1.ResumeLayout(false);
            xtraUserControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dockManager1).EndInit();
            dockPanel1.ResumeLayout(false);
            dockPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.RoundedSkinPanel roundedSkinPanel1;
        private DevExpress.XtraEditors.XtraUserControl xtraUserControl1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
    }
}