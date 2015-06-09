using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Globalization;
using DevExpress.Xpf.Charts;

namespace TP_Pricer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LineStackedSeries2D Initialized_Chart(DateTime pricingDate, DateTime maturity)
        {
            XYDiagram2D MyDiagram = new XYDiagram2D();
            RateCurveChart.Diagram = MyDiagram;

            LineStackedSeries2D series = new LineStackedSeries2D();

            MyDiagram.Series.Add(series);

            series.ArgumentScaleType = ScaleType.DateTime;

            MyDiagram.AxisX = new AxisX2D();
            MyDiagram.AxisY = new AxisY2D();

            MyDiagram.AxisX.WholeRange = new Range();
            MyDiagram.AxisY.WholeRange = new Range();

            MyDiagram.AxisX.WholeRange.SetMinMaxValues(pricingDate, maturity);
            MyDiagram.AxisY.WholeRange.SetMinMaxValues(90, 110);

            return series;
        }

        public MainWindow()
        {
            InitializeComponent();

            var repo = new RateRepository(TP_Pricer.DataRessources.taux2);
            var emissionDate = new DateTime(1993, 01, 01);
            var maturity = new DateTime(1994, 01, 01);
            var pricingDate = new DateTime(1993, 01, 04);
            var bond = new Bond(emissionDate, maturity, 0.5, 100, 0.05);
            var pr = new Pricer(bond, DataRessources.taux2);
            var p = new List<Point>();
            double res = 0;

            LineStackedSeries2D series = Initialized_Chart(pricingDate, maturity);

            while (pricingDate.CompareTo(maturity) <= 0)
            {
                res = pr.CalculateFullBond(bond, pricingDate);
                p.Add(new Point(pricingDate, res));
                pricingDate = pricingDate.AddMonths(6);
            }

            foreach (var point in p)
            {
                series.Points.Add(new SeriesPoint(point.date, point.value));
            }

        }

    }
}
