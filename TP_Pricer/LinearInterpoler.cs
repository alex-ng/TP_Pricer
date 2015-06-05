using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TP_Pricer
{
    public class LinearInterpoler : IInterpoler
    {
        private double StringToInt(string str)
        {
            double res = -1.00;

            string tmp = Regex.Match(str, @"\d+").Value;
            res = Convert.ToDouble(tmp);
            return res;
        }

        //public double CalculateInterpolation(IRepository<RateCurve> rateCurve, double alpha, DateTime date)
        //{
        //    double acturialRate = 0.00;
        //    ArrayList header = (ArrayList)rateCurve.GetHeader();
        //    ArrayList curve = (ArrayList)rateCurve.GetListByDate(date);
        //    double x1, y1, x2, y2 = 0.00;
        //    int idx = 0;

        //    for (int i = 0; StringToInt(header[i].ToString()) < alpha; i++)
        //        idx++;

        //    x2 = StringToInt(header[idx + 1].ToString()) / 100;
        //    x1 = StringToInt(header[idx].ToString()) / 100;
        //    y2 = Convert.ToDouble(curve[idx + 1]);
        //    y1 = Convert.ToDouble(curve[idx]);

        //    acturialRate = ((x2 - alpha) / (x2 - x1) * y1) + ((alpha - x1) / (x2 - x1) * y2);

        //    return acturialRate;
        //}

        public double CalculateInterpolation(ArrayList header, ArrayList curve, double alpha)
        {
            double acturialRate = 0.00;
            double x1, y1, x2, y2 = 0.00;
            int idx = 0;

            for (int i = 0; StringToInt(header[i].ToString()) < alpha; i++)
                idx++;

            x2 = StringToInt(header[idx + 1].ToString()) / 100;
            x1 = StringToInt(header[idx].ToString()) / 100;
            y2 = Convert.ToDouble(curve[idx + 1]);
            y1 = Convert.ToDouble(curve[idx]);

            acturialRate = ((x2 - alpha) / (x2 - x1) * y1) + ((alpha - x1) / (x2 - x1) * y2);

            return acturialRate;
        }
    }
}
