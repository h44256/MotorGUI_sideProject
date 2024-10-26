using Parameters.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters.Factory
{
    public static class Factory
    {
        public static AbstractParameters createInstance(string str, IBaseParameters baseParam)
        {
            switch (str)
            {
                case "label_BusVolt":
                    return new BusVolt(baseParam);
                case "label_DcCur":
                    return new DcCur(baseParam);
                case "label_PhaseCur":
                    return new PhaseCur(baseParam);
                case "label_Speed":
                    return new Speed(baseParam);
                case "label_DriverTemp":
                    return new DriverTemp(baseParam);
                case "label_MotorTemp":
                    return new MotorTemp(baseParam);
                case "label_MotorAngle":
                    return new MotorAngle(baseParam);
                case "label_TPS":
                    return new TPS(baseParam);
            }
            return null;
        }
    }
}
