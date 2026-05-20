using DevExpress.XtraEditors;
using Random12512.Infrastructure;
using Random12512.Model;
using System.ComponentModel;

namespace Random12512.Views {
    public partial class TreeListView : XtraUserControl {
        public TreeListView() {
            InitializeComponent();
        }

        BindingList<CompanyUser> companyUsers;
        public TreeListView(ICommonDataService dataService) : this() {
            companyUsers = new BindingList<CompanyUser>(dataService.GetCompanyUsers().ToList());
            treeListBindingSource.DataSource = companyUsers;
            treeList1.StateImageList = svgImageCollection1;
        }

        void treeList1_NodesReloaded(object sender, EventArgs e) {
            treeList1.ExpandAll();
        }

        void treeList1_GetStateImage_1(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e) {
            e.NodeImageIndex = 0;
        }
    }
}
