using Parameters.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    public class MotorAngle : AbstractParameters
    {
        private IBaseParameters _baseParameters;
        public MotorAngle(IBaseParameters instance)
        {
            _baseParameters = instance;
        }
        public override double getAdcValue()
        {
            return getRandomNumber(0, 4096) * gain;
        }
    }
}
