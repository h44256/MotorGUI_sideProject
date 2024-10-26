using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters.ExtensionAttribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ParamValueAttribute : Attribute
    {
        double minValue;
        double maxValue;
        public ParamValueAttribute(double _minValue, double _maxValue) 
        {
            minValue = _minValue;
            maxValue = _maxValue; 
        }
        public double validate(object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                if(double.TryParse(value.ToString(), out double resultValue))
                {
                    if (resultValue >= maxValue)
                    {
                        return maxValue;
                    }
                    else if (resultValue <= minValue)
                    {
                        return minValue;
                    }
                    else 
                    {
                        return resultValue;
                    }
                }
            }
            return 0.0;
        }
    }
}
