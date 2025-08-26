using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.RibbonForm.WinFormsFW {
    internal class MyUserControl : XtraUserControl {
        private SimpleButton simpleButton1;

        private void InitializeComponent() {
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(28, 25);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // MyUserControl
            // 
            this.Controls.Add(this.simpleButton1);
            this.Name = "MyUserControl";
            this.ResumeLayout(false);

        }
    }
}
