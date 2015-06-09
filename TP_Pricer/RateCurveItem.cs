using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_Pricer
{
    public class RateCurveItem
    {
        public double Duration { get; set; }
        public double Rate { get; set; }

        public RateCurveItem(double duration, double rate)
        {
            Duration = duration;
            Rate = rate;
        }
    }
}
