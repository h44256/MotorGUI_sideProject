using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters.Interface
{
    public interface IPowerCur
    {
        //double setDcCur(double dcCurValue);
        double getDcCur(double power, double busVolt);
    }
}
