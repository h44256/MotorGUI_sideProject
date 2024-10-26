using Parameters.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    public class BusVolt : AbstractParameters
    {
        private IBaseParameters _baseParameters;
        public BusVolt(IBaseParameters instance)
        {
            _baseParameters = instance;
            stopwatch.Start();
        }
        public override double getAdcValue()
        {
            //return getRandomNumber(3272, 3277)*gain;
            chooseMethod();
            return ADCValue;
        }
        private void setBusVoltValue(double _value)
        {
            busVoltValue = _value;
        }
        private enum ADCmethod
        {
            random,
            deRating,
            Protect,
        }
        private ADCmethod useMethod = ADCmethod.random;
        private double ADCValue;
        private int adcInitValue = 3277;
        private double busVoltValue;
        //創建 Stopwatch 物件來計時
        private Stopwatch stopwatch = new Stopwatch();
        private int getDischarge() 
        {
            int voltAdcDischarge = 10;
            AbstractParameters tps = _baseParameters.getTPS();
            TPS newTps = tps as TPS;
            double tpsValue = newTps.getPhysicalValue(ADC_tps);
            int disChargeRate = (int)tpsValue;//1以下都當作電壓小到不扣電壓, 總共分5級
            return voltAdcDischarge * disChargeRate;
        }
        private void chooseMethod()
        {
            AbstractParameters tps = _baseParameters.getTPS();
            int discharge = 0;
            switch (useMethod)
            {
                case ADCmethod.random:
                    //ADCValue = getRandomNumber(3272, 3277) * gain;
                    if (stopwatch.Elapsed.TotalSeconds >= 1)//後面改秒數
                    {
                        discharge = getDischarge();
                        stopwatch.Restart();
                    }
                    adcInitValue -= discharge;
                    ADCValue = adcInitValue * gain;
                    break;
                case ADCmethod.deRating:
                    if (stopwatch.Elapsed.TotalSeconds >= 1)//測試先用1秒
                    {
                        discharge = 10;//讓下降速度變慢, 當做UVC的Alarm處理方法
                        setMotorPowerMax(tps,2000);//電池打到警告, 把馬達功率需求降低
                        stopwatch.Restart();
                    }
                    adcInitValue -= discharge;
                    ADCValue = adcInitValue * gain;
                    break;
                case ADCmethod.Protect:
                    ADCValue = 0;
                    break;
            }
        }
        private void setUseMethod(ADCmethod chooseMethod)
        {
            this.useMethod = chooseMethod;
        }
        public void setRandomMethod()
        {
            setUseMethod(ADCmethod.random);
        }
        public void setDeRatingMethod()
        {
            setUseMethod(ADCmethod.deRating);
        }
        public void setProtectMethod()
        {
            setUseMethod(ADCmethod.Protect);
        }
    }
}
