using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using System;

namespace FW.RTL.WinForms.TestForms.Grids {
    internal static class VerticalGridHelpers {
        private static readonly Random _random = new Random();

        internal static void FillSampleData(VGridControl vGridControl) {
            var data = SampleDataGenerator.GenerateProducts(10);
            vGridControl.Rows.Clear();

            int layoutType = _random.Next(4);

            switch (layoutType) {
                case 0:
                    CreateLayout_CategorizedWithMultiEditors(vGridControl);
                    break;
                case 1:
                    CreateLayout_FlatWithMixedRows(vGridControl);
                    break;
                case 2:
                    CreateLayout_NestedCategories(vGridControl);
                    break;
                case 3:
                    CreateLayout_CompactMultiEditorOnly(vGridControl);
                    break;
            }

            vGridControl.DataSource = data;
        }

        private static void CreateLayout_CategorizedWithMultiEditors(VGridControl vGrid) {
            var catBasic = new CategoryRow("Basic Information");
            vGrid.Rows.Add(catBasic);

            catBasic.ChildRows.Add(CreateEditorRow("ProductId", "Product ID"));
            catBasic.ChildRows.Add(CreateEditorRow("ProductName", "Name"));

            var multiCatBrand = CreateMultiEditorRow("catBrand",
                ("Category", "Category"),
                ("Brand", "Brand"));
            catBasic.ChildRows.Add(multiCatBrand);

            catBasic.ChildRows.Add(CreateEditorRow("SKU", "SKU"));
            catBasic.ChildRows.Add(CreateEditorRow("Description", "Description"));

            var catPricing = new CategoryRow("Pricing");
            vGrid.Rows.Add(catPricing);

            var multiPrices = CreateMultiEditorRow("prices",
                ("Price", "Price"),
                ("Cost", "Cost"),
                ("Discount", "Discount %"));
            catPricing.ChildRows.Add(multiPrices);

            var catInventory = new CategoryRow("Inventory");
            vGrid.Rows.Add(catInventory);

            var multiStock = CreateMultiEditorRow("stock",
                ("StockQuantity", "In Stock"),
                ("ReorderLevel", "Reorder At"));
            catInventory.ChildRows.Add(multiStock);

            var multiLocation = CreateMultiEditorRow("location",
                ("Warehouse", "Warehouse"),
                ("ShelfLocation", "Shelf"));
            catInventory.ChildRows.Add(multiLocation);

            var catSupplier = new CategoryRow("Supplier");
            vGrid.Rows.Add(catSupplier);

            catSupplier.ChildRows.Add(CreateEditorRow("Supplier", "Name"));

            var multiSupplierContact = CreateMultiEditorRow("supplierContact",
                ("SupplierContact", "Phone"),
                ("SupplierEmail", "Email"));
            catSupplier.ChildRows.Add(multiSupplierContact);

            var catDimensions = new CategoryRow("Dimensions");
            vGrid.Rows.Add(catDimensions);

            var multiDims = CreateMultiEditorRow("dims",
                ("Width", "W"),
                ("Height", "H"),
                ("Depth", "D"));
            catDimensions.ChildRows.Add(multiDims);

            catDimensions.ChildRows.Add(CreateEditorRow("Weight", "Weight (kg)"));

            var catStatus = new CategoryRow("Status");
            vGrid.Rows.Add(catStatus);

            var multiFlags = CreateMultiEditorRow("flags",
                ("IsActive", "Active"),
                ("IsFeatured", "Featured"));
            catStatus.ChildRows.Add(multiFlags);

            var multiRating = CreateMultiEditorRow("rating",
                ("Rating", "Rating"),
                ("ReviewCount", "Reviews"));
            catStatus.ChildRows.Add(multiRating);

            var multiDates = CreateMultiEditorRow("dates",
                ("CreatedDate", "Created"),
                ("ModifiedDate", "Modified"));
            catStatus.ChildRows.Add(multiDates);
        }

