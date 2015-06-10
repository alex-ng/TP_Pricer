using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Pricer;

namespace TP_PricerTest
{
    [TestFixture]
    public class PricerTest
    {
        [Test]
        public void Test_Calulate_FullBond()
        {
            RateRepository repo = new RateRepository(TP_Pricer.DataRessources.taux2);
            DateTime emissionDate = new DateTime(1993, 01, 01);
            DateTime maturity = new DateTime(1994, 01, 01);
            DateTime pricingDate = new DateTime(1993, 01, 04);
            Bond bond = new Bond(emissionDate, maturity, 0.5, 100, 0.05);
            Pricer pr = new Pricer(bond, DataRessources.taux2, pricingDate);

            double res = pr.CalculateFullBond(bond, pricingDate);
            Assert.AreEqual(97.34, res);
        }

        [Test]
        public void Test_Calulate_FullBond_At_Empty_Date()
        {
            RateRepository repo = new RateRepository(TP_Pricer.DataRessources.taux2);
            DateTime emissionDate = new DateTime(1993, 01, 01);
            DateTime maturity = new DateTime(1994, 01, 01);
            DateTime pricingDate = new DateTime(1993, 01, 01);
            Bond bond = new Bond(emissionDate, maturity, 0.5, 100, 0.05);
            Pricer pr = new Pricer(bond, DataRessources.taux2, pricingDate);

            double res = pr.CalculateFullBond(bond, pricingDate);
            Assert.AreEqual(97.29, res);
        }
    }
}
