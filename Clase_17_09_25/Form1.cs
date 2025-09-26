using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_17_09_25
{
    public partial class Form1 : Form
    {
        private BackForm backForm;
        // Campos privados en ProcessForm
        int startMouseX, startMouseY;
        int deltaX, deltaY;
        int initialTejoX, initialTejoY;
        double trajectoryX0, trajectoryY0;
        double velocityX, velocityY;
        double gravity = 9.8;
        double t = 0;

        public Form1()
        {
            InitializeComponent();
            
            // Crear y mostrar BackForm
            backForm = new BackForm();
            backForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            initialTejoX = TejopictureBox.Location.X;
            initialTejoY = TejopictureBox.Location.Y;
        }

        private void TejopictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startMouseX = e.X;
                startMouseY = e.Y;
            }
        }

        private void TejopictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int newY = TejopictureBox.Location.Y + e.Y - startMouseY;
                int newX = TejopictureBox.Location.X + e.X - startMouseX;
                TejopictureBox.Location = new Point(newX, newY);
                deltaX = initialTejoX - TejopictureBox.Location.X;
                deltaY = TejopictureBox.Location.Y - initialTejoY;
            }


        }

        private void TejopictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                trajectoryX0 = deltaX * -1;
                trajectoryY0 = deltaY * -1;
                velocityX = deltaX;
                velocityY = deltaY;
                t = 0; // Resetear tiempo
                timer1.Enabled = true;

                CalcParameters();
                
                // Iniciar seguimiento en tiempo real
                if (backForm != null)
                {
                    backForm.StartRealTimeTracking();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Calcular posición en la trayectoria
            double xt = velocityX * t + trajectoryX0;
            double yt = -0.5 * gravity * Math.Pow(t, 2) + velocityY * t +
            trajectoryY0;

            // Calcular velocidades actuales
            double currentVx = velocityX;
            double currentVy = velocityY - gravity * t;

            // Enviar datos a gráficos en tiempo real
            if (backForm != null)
            {
                backForm.AddDataPoint(t, xt, yt, currentVx, currentVy);
            }

            // Actualizar la posición del Tejo
            TejopictureBox.Location = new Point(
            initialTejoX + (int)xt,
            initialTejoY - (int)yt
            );
            
            // Detectar colisiones
            if (TejopictureBox.Bounds.IntersectsWith(GroundpictureBox.Bounds) || TejopictureBox.Bounds.IntersectsWith(WallpictureBox.Bounds)
                || TejopictureBox.Bounds.IntersectsWith(TowerpictureBox.Bounds) || TejopictureBox.Bounds.IntersectsWith(MousepictureBox.Bounds) )
            {
                timer1.Enabled = false;
            }
            // Avanzar tiempo
            t += 0.1;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            // Limpiar gráficas antes de reiniciar
            if (backForm != null)
            {
                backForm.ClearCharts();
            }
            Application.Restart();
        }

        private void CalcParameters()
        {
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


    }
}
