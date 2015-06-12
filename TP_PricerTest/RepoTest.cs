using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Pricer;


namespace TP_PricerTest
{
    [TestFixture]
    public class RepoTest
    {
        [Test]
        public void Repo_Get_RateCurve_By_Date()
        {
            var repo = new RateRepository(TP_Pricer.DataRessources.tauxtest);
            var date = new DateTime(1993, 01, 01);

            RateCurve res = repo.GetRateCurveByDate(date);

            Assert.AreEqual(0.0030135, res.Items[1].Rate);
        }

        [Test]
        public void Repo_Get_RateCurve_By_Date_With_Non_Existing_Date()
        {
            var repo = new RateRepository(TP_Pricer.DataRessources.tauxtest);
            var date = new DateTime(1993, 01, 04);
            var expectedDate = new DateTime(1993, 01, 03);

            RateCurve res = repo.GetRateCurveByDate(date);

            Assert.AreEqual(expectedDate, res.Date);
        }

        [Test]
        public void Repo_Get_RateCurve_By_Date_With_Rate_Equals_To_NA()
        {
            var repo = new RateRepository(TP_Pricer.DataRessources.tauxtest);
            var date = new DateTime(1993, 01, 02);
            var expectedDate = new DateTime(1993, 01, 03);

            RateCurve res = repo.GetRateCurveByDate(date);

            Assert.AreEqual(expectedDate, res.Date);
        }
    }
}
