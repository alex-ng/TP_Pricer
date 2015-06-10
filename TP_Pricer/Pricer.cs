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
        public Bond BondSpec { get; private set; }
        public Interpoler Inter { get; private set; }
        public RateRepository Repo { get; private set; }

        public Pricer(Bond spec, string data, DateTime pricingDate)
        {
            BondSpec = new Bond(spec.EmissionDate, spec.Maturity, spec.Periodicity, spec.Nominal, spec.Rate);
            Inter = new Interpoler(new LinearInterpoler());
            Repo = new RateRepository(data);
            BondSpec.Alpha = (BondSpec.EmissionDate.AddMonths(Convert.ToInt32(12*BondSpec.Periodicity)) - pricingDate).TotalDays / 365;
        }

        private double CalculateCouponValue()
        {
            return (BondSpec.Nominal * BondSpec.Rate * BondSpec.Periodicity);
        }

        private int CountTillMaturity(Bond bond, DateTime pricingDate)
        {
            double count = ((bond.Maturity - pricingDate).TotalDays / 365) / bond.Periodicity;

            return Convert.ToInt32(count);
        }

        public double CalculateFullBond(Bond bond, DateTime pricingDate)
        {
            double res = 0;
            double indice = 0;
            double couponValue = CalculateCouponValue();
            RateCurve currentRateCurve = Repo.GetRateCurveByDate(pricingDate);
            double alpha = BondSpec.Alpha;

            int count = CountTillMaturity(bond, pricingDate);

            for (int i = 0; i <= count; i++)
            {
                double acturialRate = Inter.Calculate(currentRateCurve, indice + alpha);
                if (i == count)
                    res += Math.Round((bond.Nominal + couponValue) / Math.Pow((1 + acturialRate), (indice + alpha)), 2);
                else
                    res += Math.Round(couponValue / Math.Pow((1 + acturialRate), (indice + alpha)), 2);
                indice += bond.Periodicity;
            }
            return res;
        }

    }
}
