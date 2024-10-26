using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters.Interface
{
    public interface IControlMode
    {
        void setControlModeTPS();
        //double getControlTPS(double tps, double adcTrans);
        double setControlModeDuty(double phaseCur, double duty, double angle);
    }
}
