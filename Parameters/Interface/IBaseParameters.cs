using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters.Interface
{
    public interface IBaseParameters
    {
        //BusVolt getBusVolt();
        //DcCur getDcCur();
        //DriverTemp getDriverTemp();
        //MotorAngle getMotorAngle();
        //MotorTemp getMotorTemp();
        //PhaseCur getPhaseCur();
        //Speed getSpeed();
        //TPS getTPS();

        AbstractParameters getBusVolt();
        AbstractParameters getDcCur();
        AbstractParameters getDriverTemp();
        AbstractParameters getMotorAngle();
        AbstractParameters getMotorTemp();
        AbstractParameters getPhaseCur();
        AbstractParameters getSpeed();
        AbstractParameters getTPS();

        //AbstractParameters getAbsParams(AbstractParameters someone);

    }
}
