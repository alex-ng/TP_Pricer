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
        public double CalculateInterpolation(RateCurve rateCurve, double alpha)
        {
            double acturialRate = 0.00;
            double x1, y1, x2, y2 = 0.00;
            int idx = 0;

            foreach (var item in rateCurve.Items)
            {
                if (item.Duration < alpha)
                    break;
                idx++;
            }

            if (idx == 120)
                idx = 0;

            x1 = rateCurve.Items[idx].Duration;
            x2 = rateCurve.Items[idx + 1].Duration;
            y1 = rateCurve.Items[idx].Rate;
            y2 = rateCurve.Items[idx + 1].Rate;
            
            
            acturialRate = ((x2 - alpha) / (x2 - x1) * y1) + ((alpha - x1) / (x2 - x1) * y2);

            return acturialRate;
        }
    }
}
