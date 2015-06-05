using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pricer
{
    public class Bond
    {
        public DateTime _emissionDate { get; private set; }
        public DateTime _maturity { get; private set; }
        public double _periodicity { get; private set; }
        public double _nominal { get; private set; }
        public double _rate { get; private set; }

        public Bond(DateTime emission, DateTime maturity, double periodicity,
            double nominal, double rate)
        {
            _emissionDate = emission;
            _maturity = maturity;
            _periodicity = periodicity;
            _nominal = nominal;
            _rate = rate;
        }
    }
}
