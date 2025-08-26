namespace Ribbon.WindowsForms
{
	public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public Form1()
		{
			InitializeComponent();
		}

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
			this.RightToLeft = this.RightToLeft != System.Windows.Forms.RightToLeft.Yes 
				? System.Windows.Forms.RightToLeft.Yes 
				: System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = !this.RightToLeftLayout;
        }
    }
}
