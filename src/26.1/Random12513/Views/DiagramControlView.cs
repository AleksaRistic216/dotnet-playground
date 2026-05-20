using DevExpress.XtraDiagram;
using DevExpress.XtraEditors;
using Random12513.Infrastructure;
using Random12513.Model;

namespace Random12513.Views {
    public partial class DiagramControlView : XtraUserControl {
        public DiagramControlView() {
            InitializeComponent();
        }

        public DiagramControlView(ICommonDataService dataService) : this() {
            diagramBindingSource.DataSource = dataService.GetCompanyUsers();
        }

        void diagramOrgChartController1_ItemsGenerated(object sender, DevExpress.XtraDiagram.DiagramItemsGeneratedEventArgs e) {
            ChangeItemColors();
            diagramControl1.FitToDrawing();
        }

        void ChangeItemColors() {
            IEnumerable<DiagramContainer> userContainers = diagramControl1.Items.OfType<DiagramContainer>();
            foreach(DiagramContainer container in userContainers) {
                if(container.DataContext is CompanyUser user)
                    container.Appearance.BackColor = ConvertUserToColor(user);
            }
        }

        Color ConvertUserToColor(CompanyUser user) {
            return user.GroupName switch {
                "Executive General and Administration" => ColorTranslator.FromHtml("#005fba"),
                "Sales" => ColorTranslator.FromHtml("#00b0ce"),
                "Design" => ColorTranslator.FromHtml("#00d0ab"),
                _ => ColorTranslator.FromHtml("#8163b6"),
            };
        }
    }
}
