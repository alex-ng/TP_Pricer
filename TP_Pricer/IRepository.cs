﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace TP_Pricer
{
    public interface IRepository
    {
        RateCurve GetRateCurveByDate(DateTime date);
    }
}
