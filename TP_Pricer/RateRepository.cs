using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;
using System.Reflection;

namespace TP_Pricer
{
    public class RateRepository : IRepository
    {
        DataTable _data = new DataTable();
        List<RateCurve> _rateCurve = new List<RateCurve>();

        public RateRepository(string data)
        {
            LoadData(data);
        }

        private double StringToDouble(string str)
        {
            double res = -1;

            string tmp = Regex.Match(str, @"\d+").Value;
            res = Convert.ToInt32(tmp);
            return res;
        }

        private void FillRateCurve()
        {
            var rows = _data.Rows;
            var columns = _data.Columns;
            DateTime date = new DateTime();
            string strDate;
            List<double> duration = new List<double>();
            List<double> rate = new List<double>();

            foreach (var col in columns.Cast<DataColumn>().Skip(1))
            {
                if (!col.ToString().Equals(" "))
                {
                    double durationValue = StringToDouble(col.ToString()) / 100;
                    duration.Add(durationValue);
                }
            }

            for (int keyIdx = 0; keyIdx < rows.Count; keyIdx++)
            {
                List<RateCurveItem> tmp = new List<RateCurveItem>();
                strDate = rows[keyIdx]["Date"].ToString();
                date = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                rate.Clear();

                foreach (var col in columns.Cast<DataColumn>().Skip(1))
                {
                    var val = rows[keyIdx][col.ToString()];
                    if (!val.Equals(" "))
                    {
                        if (val.Equals(" na"))
                            rate.Add(-1);
                        else
                            rate.Add(Convert.ToDouble(val.ToString().Replace('.', ',')));
                    }
                }

                for (int i = 0; i < duration.Count; i++)
                {
                    tmp.Add(new RateCurveItem(duration[i], rate[i]));
                }

                _rateCurve.Add(new RateCurve(date, tmp));
            }
        }

        private void LoadData(string data)
        {
            StringReader sr = new StringReader(data);
            string[] rows = sr.ReadLine().Split(';');
            string line;
            DataTable dt = new DataTable();
            foreach (string header in rows)
            {
                if (header != " ")
                    dt.Columns.Add(header);
            }
            while (true)
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    rows = line.Split(';');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < rows.Length - 1; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
                else
                    break;
            }
            _data = dt;
            FillRateCurve();
        }

        public RateCurve GetRateCurveByDate(DateTime date)
        {


            foreach (var item in _rateCurve)
            {
                if (date.CompareTo(new DateTime(2011, 07, 29)) > 0)
                    return _rateCurve.Last();
                if (item.Date.Equals(date) && !item.Items[0].Rate.Equals(-1))
                    return item;
            }
            return GetRateCurveByDate(date.AddDays(1));
        }
    }
}