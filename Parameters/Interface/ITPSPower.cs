using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters.Interface
{
    public interface ITPSPower
    {
        double setTPS(double tpsValue);
        /// <summary>
        /// 用來得到MotorPower
        /// </summary>
        /// <param name="_tps">目前油門</param>
        /// <param name="adcTrans">油門的ADC轉換值</param>
        /// <returns></returns>
        double getPower(double _tps, double adcTrans);
    }
}
