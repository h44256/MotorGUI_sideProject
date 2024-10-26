using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameters
{
    public abstract class AbstractParameters
    {
        //ADC值使用的暫存器Register
        public int ADC_register = 4095;
        //ADC值的轉換, 後面轉去config讀取
        public double ADC_busVolt = 60;
        public double ADC_phaseCur = 125;
        public double ADC_speed = 14000;
        public double ADC_driverTemp = 100;
        public double ADC_motorTemp = 100;
        public double ADC_motorAngle = 360;
        public double ADC_dcCur = 125;
        public double ADC_tps = 5;
        //Setting頁面的Gain倍數
        public double gain = 1;
        //設定值
        private double motorPowerMax = 4500;
        public double deRating; //各參數現在的derating 降載值
        public double upRating; //各參數現在的uprating 升載值

        protected int getRandomNumber(int min, int max) 
        {
            Guid guid = Guid.NewGuid();
            string sGuid = guid.ToString();
            int seed = DateTime.Now.Millisecond;
            for (int i = 0; i < sGuid.Length; i++) 
            {
                switch (sGuid[i]) 
                {
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                        seed = seed + 1;
                        break;
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                        seed = seed + 2;
                        break;
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                        seed = seed + 3;
                        break;
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        seed = seed + 4;
                        break;
                }
            }
            Random random = new Random(seed);
            return random.Next(min, max);
        }
        public abstract double getAdcValue();
        public double getPhysicalValue(double ADC_trans)
        {
            return getAdcValue() / ADC_register * ADC_trans;
        }
        public virtual double paramSettingGain(string gainSet)
        {
            //這邊進來時先檢查gainSet是否為0或是Null或是空字符
            double gain;
            double gainsetMax = 10.01; //縮放最大比例10倍
            if (!string.IsNullOrWhiteSpace(gainSet) && Convert.ToDouble(gainSet) < gainsetMax)
            {
                gain = Convert.ToDouble(gainSet);
            }
            else
            {
                gain = 1.0;
            }
            return gain;
        }
        public double smoothFunction(double nowValue, double target, double deRating, double upRating, bool isPositive)
        {
            if (nowValue >= target)
            {
                nowValue -= deRating;
            }
            else if (nowValue < target)
            {
                nowValue += upRating;
            }
            //這邊如果是正數, 低於0直接給正值
            if (nowValue < 0 && isPositive)
            {
                return 0;
            }
            return nowValue;
        }
        public double getMotorPowerMax() 
        {
            return motorPowerMax;
        }
        public void setMotorPowerMax(AbstractParameters instance,double motorMax) 
        {
            instance.motorPowerMax = motorMax;
        }
    }
}
