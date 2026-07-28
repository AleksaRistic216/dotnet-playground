using DevExpress.XtraCharts;

namespace LDSSM.WinForms;

partial class RadarChartForm
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

        // RadarChartForm
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 700);
        Controls.Add(chartControl);
        Name = "RadarChartForm";
        Text = "Radar Chart - Country Age Profiles";
        Load += RadarChartForm_Load;

        ((System.ComponentModel.ISupportInitialize)chartControl).EndInit();
        ResumeLayout(false);
    }
}
