using DevExpress.XtraEditors;
using Random12513.Infrastructure;
using Random12513.Model;
using System.ComponentModel;

namespace Random12513.Views {
    public partial class GanttView : XtraUserControl {
        public GanttView() {
            InitializeComponent();
        }

        BindingList<GanttTaskItem> ganttTasks;
        public GanttView(ICommonDataService dataService) : this() {
            ganttTasks = new BindingList<GanttTaskItem>(dataService.GetGanttTasks().ToList());
            UpdateTaskStartDates();
            ganttBindingSource.DataSource = ganttTasks;
            ganttControl1.ScheduleFromStartDate(DateTime.Now.AddDays(3));
        }

        void UpdateTaskStartDates() {
            foreach(GanttTaskItem task in ganttTasks) {
                DateTime startDate = task.StartDate;
                foreach(int predId in task.Predecessors) {
                    GanttTaskItem pred = ganttTasks.First(t => t.Id == predId);
                    DateTime? predFinishDate = ganttControl1.CalcFinishDate(pred.StartDate, pred.Duration);
                    if(predFinishDate != null && predFinishDate > startDate) {
                        startDate = predFinishDate.Value;
                    }
                }
                task.StartDate = startDate;
            }
        }

        void ganttControl1_NodesReloaded(object sender, EventArgs e) {
            ganttControl1.ExpandAll();
        }
    }
}
