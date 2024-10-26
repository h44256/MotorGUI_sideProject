using Parameters.Factory;
using Parameters.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    public class BaseParameters : AbstractParameters, IBaseParameters
    {
        public AbstractParameters busVolt;
        public AbstractParameters dcCur;
        public AbstractParameters phaseCur;
        public AbstractParameters speed;
        public AbstractParameters driverTemp;
        public AbstractParameters motorTemp;
        public AbstractParameters motorAngle;
        public AbstractParameters tps;
        public BaseParameters() 
        {
            IParamFactory busVoltFactory = new BusVoltFactory();
            IParamFactory dcCurFactory = new DcCurFactory();
            IParamFactory phaseCurFactory = new PhaseCurFactory();
            IParamFactory speedFactory = new SpeedFactory();
            IParamFactory driverTempFactory = new DriverTempFactory();
            IParamFactory motorTempFactory = new MotorTempFactory();
            IParamFactory motorAngleFactory = new MotorAngleFactory();
            IParamFactory tpsFactory = new TPSFactory();

            busVolt = busVoltFactory.createParam(this);
            dcCur = dcCurFactory.createParam(this);
            phaseCur = phaseCurFactory.createParam(this);
            speed = speedFactory.createParam(this);
            driverTemp = driverTempFactory.createParam(this);
            motorTemp = motorTempFactory.createParam(this);
            motorAngle = motorAngleFactory.createParam(this);
            tps = tpsFactory.createParam(this);
            //busVolt = Factory.Factory.createInstance("label_busVolt", this);
            //dcCurValue = Factory.Factory.createInstance("label_DcCur", this);
            //phaseCur = Factory.Factory.createInstance("label_PhaseCur", this);
            //speed = Factory.Factory.createInstance("label_Speed", this);
            //driverTemp = Factory.Factory.createInstance("label_DriverTemp", this);
            //motorTemp = Factory.Factory.createInstance("label_MotorTemp", this);
            //motorAngle = Factory.Factory.createInstance("label_MotorAngle", this);
            //tps = Factory.Factory.createInstance("label_TPS", this);
        }

        public AbstractParameters getBusVolt() 
        {
            return busVolt;
        }
        public AbstractParameters getDcCur() 
        {
            return dcCur;
        }
        public AbstractParameters getDriverTemp() 
        {
            return driverTemp;
        }
        public AbstractParameters getMotorAngle() 
        {
            return motorAngle;
        }
        public AbstractParameters getMotorTemp() 
        {
            return motorTemp;
        }
        public AbstractParameters getPhaseCur()
        { 
            return phaseCur;
        }
        public AbstractParameters getSpeed() 
        {
            return speed;
        }
        public AbstractParameters getTPS() 
        {
            return tps;
        }

        public override double getAdcValue()
        {
            return getRandomNumber(0, 4096);
        }
    }
}
