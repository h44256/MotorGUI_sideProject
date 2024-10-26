using Parameters.ExtensionAttribute;
using Parameters.Interface;
using Parameters.ManagerAttr;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    public class PhaseCur : AbstractParameters
    {
        private IBaseParameters _baseParameters;
        public PhaseCur(IBaseParameters instance)
        {
            _baseParameters = instance;
        }
        public enum ADCmethod
        {
            random,
            deRating,
            Protect
        }
        public ADCmethod useMethod = ADCmethod.random;
        [ParamValue(0,40000)]
        private double ADCValue;
        private double phaseCurValue;
        private void setPhaseCurValue(double _value) 
        {
            phaseCurValue = _value;
        }
        private void getPhaseCur() 
        {
            AbstractParameters dcCur = _baseParameters.getDcCur();
            double dcCurValue = dcCur.getAdcValue();
            double phaseCurValue = dcCurValue / Math.Sqrt(3);
            setPhaseCurValue(phaseCurValue);
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
                    getPhaseCur();
                    //ADCValue = phaseCurValue * gain;
                    targetValue = phaseCurValue * gain;
                    ADCValue = smoothFunction(ADCValue, targetValue, deRating, upRating, true);
                    //this.findAttr();//預防低於0, 可以用If, 這邊選擇用特性 
                    break;
                case ADCmethod.deRating:
                    //ADCValue -= 20.0;
                    ADCValue -= deRating;
                    //this.findAttr();//預防低於0, 可以用If, 這邊也可以選擇用特性 
                    break;
                case ADCmethod.Protect:
                    ADCValue = 0;
                    break;
            }
        }
        public override double getAdcValue()
        {
            chooseMethod();
            return ADCValue;
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
