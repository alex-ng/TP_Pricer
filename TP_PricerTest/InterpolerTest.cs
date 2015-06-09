using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Pricer;

namespace TP_PricerTest
{
    [TestFixture]
    public class InterpolerTest
    {
        [Test]
        public void Calculate_Interpolation_On_Linear_RateCurve()
        {
            RateRepository repo = new RateRepository(TP_Pricer.DataRessources.tauxlineaire);
            Interpoler inter = new Interpoler(new LinearInterpoler());
            DateTime date = new DateTime(1993, 01, 01);

            RateCurve res = repo.GetRateCurveByDate(date);
            double acturial = inter.Calculate(res, 0.44);

            Assert.AreEqual(1.1, acturial);
        }

        [Test]
        public void Calculate_Interpolation_On_Normal_RateCurve()
        {
            RateRepository repo = new RateRepository(TP_Pricer.DataRessources.tauxtest);
            Interpoler inter = new Interpoler(new LinearInterpoler());
            DateTime date = new DateTime(1993, 01, 01);

            RateCurve res = repo.GetRateCurveByDate(date);
            double acturial =inter.Calculate(res, 0.44);

            Assert.AreEqual(0.00274500648, acturial);
        }
    }
}
