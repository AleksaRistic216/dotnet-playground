namespace FW.RTL.WinForms.TestForms.Misc {
    [TestForm("Misc", "SVG Image Box")]
    public partial class FormWithSvgImageBox : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithSvgImageBox() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            SetupSvgImages();
        }

        private void SetupSvgImages() {
            // Create sample SVG content for demonstration
            var svg1 = @"<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 100 100'>
                <circle cx='50' cy='50' r='40' fill='#2196F3'/>
                <text x='50' y='55' text-anchor='middle' fill='white' font-size='20'>1</text>
            </svg>";

            var svg2 = @"<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 100 100'>
                <rect x='10' y='10' width='80' height='80' fill='#4CAF50' rx='10'/>
                <text x='50' y='55' text-anchor='middle' fill='white' font-size='20'>2</text>
            </svg>";

            var svg3 = @"<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 100 100'>
                <polygon points='50,10 90,90 10,90' fill='#FF9800'/>
                <text x='50' y='70' text-anchor='middle' fill='white' font-size='20'>3</text>
            </svg>";

            var svg4 = @"<svg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 100 100'>
                <polygon points='50,5 61,40 98,40 68,62 79,97 50,75 21,97 32,62 2,40 39,40' fill='#E91E63'/>
            </svg>";

            //svgImageBox1.SvgImage = DevExpress.Utils.Svg.SvgImage.FromString(svg1);
            //svgImageBox2.SvgImage = DevExpress.Utils.Svg.SvgImage.FromString(svg2);
            //svgImageBox3.SvgImage = DevExpress.Utils.Svg.SvgImage.FromString(svg3);
            //svgImageBox4.SvgImage = DevExpress.Utils.Svg.SvgImage.FromString(svg4);
        }
    }
}
