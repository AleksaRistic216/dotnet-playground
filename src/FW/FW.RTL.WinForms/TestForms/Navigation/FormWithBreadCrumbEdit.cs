namespace FW.RTL.WinForms.TestForms.Navigation {
    [TestForm("Navigation", "BreadCrumb Edit")]
    public partial class FormWithBreadCrumbEdit : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithBreadCrumbEdit() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var breadcrumbs = SampleDataGenerator.GenerateBreadcrumbs();

            var root = new DevExpress.XtraEditors.BreadCrumbNode { Caption = breadcrumbs[0].Text, Value = breadcrumbs[0].Path };
            breadCrumbEdit1.Properties.Nodes.Add(root);

            var current = root;
            for (int i = 1; i < breadcrumbs.Count; i++) {
                var node = new DevExpress.XtraEditors.BreadCrumbNode { Caption = breadcrumbs[i].Text, Value = breadcrumbs[i].Path };
                current.ChildNodes.Add(node);
                current = node;
            }

            breadCrumbEdit1.Path = breadcrumbs[breadcrumbs.Count - 1].Path;
        }
    }
}
