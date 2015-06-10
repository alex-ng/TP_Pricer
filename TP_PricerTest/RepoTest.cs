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
            RateRepository repo = new RateRepository(TP_Pricer.DataRessources.tauxtest);
            DateTime date = new DateTime(1993, 01, 01);
            List<RateCurveItem> list = new List<RateCurveItem>();
            list.Add(new RateCurveItem(0.25, 1.1));
            list.Add(new RateCurveItem(0.50, 1.1));

            RateCurve r = new RateCurve(date, list);
            RateCurve res = repo.GetRateCurveByDate(date);

            Assert.AreEqual(0.0030135, res.Items[1].Rate);
        }
    }
}
