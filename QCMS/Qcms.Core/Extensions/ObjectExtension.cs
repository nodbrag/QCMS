using System;
using System.Globalization;
using System.Linq;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Qcms.Core.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Used to simplify and beautify casting an object to a type. 
        /// </summary>
        /// <typeparam name="T">Type to be casted</typeparam>
        /// <param name="obj">Object to cast</param>
        /// <returns>Casted object</returns>
        public static T As<T>(this object obj)
            where T : class
        {
            return (T)obj;
        }

        /// <summary>
        /// Converts given object to a value or enum type using <see cref="Convert.ChangeType(object,TypeCode)"/> or <see cref="Enum.Parse(Type,string)"/> method.
        /// </summary>
        /// <param name="obj">Object to be converted</param>
        /// <typeparam name="T">Type of the target object</typeparam>
        /// <returns>Converted object</returns>
        public static T To<T>(this object obj)
            where T : struct
        {
            if (typeof(T) == typeof(Guid))
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(obj.ToString());
            }

            if (typeof(T).IsEnum)
            {
                if (Enum.IsDefined(typeof(T), obj))
                {
                    return (T)Enum.Parse(typeof(T), obj.ToString());
                }
                else
                {
                    throw new ArgumentException($"Enum type undefined '{obj}'.");
                }
            }

            return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Check if an item is in a list.
        /// </summary>
        /// <param name="item">Item to check</param>
        /// <param name="list">List of items</param>
        /// <typeparam name="T">Type of the items</typeparam>
        public static bool IsIn<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }

        /// <summary>
        /// 将Json模型转换成json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string ConvertToString(this object value)
        {
            return null == value || DBNull.Value == value ? null : Convert.ToString(value);
        }

        public static DateTime? ConvertToNullableDateTime(this object value)
        {
            DateTime? dt = value.ConvertToString().IsNullOrEmpty() ? null : (DateTime?)Convert.ToDateTime(value);
            if (dt.IsNullOrMinValue())
                return null;

            return dt;
        }

        public static decimal? ConvertToNullableDecimal(this object value)
        {
            return value.ConvertToString().IsNullOrEmpty() ? null : (decimal?)Convert.ToDecimal(value);
        }

        public static int? ConvertToNullableInt(this object value, int? defaultValue = 0)
        {
            return value.ConvertToString().IsNullOrEmpty() ? defaultValue : (int?)Convert.ToInt32(value);
        }

        public static bool ConvertToBoolean(this object value)
        {
            return value.ConvertToString().IsNullThenEmpty().Equals("true", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
