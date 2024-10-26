using Parameters.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    public class MotorTemp : AbstractParameters
    {
        private IBaseParameters _baseParameters;
        public MotorTemp(IBaseParameters instance)
        {
            _baseParameters = instance;
            stopwatch.Start();
        }
        public override double getAdcValue()
        {
            //return getRandomNumber(1700, 1710) * gain;
            chooseMethod();
            return ADCValue;
        }
        private enum ADCmethod
        {
            random,
            deRating,
            Protect,
        }
        private ADCmethod useMethod = ADCmethod.random;
        private double ADCValue;
        private int adcInitValue = 1710;
        //創建 Stopwatch 物件來計時
        private Stopwatch stopwatch = new Stopwatch();

        private int getAdcChangeRate()
        {
            int voltAdcDischarge = 10;
            AbstractParameters tps = _baseParameters.getTPS();
            TPS newTps = tps as TPS;
            double tpsValue = newTps.getPhysicalValue(ADC_tps);
            int disChargeRate = (int)tpsValue;//1以下都當作電壓小到不升溫, 總共分5級
            return voltAdcDischarge * disChargeRate;
        }
        private void chooseMethod()
        {
            int adcChangeRate = 0;
            switch (useMethod)
            {
                case ADCmethod.random:
                    //ADCValue = getRandomNumber(3272, 3277) * gain;
                    if (stopwatch.Elapsed.TotalSeconds >= 1)//後面改秒數
                    {
                        adcChangeRate = getAdcChangeRate();
                        stopwatch.Restart();
                    }
                    adcInitValue += adcChangeRate;//升溫
                    ADCValue = adcInitValue * gain;
                    break;
                case ADCmethod.deRating:
                    if (stopwatch.Elapsed.TotalSeconds >= 1)//測試先用1秒
                    {
                        adcChangeRate = 10;//開始降溫
                        stopwatch.Restart();
                    }
                    adcInitValue -= adcChangeRate;
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
