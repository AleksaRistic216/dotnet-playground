using DevExpress.Data.Utils.Images;
using DevExpress.Images;
using DxIcon = DevExpress.Data.Utils.Images.Icon;

namespace IconsProject.Infrastructure {
    public static class IconCatalog {
        public static readonly string[] Metaphors = {
            "add", "delete", "save", "copy", "cut", "search", "filter_funnel", "alert", "home", "mail",
            "calendar", "folder", "document", "table", "zoom_in", "zoom_out", "checkmark", "arrow_left", "arrow_right", "star",
            "info", "warning", "question_circle", "key", "phone_call", "user", "globe", "share", "link", "image"
        };

        public static readonly string[] MetaphorsWithGaps = {
            "share",
            "star",
            "zoom_in",
            "zoom_out",
            "question_circle"
        };

        public static readonly (string Caption, DxIcon Icon)[] TypedIcons = {
            ("Add", Icons.Add),
            ("Delete", Icons.Delete),
            ("Save", Icons.Save),
            ("Copy", Icons.Copy),
            ("Cut", Icons.Cut),
            ("Search", Icons.Search),
            ("Filter", Icons.FilterFunnel),
            ("Alert", Icons.Alert),
            ("Home", Icons.Home),
            ("Mail", Icons.Mail),
            ("Calendar", Icons.Calendar),
            ("Folder", Icons.Folder),
            ("Document", Icons.Document),
            ("Table", Icons.Table),
            ("Zoom In", Icons.ZoomIn),
            ("Zoom Out", Icons.ZoomOut),
            ("Checkmark", Icons.Checkmark),
            ("Back", Icons.ArrowLeft),
            ("Forward", Icons.ArrowRight),
            ("Star", Icons.Star),
            ("Info", Icons.Info),
            ("Warning", Icons.Warning),
            ("Help", Icons.QuestionCircle),
            ("Key", Icons.Key),
            ("Phone", Icons.PhoneCall),
            ("User", Icons.User),
            ("Globe", Icons.Globe),
            ("Share", Icons.Share),
            ("Link", Icons.Link),
            ("Image", Icons.Image)
        };

        public static readonly (string Caption, string Uri)[] LegacyUris = {
            ("DXImages.Add", DXImages.Add),
            ("DXImages.Save", DXImages.Save),
            ("DXImages.Delete", DXImages.Delete),
            ("DXImages.Edit", DXImages.Edit),
            ("DXImages.Print", DXImages.Print),
            ("DXImages.Undo", DXImages.Undo),
            ("DXImages.Redo", DXImages.Redo),
            ("DXImages.Find", DXImages.Find),
            ("DXImages.Refresh", DXImages.Refresh),
            ("Add;Size16x16", "Add;Size16x16"),
            ("Add;Size32x32", "Add;Size32x32"),
            ("Add;Size16x16;GrayScaled", "Add;Size16x16;GrayScaled"),
            ("Add;Size32x32;GrayScaled", "Add;Size32x32;GrayScaled"),
            ("Add;Size16x16;Colored", "Add;Size16x16;Colored"),
            ("Add;Size32x32;Office2013", "Add;Size32x32;Office2013"),
            ("Add;Size16x16;DevAV", "Add;Size16x16;DevAV"),
            ("Save;Svg", "Save;Svg"),
            ("Save;Size24x24;Svg", "Save;Size24x24;Svg"),
            ("Print;Colored", "Print;Colored")
        };

