using DevExpress.Data.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Grantt {
    public partial class Form1 : Form {
        LicenseTestHelper lth;
        public Form1() {
            InitializeComponent();
            InitializeGantt();
        }
        void InitializeGantt() {
            lth = new LicenseTestHelper();
            lth.SetAsTrial();
            ganttControl1.TreeListMappings.KeyFieldName = "Id";
            ganttControl1.TreeListMappings.ParentFieldName = "ParentId";
            ganttControl1.ChartMappings.TextFieldName = "Name";
            ganttControl1.ChartMappings.StartDateFieldName = "StartDate";
            ganttControl1.ChartMappings.FinishDateFieldName = "FinishDate";
            ganttControl1.ChartMappings.DurationFieldName = "Duration";
            ganttControl1.ChartMappings.PredecessorsFieldName = "Predecessors";
            ganttControl1.ChartMappings.ProgressFieldName = "Progress";
            ganttControl1.DataSource = LoadData();
        }
        public static IList<Task> LoadData() {
            var tasks = new List<Task>();
            Task softwareDevelopment = new Task("Software Development", 0, -1, DateTime.Now, 1, 24);
            Task analyseRequirements = new Task("Analyse Requirements", 1, softwareDevelopment.Id, softwareDevelopment.StartDate, 1, 100);
            Task developFunctionalSpecifications = new Task("Develop functional specifications", 2, softwareDevelopment.Id, analyseRequirements.FinishDate, 1, 100);
            Task developSoftware = new Task("Develop software", 3, softwareDevelopment.Id, developFunctionalSpecifications.FinishDate, 5, 40);
            Task developHelpSystem = new Task("Develop help system", 4, softwareDevelopment.Id, developFunctionalSpecifications.FinishDate, 1, 90);
            Task developUserManuals = new Task("Develop user manuals", 5, softwareDevelopment.Id, developHelpSystem.FinishDate, 1, 0);
            Task testSoftware = new Task("Test software", 6, softwareDevelopment.Id, developSoftware.FinishDate, 2, 0);
            Task deployBeta = new Task("Deploy Beta", 7, softwareDevelopment.Id, testSoftware.FinishDate, 0, 0);
            Task collectFeedback = new Task("Collect feedback", 8, softwareDevelopment.Id, deployBeta.FinishDate, 2, 0);
            Task fixBugs = new Task("Fix bugs", 9, softwareDevelopment.Id, collectFeedback.FinishDate, 2, 0);
            Task incorporateFeedBack = new Task("Incorporate feedback", 10, softwareDevelopment.Id, collectFeedback.FinishDate, 3, 0);
            Task releaseSoftware = new Task("Release software", 11, softwareDevelopment.Id, incorporateFeedBack.FinishDate, 2, 0);
            Task createSoftwareMaintenanceTeam = new Task("Create software maintenance team", 12, softwareDevelopment.Id, deployBeta.FinishDate, 1, 0);
            Task softwareDevelopmentComplete = new Task("Software development complete", 13, softwareDevelopment.Id, releaseSoftware.FinishDate, 0, 0);
            softwareDevelopment.FinishDate = softwareDevelopmentComplete.FinishDate;
            tasks.AddRange(new Task[] {softwareDevelopment, analyseRequirements, developFunctionalSpecifications, developSoftware, developHelpSystem, developUserManuals,
        testSoftware,deployBeta,collectFeedback, fixBugs, incorporateFeedBack, releaseSoftware, createSoftwareMaintenanceTeam, softwareDevelopmentComplete });
            return tasks;
        }

        public class Task {
            public Task(string name, int id, int parentId, DateTime start, int duration, double progress) {
                Name = name;
                Id = id;
                ParentId = parentId;
                StartDate = start;
                FinishDate = start + TimeSpan.FromDays(duration);
                Progress = progress;
            }
            public int Id { get; set; }
            public int ParentId { get; set; }
            public BindingList<int> Predecessors { get; private set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime FinishDate { get; set; }
            public double Progress { get; set; }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ganttControl1.ExportToXml("C:\\temp\\fff.xml");
        }
    }
}
