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

            RateRepository repo = new RateRepository(TP_Pricer.DataRessources.taux2);
            //Interpoler inter = new Interpoler(new LinearInterpoler());
            DateTime emissionDate = new DateTime(1993, 01, 01);
            DateTime maturity = new DateTime(1994, 01, 01);
            DateTime pricingDate = new DateTime(1993, 01, 04);
            Bond bond = new Bond(emissionDate, maturity, 0.5, 100, 0.05);
            Pricer pr = new Pricer(bond, DataRessources.taux2);

            //RateCurve res = repo.GetRateCurveByDate(emissionDate);
            //double acturial = inter.Calculate(res, 0.44);

            double res = pr.CalculateFullBond(bond, pricingDate);
        }

    }
}
