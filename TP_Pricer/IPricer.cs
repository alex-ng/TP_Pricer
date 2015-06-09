using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pricer
{
    public interface IPricer
    {
        double CalculateFullBond(Bond bond, DateTime pricingDate);
    }
}
