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
        public void Check_Calculate_Interpoler_Value_On_Linear_Rate()
        {
            string path = "tauxlineaire.csv";
            IRepository<RateCurve> repo = new RateRepository();
            Interpoler inter = new Interpoler(new LinearInterpoler);
            repo.LoadFile(path);
            DateTime date = new DateTime(1993, 01, 01);
            ArrayList curve = (ArrayList)repo.GetListByDate(date);
            ArrayList header = (ArrayList)repo.GetHeader();

            double res = inter.Calculate(header, curve, 0.44);
            Assert.AreEqual(1.1, res);
        }
    }
}
