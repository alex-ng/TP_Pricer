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

        public Pricer(Bond spec, string data)
        {
            BondSpec = new Bond(spec.EmissionDate, spec.Maturity, spec.Periodicity, spec.Nominal, spec.Rate);
            Inter = new Interpoler(new LinearInterpoler());
            Repo = new RateRepository(data);
        }

        private double CalculateCouponValue()
        {
            return (BondSpec.Nominal * BondSpec.Rate * BondSpec.Periodicity);
        }

        private double CalculateAlphaValue(Bond bond, DateTime pricingDate)
        {
            double res = 0;
            double month = 12 * bond.Periodicity;

            res = (bond.EmissionDate.AddMonths(Convert.ToInt32(month)) - pricingDate).TotalDays / 365;

            return res;
        }

        private int CountTillMaturity(Bond bond, DateTime pricingDate)
        {
            int count = 0;
            int month = Convert.ToInt32(12 * bond.Periodicity);

            while (pricingDate.CompareTo(bond.Maturity) < 0)
            {
               pricingDate = pricingDate.AddMonths(month);
               count++;
            }
            return count;
        }

        public double CalculateFullBond(Bond bond, DateTime pricingDate)
        {
            double res = 0;
            double indice = 0;
            double couponValue = CalculateCouponValue();
            RateCurve currentRateCurve = Repo.GetRateCurveByDate(pricingDate);
            double alpha = CalculateAlphaValue(bond, pricingDate);

            int count = CountTillMaturity(bond, pricingDate);

            while (count != 0)
            {
                double acturialRate = Math.Round(Inter.Calculate(currentRateCurve, indice + alpha), 2);
                if (count == 1)
                    res += (bond.Nominal + couponValue) / Math.Pow((1 + acturialRate), indice + alpha);
                else
                    res += couponValue / Math.Pow((1 + acturialRate), indice + alpha);
                indice += bond.Periodicity;
                count--;
            }
            return Math.Round(res, 2);
        }

    }
}
