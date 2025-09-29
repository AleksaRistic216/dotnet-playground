using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T1308298 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            chartControl1.UseDirectXPaint = true;
            chartControl2.UseDirectXPaint = true;
        }

        private void Form1_Load(object sender, EventArgs e) {
            Series s1 = new Series("Sin", ViewType.Line);
            Series s2 = new Series("Cos", ViewType.Line);
            Series s3 = new Series("Sin Cos", ViewType.Line);
            for (double i = 0; i < 30; i += 0.25) {
                s1.Points.Add(new SeriesPoint(i, Math.Sin(i)));
                s2.Points.Add(new SeriesPoint(i, Math.Cos(i)));
                s3.Points.Add(new SeriesPoint(i, Math.Sin(i) + Math.Cos(i)));
            }
            chartControl1.Series.AddRange(new[] { s1, s2});
            chartControl2.Series.AddRange(new[] { s3 });

            chartControl1.CrosshairOptions.CrosshairLabelBackColor = Color.Brown;
            chartControl1.CrosshairOptions.CrosshairLabelTextOptions.TextColor = Color.White;
            chartControl1.CrosshairOptions.GroupHeaderTextOptions.TextColor = Color.White;

            chartControl1.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False;
            chartControl2.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False;
            chartControl1.MouseMove += OnMouseMove;
            chartControl2.MouseMove += OnMouseMove;
        }

        private void OnMouseMove(object sender, MouseEventArgs e) {
            ChartControl chart = sender as ChartControl;
            XYDiagram diagram = chart.Diagram as XYDiagram;
            DiagramCoordinates dCoord = diagram.PointToDiagram(e.Location);

            ShowOtherChartCrosshairAsync(chartControl1.Diagram as XYDiagram, dCoord);
            ShowOtherChartCrosshairAsync(chartControl2.Diagram as XYDiagram, dCoord);
        }

        private void ShowOtherChartCrosshairAsync(XYDiagram diagram, DiagramCoordinates dCoord) {
                if(!dCoord.IsEmpty)
                    diagram.ShowCrosshair(dCoord.NumericalArgument, dCoord.NumericalValue);
                else
                    diagram.ShowCrosshair(Point.Empty);
        }
    }
}
