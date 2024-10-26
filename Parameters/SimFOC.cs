using Parameters.ExtensionAttribute;
using Parameters.Factory;
using Parameters.Interface;
using Parameters.ManagerAttr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Parameters
{
    public class SimFOC
    {
        private BaseParameters baseParameters = new BaseParameters();//原本在SimFOC去產生參數的物件, 現在把這些參數統一丟給BaseParameters管理, SimFOC再去那邊動態拿就好
        public AbstractParameters busVolt => baseParameters.busVolt; //這個方法是語法糖，也就是表達式主體成員（Expression-bodied Members）的一種應用。
        public AbstractParameters dcCur => baseParameters.dcCur; //使用這種方法變成read-only, 這邊的dcCur不保存參考位置, 他會動態去取得baseParameters裡面的參考
        public AbstractParameters phaseCur => baseParameters.phaseCur;//動態求值：每次訪問 phaseCur 時，它都會重新從 baseParameters 中取得當前的 phaseCur 值，
        public AbstractParameters speed => baseParameters.speed;
        public AbstractParameters driverTemp => baseParameters.driverTemp;
        public AbstractParameters motorTemp => baseParameters.motorTemp;
        public AbstractParameters motorAngle => baseParameters.motorAngle;
        public AbstractParameters tps => baseParameters.tps;

        private double busVoltValue;
        private double dcCurValue;
        private double phaseCurValue;
        private double speedValue;
        private double driverTempValue;
        private double motorTempValue;
        private double motorAngleValue;
        private double tpsValue;

        //params ADCMethod
        private bool isTPSMode = false;
        private bool isDutyMode = false;
        private bool isKeyOn = false;
        private bool isStart = false;
        private bool isSideStand = false;
        private bool isPark = false;
        //params ADCRate
        private bool isCruise = false;
        //params ADCDeRate
        private bool isLowBrake = false;
        private bool isHighBrake = false;
        //params ADCUpRate
        private bool isBoost = false;
        //params Prot
        private bool isPhaseOcp =false;
        private bool isOvp = false;
        private bool isUvp = false;   
        private bool isDcOcp = false; 
        private bool isOtpMoter = false;
        private bool isOtpDriver = false;
        private bool isTPSHigh = false;
        private bool isHighSpeedProt = false;
        private bool isProtRecover = false; //用於判斷保護點是否回復
        private bool isProtNormal = true; //用於判斷保護點回復後, 但還沒再次觸發保護點的狀態
        private bool isProtActive = false;//用於判斷, 保護點是否被觸發
        //params Alarm
        private bool isLowVolt = false;
        private bool isHighCur = false;
        private bool isLowTempMotor = false;
        private bool isLowTempDriver = false;
        private bool isHighTempMotor = false;
        private bool isHighTempDriver = false;
        private bool isDerating = false;
        private bool isHighSpeedAlarm = false;

        //Protection ValueSetting
        public int phaseOcpErrValue = 72;
        public int dcOcpErrValue = 125;
        public int ovpErrValue = 60;
        public int uvpErrValue = 35;
        public int otpMotorErrValue = 100;
        public int otpDriverErrValue = 100;
        public double tpsHighErrValue = 5.1;
        public int highSpeedErrValue = 15000;
        //Alarm ValueSetting
        public int lowVoltAlarmValue =40;
        public int highCurAlarmValue = 64;
        public int lowTempMotorAlarmValue=5;
        public int lowTempDriverAlarmValue=5;
        public int highTempMotorAlarmValue=55;//原本寫90
        public int highTempDriverAlarmValue=55;//原本寫90
        public int highSpeedAlarmValue = 12000;

        /// <summary>
        /// 取得參數的物件
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public AbstractParameters getAbsParameters(string str)
        {
            switch (str)
            {
                case "label_BusVolt":
                    return busVolt;
                case "label_DcCur":
                    return dcCur;
                case "label_PhaseCur":
                    return phaseCur;
                case "label_Speed":
                    return speed;
                case "label_DriverTemp":
                    return driverTemp;
                case "label_MotorTemp":
                    return motorTemp;
                case "label_MotorAngle":
                    return motorAngle;
                case "label_TPS":
                    return tps;
            }
            return null;
        }

        public double getADCValue(string labelName) 
        {
            switch (labelName)
            {
                case "label_BusVolt":
                    busVolt.gain = busVolt.paramSettingGain(textBox_BusVoltSetText);
                    busVoltValue = busVolt.getAdcValue();               
                    return busVoltValue;
                case "label_DcCur":
                    dcCurValue = dcCur.getAdcValue();
                    return dcCurValue;
                case "label_PhaseCur":
                    phaseCur.gain = phaseCur.paramSettingGain(textBox_PhaseCurSetText);
                    phaseCurValue = phaseCur.getAdcValue();
                    return phaseCurValue;
                case "label_Speed":
                    speedValue = speed.getAdcValue();
                    return speedValue;
                case "label_DriverTemp":
                    driverTemp.gain = driverTemp.paramSettingGain(textBox_DriverTempSetText);
                    driverTempValue = driverTemp.getAdcValue();
                    return driverTempValue;
                case "label_MotorTemp":
                    motorTemp.gain = motorTemp.paramSettingGain(textBox_MotorTempSetText);
                    motorTempValue = motorTemp.getAdcValue();
                    return motorTempValue;
                case "label_MotorAngle":
                    motorAngleValue = motorAngle.getAdcValue();
                    return motorAngleValue;
                case "label_TPS":
                    tps.gain = tps.paramSettingGain(textBox_TPSSetText);
                    tpsValue = tps.getAdcValue();
                    return tpsValue;
            }
            return 0.0;
        }

        #region Control頁面的相關方法
        double[] controlParam;

        public void setControlParam(double[] param)
        {
            controlParam = param;

            if (controlParam[0] > 0.5)
            {
                //ControlTPSMode();
                isTPSMode = true;
                isDutyMode = false;
            }
            else if (controlParam.Skip(1).Take(3).Any(x => x != 0))// 檢查 controlModeTPS[1], controlModeTPS[2], controlModeTPS[3] 是否任一不為 0
            {
                //ControlDutyMode();
                isTPSMode = false;
                isDutyMode = true;
            }
            // 全部都為 0 的情況
            else
            {
                isTPSMode = false;
                isDutyMode = false;
            }
        }
        /// <summary>
        /// 把 ControlTPSMode跟 ControlDutyMode整合成一個方法, 用來把Control頁面的參數丟到simFOC裡面去改動值
        /// </summary>
        private void ControlMode()
        {
            IControlMode controlMode_tps = this.tps as IControlMode;
            ITPSPower tpsPower = this.tps as ITPSPower;

            if (isTPSMode)
            {
                double TPSValue = controlParam[0];
                tpsPower.setTPS(TPSValue);
            }
            else if (isDutyMode) 
            {
                double TPSValue = controlMode_tps.setControlModeDuty(controlParam[1], controlParam[2], controlParam[3]); //多這個duty來得到TPS
                tpsPower.setTPS(TPSValue); //這邊跟TPS設定方法的差別, TPS的直接把TPS丟進來, 這邊把三個參數運算後才變成TPS
            }
            controlMode_tps.setControlModeTPS();
            //double motorPowerValue = tpsPower.getPower(TPSValue, tps.ADC_tps);
            //double busVoltPhyValue = busVolt.getPhysicalValue(busVolt.ADC_busVolt);
            //double dcCurValue = powerDcCur.getDcCur(motorPowerValue, busVoltPhyValue);
            //powerDcCur.setDcCur(dcCurValue);
        }
        /// <summary>
        /// 用於在Control頁面使用TPS去控制的方法
        /// </summary>
        [Obsolete("整合到ControlMode, 後續有需要再來改動",false)]
        private void ControlTPSMode() 
        {
            IControlMode controlMode_tps = this.tps as IControlMode;
            ITPSPower tpsPower = this.tps as ITPSPower;
            //IPowerCur powerDcCur = this.dcCurValue as IPowerCur;

            double TPSValue = tpsPower.setTPS(controlParam[0]);
            controlMode_tps.setControlModeTPS();
            //double motorPowerValue = mode_TPS.getControlTPS(TPSValue, tps.ADC_tps);
            //double motorPowerValue = tpsPower.getPower(TPSValue, tps.ADC_tps);
            //double busVoltPhyValue = busVolt.getPhysicalValue(busVolt.ADC_busVolt); 
            //double dcCurValue = powerDcCur.getDcCur(motorPowerValue, busVoltPhyValue);
            //powerDcCur.setDcCur(dcCurValue);
        }
        /// <summary>
        /// 用於在Control頁面, 不使用TPS改成duty phaseCur跟angle來控制的方法
        /// </summary>
        [Obsolete("整合到ControlMode, 後續有需要再來改動", false)]
        private void ControlDutyMode() 
        {
            IControlMode controlMode_tps = this.tps as IControlMode;
            ITPSPower tpsPower = this.tps as ITPSPower;
            //IPowerCur powerDcCur = this.dcCurValue as IPowerCur;

            double TPSValue = controlMode_tps.setControlModeDuty(controlParam[1], controlParam[2], controlParam[3]); //多這個duty來得到TPS
            TPSValue = tpsPower.setTPS(TPSValue); //這邊跟TPS設定方法的差別, TPS的直接把TPS丟進來, 這邊把三個參數運算後才變成TPS
            controlMode_tps.setControlModeTPS(); 
            //double motorPowerValue = mode_TPS.getControlTPS(TPSValue, tps.ADC_tps); 
            //double motorPowerValue = tpsPower.getPower(TPSValue, tps.ADC_tps);
            //double busVoltPhyValue = busVolt.getPhysicalValue(busVolt.ADC_busVolt);
            //double dcCurValue = powerDcCur.getDcCur(motorPowerValue, busVoltPhyValue);
            //powerDcCur.setDcCur(dcCurValue);
        }
        /// <summary>
        /// 假裝經過FOC運算後得到一個ratio value去影響最終phase Current值,
        /// 只是一個概念, 目的是製作軟體部分而非FOC演算法
        /// </summary>
        /// <returns></returns>
        public double getFOCResult22222222()
        {
            if (controlParam != null)
            {
                for (int i = 0; i < controlParam.Length; i++)
                {
                    if (controlParam[i] < 0)
                    {
                        return 0;
                    }
                    else if (controlParam[0] != 0)
                    {
                        return controlParam[0] / 5;
                    }
                    else if (controlParam[i] != 0)
                    {
                        return (controlParam[1] + controlParam[2] + controlParam[3]) / 3 / 100;
                    }
                }
            }
            return 1;//代表沒啟動Control功能, 所以就給1當作沒發生過
        }
        #endregion

        #region 設定param TPS區域
        /// <summary>
        /// 用來把simFOC的bool設定給到TPS的Enum, ADCMethod
        /// </summary>
        public void chooseTpsMode()
        {
            TPS newTps = this.tps as TPS; // 進行轉型
            if (isKeyOn)
            {
                newTps.setFuncKeyOn();
                if (isStart)
                {
                    //設定ADCUpRating, 不改變狀態 主要是改變參數
                    if (isCruise) 
                    {
                        newTps.setRateCruise();
                    }
                    else if (isBoost)
                    {
                        newTps.setUpRateBoost();
                    }
                    else
                    {
                        newTps.setUpRateDefault();
                    }

                    //設定ADCDeRating, 不改變狀態 主要是改變參數
                    if (isCruise)
                    {
                        newTps.setRateCruise();
                    }
                    else if (isLowBrake)
                    {
                        newTps.setDeRateLowBrake();
                    }
                    else if (isHighBrake)
                    {
                        newTps.setDeRateHighBrake();
                    }
                    else 
                    {
                        newTps.setDeRateDefault();
                    }

                    newTps.setFuncStart();
                    if (isSideStand)
                    {
                        newTps.setFuncSideStand();
                    }
                    else if (isPark)
                    {
                        newTps.setFuncPark();
                    }
                    else if (isTPSMode || isDutyMode)
                    {
                        ControlMode();
                    }
                }
            }
            else
            {
                if (newTps != null)
                {
                    newTps.setRandomMehtod();
                    //newTps.setUseMethod(TPS.ADCmethod.random);
                    //newTps.useMethod = TPS.ADCmethod.random;
                }
            }
        }
        #endregion

        #region Setting區域Setting頁面的相關方法
        //Setting區域
        public string textBox_TPSSetText;
        public string textBox_BusVoltSetText;
        public string textBox_PhaseCurSetText;
        public string textBox_DriverTempSetText;
        public string textBox_MotorTempSetText;
        private bool[] funcCheckBoxes;
        private bool[] protCheckBoxes;
        private bool[] alarmCheckBoxes;

        /// <summary>
        /// 讓外部直接修改funCheckBoxes, 而funcCheckBoxes依然是private, 不用再set一次, 直接用get就可修改物件
        /// </summary>
        /// <returns></returns>
        public ref bool[] getFuncCheckBoxes() 
        {
            return ref funcCheckBoxes;
        }
        public ref bool[] getProtCheckBoxes() 
        {
            return ref protCheckBoxes;
        }
        public ref bool[] getAlarmCheckBoxes()
        {
            return ref alarmCheckBoxes;
        }
        public void setSettingCheckBox(bool[] sourceArr, ref bool[] arr)
        {
            arr = sourceArr;
        }
        /// <summary>
        /// 全取消就當作機車已經重新啟動, 檢查Func是否全部都取消勾選, 全部取消時重置保護設定, 
        /// </summary>
        private void checkFuncStates()
        {
            int num = 0;//用來判斷有幾個true幾個false, 全部都沒打勾代表重置保護點
            foreach (var item in funcCheckBoxes)
            {
                if (item == false)
                {
                    num++;
                }
                else if (num > 0 && item == true)
                {
                    num--;
                }
                if (num == protCheckBoxes.Length)
                {
                    isProtRecover = true;
                }
                else
                {
                    isProtRecover = false;
                }
            }
        }
        /// <summary>
        /// 把funcCheckBoxes的各個位置, 使用新boolean來承接, 方便閱讀而已
        /// </summary>
        public void updateFuncStates() 
        {
            isKeyOn = funcCheckBoxes[0];
            isStart = funcCheckBoxes[1];
            isCruise = funcCheckBoxes[2];
            isSideStand = funcCheckBoxes[3];
            isLowBrake = funcCheckBoxes[4];
            isHighBrake = funcCheckBoxes[5];
            isBoost = funcCheckBoxes[6];
            isPark = funcCheckBoxes[7];
            checkFuncStates();
        }
        /// <summary>
        /// 把protCheckBoxes的各個位置, 使用新boolean來承接, 方便閱讀而已
        /// </summary>
        public void updateProtStates()
        {
            isPhaseOcp = protCheckBoxes[0];
            isOvp = protCheckBoxes[1];
            isUvp = protCheckBoxes[2];
            isDcOcp = protCheckBoxes[3];
            isOtpMoter = protCheckBoxes[4];
            isOtpDriver = protCheckBoxes[5];
            isTPSHigh = protCheckBoxes[6];
            isHighSpeedProt = protCheckBoxes[7];
        }
        public void updateAlarmStates()
        {
            isLowVolt = alarmCheckBoxes[0];
            isHighCur = alarmCheckBoxes[1];
            isLowTempMotor = alarmCheckBoxes[2];
            isLowTempDriver  = alarmCheckBoxes[3];
            isHighTempMotor = alarmCheckBoxes[4];
            isHighTempDriver = alarmCheckBoxes[5];
            isDerating = alarmCheckBoxes[6];
            isHighSpeedAlarm = alarmCheckBoxes[7];
        }

        //private double paramSettingGain(string gainSet) 
        //{
        //    //這邊進來時先檢查gainSet是否為0或是Null或是空字符
        //    double gain;
        //    double gainsetMax = 10.01; //縮放最大比例10倍
        //    if (!string.IsNullOrWhiteSpace(gainSet) && Convert.ToDouble(gainSet) < gainsetMax)
        //    {
        //        gain = Convert.ToDouble(gainSet);
        //    }
        //    else
        //    {
        //        gain = 1.0;
        //    }
        //    return gain;
        //}

        #endregion
        #region 警示判斷 警告判斷 Alarm判斷
        //public int lowVoltAlarmValue = 40;
        //public int lowTempMotorAlarmValue = 30;
        //public int lowTempDriverAlarmValue = 30;
        //public int highCurAlarmValue = 70;
        //public int highSpeedAlarmValue = 8000;
        //public int highTempMotorAlarmValue = 50;
        //public int highTempDriverAlarmValue = 50;
        public void detectSettingAlarm()
        {
            double busVoltValue = busVolt.getPhysicalValue(busVolt.ADC_busVolt);
            double phaseCurValue = phaseCur.getPhysicalValue(phaseCur.ADC_phaseCur);
            double speedValue = speed.getPhysicalValue(speed.ADC_speed);
            double motorTempValue = motorTemp.getPhysicalValue(motorTemp.ADC_motorTemp);
            double driverTempValue = driverTemp.getPhysicalValue(driverTemp.ADC_driverTemp);

            PhaseCur newPhaseCur = phaseCur as PhaseCur;
            Speed newSpeed = speed as Speed;
            BusVolt newBusVolt = busVolt as BusVolt;
            MotorTemp newMotorTemp = motorTemp as MotorTemp;
            DriverTemp newDriverTemp = driverTemp as DriverTemp;

            if (!isLowVolt)
            {
                if (busVoltValue < lowVoltAlarmValue)
                {
                    newBusVolt.setDeRatingMethod();
                }
                else
                {
                    newBusVolt.setRandomMethod();
                }
            }
            else
            {
                newBusVolt.setRandomMethod();
            }
            if (!isHighCur)
            {
                if (phaseCurValue >= highCurAlarmValue)
                {
                    newPhaseCur.setDeRatingMethod();
                }
                else
                {
                    newPhaseCur.setRandomMethod();
                }
            }
            else
            {
                newPhaseCur.setRandomMethod();
            }
            //配合checkBox_LowTempMotorAlarm的警示判斷
            if (!isLowTempMotor)
            {
                newMotorTemp.setRandomMethod();//太冷的話就升溫
            }
            else
            {
                newMotorTemp.setRandomMethod();
            }
            //配合checkBox_LowTempDriverAlarm的警示判斷
            if (!isLowTempDriver)
            {
                newDriverTemp.setRandomMethod();//太冷的話就升溫
            }
            else
            {
                newDriverTemp.setRandomMethod();
            }
            //配合checkBox_HighTempMotorAlarm的警示判斷
            if (!isHighTempMotor)
            {
                if (motorTempValue > highTempMotorAlarmValue)
                {
                    newMotorTemp.setDeRatingMethod();
                }
                else
                {
                    newMotorTemp.setRandomMethod();
                }
            }
            else
            {
                newMotorTemp.setRandomMethod();
            }
            //配合checkBox_HighTempDriverAlarm的警示判斷
            if (!isHighTempDriver)
            {
                if (driverTempValue > highTempDriverAlarmValue)
                {
                    newDriverTemp.setDeRatingMethod();
                }
                else
                {
                    newDriverTemp.setRandomMethod();
                }
            }
            else
            {
                newDriverTemp.setRandomMethod();
            }
            if (!isHighSpeedAlarm)
            {
                if (speedValue >= highSpeedAlarmValue)
                {
                    newSpeed.setDeRatingMethod();
                }
                else
                {
                    newSpeed.setRandomMethod();
                }
            }
            else
            {
                newSpeed.setRandomMethod();
            }

        }
        #endregion

        #region 保護判斷
        public bool getIsProtActive() 
        {
            return isProtActive;
        }
        public void detectProtection() 
        {
            double phaseCurValue = phaseCur.getPhysicalValue(phaseCur.ADC_phaseCur);
            double busVoltValue = busVolt.getPhysicalValue(busVolt.ADC_busVolt);
            double dcCurValue = dcCur.getPhysicalValue(dcCur.ADC_dcCur);
            double speedValue = speed.getPhysicalValue(speed.ADC_speed);
            double tpsValue = tps.getPhysicalValue(tps.ADC_tps);
            double motorTempValue = motorTemp.getPhysicalValue(motorTemp.ADC_motorTemp);
            double driverTempValue = driverTemp.getPhysicalValue(driverTemp.ADC_driverTemp);

            BusVolt newBusVolt = busVolt as BusVolt;
            PhaseCur newPhaseCur = phaseCur as PhaseCur;
            DcCur newDcCur = dcCur as DcCur;
            Speed newSpeed = speed as Speed;
            TPS newTps = tps as TPS;
            MotorTemp newMotorTemp = motorTemp as MotorTemp;
            DriverTemp newDriverTemp = driverTemp as DriverTemp;
            void protVoltCur()
            {
                newDcCur.setProtectMethod();
                newPhaseCur.setProtectMethod();
                newBusVolt.setProtectMethod();
                newSpeed.setProtectMethod();
            }
            void protRecover() 
            {
                newDcCur.setRandomMethod();
                newPhaseCur.setRandomMethod();
                newBusVolt.setRandomMethod();
                newSpeed.setRandomMethod();
            }
            //配合checkBox_phaseOcpProt的保護判斷
            if (!isPhaseOcp)
            {
                if (phaseCurValue > phaseOcpErrValue)
                {
                    protVoltCur();
                    isProtActive=true;
                }
                else if (isProtRecover) 
                {
                    protRecover();
                    isProtActive = false;
                }
            }
            //配合checkBox_OvpProt的保護判斷
            if (!isOvp)
            {
                if (busVoltValue > ovpErrValue)
                {
                    protVoltCur();
                    isProtActive = true;
                }
                else if (isProtRecover)
                {
                    protRecover();
                    isProtActive = false;
                }
            }
            //配合checkBox_uvpProt的保護判斷
            if (!isUvp)
            {
                if (busVoltValue < uvpErrValue)
                {
                    protVoltCur();
                    isProtActive = true;
                }
                else if (isProtRecover)
                {
                    protRecover();
                    isProtActive = false;
                }
            }
            //配合checkBox_DcOcpProt的保護判斷
            if (!isDcOcp)
            {
                if (dcCurValue > dcOcpErrValue)
                {
                    protVoltCur();
                    isProtActive = true;
                }
                else if (isProtRecover)
                {
                    protRecover();
                    isProtActive = false;
                }
            }
            //配合checkBox_OTPMoterProtect的保護判斷
            if (!isOtpMoter) 
            {
                if (motorTempValue > otpMotorErrValue)
                {
                    newMotorTemp.setProtectMethod();
                    isProtActive = true;
                }
                else if (isProtRecover)
                {
                    newMotorTemp.setRandomMethod();
                    isProtActive = false;
                }
            }
            //配合checkBox_OTPDriverProtect的保護判斷
            if (!isOtpDriver)
            {
                if (driverTempValue > otpDriverErrValue)
                {
                    newDriverTemp.setProtectMethod();
                    isProtActive = true;
                }
                else if (isProtRecover)
                {
                    newDriverTemp.setRandomMethod();
                    isProtActive = false;
                }
            }
            //配合checkBox_HighSpeedProt的保護判斷
            if (!isHighSpeedProt) 
            {
                if (speedValue > highSpeedErrValue)
                {
                    protVoltCur();
                    isProtActive = true;
                }
                else if (isProtRecover)
                {
                    protRecover();
                    isProtActive = false;
                }
            }
            //配合checkBox_TPSHighProt的保護判斷
            if (!isTPSHigh)
            {
                if (tpsValue > tpsHighErrValue)
                {
                    newTps.setProtectMethod();
                    isProtNormal = false;
                    isProtActive = true;
                }
                else if (isProtRecover || isProtNormal)
                {
                    chooseTpsMode();
                    isProtNormal = true;
                    isProtActive = false;
                }
            }
            else 
            {
                chooseTpsMode();
            }
        }
        #endregion
    }
}
