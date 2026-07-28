using DevExpress.XtraCharts;

namespace LDSSM.WinForms;

partial class ChartForm
{
    private System.ComponentModel.IContainer components = null;
    private ChartControl chartControl;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        chartControl = new ChartControl();
        ((System.ComponentModel.ISupportInitialize)chartControl).BeginInit();
        SuspendLayout();

        // chartControl
        chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
        chartControl.Name = "chartControl";
        chartControl.TabIndex = 0;

        // ChartForm
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(900, 550);
        Controls.Add(chartControl);
        Name = "ChartForm";
        Text = "User Statistics Chart";
        Load += ChartForm_Load;

        ((System.ComponentModel.ISupportInitialize)chartControl).EndInit();
        ResumeLayout(false);
    }
}
