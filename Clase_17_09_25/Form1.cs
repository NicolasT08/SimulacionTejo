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
        
        // Variables para el sistema de rebotes
        int bounceCount = 0;
        const int maxBounces = 3;
        bool hasHitTarget = false;
        bool isBouncing = false; // Para evitar detección múltiple de colisiones
        
        // Variables para visualización de trayectoria
        private List<Point> trajectoryPoints = new List<Point>();
        private bool showTrajectory = false;
        private Timer trajectoryTimer;

        public Form1()
        {
            InitializeComponent();
            
            // Crear y mostrar BackForm
            backForm = new BackForm();
            backForm.Show();
            
            // Inicializar timer para trayectoria
            trajectoryTimer = new Timer();
            trajectoryTimer.Interval = 1500; // 1.5 segundos
            trajectoryTimer.Tick += (s, e) => {
                showTrajectory = false;
                trajectoryPoints.Clear();
                trajectoryTimer.Stop();
                this.Invalidate();
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            initialTejoX = TejopictureBox.Location.X;
            initialTejoY = TejopictureBox.Location.Y;

            GenerarObjetivo();
        }

        private void TejopictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startMouseX = e.X;
                startMouseY = e.Y;

                var (v0, angle, hasSolution) = CalcularDisparo(MousepictureBox.Location);

                // Calcular y dibujar trayectoria en Form1
                CalculateAndDrawTrajectory(MousepictureBox.Location, v0, angle, hasSolution);

                if (backForm != null)
                {
                    backForm.SetRecomendacion(v0, angle, hasSolution);
                }
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
                
                // No limpiar trayectoria inmediatamente - el timer la manejará
            }
        }

        private void GenerarObjetivo()
        {
            Random rnd = new Random();
            bool posicionValida = false;
            int x = 0, y = 0;

            while (!posicionValida)
            {
                x = rnd.Next(200, this.ClientSize.Width - MousepictureBox.Width - 50);
                y = rnd.Next(100, this.ClientSize.Height - MousepictureBox.Height - 100);

                Rectangle candidato = new Rectangle(x, y, MousepictureBox.Width, MousepictureBox.Height);

                if (!candidato.IntersectsWith(GroundpictureBox.Bounds) &&
                    !candidato.IntersectsWith(WallpictureBox.Bounds) &&
                    !candidato.IntersectsWith(TowerpictureBox.Bounds) &&
                    !candidato.IntersectsWith(TejopictureBox.Bounds))
                {
                    posicionValida = true;
                }
            }

            MousepictureBox.Location = new Point(x, y);
        }

        private (double v0, double angle, bool hasSolution) CalcularDisparo(Point objetivo)
        {
            double x0 = initialTejoX;
            double y0 = initialTejoY;

            double Xt = objetivo.X;
            double Yt = objetivo.Y;

            double dx = Xt - x0;
            double dy = y0 - Yt; // ojo con los signos en WinForms (eje Y hacia abajo)
            double g = 9.8;

            // Escoger un ángulo (ej: 45°)
            double angle = Math.PI / 4;

            double numerator = g * dx * dx;
            double denominator = 2 * Math.Cos(angle) * Math.Cos(angle) *
                                 (dx * Math.Tan(angle) - dy);

            bool hasSolution = denominator > 0;
            
            double v0 = hasSolution ? Math.Sqrt(numerator / denominator) : 0;

            return (v0, angle, hasSolution);
        }

        private void CalculateAndDrawTrajectory(Point objetivo, double v0, double angle, bool hasSolution)
        {
            if (!hasSolution)
            {
                trajectoryTimer.Stop(); // Detener timer si estaba corriendo
                showTrajectory = false;
                trajectoryPoints.Clear();
                this.Invalidate(); // Refrescar el formulario
                return;
            }

            // Calcular tiempo de impacto
            double g = 9.8;
            double v0x = v0 * Math.Cos(angle);
            double v0y = v0 * Math.Sin(angle);
            
            double dx = objetivo.X - initialTejoX;
            double dy = initialTejoY - objetivo.Y; // Invertir Y para WinForms

            // Resolver ecuación cuadrática para encontrar tiempo de impacto
            double a = -0.5 * g;
            double b = v0y;
            double c = -dy;

            double discriminant = b * b - 4 * a * c;
            if (discriminant < 0) return;

            double t1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double t2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            
            double impactTime = Math.Max(t1, t2);
            if (impactTime <= 0) return;

            // Generar puntos de la trayectoria
            trajectoryPoints.Clear();
            int numPoints = 50;
            
            for (int i = 0; i <= numPoints; i++)
            {
                double t = (double)i / numPoints * impactTime;
                double x = initialTejoX + v0x * t;
                double y = initialTejoY - (v0y * t - 0.5 * g * t * t); // Invertir Y para WinForms
                
                trajectoryPoints.Add(new Point((int)x, (int)y));
            }

            showTrajectory = true;
            
            // Iniciar timer para ocultar trayectoria después de 1.5 segundos
            trajectoryTimer.Stop(); // Detener timer anterior si existe
            trajectoryTimer.Start();
            
            this.Invalidate(); // Refrescar el formulario para dibujar la trayectoria
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            if (showTrajectory && trajectoryPoints.Count > 1)
            {
                using (Pen trajectoryPen = new Pen(Color.Blue, 2))
                {
                    // Dibujar la trayectoria teórica
                    e.Graphics.DrawLines(trajectoryPen, trajectoryPoints.ToArray());
                }
                
                // Dibujar punto de impacto
                if (trajectoryPoints.Count > 0)
                {
                    Point impactPoint = trajectoryPoints[trajectoryPoints.Count - 1];
                    using (Brush impactBrush = new SolidBrush(Color.Red))
                    {
                        e.Graphics.FillEllipse(impactBrush, impactPoint.X - 4, impactPoint.Y - 4, 8, 8);
                    }
                }
            }
        }

        private void HandleBounce()
        {
            if (bounceCount >= maxBounces)
            {
                timer1.Enabled = false;
                return;
            }

            isBouncing = true;

            // Reducir velocidad en 50%
            velocityX *= 0.5;
            velocityY *= 0.5;

            // Detectar qué tipo de superficie golpeó para invertir la velocidad correcta
            bool hitGround = TejopictureBox.Bounds.IntersectsWith(GroundpictureBox.Bounds);
            bool hitWall = TejopictureBox.Bounds.IntersectsWith(WallpictureBox.Bounds);
            bool hitTower = TejopictureBox.Bounds.IntersectsWith(TowerpictureBox.Bounds);

            if (hitGround)
            {
                // Si golpea el suelo, invertir velocidad Y (rebote vertical)
                velocityY = -velocityY;
            }
            else if (hitWall)
            {
                // Si golpea una pared, invertir velocidad X (rebote horizontal)
                velocityX = -velocityX;
            }
            else if (hitTower)
            {
                // Si golpea la torre, invertir ambas velocidades (rebote diagonal)
                velocityX = -velocityX;
                velocityY = -velocityY;
            }

            // Actualizar posición de referencia para nueva trayectoria
            trajectoryX0 = TejopictureBox.Location.X - initialTejoX;
            trajectoryY0 = initialTejoY - TejopictureBox.Location.Y;

            // Resetear tiempo para nueva trayectoria
            t = 0;
            
            // Incrementar contador de rebotes
            bounceCount++;

            // Actualizar gráficos en BackForm
            if (backForm != null)
            {
                backForm.CalcParameters(velocityX, velocityY, trajectoryX0, trajectoryY0);
            }

            // Resetear bandera de rebote después de un pequeño delay
            Timer bounceTimer = new Timer();
            bounceTimer.Interval = 100; // 100ms
            bounceTimer.Tick += (s, e) => {
                isBouncing = false;
                bounceTimer.Stop();
                bounceTimer.Dispose();
            };
            bounceTimer.Start();
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
                
                // Resetear variables de rebote para nuevo disparo
                bounceCount = 0;
                hasHitTarget = false;
                isBouncing = false;
                
                // Limpiar trayectoria al iniciar disparo
                trajectoryTimer.Stop(); // Detener timer de trayectoria
                showTrajectory = false;
                trajectoryPoints.Clear();
                
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
            
            // Detectar colisiones solo si no estamos en proceso de rebote
            if (!isBouncing)
            {
                bool hitGround = TejopictureBox.Bounds.IntersectsWith(GroundpictureBox.Bounds);
                bool hitWall = TejopictureBox.Bounds.IntersectsWith(WallpictureBox.Bounds);
                bool hitTower = TejopictureBox.Bounds.IntersectsWith(TowerpictureBox.Bounds);
                bool hitTarget = TejopictureBox.Bounds.IntersectsWith(MousepictureBox.Bounds);

                if (hitTarget)
                {
                    // Si golpea el objetivo, no rebota, se queda ahí
                    timer1.Enabled = false;
                    hasHitTarget = true;
                }
                else if (hitGround || hitWall || hitTower)
                {
                    // Si golpea un obstáculo y aún puede rebotar
                    if (bounceCount < maxBounces)
                    {
                        HandleBounce();
                    }
                    else
                    {
                        // Si ya no puede rebotar más, detener
                        timer1.Enabled = false;
                    }
                }
            }
            // Avanzar tiempo
            t += 0.1;
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            // Resetear variables de rebote
            bounceCount = 0;
            hasHitTarget = false;
            isBouncing = false;
            
            // Limpiar trayectoria
            trajectoryTimer.Stop(); // Detener timer de trayectoria
            showTrajectory = false;
            trajectoryPoints.Clear();
            
            // Limpiar gráficas antes de reiniciar
            if (backForm != null)
            {
                backForm.ClearCharts();
            }
            Application.Restart();
        }



    }
}