        public static readonly (string Caption, string Uri)[] IconSetUris = {
            ("add", "add"),
            ("add;Fluent", "add;Fluent"),
            ("add;Classic", "add;Classic"),
            ("add;Blazor", "add;Blazor"),
            ("add;Fluent;Filled", "add;Fluent;Filled"),
            ("add;Fluent;Monochrome", "add;Fluent;Monochrome"),
            ("add;Fluent;Multicolor", "add;Fluent;Multicolor"),
            ("add;Fluent;Filled;Monochrome;Size24", "add;Fluent;Filled;Monochrome;Size24"),
            ("add;Classic;Size32", "add;Classic;Size32"),
            ("delete;Fluent;Size48", "delete;Fluent;Size48"),
            ("delete;Fluent;Size12", "delete;Fluent;Size12"),
            ("alert;Fluent", "alert;Fluent"),
            ("filter_funnel;Blazor;Filled", "filter_funnel;Blazor;Filled"),
            ("add;Filled (no set)", "add;Filled"),
            ("add;Size20 (no set)", "add;Size20"),
            ("fluentxaf/action_edit;Fluent", "fluentxaf/action_edit;Fluent")
        };

        public static readonly (string Caption, string Uri)[] EdgeUris = {
            ("comma separated", "add,Fluent,Filled"),
            ("reordered tokens", "add;Size16;Filled;Fluent"),
            ("duplicate set (first wins)", "add;Classic;Fluent"),
            ("lower-case tokens", "add;fluent;filled;monochrome;size24"),
            ("numeric token", "add;1"),
            ("unknown token", "add;Fluent;Bogus"),
            ("missing icon", "doesnotexist;Fluent"),
            ("missing icon, no set", "doesnotexist"),
            ("share has no Classic file", "share;Classic"),
            ("star has no Blazor file", "star;Blazor"),
            ("Size28 not published for add", "add;Fluent;Size28"),
            ("Size48 not published for add", "add;Fluent;Size48"),
            ("Size12 not published for add", "add;Fluent;Size12"),
            ("legacy + icon set mixed", "Add;Size16x16;Fluent"),
            ("svg type + fluent", "add;Svg;Fluent"),
            ("whitespace token", "add; Fluent"),
            ("empty", "")
        };

        public static IEnumerable<(string Caption, string Uri)> AllUris() {
            foreach(var entry in LegacyUris)
                yield return entry;
            foreach(var entry in IconSetUris)
                yield return entry;
            foreach(var entry in EdgeUris)
                yield return entry;
        }

        public static readonly IconSet[] Sets = { IconSet.Default, IconSet.Fluent, IconSet.Classic, IconSet.Blazor };
        public static readonly IconStyle[] Styles = { IconStyle.Default, IconStyle.Regular, IconStyle.Filled };
        public static readonly IconColor[] Colors = { IconColor.Default, IconColor.Multicolor, IconColor.Monochrome };
        public static readonly IconSize[] Sizes = {
            IconSize.Default, IconSize.Size12, IconSize.Size16, IconSize.Size20, IconSize.Size24, IconSize.Size28, IconSize.Size32, IconSize.Size48
        };

        public static Size PixelSize(IconSize size) {
            switch(size) {
                case IconSize.Size12: return new Size(12, 12);
                case IconSize.Size16: return new Size(16, 16);
                case IconSize.Size20: return new Size(20, 20);
                case IconSize.Size24: return new Size(24, 24);
                case IconSize.Size28: return new Size(28, 28);
                case IconSize.Size48: return new Size(48, 48);
                default: return new Size(32, 32);
            }
        }

        public static string ExpectedFileName(string id, IconSet set, IconStyle style, IconColor color, IconSize size) {
            string setToken = set == IconSet.Fluent ? "fluent" : set == IconSet.Blazor ? "blazor_classic" : "desktop_classic";
            string styleToken = style == IconStyle.Filled ? "filled" : "regular";
            string colorToken = color == IconColor.Monochrome ? "monochrome" : color == IconColor.Multicolor ? "multicolor" : set == IconSet.Classic || set == IconSet.Default ? "multicolor" : "monochrome";
            return $"{id}-{setToken}-{styleToken}-{colorToken}-{PixelSize(size).Width}.svg";
        }

        public static IEnumerable<(string Name, DxIcon Icon)> AllGeneratedIcons() {
            foreach(var property in typeof(Icons).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)) {
                if(property.PropertyType != typeof(DxIcon))
                    continue;
                if(property.GetValue(null) is DxIcon icon)
                    yield return (property.Name, icon);
            }
        }
    }
}
