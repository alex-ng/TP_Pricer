using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TP_Pricer
{
    public class RateCurve
    {
        public DateTime Date { get; set; }
        public List<RateCurveItem> Items { get; set; }

        public RateCurve(DateTime date, List<RateCurveItem> item)
        {
            Date = date;
            Items = item;

        }
    }
}
