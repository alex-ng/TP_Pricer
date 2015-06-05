using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TP_Pricer
{
    public class Pricer : IPricer
    {
        public Bond _bond { get; private set; }
        public Interpoler _interpoler { get; private set; }
        public IRepository<RateCurve> _repo { get; private set; }

        public Pricer(DateTime emission, DateTime maturity, double periodicity,
            double nominal, double rate)
        {
            _bond = new Bond(emission, maturity, periodicity, nominal, rate);
            _interpoler = new Interpoler(new LinearInterpoler());
            _repo = new RateRepository();
            _repo.LoadFile("tauxtest.csv");
            //_repo.LoadFile("taux2.csv");
            //_repo.LoadFile("tauxlineaire.csv");
        }

        private double StringToInt(string str)
        {
            double res = -1.00;

            string tmp = Regex.Match(str, @"\d+").Value;
            res = Convert.ToDouble(tmp);
            return res;
        }

        private double CalculateCouponValue()
        {
            return (_bond._nominal * _bond._rate * _bond._periodicity);
        }

        private double CalculateBond(double acturialRate)
        {
            return 1.00;
        }

        public double CalulateFullBond(DateTime pricingDate)
        {
            double result = 0.00;
            ArrayList header = (ArrayList)_repo.GetHeader();
            ArrayList curve = (ArrayList)_repo.GetListByDate(pricingDate);

            

            return result;
        }
    }
}
