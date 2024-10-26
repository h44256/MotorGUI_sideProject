using Parameters.ExtensionAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Parameters.ManagerAttr
{
    public static class InvokeAttrMethod
    {
        /// <summary>
        /// 用物件的形式去做擴充方法
        /// </summary>
        /// <param name="oObject"></param>
        //public static void findAttr(this object oObject)
        //{
        //    //Type type = typeof(Form1);
        //    //FieldInfo field = type.GetField("Control_textBoxTPSValue", BindingFlags.NonPublic | BindingFlags.Instance);
        //    Type type = oObject.GetType();
        //    FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        //    foreach (FieldInfo field in fields)
        //    {
        //        if (field.IsDefined(typeof(ParamValueAttribute), true))
        //        {
        //            ParamValueAttribute attribute = field.GetCustomAttribute(typeof(ParamValueAttribute), true) as ParamValueAttribute;
        //            // 獲取字段的當前值
        //            object currentValue = field.GetValue(oObject);
        //            // 驗證該字段的值
        //            double validatedValue = attribute.validate(currentValue);
        //            // 將驗證後的值設置回字段
        //            field.SetValue(oObject, validatedValue);
        //        }
        //    }
        //}

        /// <summary>
        /// 用泛型來做擴充方法,可以進行約束
        /// </summary>
        /// <typeparam name="T">要使用的物件</typeparam>
        /// <param name="t"></param>
        public static void findAttr<T>(this T t)
            where T : class
        {
            //Type type = typeof(Form1);
            //FieldInfo field = type.GetField("Control_textBoxTPSValue", BindingFlags.NonPublic | BindingFlags.Instance);
            Type type = t.GetType();
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                if (field.IsDefined(typeof(ParamValueAttribute), true))
                {
                    ParamValueAttribute attribute = field.GetCustomAttribute(typeof(ParamValueAttribute), true) as ParamValueAttribute;
                    // 獲取字段的當前值
                    object currentValue = field.GetValue(t);
                    // 驗證該字段的值
                    double validatedValue = attribute.validate(currentValue);
                    // 將驗證後的值設置回字段
                    field.SetValue(t, validatedValue);
                }
            }
        }
    }
}
