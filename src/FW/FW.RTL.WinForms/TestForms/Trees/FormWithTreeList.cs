using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;

namespace FW.RTL.WinForms.TestForms.Trees {
    [TestForm("Trees", "Tree List")]
    public partial class FormWithTreeList : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithTreeList() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            SetupColumns();
            PopulateSampleData();
        }

        private void SetupColumns() {
            treeList1.Columns.Add(new TreeListColumn { FieldName = "Name", Caption = "Name", Visible = true, Width = 200 });
            treeList1.Columns.Add(new TreeListColumn { FieldName = "Size", Caption = "Size", Visible = true, Width = 100 });
            treeList1.Columns.Add(new TreeListColumn { FieldName = "Type", Caption = "Type", Visible = true, Width = 100 });
            treeList1.Columns.Add(new TreeListColumn { FieldName = "Modified", Caption = "Modified", Visible = true, Width = 150 });
        }

        private void PopulateSampleData() {
            treeList1.BeginUnboundLoad();

            // Root folders
            var documents = treeList1.AppendNode(new object[] { "Documents", "", "Folder", System.DateTime.Now.AddDays(-5) }, null);
            var downloads = treeList1.AppendNode(new object[] { "Downloads", "", "Folder", System.DateTime.Now.AddDays(-2) }, null);
            var pictures = treeList1.AppendNode(new object[] { "Pictures", "", "Folder", System.DateTime.Now.AddDays(-10) }, null);

            // Documents subfolders and files
            var work = treeList1.AppendNode(new object[] { "Work", "", "Folder", System.DateTime.Now.AddDays(-3) }, documents);
            treeList1.AppendNode(new object[] { "Report.docx", "245 KB", "Word Document", System.DateTime.Now.AddDays(-1) }, work);
            treeList1.AppendNode(new object[] { "Budget.xlsx", "128 KB", "Excel Spreadsheet", System.DateTime.Now.AddDays(-2) }, work);
            treeList1.AppendNode(new object[] { "Presentation.pptx", "1.2 MB", "PowerPoint", System.DateTime.Now.AddDays(-3) }, work);

            var personal = treeList1.AppendNode(new object[] { "Personal", "", "Folder", System.DateTime.Now.AddDays(-7) }, documents);
            treeList1.AppendNode(new object[] { "Resume.pdf", "89 KB", "PDF Document", System.DateTime.Now.AddDays(-30) }, personal);
            treeList1.AppendNode(new object[] { "Notes.txt", "12 KB", "Text File", System.DateTime.Now.AddDays(-5) }, personal);

            // Downloads files
            treeList1.AppendNode(new object[] { "Setup.exe", "45.3 MB", "Application", System.DateTime.Now.AddDays(-1) }, downloads);
            treeList1.AppendNode(new object[] { "Archive.zip", "23.1 MB", "ZIP Archive", System.DateTime.Now.AddHours(-5) }, downloads);
            treeList1.AppendNode(new object[] { "Music.mp3", "8.4 MB", "Audio File", System.DateTime.Now.AddHours(-2) }, downloads);

            // Pictures subfolders and files
            var vacation = treeList1.AppendNode(new object[] { "Vacation 2024", "", "Folder", System.DateTime.Now.AddMonths(-2) }, pictures);
            treeList1.AppendNode(new object[] { "Beach.jpg", "2.3 MB", "JPEG Image", System.DateTime.Now.AddMonths(-2) }, vacation);
            treeList1.AppendNode(new object[] { "Mountain.jpg", "3.1 MB", "JPEG Image", System.DateTime.Now.AddMonths(-2) }, vacation);
            treeList1.AppendNode(new object[] { "Sunset.png", "4.5 MB", "PNG Image", System.DateTime.Now.AddMonths(-2) }, vacation);

            var family = treeList1.AppendNode(new object[] { "Family", "", "Folder", System.DateTime.Now.AddMonths(-6) }, pictures);
            treeList1.AppendNode(new object[] { "Birthday.jpg", "1.8 MB", "JPEG Image", System.DateTime.Now.AddMonths(-3) }, family);
            treeList1.AppendNode(new object[] { "Holiday.jpg", "2.1 MB", "JPEG Image", System.DateTime.Now.AddMonths(-6) }, family);

            treeList1.EndUnboundLoad();

            treeList1.ExpandAll();
        }
    }
}
