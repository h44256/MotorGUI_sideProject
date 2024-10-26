using Parameters.ExtensionAttribute;
using Parameters.Interface;
using Parameters.ManagerAttr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    public class Speed : AbstractParameters
    {
        private IBaseParameters _baseParameters;
        public Speed(IBaseParameters instance)
        {
            _baseParameters = instance;
        }
        public override double getAdcValue()
        {
            //return getRandomNumber(0, 4) * gain;
            chooseMethod();
            return ADCValue;
        }

        /// <summary>
        /// 用來確認要使用哪個方法
        /// </summary>
        private enum ADCmethod
        {
            random,
            deRating,
            Protect
        }
        private ADCmethod useMethod = ADCmethod.random;
        private double ADCValue;
        private double speedValue;
        /// <summary>
        /// 傳physic給Speed,後面可以用speedToADC轉換
        /// </summary>
        /// <param name="_value"></param>
        public void setSpeedValue(double _value)
        {
            speedValue = _value;
        }
        public double speedToADC(double _speedValue)
        {
            double _ADCValue;
            _ADCValue = _speedValue * ADC_register / ADC_speed;
            return _ADCValue;
        }
        private void getAdcByTps() 
        {
            AbstractParameters tps = _baseParameters.getTPS();
            TPS newTps = tps as TPS;
            double tpsValue = newTps.getAdcValue();
            if (tpsValue == 0)
            {
                tpsValue = 0;
            }
            else 
            {
                tpsValue = getRandomNumber((int)tpsValue-200, (int)tpsValue + 200); //這邊做一點變化 不要讓他跟tps一模一樣, 所以random一個範圍
                tpsValue *= 0.9;
                if (tpsValue < 1000)
                {
                    deRating = 20;
                    upRating = 50;
                }
                else if (tpsValue < 2000) 
                {
                    deRating = 20;
                    upRating = 40;
                }
                else if (tpsValue < 3000)
                {
                    deRating = 20;
                    upRating = 30;
                }
                else if (tpsValue < 4000)
                {
                    deRating = 20;
                    upRating = 20;
                }

            }
            setSpeedValue(tpsValue);
        }
        private void chooseMethod()
        {
            double targetValue;
            AbstractParameters tps = _baseParameters.getTPS();
            TPS newTps = tps as TPS;
            switch (useMethod)
            {
                case ADCmethod.random:
                    //ADCValue = getRandomNumber(0, 4) * gain;
                    getAdcByTps();
                    //ADCValue = speedValue * gain;
                    targetValue = speedValue * gain;
                    ADCValue = smoothFunction(ADCValue, targetValue, deRating, upRating, true);//這邊的值要跟TPS同步,還沒改
                    //this.findAttr();//預防低於0, 可以用If, 也可以選擇用特性 
                    break;
                case ADCmethod.deRating:
                    deRating = newTps.getDeRating();//這邊的值跟TPS同步
                    ADCValue -= deRating;
                    break;
                case ADCmethod.Protect:
                    //ADCValue = 0;
                    ADCValue = smoothFunction(ADCValue, 0, 30, 0, true);//開始往0降速度, 降速率給定值(因為沒電了,靠摩擦力),  
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
