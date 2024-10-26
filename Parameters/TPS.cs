using Parameters.ExtensionAttribute;
using Parameters.ManagerAttr;
using Parameters.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    public class TPS : AbstractParameters, IControlMode, ITPSPower
    {
        private IBaseParameters _baseParameters;
        public TPS(IBaseParameters instance)
        {
            _baseParameters = instance;
        }
        /// <summary>
        /// 用來確認要使用哪個方法
        /// </summary>
        private enum ADCmethod 
        {
            random,
            controlModeTPS,
            settingKeyOn,
            settingStart,
            settingSideStand,
            settingPark,
            Protect,
        }
        private enum ADCDeRate 
        {
            Default,
            settingLowBrake,
            settingHighBrake,
            settingCruise,//同時也設定UpRating
        }
        private enum ADCUpRate
        {
            Default,
            settingBoost,
            settingCruise,//同時也設定DeRating
        }
        private ADCmethod useMethod=ADCmethod.random;
        private ADCDeRate useDeRate = ADCDeRate.Default;
        private ADCUpRate useUpRate = ADCUpRate.Default;
        [ParamValue(0,4095)]//用來擋ADC值
        private double ADCValue;
        private double TPSValue;
        //private double deRating; //透過TPS傳送給各參數現在的derating 降載值
        //private double upRating; //透過TPS傳送給各參數現在的uprating 升載值

        public void setTPSValue(double _value) 
        {
            TPSValue = _value;
        }
        private double TPSToADC(double _tpsValue) 
        {
            double _ADCValue;
            _ADCValue = _tpsValue * ADC_register / ADC_tps;
            return _ADCValue;
        }
        private double chooseDeRate()
        {
            double deRate = 0.0;
            switch (useDeRate)
            {
                case ADCDeRate.Default:
                    deRate = 20.0;
                    break;
                case ADCDeRate.settingLowBrake:
                    deRate = 10.0;
                    break;
                case ADCDeRate.settingHighBrake:
                    deRate = 40.0;
                    break;
                case ADCDeRate.settingCruise:
                    deRate = 0.0;
                    break;
            }
            return deRate;
        }
        private double chooseUpRate()
        {
            double upRate = 0.0;
            switch (useUpRate)
            {
                case ADCUpRate.Default:
                    upRate = 20.0;
                    break;
                case ADCUpRate.settingBoost:
                    upRate = 40.0;
                    break;
                case ADCUpRate.settingCruise:
                    upRate = 0.0;
                    break;
            }
            return upRate;
        }
        private void chooseMethod(double deRate, double upRate) 
        {
            double targetValue;
            deRating = deRate;
            upRating = upRate;
            switch (useMethod) 
            {
                case ADCmethod.Protect:
                    ADCValue = 0;
                    break;
                case ADCmethod.settingStart:
                    //ADCValue = getRandomNumber(410, 411) * gain;
                    targetValue = getRandomNumber(410, 411) * gain;
                    ADCValue = smoothFunction(ADCValue, targetValue, deRating, upRating,true);
                    break;
                case ADCmethod.controlModeTPS:
                    //ADCValue = TPSToADC(TPSValue) * gain;//這邊沒有約束一定先setTPSValue才去使用這個TPSValue
                    targetValue = TPSToADC(TPSValue) * gain;//這邊沒有約束一定先setTPSValue才去使用這個TPSValue
                    ADCValue = smoothFunction(ADCValue, targetValue, deRating, upRating, true);
                    //this.findAttr();//用特性來擋ADC值
                    break;
                case ADCmethod.random:
                case ADCmethod.settingKeyOn:
                case ADCmethod.settingSideStand:
                case ADCmethod.settingPark:
                    //ADCValue = 0.0;
                    targetValue = 0.0;
                    ADCValue = smoothFunction(ADCValue, targetValue, deRating, upRating, true);
                    //this.findAttr();//用特性來擋ADC值
                    break;
            }
        }
        public override double getAdcValue()
        {
            //return getRandomNumber(410, 411);
            double deRate = chooseDeRate();
            double upRate = chooseUpRate();
            chooseMethod(deRate, upRate);
            return ADCValue;
        }
        public double setTPS(double tpsValue) 
        {
            this.setTPSValue(tpsValue);
            return tpsValue;
        }

        public double getPower(double _tps, double adcTrans)
        {
            double motorPower;
            double motorPowerMax = getMotorPowerMax();
            motorPower = motorPowerMax * _tps / adcTrans;
            return motorPower;
        }
        public double getDeRating() 
        {
            return deRating;
        }
        public double getUpRating()
        { 
            return upRating;
        }
        private void setUseMethod(ADCmethod chooseMethod)
        {
            this.useMethod = chooseMethod;
        }
        private void setUseDeRate(ADCDeRate chooseDeRate)
        {
            this.useDeRate = chooseDeRate;
        }
        private void setUseUpRate(ADCUpRate chooseUpRate)
        {
            this.useUpRate = chooseUpRate;
        }
        public void setFuncKeyOn() 
        {
            setUseMethod(ADCmethod.settingKeyOn);
        }
        public void setFuncStart()
        {
            setUseMethod(ADCmethod.settingStart);
        }
        public void setFuncSideStand()
        {
            setUseMethod(ADCmethod.settingSideStand);
        }
        public void setDeRateLowBrake()
        {
            setUseDeRate(ADCDeRate.settingLowBrake);
        }
        public void setDeRateHighBrake()
        {
            setUseDeRate(ADCDeRate.settingHighBrake);
        }
        public void setDeRateDefault() 
        {
            setUseDeRate(ADCDeRate.Default);
        }
        public void setRateCruise()
        {
            setUseDeRate(ADCDeRate.settingCruise);
            setUseUpRate(ADCUpRate.settingCruise);
        }
        public void setUpRateBoost()
        {
            setUseUpRate(ADCUpRate.settingBoost);
        }
        public void setUpRateDefault()
        {
            setUseUpRate(ADCUpRate.Default);
        }
        public void setFuncPark() 
        {
            setUseMethod(ADCmethod.settingPark);
        }
        public void setRandomMehtod() 
        {
            setUseMethod(ADCmethod.random);
        }
        public void setProtectMethod()
        {
            setUseMethod(ADCmethod.Protect);
        }
        public void setControlModeTPS()
        {
            setUseMethod(ADCmethod.controlModeTPS);
            //this.useMethod = TPS.ADCmethod.controlModeTPS;
        }
        /// <summary>
        /// 假裝經過FOC運算, 這邊就是隨便給個方法
        /// </summary>
        /// <param name="phaseCur"></param>
        /// <param name="duty"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public double setControlModeDuty(double phaseCur, double duty, double angle) 
        {
            double TPSratio;
            TPSratio = (phaseCur / ADC_phaseCur + duty / 100 + angle / 360)*ADC_tps/3;
            return TPSratio;
        }
    }
}
