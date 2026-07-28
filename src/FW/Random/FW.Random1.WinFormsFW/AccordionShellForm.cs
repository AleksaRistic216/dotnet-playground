using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace FW.Random1.WinFormsFW {
    public partial class AccordionShellForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        AccordionShellForm() {
            InitializeComponent();
        }
        public AccordionShellForm(IServiceProvider serviceProvider) : this() {
            Services = serviceProvider;
            InitNavigationItems();
            InitAccentColors();
        }
        void OnNavigationFrameQueryControl(object sender, QueryControlEventArgs e) {
            e.Control = (Control)Services.GetService((Type)((NavigationPage)e.Page).Tag);
        }

        void InitNavigationItems() {
            dataGridViewPage.Tag = dataGridViewAccordionElement.Tag = typeof(Views.DataGridView);

            navigationAccordion.SelectElement(navigationAccordion.Elements[0].Elements[0]);
        }


        void OnSelectedAccordionElementChanged(object sender, SelectedElementChangedEventArgs e) {
            viewNavigationFrame.SelectedPage = (NavigationPage)viewNavigationFrame.Pages.First(p => p.Tag == e.Element.Tag);
        }
        public IServiceProvider Services { get; private set; }

        void InitAccentColors() {
            SkinHelper.InitTrackWindowsAppMode(bciTrackWindowsAppMode);
            bciTrackWindowsAppMode.SuperTip = new SuperToolTip();
            bciTrackWindowsAppMode.SuperTip.Items.Add("This setting is available for WXI, Basic, and Bezier skins.");
            bciTrackWindowsAppMode.SuperTip.Items[0].Appearance.FontStyleDelta = FontStyle.Bold;
            SkinHelper.InitResetToOriginalPalette(bciOriginalPalette);
            SkinHelper.InitTrackWindowsAccentColor(bciTrackWindowsAccentColor);
            SkinHelper.InitCustomAccentColor(Ribbon.Manager, bbiCustomColors);
            bbiCustomColors.SuperTip = new SuperToolTip();
            bbiCustomColors.SuperTip.Items.Add("Custom Accent Color.");
            bbiCustomColors.SuperTip.Items[0].Appearance.FontStyleDelta = FontStyle.Bold;
            SkinHelper.InitCustomAccentColor2(Ribbon.Manager, bbiCustomColors2);
            bbiCustomColors2.SuperTip = new SuperToolTip();
            bbiCustomColors2.SuperTip.Items.Add("Custom Accent Color 2.");
            bbiCustomColors2.SuperTip.Items[0].Appearance.FontStyleDelta = FontStyle.Bold;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e) {
            this.Controls.Add(new SimpleButton());
            this.PerformLayout();
        }
    }
}
