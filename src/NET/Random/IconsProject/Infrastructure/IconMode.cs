using DevExpress.IconLibrary;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.XtraEditors;

namespace IconsProject.Infrastructure {
    public enum IconMode {
        ThemeBased,
        Fluent,
        Classic
    }

    public static class IconModeSwitch {
        public static IconMode Mode { get; private set; } = IconMode.ThemeBased;
        public static event EventHandler? Changed;

        public static void Apply(IconMode mode) {
            switch(mode) {
                case IconMode.Fluent:
                    WindowsFormsSettings.SetFluentIconStyle();
                    break;
                case IconMode.Classic:
                    WindowsFormsSettings.SetDesktopClassicIconStyle();
                    break;
                default:
                    WindowsFormsSettings.SetThemeBasedIconStyle();
                    break;
            }
            Mode = mode;
            IconLog.Write($"Icon mode -> {mode} | {Describe()}");
            Changed?.Invoke(null, EventArgs.Empty);
        }

        public static IconSet ActiveForDefaultLookAndFeel => LookAndFeelHelper.GetActiveIconSet(UserLookAndFeel.Default);

        public static string Describe() {
            string context = IconSetContext.HasValue ? IconSetContext.Current.ToString() : "none";
            return $"IconSetSettings.ActiveIconSet={IconSetSettings.ActiveIconSet}, active(Default LnF)={ActiveForDefaultLookAndFeel}, IconSetContext={context}, skin={UserLookAndFeel.Default.ActiveSkinName}, glyphAppearance={DxImageUriUtils.GetAppearanceType(UserLookAndFeel.Default)}";
        }

        public static IconMode Parse(string value) {
            return Enum.TryParse(value, true, out IconMode mode) ? mode : IconMode.ThemeBased;
        }
    }
}
