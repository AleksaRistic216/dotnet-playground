using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Random12512.Infrastructure;

namespace Random12512.Views {
    public partial class ReportView : XtraUserControl {
        public ReportView() {
            InitializeComponent();
            this.documentViewer1.DocumentSource = new Report();
        }
    }
}
