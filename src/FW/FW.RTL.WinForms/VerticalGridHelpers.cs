using Bogus;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.Collections.Generic;

namespace FW.RTL.WinForms {
    internal static class VerticalGridHelpers {
        private static readonly Random _random = new Random();

        internal static void FillSampleData(VGridControl vGridControl) {
            // Generate sample data using Bogus
            var data = GenerateSampleData(10);

            // Clear existing rows
            vGridControl.Rows.Clear();

            // Choose a random layout configuration
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

            // Bind data
            vGridControl.DataSource = data;
        }

        private static List<SampleProduct> GenerateSampleData(int count) {
            var faker = new Faker<SampleProduct>()
                .RuleFor(p => p.ProductId, f => f.IndexFaker + 1)
                .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
                .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0])
                .RuleFor(p => p.Brand, f => f.Company.CompanyName())
                .RuleFor(p => p.SKU, f => f.Commerce.Ean13())
                .RuleFor(p => p.Price, f => f.Finance.Amount(10, 500))
                .RuleFor(p => p.Cost, f => f.Finance.Amount(5, 200))
                .RuleFor(p => p.Discount, f => f.Random.Decimal(0, 30))
                .RuleFor(p => p.StockQuantity, f => f.Random.Int(0, 1000))
                .RuleFor(p => p.ReorderLevel, f => f.Random.Int(10, 100))
                .RuleFor(p => p.Supplier, f => f.Company.CompanyName())
                .RuleFor(p => p.SupplierContact, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.SupplierEmail, f => f.Internet.Email())
                .RuleFor(p => p.Warehouse, f => f.Address.City())
                .RuleFor(p => p.ShelfLocation, f => $"{f.Random.Char('A', 'Z')}-{f.Random.Int(1, 50)}")
                .RuleFor(p => p.Weight, f => f.Random.Decimal(0.1m, 50m))
                .RuleFor(p => p.Width, f => f.Random.Decimal(1, 100))
                .RuleFor(p => p.Height, f => f.Random.Decimal(1, 100))
                .RuleFor(p => p.Depth, f => f.Random.Decimal(1, 100))
                .RuleFor(p => p.IsActive, f => f.Random.Bool(0.9f))
                .RuleFor(p => p.IsFeatured, f => f.Random.Bool(0.2f))
                .RuleFor(p => p.CreatedDate, f => f.Date.Past(2))
                .RuleFor(p => p.ModifiedDate, f => f.Date.Recent(30))
                .RuleFor(p => p.Rating, f => f.Random.Decimal(1, 5))
                .RuleFor(p => p.ReviewCount, f => f.Random.Int(0, 500))
                .RuleFor(p => p.Description, f => f.Lorem.Paragraph());

