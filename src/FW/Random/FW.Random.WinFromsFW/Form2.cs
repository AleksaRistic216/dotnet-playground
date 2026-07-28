using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW.Random.WinFromsFW {
    public partial class Form2 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form2() {
            InitializeComponent();
            backstageViewControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        }
    }
}
