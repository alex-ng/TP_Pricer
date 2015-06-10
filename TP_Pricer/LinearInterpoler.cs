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

            if (alpha < 0.25)
                return rateCurve.Items[0].Rate;

            foreach (var item in rateCurve.Items)
            {
                if (item.Duration >= alpha)
                    break;
                idx++;
            }

            x1 = rateCurve.Items[idx - 1].Duration;
            x2 = rateCurve.Items[idx].Duration;
            y1 = rateCurve.Items[idx - 1].Rate;
            y2 = rateCurve.Items[idx].Rate;
            
            
            acturialRate = y1 + (alpha - x1) * (y2 - y1) / (x2 - x1);

            return acturialRate;
        }
    }
}
