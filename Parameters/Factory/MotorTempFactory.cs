﻿using Parameters.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters.Factory
{
    public class MotorTempFactory : IParamFactory
    {
        public AbstractParameters createParam(IBaseParameters baseParam)
        {
            return new MotorTemp(baseParam);
        }
    }
}
