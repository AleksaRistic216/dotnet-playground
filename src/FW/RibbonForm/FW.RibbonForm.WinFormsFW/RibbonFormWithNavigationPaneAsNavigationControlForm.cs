using DevExpress.Utils;
using DevExpress.XtraBars.Navigation;
using FW.RibbonForm.WinFormsFW.Helpers;
using System.Windows.Forms;

namespace FW.RibbonForm.WinFormsFW {
    public partial class RibbonFormWithNavigationPaneAsNavigationControlForm : DevExpress.XtraBars.Ribbon.RibbonForm {
        public RibbonFormWithNavigationPaneAsNavigationControlForm() {
            InitializeComponent();
            RibbonHelpers.InitializeQuickAccessToolbarSkinSelectors(ribbonControl1);
            RibbonHelpers.InitializeCommonRibbonCommands(this, ribbonPage1);
            RibbonHelpers.InitializeCommonRibbonCommands(null, ribbonPage2);
            var navigationPane = CreateNavigationPane(NavigationPaneState.Collapsed);
            Controls.Add(navigationPane);
            NavigationControl = navigationPane;
            NavigationControlLayoutMode = DevExpress.XtraBars.Ribbon.RibbonFormNavigationControlLayoutMode.StretchToFormTitle;

        }

        NavigationPane CreateNavigationPane(NavigationPaneState state) {
            var navigationPane = new NavigationPane();
            navigationPane.Dock = DockStyle.Left;
            navigationPane.State = state;
            navigationPane.Width = ScaleUtils.ScaleValue(200);

            for(int i = 0; i < 3; i++) {
                var page = new NavigationPage() {
                    Caption = $"Page {i + 1}",
                    PageText = $"Page {i + 1}"
                };
                //page.ImageOptions.SvgImage = ImageCollectionHelper.SvgCollection[ImageCollectionHelper.checkKey];
                navigationPane.Pages.Add(page);
            }

            return navigationPane;
        }
    }
}
