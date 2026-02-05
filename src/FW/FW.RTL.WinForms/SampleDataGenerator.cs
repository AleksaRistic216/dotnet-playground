using Bogus;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FW.RTL.WinForms {
    public static class SampleDataGenerator {
        private static readonly Random _random = new Random();
        private static readonly Faker _faker = new Faker();

        public static List<SamplePerson> GeneratePersons(int count = 50) {
            var faker = new Faker<SamplePerson>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Company, f => f.Company.CompanyName())
                .RuleFor(p => p.JobTitle, f => f.Name.JobTitle())
                .RuleFor(p => p.Department, f => f.Commerce.Department())
                .RuleFor(p => p.Street, f => f.Address.StreetAddress())
                .RuleFor(p => p.City, f => f.Address.City())
                .RuleFor(p => p.State, f => f.Address.State())
                .RuleFor(p => p.ZipCode, f => f.Address.ZipCode())
                .RuleFor(p => p.Country, f => f.Address.Country())
                .RuleFor(p => p.BirthDate, f => f.Date.Past(50, DateTime.Now.AddYears(-18)))
                .RuleFor(p => p.HireDate, f => f.Date.Past(10))
                .RuleFor(p => p.Salary, f => f.Finance.Amount(30000, 150000))
                .RuleFor(p => p.IsActive, f => f.Random.Bool(0.85f))
                .RuleFor(p => p.Rating, f => f.Random.Int(1, 5))
                .RuleFor(p => p.Notes, f => f.Lorem.Sentence());

            return faker.Generate(count);
        }

        public static List<SampleProduct> GenerateProducts(int count = 30) {
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

        public static List<SampleOrder> GenerateOrders(int count = 100) {
            var faker = new Faker<SampleOrder>()
                .RuleFor(o => o.OrderId, f => f.IndexFaker + 1)
                .RuleFor(o => o.OrderNumber, f => f.Random.Replace("ORD-######"))
                .RuleFor(o => o.CustomerName, f => f.Name.FullName())
                .RuleFor(o => o.CustomerEmail, f => f.Internet.Email())
                .RuleFor(o => o.OrderDate, f => f.Date.Past(1))
                .RuleFor(o => o.ShipDate, (f, o) => o.OrderDate.AddDays(f.Random.Int(1, 7)))
                .RuleFor(o => o.Status, f => f.PickRandom("Pending", "Processing", "Shipped", "Delivered", "Cancelled"))
                .RuleFor(o => o.Priority, f => f.PickRandom("Low", "Normal", "High", "Urgent"))
                .RuleFor(o => o.TotalAmount, f => f.Finance.Amount(50, 5000))
                .RuleFor(o => o.Tax, (f, o) => o.TotalAmount * 0.08m)
                .RuleFor(o => o.Discount, f => f.Finance.Amount(0, 200))
                .RuleFor(o => o.ShippingCost, f => f.Finance.Amount(5, 50))
                .RuleFor(o => o.PaymentMethod, f => f.PickRandom("Credit Card", "PayPal", "Bank Transfer", "Cash"))
                .RuleFor(o => o.ShippingAddress, f => f.Address.FullAddress())
                .RuleFor(o => o.BillingAddress, f => f.Address.FullAddress())
                .RuleFor(o => o.Notes, f => f.Random.Bool(0.3f) ? f.Lorem.Sentence() : null)
                .RuleFor(o => o.IsGift, f => f.Random.Bool(0.1f))
                .RuleFor(o => o.ItemCount, f => f.Random.Int(1, 10));

            return faker.Generate(count);
        }

        public static List<SampleTask> GenerateTasks(int count = 40) {
            var faker = new Faker<SampleTask>()
                .RuleFor(t => t.TaskId, f => f.IndexFaker + 1)
                .RuleFor(t => t.Title, f => f.Lorem.Sentence(3, 5))
                .RuleFor(t => t.Description, f => f.Lorem.Paragraph())
                .RuleFor(t => t.AssignedTo, f => f.Name.FullName())
                .RuleFor(t => t.CreatedBy, f => f.Name.FullName())
                .RuleFor(t => t.CreatedDate, f => f.Date.Past(3))
                .RuleFor(t => t.DueDate, (f, t) => t.CreatedDate.AddDays(f.Random.Int(7, 60)))
                .RuleFor(t => t.CompletedDate, (f, t) => f.Random.Bool(0.6f) ? (DateTime?)t.CreatedDate.AddDays(f.Random.Int(1, 30)) : null)
                .RuleFor(t => t.Status, f => f.PickRandom("Not Started", "In Progress", "On Hold", "Completed", "Cancelled"))
                .RuleFor(t => t.Priority, f => f.Random.Int(1, 5))
                .RuleFor(t => t.PercentComplete, f => f.Random.Int(0, 100))
                .RuleFor(t => t.Category, f => f.PickRandom("Development", "Design", "Testing", "Documentation", "Meetings", "Support"))
                .RuleFor(t => t.Tags, f => string.Join(", ", f.Lorem.Words(f.Random.Int(1, 4))))
                .RuleFor(t => t.EstimatedHours, f => f.Random.Decimal(1, 40))
                .RuleFor(t => t.ActualHours, f => f.Random.Decimal(0, 50));

            return faker.Generate(count);
        }

        public static List<SampleFile> GenerateFiles(int count = 50) {
            string[] extensions = { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".txt", ".jpg", ".png", ".zip", ".csv" };
            string[] folders = { "Documents", "Images", "Reports", "Archives", "Projects", "Downloads" };

            var faker = new Faker<SampleFile>()
                .RuleFor(f => f.FileId, fa => fa.IndexFaker + 1)
                .RuleFor(f => f.FileName, fa => fa.System.FileName())
                .RuleFor(f => f.Extension, fa => fa.PickRandom(extensions))
                .RuleFor(f => f.Folder, fa => fa.PickRandom(folders))
                .RuleFor(f => f.FilePath, (fa, file) => $"C:\\{file.Folder}\\{file.FileName}")
                .RuleFor(f => f.FileSize, fa => fa.Random.Long(1024, 104857600))
                .RuleFor(f => f.CreatedDate, fa => fa.Date.Past(3))
                .RuleFor(f => f.ModifiedDate, (fa, file) => fa.Date.Between(file.CreatedDate, DateTime.Now))
                .RuleFor(f => f.Owner, fa => fa.Name.FullName())
                .RuleFor(f => f.IsReadOnly, fa => fa.Random.Bool(0.2f))
                .RuleFor(f => f.IsHidden, fa => fa.Random.Bool(0.1f));

            return faker.Generate(count);
        }

        public static List<TreeNode> GenerateTreeNodes(int depth = 3, int childrenPerNode = 4) {
            var nodes = new List<TreeNode>();
            var categories = new[] { "Electronics", "Clothing", "Home & Garden", "Sports", "Books" };

            foreach (var category in categories) {
                nodes.Add(GenerateTreeNodeRecursive(category, depth, childrenPerNode));
            }

            return nodes;
        }

        private static TreeNode GenerateTreeNodeRecursive(string name, int remainingDepth, int childrenPerNode) {
            var node = new TreeNode {
                Id = _random.Next(1, 100000),
                Name = name,
                Description = _faker.Lorem.Sentence(),
                Icon = _random.Next(0, 10),
                IsExpanded = remainingDepth > 1,
                Children = new List<TreeNode>()
            };

            if (remainingDepth > 0) {
                int childCount = _random.Next(1, childrenPerNode + 1);
                for (int i = 0; i < childCount; i++) {
                    var childName = $"{name} - {_faker.Commerce.ProductAdjective()} {_faker.Commerce.Product()}";
                    node.Children.Add(GenerateTreeNodeRecursive(childName, remainingDepth - 1, childrenPerNode));
                }
            }

            return node;
        }

        public static List<string> GenerateStrings(int count = 20) {
            var result = new List<string>();
            for (int i = 0; i < count; i++) {
                result.Add(_faker.Lorem.Sentence(2, 5));
            }
            return result;
        }

        public static List<Color> GenerateColors(int count = 20) {
            var result = new List<Color>();
            for (int i = 0; i < count; i++) {
                result.Add(Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256)));
            }
            return result;
        }

        public static string GenerateLoremText(int paragraphs = 3) {
            return string.Join("\n\n", _faker.Lorem.Paragraphs(paragraphs));
        }

        public static string GenerateHtmlContent() {
            return $@"<html>
<body style='font-family: Segoe UI, Arial, sans-serif; padding: 20px;'>
    <h1>{_faker.Company.CompanyName()}</h1>
    <p>{_faker.Lorem.Paragraph()}</p>
    <h2>Features</h2>
    <ul>
        <li>{_faker.Lorem.Sentence()}</li>
        <li>{_faker.Lorem.Sentence()}</li>
        <li>{_faker.Lorem.Sentence()}</li>
    </ul>
    <h2>Contact</h2>
    <p>Email: <a href='mailto:{_faker.Internet.Email()}'>{_faker.Internet.Email()}</a></p>
    <p>Phone: {_faker.Phone.PhoneNumber()}</p>
</body>
</html>";
        }

        public static List<NavItem> GenerateNavItems(int count = 10) {
            var faker = new Faker<NavItem>()
                .RuleFor(n => n.Id, f => f.IndexFaker + 1)
                .RuleFor(n => n.Text, f => f.Commerce.Department())
                .RuleFor(n => n.Description, f => f.Lorem.Sentence())
                .RuleFor(n => n.IconIndex, f => f.Random.Int(0, 15))
                .RuleFor(n => n.IsEnabled, f => f.Random.Bool(0.9f));

            return faker.Generate(count);
        }

        public static List<BreadcrumbItem> GenerateBreadcrumbs() {
            var items = new List<BreadcrumbItem> {
                new BreadcrumbItem { Text = "Home", Path = "/" },
                new BreadcrumbItem { Text = _faker.Commerce.Department(), Path = "/category" },
                new BreadcrumbItem { Text = _faker.Commerce.ProductAdjective(), Path = "/category/sub" },
                new BreadcrumbItem { Text = _faker.Commerce.Product(), Path = "/category/sub/product" }
            };
            return items;
        }
    }

    public class SamplePerson {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
    }

    public class SampleProduct {
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

    public class SampleOrder {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal ShippingCost { get; set; }
        public string PaymentMethod { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string Notes { get; set; }
        public bool IsGift { get; set; }
        public int ItemCount { get; set; }
    }

    public class SampleTask {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public int PercentComplete { get; set; }
        public string Category { get; set; }
        public string Tags { get; set; }
        public decimal EstimatedHours { get; set; }
        public decimal ActualHours { get; set; }
    }

    public class SampleFile {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Folder { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Owner { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsHidden { get; set; }
    }

    public class TreeNode {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Icon { get; set; }
        public bool IsExpanded { get; set; }
        public List<TreeNode> Children { get; set; }
    }

    public class NavItem {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int IconIndex { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class BreadcrumbItem {
        public string Text { get; set; }
        public string Path { get; set; }
    }
}
