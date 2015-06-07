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
        public void Load_CSV_File_GetHeader()
        {
            string path = "tauxlineaire.csv";
            IRepository<RateCurve> repo = new RateRepository();
            repo.LoadFile(path);

            ArrayList header = (ArrayList)repo.GetHeader();
            ArrayList tmp = new ArrayList();
            tmp.Add(" ZC025YR");
            tmp.Add(" ZC050YR");

            Assert.AreEqual(tmp, header);
        }

        [Test]
        public void Load_CSV_File_GetValue()
        {
            string path = "tauxlineaire.csv";
            IRepository<RateCurve> repo = new RateRepository();
            repo.LoadFile(path);

            DateTime date = new DateTime(1993, 01, 01);

            ArrayList curve = (ArrayList)repo.GetListByDate(date);
            ArrayList tmp = new ArrayList();
            tmp.Add("1.1");
            tmp.Add("1.1");

            Assert.AreEqual(tmp, curve);
        }
    }
}
 