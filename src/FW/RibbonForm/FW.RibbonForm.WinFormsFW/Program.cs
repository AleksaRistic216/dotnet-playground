using DevExpress.Images;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FW.RibbonForm.WinFormsFW {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            DevExpress.UserSkins.BonusSkins.Register();
            //WindowsFormsSettings.SetPerMonitorDpiAware();
            //SkinManager.Default.RegisterSkinPatch("C:\\Users\\aleksa.ristic\\Documents\\My DXSkins\\WXI_ICONS_SKIN_PATCH\\WXI_ICONS_SKIN_PATCH.skinpatch");
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.WXI);
            Application.EnableVisualStyles();
            WindowsFormsSettings.ActiveIconSet = IconSet.Fluent;
            //WindowsFormsSettings.IconColor = "monochrome";

            AppearanceObject.DefaultFont = new Font("Segoe UI", 13F);
            AppearanceObject.ControlAppearance.Options.UseFont = true;
            AppearanceObject.ControlAppearance.Font = new Font("Segoe UI", AppearanceObject.ControlAppearance.Font.Size);
            AppearanceDefault.Control.Font = new Font("Segoe UI",
                13F);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
