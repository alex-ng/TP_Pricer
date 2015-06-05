using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pricer
{
    public interface IInterpoler
    {
        double CalculateInterpolation(ArrayList header, ArrayList curve, double alpha);
    }
}
