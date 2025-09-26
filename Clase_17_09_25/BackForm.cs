using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Clase_17_09_25
{
    public partial class BackForm : Form
    {
        private ChartGenerator chartGenerator;
        
        public BackForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            
            // Inicializar el generador de gráficas
            Chart[] charts = { chartYvsT, chart2, chart3, chart4, chart5, chart6, chartAnglevsT };
            chartGenerator = new ChartGenerator(charts);
        }
        private void BackForm_MouseDown(object sender, MouseEventArgs e)
        {
            var processForm = Application.OpenForms["ProcessForm"];
            processForm?.BringToFront();
        }

        private void BackForm_Load(object sender, EventArgs e)
        {

        }

        private void chart5_Click(object sender, EventArgs e)
        {

        }

        // Método público para generar gráficas desde Form1
        public void GenerateCharts(double velocityX, double velocityY, double initialX, double initialY)
        {
            chartGenerator.GenerateCharts(velocityX, velocityY, initialX, initialY);
        }

        // Método público para iniciar seguimiento en tiempo real
        public void StartRealTimeTracking()
        {
            chartGenerator.StartRealTimeTracking();
        }

        // Método público para agregar datos en tiempo real
        public void AddDataPoint(double time, double x, double y, double vx, double vy)
        {
            chartGenerator.AddDataPoint(time, x, y, vx, vy);
        }

        // Método público para limpiar gráficas
        public void ClearCharts()
        {
            chartGenerator.ClearCharts();
        }

        // Método para calcular y mostrar parámetros en los DataGridViews
        public void CalcParameters(double velocityX, double velocityY, double trajectoryX0, double trajectoryY0)
        {
            double gravity = 9.8;
            double v0x = velocityX;
            double v0y = velocityY;
            double v0 = Math.Sqrt(v0x * v0x + v0y * v0y);
            double thetaRad = Math.Atan2(v0y, v0x);
            double thetaDeg = thetaRad * (180.0 / Math.PI);

            double a = -0.5 * gravity;
            double b = v0y;
            double c = trajectoryY0;

            double T = double.NaN;
            
            if (Math.Abs(a) > 1e-9)
            {
                double D = b * b - 4 * a * c;
                if (D >= 0)
                {
                    double sqrtD = Math.Sqrt(D);
                    double t1 = (-b + sqrtD) / (2 * a);
                    double t2 = (-b - sqrtD) / (2 * a);

                    double tPos = -1;
                    if (t1 > 1e-9) tPos = t1;
                    if (t2 > 1e-9 && t2 > tPos) tPos = t2;
                    if (tPos > 0) T = tPos;
                }
            }
            else
            {
                if (Math.Abs(b) > 1e-9)
                {
                    double t = -c / b;
                    if (t > 1e-9) T = t;
                }
            }

            double R = double.NaN;
            if (!double.IsNaN(T)) R = v0x * T;

            double tVertex = v0y / gravity;
            double yMax = -0.5 * gravity * tVertex * tVertex + v0y * tVertex + trajectoryY0;

            double vxMax = v0x;
            double vyMax = v0y - gravity * tVertex;
            double vMagMax = Math.Sqrt(vxMax * vxMax + vyMax * vyMax);
            double angMax = Math.Atan2(vyMax, vxMax) * (180.0 / Math.PI);

            double vfx = double.NaN, vfy = double.NaN, vMagFinal = double.NaN, angFinal = double.NaN;
            if (!double.IsNaN(T))
            {
                vfx = v0x;
                vfy = v0y - gravity * T;
                vMagFinal = Math.Sqrt(vfx * vfx + vfy * vfy);
                angFinal = Math.Atan2(vfy, vfx) * (180.0 / Math.PI);
            }

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            dataGridView1.Rows.Add(
                $"{v0:F2} m/s ({v0x:F2}, {v0y:F2}) {thetaDeg:F1}°",
                double.IsNaN(T) ? "No impacto" : $"{T:F2} s",
                double.IsNaN(R) ? "-" : $"{R:F2} m",
                $"{yMax:F2} m",
                double.IsNaN(vMagFinal) ? "-" : $"{vMagFinal:F2} m/s ({vfx:F2}, {vfy:F2}) {angFinal:F1}°"
            );

            dataGridView2.Rows.Add(
                $"{vMagMax:F2} m/s",
                $"{vxMax:F2} m/s",
                $"{vyMax:F6} m/s",
                $"{vMagMax:F2} m/s",
                $"{angMax:F6}°"
            );
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
