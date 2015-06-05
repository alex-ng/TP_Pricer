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

namespace TP_Pricer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DateTime emission = new DateTime(1993, 01, 01);
            DateTime maturity = new DateTime(1993, 07, 01);
            DateTime princingDate = new DateTime(1993, 01, 04);
            Pricer pr = new Pricer(emission, maturity, 0.5, 100.0, 0.05);
            ArrayList header = (ArrayList)pr._repo.GetHeader();
            ArrayList curve = (ArrayList)pr._repo.GetListByDate(emission);


            //double test = pr._interpoler.Calculate(header, curve, 0.44);

            //var tmp = pr._repo.GetAll();

            //var tmp2 = tmp._rateCurve[emission];

            var tmp = pr.CalulateFullBond(emission, princingDate);

            //double res = (maturity - emission).TotalDays;

            //double alpha = res / 365.0;
        }
    }
}
