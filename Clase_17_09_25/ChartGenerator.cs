using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Clase_17_09_25
{
    public class ChartGenerator
    {
        private Chart[] charts;
        private double gravity = 9.8;
        private double timeStep = 0.1;
        private double maxTime = 10.0; // Tiempo máximo para las gráficas

        // Listas para almacenar datos en tiempo real
        private List<double> timeData = new List<double>();
        private List<double> xData = new List<double>();
        private List<double> yData = new List<double>();
        private List<double> vxData = new List<double>();
        private List<double> vyData = new List<double>();
        private List<double> magnitudeData = new List<double>();
        private List<double> angleData = new List<double>();

        public ChartGenerator(Chart[] chartArray)
        {
            charts = chartArray;
            InitializeCharts();
        }

        private void InitializeCharts()
        {
            string[] chartTitles = {
                "y vs t (Posición Vertical)",
                "x vs t (Posición Horizontal)", 
                "y vs x (Trayectoria)",
                "vx vs t (Velocidad Horizontal)",
                "vy vs t (Velocidad Vertical)",
                "|v| vs t (Magnitud de Velocidad)",
                "θ vs t (Ángulo de Velocidad)"
            };

            for (int i = 0; i < charts.Length && i < chartTitles.Length; i++)
            {
                charts[i].Series.Clear();
                charts[i].ChartAreas.Clear();
                charts[i].Legends.Clear();
                charts[i].Titles.Clear();
                
                // Configurar área del gráfico
                ChartArea chartArea = new ChartArea();
                chartArea.Name = "ChartArea1";
                chartArea.AxisX.Title = GetXAxisTitle(i);
                chartArea.AxisY.Title = GetYAxisTitle(i);
                chartArea.AxisX.MajorGrid.Enabled = true;
                chartArea.AxisY.MajorGrid.Enabled = true;
                charts[i].ChartAreas.Add(chartArea);

                // Configurar serie
                Series series = new Series();
                series.Name = GetSeriesName(i);
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 2;
                series.Color = System.Drawing.Color.Blue;
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 3;
                series.IsVisibleInLegend = false; // Ocultar de la leyenda
                charts[i].Series.Add(series);

                // Configurar leyenda (vacía para ocultar "Series1")
                Legend legend = new Legend();
                legend.Name = "Legend1";
                legend.Enabled = false; // Deshabilitar leyenda completamente
                charts[i].Legends.Add(legend);

                // Título del gráfico
                Title title = new Title(chartTitles[i]);
                title.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                charts[i].Titles.Add(title);
            }
        }

        private string GetXAxisTitle(int chartIndex)
        {
            switch (chartIndex)
            {
                case 0: return "Tiempo (s)";
                case 1: return "Tiempo (s)";
                case 2: return "Posición X (m)";
                case 3: return "Tiempo (s)";
                case 4: return "Tiempo (s)";
                case 5: return "Tiempo (s)";
                case 6: return "Tiempo (s)";
                default: return "X";
            }
        }

        private string GetYAxisTitle(int chartIndex)
        {
            switch (chartIndex)
            {
                case 0: return "Posición Y (m)";
                case 1: return "Posición X (m)";
                case 2: return "Posición Y (m)";
                case 3: return "Velocidad X (m/s)";
                case 4: return "Velocidad Y (m/s)";
                case 5: return "Magnitud |v| (m/s)";
                case 6: return "Ángulo θ (°)";
                default: return "Y";
            }
        }

        private string GetSeriesName(int chartIndex)
        {
            switch (chartIndex)
            {
                case 0: return "Posición Vertical";
                case 1: return "Posición Horizontal";
                case 2: return "Trayectoria";
                case 3: return "Velocidad Horizontal";
                case 4: return "Velocidad Vertical";
                case 5: return "Magnitud de Velocidad";
                case 6: return "Ángulo de Velocidad";
                default: return "Serie";
            }
        }

        public void GenerateCharts(double velocityX, double velocityY, double initialX, double initialY)
        {
            // Calcular tiempo de vuelo
            double flightTime = CalculateFlightTime(velocityY, initialY);
            if (flightTime <= 0) flightTime = maxTime;

            // Limpiar datos existentes
            foreach (Chart chart in charts)
            {
                if (chart.Series.Count > 0)
                    chart.Series[0].Points.Clear();
            }

            // Generar datos para cada gráfico
            for (double t = 0; t <= Math.Min(flightTime, maxTime); t += timeStep)
            {
                // Calcular posición y velocidad en el tiempo t
                double x = velocityX * t + initialX;
                double y = -0.5 * gravity * t * t + velocityY * t + initialY;
                double vx = velocityX;
                double vy = velocityY - gravity * t;
                double vMagnitude = Math.Sqrt(vx * vx + vy * vy);
                double angle = Math.Atan2(vy, vx) * (180.0 / Math.PI);

                // Agregar puntos a cada gráfico
                if (charts.Length > 0) charts[0].Series[0].Points.AddXY(t, y); // y vs t
                if (charts.Length > 1) charts[1].Series[0].Points.AddXY(t, x); // x vs t
                if (charts.Length > 2) charts[2].Series[0].Points.AddXY(x, y); // y vs x
                if (charts.Length > 3) charts[3].Series[0].Points.AddXY(t, vx); // vx vs t
                if (charts.Length > 4) charts[4].Series[0].Points.AddXY(t, vy); // vy vs t
                if (charts.Length > 5) charts[5].Series[0].Points.AddXY(t, vMagnitude); // |v| vs t
                if (charts.Length > 6) charts[6].Series[0].Points.AddXY(t, angle); // θ vs t
            }

            // Ajustar escalas automáticamente
            foreach (Chart chart in charts)
            {
                if (chart.Series.Count > 0 && chart.Series[0].Points.Count > 0)
                {
                    chart.ChartAreas[0].RecalculateAxesScale();
                }
            }
        }

        // Método para agregar datos en tiempo real desde Form1
        public void AddDataPoint(double time, double x, double y, double vx, double vy)
        {
            timeData.Add(time);
            xData.Add(x);
            yData.Add(y);
            vxData.Add(vx);
            vyData.Add(vy);
            
            double vMagnitude = Math.Sqrt(vx * vx + vy * vy);
            double angle = Math.Atan2(vy, vx) * (180.0 / Math.PI);
            magnitudeData.Add(vMagnitude);
            angleData.Add(angle);

            // Actualizar gráficos en tiempo real
            UpdateCharts();
        }

        // Método para actualizar gráficos con datos reales
        private void UpdateCharts()
        {
            if (timeData.Count == 0) return;

            // Limpiar gráficos
            foreach (Chart chart in charts)
            {
                if (chart.Series.Count > 0)
                    chart.Series[0].Points.Clear();
            }

            // Agregar todos los datos reales
            for (int i = 0; i < timeData.Count; i++)
            {
                if (charts.Length > 0) charts[0].Series[0].Points.AddXY(timeData[i], yData[i]); // y vs t
                if (charts.Length > 1) charts[1].Series[0].Points.AddXY(timeData[i], xData[i]); // x vs t
                if (charts.Length > 2) charts[2].Series[0].Points.AddXY(xData[i], yData[i]); // y vs x
                if (charts.Length > 3) charts[3].Series[0].Points.AddXY(timeData[i], vxData[i]); // vx vs t
                if (charts.Length > 4) charts[4].Series[0].Points.AddXY(timeData[i], vyData[i]); // vy vs t
                if (charts.Length > 5) charts[5].Series[0].Points.AddXY(timeData[i], magnitudeData[i]); // |v| vs t
                if (charts.Length > 6) charts[6].Series[0].Points.AddXY(timeData[i], angleData[i]); // θ vs t
            }

            // Ajustar escalas automáticamente
            foreach (Chart chart in charts)
            {
                if (chart.Series.Count > 0 && chart.Series[0].Points.Count > 0)
                {
                    chart.ChartAreas[0].RecalculateAxesScale();
                }
            }
        }

        // Método para iniciar seguimiento en tiempo real
        public void StartRealTimeTracking()
        {
            // Limpiar datos anteriores
            timeData.Clear();
            xData.Clear();
            yData.Clear();
            vxData.Clear();
            vyData.Clear();
            magnitudeData.Clear();
            angleData.Clear();

            // Limpiar gráficos
            foreach (Chart chart in charts)
            {
                if (chart.Series.Count > 0)
                    chart.Series[0].Points.Clear();
            }
        }

        private double CalculateFlightTime(double velocityY, double initialY)
        {
            // Resolver ecuación cuadrática: y = -0.5*g*t² + v0y*t + y0 = 0
            double a = -0.5 * gravity;
            double b = velocityY;
            double c = initialY;

            double discriminant = b * b - 4 * a * c;
            if (discriminant < 0) return maxTime; // No hay solución real

            double t1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double t2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

            // Retornar el tiempo positivo más pequeño
            if (t1 > 0 && t2 > 0)
                return Math.Min(t1, t2);
            else if (t1 > 0)
                return t1;
            else if (t2 > 0)
                return t2;
            else
                return maxTime;
        }

        public void ClearCharts()
        {
            // Limpiar datos
            timeData.Clear();
            xData.Clear();
            yData.Clear();
            vxData.Clear();
            vyData.Clear();
            magnitudeData.Clear();
            angleData.Clear();

            // Limpiar gráficos
            foreach (Chart chart in charts)
            {
                if (chart.Series.Count > 0)
                    chart.Series[0].Points.Clear();
            }
        }
    }
}
