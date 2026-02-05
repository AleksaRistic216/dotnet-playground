using DevExpress.Utils;

namespace FW.RTL.WinForms.TestForms.Misc {
    [TestForm("Misc", "Tooltip Controller")]
    public partial class FormWithTooltipController : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithTooltipController() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            SetupTooltips();
        }

        private void SetupTooltips() {
            // Simple tooltip
            toolTipController1.SetToolTip(simpleButton1, "This is a simple tooltip");

            // SuperToolTip for button 2
            var superTip2 = new SuperToolTip();
            superTip2.Items.AddTitle("Super Tooltip Title");
            superTip2.Items.Add("This is a SuperToolTip with a title and description text that can span multiple lines.");
            toolTipController1.SetSuperTip(simpleButton2, superTip2);

            // SuperToolTip with separator for button 3
            var superTip3 = new SuperToolTip();
            superTip3.Items.AddTitle("Feature Information");
            superTip3.Items.Add("Primary description of this feature goes here.");
            superTip3.Items.AddSeparator();
            superTip3.Items.Add("Additional details: This tooltip demonstrates separators in SuperToolTips.");
            toolTipController1.SetSuperTip(simpleButton3, superTip3);

            // SuperToolTip with footer for button 4
            var superTip4 = new SuperToolTip();
            var titleItem = new ToolTipTitleItem { Text = "Advanced Tooltip" };
            superTip4.Items.Add(titleItem);
            superTip4.Items.Add("This tooltip includes rich formatting options.");
            superTip4.Items.AddSeparator();
            var footerItem = new ToolTipItem { Text = "Press F1 for more help", LeftIndent = 6 };
            superTip4.Items.Add(footerItem);
            toolTipController1.SetSuperTip(simpleButton4, superTip4);
        }
    }
}
