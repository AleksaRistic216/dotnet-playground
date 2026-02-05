using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FW.RTL.WinForms {
    public static class FormRegistry {
        private static readonly Dictionary<Type, Form> _formCache = new Dictionary<Type, Form>();
        private static List<FormRegistration> _registrations;

        public class FormRegistration {
            public Type FormType { get; set; }
            public string Category { get; set; }
            public string DisplayName { get; set; }
            public int Order { get; set; }
        }

        public static IReadOnlyList<FormRegistration> GetRegistrations() {
            if (_registrations == null) {
                _registrations = DiscoverForms();
            }
            return _registrations;
        }

        private static List<FormRegistration> DiscoverForms() {
            var result = new List<FormRegistration>();
            var assembly = Assembly.GetExecutingAssembly();

            foreach (var type in assembly.GetTypes()) {
                var attr = type.GetCustomAttribute<TestFormAttribute>();
                if (attr != null && typeof(Form).IsAssignableFrom(type)) {
                    result.Add(new FormRegistration {
                        FormType = type,
                        Category = attr.Category,
                        DisplayName = attr.DisplayName,
                        Order = attr.Order
                    });
                }
            }

            return result.OrderBy(r => r.Category).ThenBy(r => r.Order).ThenBy(r => r.DisplayName).ToList();
        }

        public static void PopulateMenu(BarSubItem menuItem, Form owner) {
            var registrations = GetRegistrations();
            var categories = registrations.GroupBy(r => r.Category).OrderBy(g => g.Key);

            var manager = menuItem.Manager;

            foreach (var category in categories) {
                var subMenu = new BarSubItem(manager, category.Key) {
                    Name = $"barSubItem{category.Key.Replace(" ", "")}"
                };

                foreach (var reg in category) {
                    var button = new BarButtonItem(manager, reg.DisplayName) {
                        Name = $"barButton{reg.FormType.Name}",
                        Tag = reg.FormType
                    };
                    button.ItemClick += (s, e) => ShowForm(reg.FormType, owner);
                    subMenu.ItemLinks.Add(button);
                }

                menuItem.ItemLinks.Add(subMenu);
            }
        }

        public static void ShowForm(Type formType, Form owner) {
            if (_formCache.TryGetValue(formType, out var existingForm)) {
                if (!existingForm.IsDisposed) {
                    existingForm.Show();
                    existingForm.BringToFront();
                    return;
                }
                _formCache.Remove(formType);
            }

            var form = (Form)Activator.CreateInstance(formType);
            _formCache[formType] = form;
            form.Show(owner);
        }

        public static void ClearCache() {
            foreach (var form in _formCache.Values) {
                if (!form.IsDisposed) {
                    form.Close();
                }
            }
            _formCache.Clear();
        }
    }
}
