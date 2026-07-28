using DevExpress.XtraCharts;

namespace LDSSM.WinForms;

partial class Chart3DForm
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

        // Chart3DForm
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(900, 600);
        Controls.Add(chartControl);
        Name = "Chart3DForm";
        Text = "3D Pie Chart - User Distribution";
        Load += Chart3DForm_Load;

        ((System.ComponentModel.ISupportInitialize)chartControl).EndInit();
        ResumeLayout(false);
    }
}
