using DevExpress.Images;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace FW.FluentIcons.WinFormsFW {
    internal static class Program {
        [STAThread]
        static void Main() {
            DevExpress.UserSkins.BonusSkins.Register();
            WindowsFormsSettings.SetPerMonitorDpiAware();

            // Force DevExpress.Images assembly to load (required for icon resolution)
            var _ = ImageResourceCache.Default;

            // Global
            //WindowsFormsSettings.ActiveIconSet = DevExpress.Utils.Design.IconSet.Fluent;

            // With skin patch
            // I force WXI skin - ribbon + buttons down have icons
            //UserLookAndFeel.Default.SetSkinStyle(SkinStyle.WXI);
            SkinManager.Default.RegisterSkinPatch("C:\\Users\\aleksa.ristic\\Documents\\My DXSkins\\WXI_ICONS_SKIN_PATCH\\WXI_ICONS_SKIN_PATCH.skinpatch");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
