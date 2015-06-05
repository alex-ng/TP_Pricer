using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;

namespace TP_Pricer
{
    public class RateRepository : IRepository<RateCurve>
    {
        private RateCurve _data;

        private void FillRateCurve(DataTable dt)
        {
            _data = new RateCurve();
            _data._rateCurve = new Hashtable();
            ArrayList _header = new ArrayList();
            var rows = dt.Rows;
            var columns = dt.Columns;
            DateTime date = new DateTime();
            string strDate;

            // Add Header of <string, ArrayList> into Hashtable
            foreach (var col in columns.Cast<DataColumn>().Skip(1))
            {
                if (!col.ToString().Equals(" "))
                    _header.Add(col.ToString());
            }
            _data._rateCurve.Add(columns[0].ToString(), _header);

            // Add Rate Curve of <Date, ArrayList> into Hashtable

            for (int keyIdx = 0; keyIdx < rows.Count; keyIdx++)
            {
                ArrayList tmp = new ArrayList();
                foreach (var col in columns.Cast<DataColumn>().Skip(1))
                {
                    var val = rows[keyIdx][col.ToString()];
                    if (!val.Equals(" "))
                    {
                        if (val.Equals(" na"))
                            tmp.Add(val.ToString());
                        else
                            tmp.Add(Convert.ToDouble(val.ToString().Replace('.', ',')));
                    }
                }
                strDate = rows[keyIdx]["Date"].ToString();
                date = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                _data._rateCurve.Add(date, tmp);
            }
        }

        public void LoadFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string[] headers = sr.ReadLine().Split(';');
            DataTable dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(';');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            FillRateCurve(dt);
        }

        public RateCurve GetAll()
        {
            return _data;
        }

        public Object GetListByDate(DateTime date)
        {
            return _data._rateCurve[date];
        }

        public Object GetHeader()
        {
            return _data._rateCurve["Date"];
        }
    }
}