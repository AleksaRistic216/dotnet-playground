using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace Random12512.Views {
    public partial class DashboardView : XtraUserControl {
        public DashboardView() {
            InitializeComponent();
            dashboardViewer.DashboardSource = typeof(SampleDashboard);
        }
    }
}
