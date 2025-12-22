using FW.RibbonForm.WinFormsFW.Helpers;
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
    public partial class NestedRibbonWithinRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public NestedRibbonWithinRibbonForm() {
            InitializeComponent();
            RibbonHelpers.InitializeQuickAccessToolbarSkinSelectors(ribbonControl1);
            RibbonHelpers.InitializeCommonRibbonCommands(this, ribbonPage1);
            RibbonHelpers.InitializeCommonRibbonCommands(null, ribbonPage2);
        }
    }
}
