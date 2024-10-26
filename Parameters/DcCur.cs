using Parameters.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    public class DcCur : AbstractParameters, IPowerCur
    {
        private IBaseParameters _baseParameters;
        public DcCur(IBaseParameters instance)
        {
            _baseParameters = instance;
        }

        #region 最基本方法與參數
        /// <summary>
        /// 用來確認要使用哪個方法
        /// </summary>
        public enum ADCmethod
        {
            random,
            Protect
        }
        private ADCmethod useMethod = ADCmethod.random;
        private double ADCValue;
        private double dcCurValue;
        /// <summary>
        /// 傳physic給DcCur,後面可以用dcCurToADC轉換
        /// </summary>
        /// <param name="_value"></param>
        public void setDcCurValue(double _value)
        {
            dcCurValue = _value;
        }
        private double dcCurToADC(double _dcCurValue)
        {
            double _ADCValue;
            _ADCValue = _dcCurValue * ADC_register / ADC_dcCur;
            return _ADCValue;
        }
        #endregion

        private void getAdcDcCurByMotor()
        {
            AbstractParameters tps = _baseParameters.getTPS();
            AbstractParameters busVolt = _baseParameters.getBusVolt();
            ITPSPower tpsPower = tps as ITPSPower;
            double tpsValue = tps.getPhysicalValue(tps.ADC_tps);
            double powerValue = tpsPower.getPower(tpsValue, ADC_tps);
            double dcCurValue = getDcCur(powerValue, busVolt.getPhysicalValue(busVolt.ADC_busVolt));
            dcCurValue = dcCurToADC(dcCurValue);
            setDcCurValue(dcCurValue);
        }

        private void chooseMethod()
        {
            double targetValue;
            AbstractParameters tps = _baseParameters.getTPS();
            TPS newTps = tps as TPS;
            deRating = newTps.getDeRating();//這邊的值跟TPS同步
            upRating = newTps.getUpRating();//透過TPS得到Rateing值
            switch (useMethod)
            {
                case ADCmethod.random:
                    //ADCValue = getRandomNumber(0, 4) * gain;
                    getAdcDcCurByMotor();
                    //ADCValue = dcCurValue * gain;
                    targetValue = dcCurValue * gain;
                    ADCValue = smoothFunction(ADCValue, targetValue, deRating, upRating, true);
                    break;
                case ADCmethod.Protect:
                    ADCValue = 0;
                    break;
            }
        }
        public override double getAdcValue()
        {
            //return getRandomNumber(0, 4);
            chooseMethod();
            return ADCValue;
        }
        //public double setDcCur(double dcCurValue)
        //{
        //    this.setDcCurValue(dcCurValue);
        //    return dcCurValue;
        //}

        //public double getControlTPS(double power, double busVolt)
        //{
        //    double dcCurValue;
        //    dcCurValue = power / busVolt;
        //    return dcCurValue;
        //}
        /// <summary>
        /// 得到真實電流值非ADC值
        /// </summary>
        /// <param name="phyPower">丟入真值</param>
        /// <param name="phyBusVolt">丟入真值</param>
        /// <returns></returns>
        public double getDcCur(double phyPower, double phyBusVolt)
        {
            double phyDcCur;
            phyDcCur = phyPower / phyBusVolt;
            return phyDcCur;
        }
        private void setUseMethod(ADCmethod chooseMethod)
        {
            this.useMethod = chooseMethod;
        }
        public void setRandomMethod()
        {
            setUseMethod(ADCmethod.random);
        }
        public void setProtectMethod()
        {
            setUseMethod(ADCmethod.Protect);
        }
    }
}
