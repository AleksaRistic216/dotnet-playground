using System.Windows.Forms;

namespace FW.RTL.WinForms.TestForms.Trees {
    [TestForm("Trees", "Tree View")]
    public partial class FormWithTreeView : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithTreeView() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            PopulateSampleData();
        }

        private void PopulateSampleData() {
            treeView1.BeginUpdate();

            // Root nodes
            var computerNode = treeView1.Nodes.Add("My Computer");

            // Drives
            var cDrive = computerNode.Nodes.Add("Local Disk (C:)");
            var dDrive = computerNode.Nodes.Add("Local Disk (D:)");

            // C: Drive contents
            var programFiles = cDrive.Nodes.Add("Program Files");
            programFiles.Nodes.Add("Common Files");
            programFiles.Nodes.Add("Internet Explorer");
            programFiles.Nodes.Add("Microsoft Office");
            programFiles.Nodes.Add("Windows Defender");

            var programFilesX86 = cDrive.Nodes.Add("Program Files (x86)");
            programFilesX86.Nodes.Add("Adobe");
            programFilesX86.Nodes.Add("Google");
            programFilesX86.Nodes.Add("Microsoft");

            var users = cDrive.Nodes.Add("Users");
            var currentUser = users.Nodes.Add("Current User");
            currentUser.Nodes.Add("Desktop");
            currentUser.Nodes.Add("Documents");
            currentUser.Nodes.Add("Downloads");
            currentUser.Nodes.Add("Music");
            currentUser.Nodes.Add("Pictures");
            currentUser.Nodes.Add("Videos");
            users.Nodes.Add("Public");

            var windows = cDrive.Nodes.Add("Windows");
            windows.Nodes.Add("System32");
            windows.Nodes.Add("Fonts");
            windows.Nodes.Add("Temp");

            // D: Drive contents
            var backup = dDrive.Nodes.Add("Backup");
            backup.Nodes.Add("2024-01");
            backup.Nodes.Add("2024-02");
            backup.Nodes.Add("2024-03");

            var games = dDrive.Nodes.Add("Games");
            games.Nodes.Add("Steam");
            games.Nodes.Add("Epic Games");
            games.Nodes.Add("GOG");

            var projects = dDrive.Nodes.Add("Projects");
            var webProjects = projects.Nodes.Add("Web");
            webProjects.Nodes.Add("Portfolio");
            webProjects.Nodes.Add("Blog");
            var mobileProjects = projects.Nodes.Add("Mobile");
            mobileProjects.Nodes.Add("TodoApp");
            mobileProjects.Nodes.Add("WeatherApp");

            // Network
            var networkNode = treeView1.Nodes.Add("Network");
            networkNode.Nodes.Add("Server-01");
            networkNode.Nodes.Add("Server-02");
            networkNode.Nodes.Add("NAS-Storage");

            treeView1.EndUpdate();

            // Expand root and first level
            computerNode.Expand();
            cDrive.Expand();
            dDrive.Expand();
        }
    }
}
