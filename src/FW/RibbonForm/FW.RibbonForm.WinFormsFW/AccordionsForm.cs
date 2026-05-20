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
    public partial class AccordionsForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public AccordionsForm() {
            InitializeComponent();
            Helpers.RibbonHelpers.InitializeCommonRibbonCommands(this, ribbonPage1);
            Helpers.RibbonHelpers.InitializeQuickAccessToolbarSkinSelectors(ribbonControl1);
            Helpers.RibbonHelpers.InitializePopulateAccordionButton(ribbonPageGroup1, accordionControl1, accordionControl2, accordionControl3, accordionControl4);
        }
    }
}
