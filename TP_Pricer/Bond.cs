using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pricer
{
    public class Bond
    {
        public DateTime EmissionDate { get; private set; }
        public DateTime Maturity { get; private set; }
        public double Periodicity { get; private set; }
        public double Nominal { get; private set; }
        public double Rate { get; private set; }
        public double Alpha { get; set; }

        public Bond(DateTime emission, DateTime maturity, double periodicity,
            double nominal, double rate)
        {
            EmissionDate = emission;
            Maturity = maturity;
            Periodicity = periodicity;
            Nominal = nominal;
            Rate = rate;
        }
    }
}