        private static void CreateLayout_FlatWithMixedRows(VGridControl vGrid) {
            vGrid.Rows.Add(CreateEditorRow("ProductId", "ID"));

            var multiName = CreateMultiEditorRow("name",
                ("ProductName", "Product Name"),
                ("SKU", "SKU"));
            vGrid.Rows.Add(multiName);

            var multiCatBrand = CreateMultiEditorRow("catBrand",
                ("Category", "Category"),
                ("Brand", "Brand"));
            vGrid.Rows.Add(multiCatBrand);

            var multiPricing = CreateMultiEditorRow("pricing",
                ("Price", "Price"),
                ("Cost", "Cost"),
                ("Discount", "Discount"));
            vGrid.Rows.Add(multiPricing);

            var multiInventory = CreateMultiEditorRow("inventory",
                ("StockQuantity", "Stock"),
                ("ReorderLevel", "Reorder Level"));
            vGrid.Rows.Add(multiInventory);

            vGrid.Rows.Add(CreateEditorRow("Supplier", "Supplier"));

            var multiSupplier = CreateMultiEditorRow("supplierInfo",
                ("SupplierContact", "Supplier Phone"),
                ("SupplierEmail", "Supplier Email"));
            vGrid.Rows.Add(multiSupplier);

            var multiWarehouse = CreateMultiEditorRow("warehouse",
                ("Warehouse", "Warehouse"),
                ("ShelfLocation", "Location"));
            vGrid.Rows.Add(multiWarehouse);

            var multiDimensions = CreateMultiEditorRow("dimensions",
                ("Weight", "Weight"),
                ("Width", "W"),
                ("Height", "H"),
                ("Depth", "D"));
            vGrid.Rows.Add(multiDimensions);

            var multiStatus = CreateMultiEditorRow("status",
                ("IsActive", "Active"),
                ("IsFeatured", "Featured"));
            vGrid.Rows.Add(multiStatus);

            var multiRating = CreateMultiEditorRow("rating",
                ("Rating", "Rating"),
                ("ReviewCount", "Reviews"));
            vGrid.Rows.Add(multiRating);

            var multiDates = CreateMultiEditorRow("dates",
                ("CreatedDate", "Created"),
                ("ModifiedDate", "Modified"));
            vGrid.Rows.Add(multiDates);

            vGrid.Rows.Add(CreateEditorRow("Description", "Description"));
        }

        private static void CreateLayout_NestedCategories(VGridControl vGrid) {
            var catProduct = new CategoryRow("Product");
            vGrid.Rows.Add(catProduct);

            var catIdentity = new CategoryRow("Identity");
            catProduct.ChildRows.Add(catIdentity);

            catIdentity.ChildRows.Add(CreateEditorRow("ProductId", "ID"));
            catIdentity.ChildRows.Add(CreateEditorRow("ProductName", "Name"));
            catIdentity.ChildRows.Add(CreateEditorRow("SKU", "SKU"));

            var catClassification = new CategoryRow("Classification");
            catProduct.ChildRows.Add(catClassification);

            catClassification.ChildRows.Add(CreateEditorRow("Category", "Category"));
            catClassification.ChildRows.Add(CreateEditorRow("Brand", "Brand"));

            catProduct.ChildRows.Add(CreateEditorRow("Description", "Description"));

            var catCommercial = new CategoryRow("Commercial");
            vGrid.Rows.Add(catCommercial);

            var catPricing = new CategoryRow("Pricing");
            catCommercial.ChildRows.Add(catPricing);

            catPricing.ChildRows.Add(CreateEditorRow("Price", "Sell Price"));
            catPricing.ChildRows.Add(CreateEditorRow("Cost", "Unit Cost"));
            catPricing.ChildRows.Add(CreateEditorRow("Discount", "Discount %"));

            var catReviews = new CategoryRow("Reviews");
            catCommercial.ChildRows.Add(catReviews);

            var multiRating = CreateMultiEditorRow("rating",
                ("Rating", "Rating"),
                ("ReviewCount", "Count"));
            catReviews.ChildRows.Add(multiRating);

            var catLogistics = new CategoryRow("Logistics");
            vGrid.Rows.Add(catLogistics);

            var catInventory = new CategoryRow("Inventory");
            catLogistics.ChildRows.Add(catInventory);

            var multiStock = CreateMultiEditorRow("stock",
                ("StockQuantity", "Qty"),
                ("ReorderLevel", "Reorder"));
            catInventory.ChildRows.Add(multiStock);

            var catLocation = new CategoryRow("Storage Location");
            catLogistics.ChildRows.Add(catLocation);

            catLocation.ChildRows.Add(CreateEditorRow("Warehouse", "Warehouse"));
            catLocation.ChildRows.Add(CreateEditorRow("ShelfLocation", "Shelf"));

            var catPhysical = new CategoryRow("Physical");
            catLogistics.ChildRows.Add(catPhysical);

            catPhysical.ChildRows.Add(CreateEditorRow("Weight", "Weight"));

            var multiDims = CreateMultiEditorRow("dims",
                ("Width", "W"),
                ("Height", "H"),
                ("Depth", "D"));
            catPhysical.ChildRows.Add(multiDims);

            var catSupplyChain = new CategoryRow("Supply Chain");
            vGrid.Rows.Add(catSupplyChain);

            catSupplyChain.ChildRows.Add(CreateEditorRow("Supplier", "Supplier Name"));
            catSupplyChain.ChildRows.Add(CreateEditorRow("SupplierContact", "Phone"));
            catSupplyChain.ChildRows.Add(CreateEditorRow("SupplierEmail", "Email"));

            var catMetadata = new CategoryRow("Metadata");
            vGrid.Rows.Add(catMetadata);

            var multiFlags = CreateMultiEditorRow("flags",
                ("IsActive", "Active"),
                ("IsFeatured", "Featured"));
            catMetadata.ChildRows.Add(multiFlags);

            var multiDates = CreateMultiEditorRow("dates",
                ("CreatedDate", "Created"),
                ("ModifiedDate", "Modified"));
            catMetadata.ChildRows.Add(multiDates);
        }

