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

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
