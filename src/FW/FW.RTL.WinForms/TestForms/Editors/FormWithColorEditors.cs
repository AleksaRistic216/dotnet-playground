using System.Drawing;

namespace FW.RTL.WinForms.TestForms.Editors {
    [TestForm("Editors", "Color Editors")]
    public partial class FormWithColorEditors : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithColorEditors() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var colors = SampleDataGenerator.GenerateColors(10);
            colorEdit1.Color = colors[0];
            colorPickEdit1.Color = colors[1];
        }
    }
}
