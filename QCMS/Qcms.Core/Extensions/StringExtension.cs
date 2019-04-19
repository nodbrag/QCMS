using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Qcms.Core.Extensions
{
    public static class StringExtension
    {

        /// <summary>
        /// 将字符串转换成Json模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToJsonModel<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }


        /// <summary>
        /// 字符串是否为Null、空字符串组成。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNotNullAndEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static string IsEmptyThenNull(this string value)
        {
            return string.Empty == value ? null : value;
        }

        public static string IsNullThenEmpty(this string value)
        {
            return null == value ? string.Empty : value;
        }

        public static string IsNullThenDetault(this string value, string defaultValue)
        {
            return value.IsNullOrEmpty() ? defaultValue : value;
        }
        /// <summary>
        /// 字符串是否为Null、空字符串或仅由空白字符组成。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 从字符串的开头得到一个字符串的子串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Left(this string str, int len)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            if (str.Length < len)
            {
                throw new ArgumentException("len参数不能大于给定字符串的长度");
            }

            return str.Substring(0, len);
        }

        /// <summary>
        /// 从字符串的末尾得到一个字符串的子串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Right(this string str, int len)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            if (str.Length < len)
            {
                throw new ArgumentException("len参数不能大于给定字符串的长度");
            }

            return str.Substring(str.Length - len, len);
        }

        /// <summary>
        /// 字符串转枚举
        /// </summary>
        /// <typeparam name="T">类型的枚举</typeparam>
        /// <param name="value">字符串值转换</param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
           where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// 字符串转枚举
        /// </summary>
        /// <typeparam name="T">类型的枚举</typeparam>
        /// <param name="value">字符串值转换</param>
        /// <param name="ignoreCase">忽略大小写</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value, bool ignoreCase)
            where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        #region 数据验证
        /// <summary>
        /// 验证正整数
        /// </summary>      
        public static bool IsInteger(this string txt)
        {
            if (txt.IsNullOrEmpty()) return true;
            Regex objReg = new Regex(@"^[1-9]\d*$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 验证是否Email
        /// </summary>     
        public static bool IsEmail(this string txt)
        {
            if (txt.IsNullOrEmpty()) return true;
            Regex objReg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 验证身份证
        /// </summary>        
        public static bool IsIdentityCard(this string idcord)
        {
            if (idcord.IsNullOrEmpty()) return true;
            Regex objReg = new Regex(@"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
            return objReg.IsMatch(idcord);
        }
        /// <summary>
        /// 验证电话号码
        /// </summary>
        /// <param str_telephone=""></param>
        /// <returns></returns>
        public static bool IsTelephone(this string str_telephone)
        {
            if (str_telephone.IsNullOrEmpty()) return true;
            return System.Text.RegularExpressions.Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }
        /// <summary>
        /// 验证手机号码
        /// </summary>
        /// <param name="str_handset"></param>
        /// <returns></returns>
        public static bool IsHandset(this string str_handset)
        {
            if (str_handset.IsNullOrEmpty()) return true;

            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+[3,5,6,7,8,9]+\d{9}");
        }
        /// <summary>
        /// 验证身份证号
        /// </summary>
        /// <param name="str_idcard"></param>
        /// <returns></returns>
        public static bool IsIDcard(this string str_idcard)
        {
            if (str_idcard.IsNullOrEmpty()) return true;
            return System.Text.RegularExpressions.Regex.IsMatch(str_idcard, @"(^\d{18}$)|(^\d{15}$)");
        }

        /// <summary>
        /// 验证邮编
        /// </summary>
        /// <param name="str_postalcode"></param>
        public static bool IsPostalcode(this string str_postalcode)
        {
            if (str_postalcode.IsNullOrEmpty()) return true;
            return System.Text.RegularExpressions.Regex.IsMatch(str_postalcode, @"^\d{6}$");
        }
        #endregion
    }
}