        private static void CreateLayout_CompactMultiEditorOnly(VGridControl vGrid) {
            var multiId = CreateMultiEditorRow("id",
                ("ProductId", "ID"),
                ("SKU", "SKU"),
                ("IsActive", "Active"));
            vGrid.Rows.Add(multiId);

            var multiProduct = CreateMultiEditorRow("product",
                ("ProductName", "Product"),
                ("Brand", "Brand"),
                ("Category", "Category"));
            vGrid.Rows.Add(multiProduct);

            var multiMoney = CreateMultiEditorRow("money",
                ("Price", "Price"),
                ("Cost", "Cost"),
                ("Discount", "Disc %"));
            vGrid.Rows.Add(multiMoney);

            var multiInventory = CreateMultiEditorRow("inventory",
                ("StockQuantity", "Stock"),
                ("ReorderLevel", "Reorder"),
                ("Warehouse", "Warehouse"),
                ("ShelfLocation", "Shelf"));
            vGrid.Rows.Add(multiInventory);

            var multiSupplier = CreateMultiEditorRow("supplier",
                ("Supplier", "Supplier"),
                ("SupplierContact", "Phone"),
                ("SupplierEmail", "Email"));
            vGrid.Rows.Add(multiSupplier);

            var multiDimWeight = CreateMultiEditorRow("dimWeight",
                ("Weight", "Wt"),
                ("Width", "W"),
                ("Height", "H"),
                ("Depth", "D"));
            vGrid.Rows.Add(multiDimWeight);

            var multiReviews = CreateMultiEditorRow("reviews",
                ("Rating", "Rating"),
                ("ReviewCount", "Reviews"),
                ("IsFeatured", "Featured"));
            vGrid.Rows.Add(multiReviews);

            var multiDates = CreateMultiEditorRow("dates",
                ("CreatedDate", "Created"),
                ("ModifiedDate", "Modified"));
            vGrid.Rows.Add(multiDates);

            vGrid.Rows.Add(CreateEditorRow("Description", "Description"));
        }

        private static EditorRow CreateEditorRow(string fieldName, string caption) {
            var row = new EditorRow(fieldName) {
                Name = $"row{fieldName}"
            };
            row.Properties.Caption = caption;
            row.Properties.FieldName = fieldName;
            return row;
        }

        private static MultiEditorRow CreateMultiEditorRow(string name, params (string fieldName, string caption)[] fields) {
            var row = new MultiEditorRow {
                Name = $"multiRow{name}"
            };

            foreach (var (fieldName, caption) in fields) {
                row.PropertiesCollection.Add(new MultiEditorRowProperties {
                    FieldName = fieldName,
                    Caption = caption
                });
            }

            return row;
        }
    }
}
