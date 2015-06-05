using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Pricer
{
    public class Interpoler
    {
        private IInterpoler strategy;

        public Interpoler(IInterpoler strat)
        {
            this.strategy = strat;
        }

        public double Calculate(ArrayList header, ArrayList curve, double alpha)
        {
            return strategy.CalculateInterpolation(header, curve, alpha);
        }
    }
}
