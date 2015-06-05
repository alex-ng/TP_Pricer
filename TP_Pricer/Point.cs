using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pricer
{
    public class Point
    {
        public DateTime date { get; set; }
        public double value { get; set; }

        public Point(DateTime date, double value)
        {
            this.date = date;
            this.value = value;
 
        }
    }
}
