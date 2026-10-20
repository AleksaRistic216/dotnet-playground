using DevExpress.IconLibrary;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraVerticalGrid;
using IconsProject.Infrastructure;
using DxIcon = DevExpress.IconLibrary.Icon;

namespace IconsProject.Forms {
    public class GridTreeForm : TestFormBase {
        readonly GridControl grid;
        readonly GridView view;
        readonly TreeList treeList;

        public GridTreeForm()
            : base("Grid, TreeList, VerticalGrid: built-in menus and header glyphs",
                  "Built-in UI glyphs come from mapped resources (Grid SvgImages/Menu/Column, FormatRule/SVG/MenuImages, FilterEditor clause images, TreeList DataPicker, Printing PreviewSvg). " +
                  "Right-click a column header, open 'Conditional Formatting', the Filter Editor, the find panel, the embedded navigator and the print preview, in each icon mode. Column headers carry ImageOptions.ImageUri; the Status column uses an image combo backed by a SvgImageCollection.") {
            grid = new GridControl { UseEmbeddedNavigator = true };
            view = new GridView(grid);
            grid.MainView = view;
            grid.DataSource = Row.Create(60);
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowFooter = true;
            view.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            view.OptionsFind.AlwaysVisible = true;
            view.OptionsMenu.ShowConditionalFormattingItem = true;
            view.OptionsMenu.ShowGroupSummaryEditorItem = true;
            view.OptionsMenu.ShowAddNewSummaryItem = DefaultBoolean.True;
            view.OptionsView.ShowGroupPanel = true;
            foreach(string field in new[] { nameof(Row.Id), nameof(Row.Name), nameof(Row.Email), nameof(Row.Created), nameof(Row.Score), nameof(Row.Active), nameof(Row.Status) })
                view.Columns.AddVisible(field);
            string[] headerIcons = { "key", "user", "mail", "calendar", "table", "star", "alert" };
            for(int i = 0; i < view.Columns.Count; i++) {
                GridColumn column = view.Columns[i];
                column.ImageOptions.ImageUri = new DxIcon(headerIcons[i % headerIcons.Length]);
                column.ImageOptions.Alignment = StringAlignment.Near;
                Track(column.ImageOptions);
            }
            var statusEdit = new RepositoryItemImageComboBox();
            var statusImages = new SvgImageCollection { ImageSize = new Size(16, 16) };
            var provider = DxImageAssemblyUtil.ImageProvider;
            string[] statuses = { "checkmark", "warning", "alert", "info" };
            for(int i = 0; i < statuses.Length; i++) {
                statusImages.Add(statuses[i], provider.GetSvgImage(statuses[i], IconModeSwitch.ActiveForDefaultLookAndFeel, new Size(16, 16)));
                statusEdit.Items.Add(new ImageComboBoxItem(statuses[i], i, i));
            }
            statusEdit.SmallImages = statusImages;
            grid.RepositoryItems.Add(statusEdit);
            view.Columns[nameof(Row.Status)].ColumnEdit = statusEdit;
            var buttonEdit = new RepositoryItemButtonEdit { TextEditStyle = TextEditStyles.HideTextEditor };
            buttonEdit.Buttons.Clear();
            foreach(string id in new[] { "search", "delete" }) {
                var button = new EditorButton(ButtonPredefines.Glyph);
                button.ImageOptions.ImageUri = new DxIcon(id);
                buttonEdit.Buttons.Add(button);
            }
            grid.RepositoryItems.Add(buttonEdit);
            var actionsColumn = view.Columns.AddVisible("Actions");
            actionsColumn.UnboundDataType = typeof(string);
            actionsColumn.ColumnEdit = buttonEdit;
            actionsColumn.ImageOptions.ImageUri = "Add;Size16x16";
            var formatRule = new GridFormatRule { Column = view.Columns[nameof(Row.Score)], ApplyToRow = false };
            formatRule.Rule = new DevExpress.XtraEditors.FormatConditionRuleDataBar { PredefinedName = "Blue Gradient" };
            view.FormatRules.Add(formatRule);

            var actions = new FlowLayoutPanel();
            AddToolbarButton(actions, "Filter Editor", (s, e) => view.ShowFilterEditor(view.Columns[nameof(Row.Name)]));
            AddToolbarButton(actions, "Column chooser", (s, e) => view.ShowCustomization());
            AddToolbarButton(actions, "Ribbon print preview", (s, e) => grid.ShowRibbonPrintPreview());
            AddToolbarButton(actions, "Print preview (bars)", (s, e) => grid.ShowPrintPreview());
            AddToolbarButton(actions, "Group by Status", (s, e) => view.Columns[nameof(Row.Status)].GroupIndex = view.Columns[nameof(Row.Status)].GroupIndex < 0 ? 0 : -1);
            AddToolbarButton(actions, "TreeList filter editor", (s, e) => treeList!.ShowFilterEditor(treeList.Columns[0]));
            AddToolbarButton(actions, "TreeList customization", (s, e) => treeList!.ColumnsCustomization());

            treeList = new TreeList();
            treeList.OptionsView.ShowAutoFilterRow = true;
            treeList.OptionsFind.AlwaysVisible = true;
            treeList.OptionsMenu.ShowConditionalFormattingItem = true;
            var nameColumn = treeList.Columns.AddVisible("Name");
            nameColumn.ImageOptions.ImageUri = new DxIcon("folder");
            var sizeColumn = treeList.Columns.AddVisible("Size");
            sizeColumn.ImageOptions.ImageUri = new DxIcon("document");
            var stateImages = new SvgImageCollection { ImageSize = new Size(16, 16) };
            foreach(string id in new[] { "folder", "document", "image", "table" })
                stateImages.Add(id, provider.GetSvgImage(id, IconModeSwitch.ActiveForDefaultLookAndFeel, new Size(16, 16)));
            treeList.StateImageList = stateImages;
            treeList.BeginUnboundLoad();
            for(int i = 0; i < 6; i++) {
                var folder = treeList.AppendNode(new object?[] { $"Folder {i}", null }, null);
                folder.StateImageIndex = 0;
                for(int j = 0; j < 5; j++) {
                    var child = treeList.AppendNode(new object[] { $"File {i}.{j}", (i + 1) * (j + 1) * 1024 }, folder);
                    child.StateImageIndex = 1 + j % 3;
                }
            }
            treeList.EndUnboundLoad();
            treeList.ExpandAll();

            var vgrid = new PropertyGridControl { SelectedObject = new Row { Name = "Selected row", Email = "a@b.c" } };

            var split = new SplitContainerControl { Horizontal = true, SplitterPosition = 520 };
            split.Panel1.Controls.Add(treeList);
            treeList.Dock = DockStyle.Fill;
            split.Panel2.Controls.Add(vgrid);
            vgrid.Dock = DockStyle.Fill;

            AddSections(
                Section("Actions", actions, 70),
                Section("GridControl", grid, 420),
                Section("TreeList / PropertyGridControl", split, 300));
        }

        public class Row {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public DateTime Created { get; set; }
            public decimal Score { get; set; }
            public bool Active { get; set; }
            public int Status { get; set; }

            public static List<Row> Create(int count) {
                var random = new Random(48050);
                var rows = new List<Row>();
                for(int i = 0; i < count; i++)
                    rows.Add(new Row { Id = i + 1, Name = $"Customer {i + 1}", Email = $"customer{i + 1}@example.com", Created = DateTime.Today.AddDays(-random.Next(1000)), Score = random.Next(0, 1000) / 10m, Active = random.Next(2) == 0, Status = random.Next(4) });
                return rows;
            }
        }
    }
}
