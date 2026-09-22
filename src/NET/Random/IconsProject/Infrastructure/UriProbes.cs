using DevExpress.LookAndFeel;
using DevExpress.Utils;

namespace IconsProject.Infrastructure {
    public class CountingDxImageUri : DxImageUri {
        bool isChanging;
        public CountingDxImageUri(string uri)
            : base(uri) {
        }
        public int ChangedCount { get; private set; }
        public int MaxDepth { get; private set; }
        public bool IsChangedReentered { get; private set; }
        int depth;
        public void ResetCounters() {
            ChangedCount = 0;
            MaxDepth = 0;
            IsChangedReentered = false;
        }
        protected override void OnChanged() {
            ChangedCount++;
            depth++;
            MaxDepth = Math.Max(MaxDepth, depth);
            try {
                if(isChanging) {
                    IsChangedReentered = true;
                    if(depth > 16)
                        return;
                }
                bool wasChanging = isChanging;
                isChanging = true;
                try {
                    base.OnChanged();
                }
                finally {
                    isChanging = wasChanging;
                }
            }
            finally {
                depth--;
            }
        }
        public override string ToString() => $"'{Uri}' changed={ChangedCount} maxDepth={MaxDepth} reentered={IsChangedReentered}";
    }

    public sealed class ProbeClient : IDXImageUriClient, IDXImageUriIconSizeProvider, IDisposable {
        readonly UserLookAndFeel lookAndFeel;
        public ProbeClient(string skinName, Size preferredIconSize = default) {
            lookAndFeel = new UserLookAndFeel(null);
            lookAndFeel.UseDefaultLookAndFeel = false;
            lookAndFeel.SetSkinStyle(skinName);
            PreferredIconSize = preferredIconSize;
        }
        public Size PreferredIconSize { get; set; }
        public int SetGlyphSkinningValueCount { get; private set; }
        public int PreferredIconSizeRequests { get; private set; }
        public bool GlyphSkinningValue { get; private set; }
        public bool SupportsLookAndFeel => true;
        public bool SupportsGlyphSkinning => true;
        public UserLookAndFeel LookAndFeel => lookAndFeel;
        public bool IsDesignMode => false;
        public void SetGlyphSkinningValue(bool value) {
            SetGlyphSkinningValueCount++;
            GlyphSkinningValue = value;
        }
        public Size GetPreferredIconSize() {
            PreferredIconSizeRequests++;
            return PreferredIconSize;
        }
        public void Dispose() {
            lookAndFeel.Dispose();
        }
    }
}
