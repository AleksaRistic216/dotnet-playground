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
    public partial class NormalForm : XtraForm {
        public NormalForm() {
            InitializeComponent();
            this.Text = "asd";
            HelpButton = true;
            MinimizeBox = false;
            MaximizeBox = false;
            //RightToLeft = RightToLeft.Yes;
            //RightToLeftLayout = true;
        }
    }
}
