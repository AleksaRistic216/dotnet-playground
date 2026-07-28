using DevExpress.Utils;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW.RibbonForm.WinFormsFW {
    public partial class MdiOnes : XtraForm {
        public MdiOnes() {
            Opt2();

        }

        void Opt3() {
            InitializeComponent();

            var form2 = new XtraForm() { Text = "Form with DockManager", Size = new Size(400, 300) };
            var dockManager = new DockManager() { Form = form2 };
            var dockPanel = dockManager.AddPanel(DockingStyle.Float);
            dockPanel.Text = "Docked Panel";
            dockPanel.Controls.Add(new SimpleButton() { Text = "Button in DockPanel", Dock = DockStyle.Top });

            this.Shown += (sender, e) => {
                form2.Show(this);
                //form2.Scale(new SizeF(2f, 2f));
            };
        }

        void Opt2() {

            InitializeComponent();


            var documentManager = new DocumentManager() {
                MdiParent = this,
                View = new TabbedView()
            };
            var childForm = new XtraForm() {
                MdiParent = this,
            };
            var dockManager = new DockManager() {
                //Form = this // this one works as expected
                Form = childForm // this is problematic and doesn't handle layout logic correctly
            };
            this.Shown += (sender, e) => {
                var dockPanel = dockManager.AddPanel(DockingStyle.Float);
            };
        }

        void Opt1() {
            InitializeComponent();
            //IsMdiContainer = true;

            //var childForm = new XtraForm() {
            //    MdiParent = this
            //};
            Controls.Add(new XtraUserControl() { BackColor = Color.Red, Dock = DockStyle.Fill });
            Controls.Add(new Panel() { BackColor = Color.Blue, Dock = DockStyle.Right });
            var dockManager = new DockManager() {
                Form = Controls[0] as XtraUserControl
            };
            this.Shown += (sender, e) => {
                var dockPanel = dockManager.AddPanel(DockingStyle.Float);
            };
        }
    }
}
