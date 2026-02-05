namespace FW.RTL.WinForms.TestForms.Progress {
    [TestForm("Progress", "Progress Bar")]
    public partial class FormWithProgressBar : DevExpress.XtraBars.Ribbon.RibbonForm {
        private System.Windows.Forms.Timer timer;
        private int currentValue = 0;

        public FormWithProgressBar() {
            InitializeComponent();
            FormHelpers.InitializeCommonControlsPanel(ribbonPage1, this);
            InitializeTimer();
        }

        private void InitializeTimer() {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, e) => {
                currentValue += 2;
                if (currentValue > 100) currentValue = 0;
                progressBarControl1.EditValue = currentValue;
                progressBarControl2.EditValue = currentValue;
                progressBarControl3.EditValue = currentValue;
            };
            timer.Start();
        }

        protected override void OnFormClosed(System.Windows.Forms.FormClosedEventArgs e) {
            timer?.Stop();
            timer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
