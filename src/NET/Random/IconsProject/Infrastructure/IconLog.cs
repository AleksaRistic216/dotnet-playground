namespace IconsProject.Infrastructure {
    public static class IconLog {
        static readonly List<string> entries = new List<string>();
        public static string FilePath { get; } = Path.Combine(AppContext.BaseDirectory, "iconsproject.log");
        public static event Action<string>? Logged;
        public static string[] Snapshot() {
            lock(entries)
                return entries.ToArray();
        }
        public static void Write(string message) {
            string line = $"{DateTime.Now:HH:mm:ss.fff} [T{Environment.CurrentManagedThreadId}] {message}";
            lock(entries) {
                entries.Add(line);
                try {
                    File.AppendAllText(FilePath, line + Environment.NewLine);
                }
                catch(IOException) {
                }
            }
            System.Diagnostics.Debug.WriteLine(line);
            Logged?.Invoke(line);
        }
        public static void Pass(string check, string details = "") => Write($"PASS  {check} {details}".TrimEnd());
        public static void Fail(string check, string details = "") => Write($"FAIL  {check} {details}".TrimEnd());
        public static void Info(string check, string details = "") => Write($"INFO  {check} {details}".TrimEnd());
        public static void Error(string context, Exception ex) => Write($"ERROR [{context}] {ex.GetType().Name}: {ex.Message}{Environment.NewLine}{ex.StackTrace}");
    }
}
