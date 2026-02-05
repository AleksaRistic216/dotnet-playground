namespace FW.RTL.WinForms.TestForms.Grids {
    [TestForm("Grids", "WinExplorer View")]
    public partial class FormWithWinExplorerView : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithWinExplorerView() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            var data = SampleDataGenerator.GenerateFiles(50);
            gridControl1.DataSource = data;
            winExplorerView1.ColumnSet.TextColumn = winExplorerView1.Columns["FileName"];
            winExplorerView1.ColumnSet.GroupColumn = winExplorerView1.Columns["Folder"];
            winExplorerView1.ColumnSet.DescriptionColumn = winExplorerView1.Columns["FilePath"];
        }
    }
}
