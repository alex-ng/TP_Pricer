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
        public List<Point> _point { get; private set; }

        public Pricer(DateTime emission, DateTime maturity, double periodicity,
            double nominal, double rate)
        {
            _bond = new Bond(emission, maturity, periodicity, nominal, rate);
            _interpoler = new Interpoler(new LinearInterpoler());
            _repo = new RateRepository();
            //_repo.LoadFile("tauxtest.csv");
            _repo.LoadFile("taux2.csv");
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

        public double CalulateFullBond(DateTime date, DateTime pricingDate)
        {
            double result = 0.00;
            ArrayList header = (ArrayList)_repo.GetHeader();
            ArrayList curve = (ArrayList)_repo.GetListByDate(pricingDate);
            double bondValue = CalculateCouponValue();
            double month = 12 * _bond._periodicity;
            double alpha = (date.AddMonths(Convert.ToInt32(month)) - pricingDate).TotalDays / 365;
            double periodicity = 0;

            for (int i = 0; i < header.Count; i++)
            {
                double indice = StringToInt(header[i].ToString()) / 100;
                if (indice > (periodicity + alpha))
                {
                    double acturialRate = _interpoler.Calculate(header, curve, (periodicity + alpha));
                    if (i == header.Count - 1)
                        result += (_bond._nominal + bondValue) / Math.Pow((1 + acturialRate), periodicity + alpha);
                    else
                        result += bondValue / Math.Pow((1 + acturialRate), periodicity + alpha);
                    periodicity += _bond._periodicity;
                }
            }
               
            return result;
        }

        public void CalculateFullBondToMaturity(DateTime date, DateTime pricingDate)
        {
            while (date.CompareTo(_bond._maturity) > 0)
            {
                date.AddMonths(Convert.ToInt32(12 * _bond._periodicity));
            }
        }
    }
}
