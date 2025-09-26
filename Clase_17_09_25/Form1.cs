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

                // Calcular parámetros y mostrar en BackForm
                if (backForm != null)
                {
                    backForm.CalcParameters(velocityX, velocityY, trajectoryX0, trajectoryY0);
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



    }
}