            return faker.Generate(count);
        }

        // Layout 1: Categorized with multi-editor rows
        private static void CreateLayout_CategorizedWithMultiEditors(VGridControl vGrid) {
            // Basic Info Category
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

            // Pricing Category
            var catPricing = new CategoryRow("Pricing");
            vGrid.Rows.Add(catPricing);

            var multiPrices = CreateMultiEditorRow("prices",
                ("Price", "Price"),
                ("Cost", "Cost"),
                ("Discount", "Discount %"));
            catPricing.ChildRows.Add(multiPrices);

            // Inventory Category
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

            // Supplier Category
            var catSupplier = new CategoryRow("Supplier");
            vGrid.Rows.Add(catSupplier);

            catSupplier.ChildRows.Add(CreateEditorRow("Supplier", "Name"));

            var multiSupplierContact = CreateMultiEditorRow("supplierContact",
                ("SupplierContact", "Phone"),
                ("SupplierEmail", "Email"));
            catSupplier.ChildRows.Add(multiSupplierContact);

            // Dimensions Category
            var catDimensions = new CategoryRow("Dimensions");
            vGrid.Rows.Add(catDimensions);

            var multiDims = CreateMultiEditorRow("dims",
                ("Width", "W"),
                ("Height", "H"),
                ("Depth", "D"));
            catDimensions.ChildRows.Add(multiDims);

            catDimensions.ChildRows.Add(CreateEditorRow("Weight", "Weight (kg)"));

            // Status Category
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

        // Layout 2: Flat layout with mixed single and multi-editor rows
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

        // Layout 3: Nested categories with subcategories
        private static void CreateLayout_NestedCategories(VGridControl vGrid) {
            // Product Category
            var catProduct = new CategoryRow("Product");
            vGrid.Rows.Add(catProduct);

            // Identity subcategory
            var catIdentity = new CategoryRow("Identity");
            catProduct.ChildRows.Add(catIdentity);

            catIdentity.ChildRows.Add(CreateEditorRow("ProductId", "ID"));
            catIdentity.ChildRows.Add(CreateEditorRow("ProductName", "Name"));
            catIdentity.ChildRows.Add(CreateEditorRow("SKU", "SKU"));

            // Classification subcategory
            var catClassification = new CategoryRow("Classification");
            catProduct.ChildRows.Add(catClassification);

            catClassification.ChildRows.Add(CreateEditorRow("Category", "Category"));
            catClassification.ChildRows.Add(CreateEditorRow("Brand", "Brand"));

            catProduct.ChildRows.Add(CreateEditorRow("Description", "Description"));

            // Commercial Category
            var catCommercial = new CategoryRow("Commercial");
            vGrid.Rows.Add(catCommercial);

            // Pricing subcategory
            var catPricing = new CategoryRow("Pricing");
            catCommercial.ChildRows.Add(catPricing);

            catPricing.ChildRows.Add(CreateEditorRow("Price", "Sell Price"));
            catPricing.ChildRows.Add(CreateEditorRow("Cost", "Unit Cost"));
            catPricing.ChildRows.Add(CreateEditorRow("Discount", "Discount %"));

            // Reviews subcategory
            var catReviews = new CategoryRow("Reviews");
            catCommercial.ChildRows.Add(catReviews);

            var multiRating = CreateMultiEditorRow("rating",
                ("Rating", "Rating"),
                ("ReviewCount", "Count"));
            catReviews.ChildRows.Add(multiRating);

            // Logistics Category
            var catLogistics = new CategoryRow("Logistics");
            vGrid.Rows.Add(catLogistics);

            // Inventory subcategory
            var catInventory = new CategoryRow("Inventory");
            catLogistics.ChildRows.Add(catInventory);

            var multiStock = CreateMultiEditorRow("stock",
                ("StockQuantity", "Qty"),
                ("ReorderLevel", "Reorder"));
            catInventory.ChildRows.Add(multiStock);

            // Location subcategory
            var catLocation = new CategoryRow("Storage Location");
            catLogistics.ChildRows.Add(catLocation);

            catLocation.ChildRows.Add(CreateEditorRow("Warehouse", "Warehouse"));
            catLocation.ChildRows.Add(CreateEditorRow("ShelfLocation", "Shelf"));

            // Physical subcategory
            var catPhysical = new CategoryRow("Physical");
            catLogistics.ChildRows.Add(catPhysical);

            catPhysical.ChildRows.Add(CreateEditorRow("Weight", "Weight"));

            var multiDims = CreateMultiEditorRow("dims",
                ("Width", "W"),
                ("Height", "H"),
                ("Depth", "D"));
            catPhysical.ChildRows.Add(multiDims);

            // Supply Chain Category
            var catSupplyChain = new CategoryRow("Supply Chain");
            vGrid.Rows.Add(catSupplyChain);

            catSupplyChain.ChildRows.Add(CreateEditorRow("Supplier", "Supplier Name"));
            catSupplyChain.ChildRows.Add(CreateEditorRow("SupplierContact", "Phone"));
            catSupplyChain.ChildRows.Add(CreateEditorRow("SupplierEmail", "Email"));

            // Metadata Category
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

        // Layout 4: Compact layout using mostly multi-editor rows
        private static void CreateLayout_CompactMultiEditorOnly(VGridControl vGrid) {
            // Maximize density with multi-editor rows

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

    internal class SampleProduct {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal Discount { get; set; }
        public int StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public string Supplier { get; set; }
        public string SupplierContact { get; set; }
        public string SupplierEmail { get; set; }
        public string Warehouse { get; set; }
        public string ShelfLocation { get; set; }
        public decimal Weight { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Depth { get; set; }
        public bool IsActive { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public decimal Rating { get; set; }
        public int ReviewCount { get; set; }
        public string Description { get; set; }
    }
}
