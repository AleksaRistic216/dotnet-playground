namespace NCSTTB.WinForms {
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
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accordionControl1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new Padding(28, 23, 28, 23);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem });
            ribbonControl1.Location = new Point(0, 0);
            ribbonControl1.Margin = new Padding(3, 2, 3, 2);
            ribbonControl1.MaxItemId = 1;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 305;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbonControl1.Size = new Size(2154, 308);
            ribbonControl1.StatusBar = ribbonStatusBar1;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar1
            // 
            ribbonStatusBar1.Location = new Point(0, 802);
            ribbonStatusBar1.Name = "ribbonStatusBar1";
            ribbonStatusBar1.Ribbon = ribbonControl1;
            ribbonStatusBar1.Size = new Size(1634, 54);
            // 
            // accordionControl1
            // 
            accordionControl1.Dock = DockStyle.Right;
            accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlElement1 });
            accordionControl1.Location = new Point(1634, 64);
            accordionControl1.MinimumSize = new Size(0, 1102);
            accordionControl1.Name = "accordionControl1";
            accordionControl1.Size = new Size(520, 1102);
            accordionControl1.TabIndex = 1;
            accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            accordionControlElement1.Name = "accordionControlElement1";
            accordionControlElement1.Text = "Element1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 128, 255);
            panel1.Controls.Add(ribbonStatusBar1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 308);
            panel1.Name = "panel1";
            panel1.Size = new Size(1634, 856);
            panel1.TabIndex = 3;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2154, 1164);
            Controls.Add(panel1);
            Controls.Add(accordionControl1);
            Controls.Add(ribbonControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form2";
            NavigationControl = accordionControl1;
            NavigationControlLayoutMode = DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToFormTitle;
            Ribbon = ribbonControl1;
            StatusBar = ribbonStatusBar1;
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)accordionControl1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private Panel panel1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
    }
}