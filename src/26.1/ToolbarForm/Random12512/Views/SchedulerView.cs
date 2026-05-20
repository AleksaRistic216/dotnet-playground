using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraTreeList.Nodes;
using Random12512.Infrastructure;

namespace Random12512.Views {
    public partial class SchedulerView : XtraUserControl {
        public SchedulerView() {
            InitializeComponent();
            schedulerDataStorage1.Resources.ColorSaving = DXColorSavingType.ColorInstance;
            schedulerControl1.GoToToday();
        }
        public SchedulerView(ICommonDataService dataService) : this() {
            appointmentBindingSource.DataSource = dataService.GetAppointmentData();
            resourceBindingSource.DataSource = dataService.GetCalendarResources().Where(r => r.ParentId != -1);
            resourceTreeList.DataSource = dataService.GetCalendarResources();
            resourceTreeList.ExpandAll();
        }
        void OnSchedulerStorageFilterResource(object sender, PersistentObjectCancelEventArgs e) {
            Resource res = (Resource)e.Object;
            e.Cancel = !(bool)res.CustomFields["Visible"];
            if((int)res.ParentId == -1)
                res.Visible = false;
        }
        void OnTreeListAfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e) {
            schedulerDataStorage1.RefreshData();
        }
        void OnSchedulerAppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e) {
            object resourceId = e.ViewInfo.Appointment.ResourceId;
            Resource resource = schedulerControl1.DataStorage.Resources.GetResourceById(resourceId);
            e.ViewInfo.Appearance.BackColor = resource.GetColor();
        }
    }
}
