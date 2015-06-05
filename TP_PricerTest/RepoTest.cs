using NUnit.Framework;
using System;
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
        //[Test]
        //public void Load_CSV_Into_Datatable_Got_Right_Column()
        //{
        //    string path = "taux2.csv";

        //    RateRepository repo = new RateRepository();
        //    repo.LoadCSVFile(path);
        //    var row = repo._data.Rows;
        //    var col = repo._data.Columns;

        //    var tmp = row[1]["Date"].ToString();

        //    DateTime date = new DateTime();
        //    //date = DateTime.ParseExact(tmp, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    Assert.AreEqual(" ZC025YR", col[1].ToString());
        //}

        //[Test]
        //public void Load_CSV_Into_Datatable_Got_Right_Date()
        //{
        //    string path = "taux2.csv";

        //    RateRepository repo = new RateRepository();
        //    repo.LoadCSVFile(path);
        //    var row = repo._data.Rows;
        //    var col = repo._data.Columns;

        //    var tmp = row[1]["Date"].ToString();

        //    DateTime date = new DateTime();
        //    date = DateTime.ParseExact(tmp, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    DateTime totest = new DateTime(1993, 01, 04);

        //    Assert.AreEqual(String.Format("dd/MM/yyyy", totest), String.Format("dd/MM/yyyy", date));
        //}

        //[Test]
        //public void Load_CSV_Into_Datatable_Got_Right_Value_At_Date_And_Periodicity()
        //{
        //    string path = "taux2.csv";

        //    RateRepository repo = new RateRepository();
        //    repo.LoadCSVFile(path);
        //    var row = repo._data.Rows;
        //    var col = repo._data.Columns;

        //    Assert.AreEqual(" 0.0680790380", row[1][" ZC025YR"]);
        //}

        //[Test]
        //public void __()
        //{
        //    string path = "taux2.csv";

        //    RateRepository repo = new RateRepository();
        //    repo.LoadCSVFile(path);
        //    var row = repo._data.Rows;
        //    var col = repo._data.Columns;

        //    var tmp = row[1]["Date"].ToString();

        //    //DateTime date = new DateTime();
        //    //date = DateTime.ParseExact(tmp, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    Assert.AreEqual(25, repo.StringToInt(col[1].ToString()));
        //}

    }
}
 