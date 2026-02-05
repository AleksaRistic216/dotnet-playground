using DevExpress.Data.Filtering;
using DevExpress.XtraEditors.Filtering;
using System.Collections.Generic;

namespace FW.RTL.WinForms.TestForms.Misc {
    [TestForm("Misc", "Filter Control")]
    public partial class FormWithFilterControl : DevExpress.XtraBars.Ribbon.RibbonForm {
        public FormWithFilterControl() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            SetupFilterControl();
            PopulateSampleData();
        }

        private void SetupFilterControl() {
            // Define filter columns
            //filterControl1.FilterColumns.Add(new FilterColumn {
            //    FieldName = "Name",
            //    Caption = "Name",
            //    ColumnType = typeof(string)
            //});
            //filterControl1.FilterColumns.Add(new FilterColumn {
            //    FieldName = "Category",
            //    Caption = "Category",
            //    ColumnType = typeof(string)
            //});
            //filterControl1.FilterColumns.Add(new FilterColumn {
            //    FieldName = "Price",
            //    Caption = "Price",
            //    ColumnType = typeof(decimal)
            //});
            //filterControl1.FilterColumns.Add(new FilterColumn {
            //    FieldName = "InStock",
            //    Caption = "In Stock",
            //    ColumnType = typeof(bool)
            //});
            //filterControl1.FilterColumns.Add(new FilterColumn {
            //    FieldName = "DateAdded",
            //    Caption = "Date Added",
            //    ColumnType = typeof(System.DateTime)
            //});

            // Set initial filter
            filterControl1.FilterCriteria = new BinaryOperator("Price", 100m, BinaryOperatorType.GreaterOrEqual);
        }

        private void PopulateSampleData() {
            var products = SampleDataGenerator.GenerateProducts(20);
            gridControl1.DataSource = products;
        }

        private void ApplyFilter() {
            var filter = filterControl1.FilterCriteria;
            if (filter != null) {
                var view = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (view != null) {
                    view.ActiveFilterCriteria = filter;
                }
            }
        }
    }
}
