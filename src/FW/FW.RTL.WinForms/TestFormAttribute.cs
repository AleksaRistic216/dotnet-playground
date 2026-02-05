using System;

namespace FW.RTL.WinForms {
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TestFormAttribute : Attribute {
        public string Category { get; }
        public string DisplayName { get; }
        public int Order { get; set; }

        public TestFormAttribute(string category, string displayName) {
            Category = category;
            DisplayName = displayName;
            Order = 0;
        }
    }
}
