using DevExpress.Images;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;

namespace IconsProject
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm {
        public Form1()
		{
			InitializeComponent();
			barButtonItem2.ImageOptions.ImageUri = DXImages.Add;
		}
	}
}
