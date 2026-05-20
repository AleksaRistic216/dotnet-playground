using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Linq;

namespace Random12512 {
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
            editFormViewPage.Tag = editFormViewAccordionElement.Tag = typeof(Views.EditFormView);
            altEditFormViewPage.Tag = altEditFormViewAccordionElement.Tag = typeof(Views.AltEditFormView);
            treeListViewPage.Tag = treeListViewAccordionElement.Tag = typeof(Views.TreeListView);
            schedulerViewPage.Tag = schedulerViewAccordionElement.Tag = typeof(Views.SchedulerView);
            richEditorViewPage.Tag = richEditorViewAccordionElement.Tag = typeof(Views.RichEditorView);
            spreadsheetViewPage.Tag = spreadsheetViewAccordionElement.Tag = typeof(Views.SpreadsheetView);
            pdfViewerViewPage.Tag = pdfViewerViewAccordionElement.Tag = typeof(Views.PdfViewerView);
            pieChartViewPage.Tag = pieChartViewAccordionElement.Tag = typeof(Views.PieChartView);
            donutChartViewPage.Tag = donutChartViewAccordionElement.Tag = typeof(Views.DonutChartView);
            barChartViewPage.Tag = barChartViewAccordionElement.Tag = typeof(Views.BarChartView);
            stackedBarChartViewPage.Tag = stackedBarChartViewAccordionElement.Tag = typeof(Views.StackedBarChartView);
            areaChartViewPage.Tag = areaChartViewAccordionElement.Tag = typeof(Views.AreaChartView);
            areaStackedChartViewPage.Tag = areaStackedChartViewAccordionElement.Tag = typeof(Views.AreaStackedChartView);
            diagramControlViewPage.Tag = diagramControlViewAccordionElement.Tag = typeof(Views.DiagramControlView);
            ganttViewPage.Tag = ganttViewAccordionElement.Tag = typeof(Views.GanttView);
            dashboardViewPage.Tag = dashboardViewAccordionElement.Tag = typeof(Views.DashboardView);
            reportViewPage.Tag = reportViewAccordionElement.Tag = typeof(Views.ReportView);

            navigationAccordion.SelectElement(navigationAccordion.Elements[0].Elements[0]);
        }


        void OnSelectedAccordionElementChanged(object sender, SelectedElementChangedEventArgs e) {
            try {
                viewNavigationFrame.SelectedPage = (NavigationPage)viewNavigationFrame.Pages.First(p => p.Tag == e.Element.Tag);
            }
            catch { }
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

    }
}
