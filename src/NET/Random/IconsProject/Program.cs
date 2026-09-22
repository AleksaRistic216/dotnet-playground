using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using IconsProject.Forms;
using IconsProject.Infrastructure;

namespace IconsProject {
    internal static class Program {
        [STAThread]
        static void Main(string[] args) {
            ApplicationConfiguration.Initialize();
            File.WriteAllText(IconLog.FilePath, string.Empty);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => IconLog.Error("UI thread", e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => IconLog.Write($"FATAL {e.ExceptionObject}");
            WindowsFormsSettings.EnableFormSkins();

            string? skin = Option(args, "--skin");
            if(skin != null)
                UserLookAndFeel.Default.SetSkinStyle(skin);
            string? mode = Option(args, "--mode");
            if(mode != null)
                IconModeSwitch.Apply(IconModeSwitch.Parse(mode));
            IconLog.Write($"Startup | {IconModeSwitch.Describe()}");

            var hub = new HubForm();
            string? open = Option(args, "--open");
            bool autorun = args.Contains("--autorun", StringComparer.OrdinalIgnoreCase);
            if(open != null) {
                hub.Shown += (s, e) => {
                    foreach(var entry in HubForm.Entries.Where(x => x.Title.Contains(open, StringComparison.OrdinalIgnoreCase))) {
                        try {
                            var form = entry.Create();
                            if(autorun && form is IAutoRunnable runnable)
                                form.Shown += (_, _) => form.BeginInvoke(new Action(runnable.RunAll));
                            form.Show();
                            IconLog.Write($"Opened '{entry.Title}'");
                        }
                        catch(Exception ex) {
                            IconLog.Error($"open {entry.Title}", ex);
                        }
                    }
                };
            }
            string? quitAfter = Option(args, "--quit-after");
            if(quitAfter != null && int.TryParse(quitAfter, out int seconds)) {
                var timer = new System.Windows.Forms.Timer { Interval = seconds * 1000 };
                timer.Tick += (s, e) => {
                    timer.Stop();
                    IconLog.Write($"--quit-after {seconds}s reached, exiting");
                    Application.Exit();
                };
                timer.Start();
            }
            Application.Run(hub);
        }

        static string? Option(string[] args, string name) {
            int index = Array.FindIndex(args, a => string.Equals(a, name, StringComparison.OrdinalIgnoreCase));
            return index >= 0 && index + 1 < args.Length ? args[index + 1] : null;
        }
    }
}
