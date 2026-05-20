using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Random12513.Infrastructure;

namespace Random12513.Views {
    public partial class ReportView : XtraUserControl {
        public ReportView() {
            InitializeComponent();
            this.documentViewer1.DocumentSource = new Report();
        }
    }
}
