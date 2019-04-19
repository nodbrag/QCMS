using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Qcms.Core.Extensions;

namespace Qcms.Core.Utility
{
    public class FilterCondtionHelper
    {
        /*filter":{"operatingTime^lower":"2019-04-15 14:30","operatingTime^upper":"2019-04-09 10:30"}*/
        public static Tuple<string, object[]> GetExpression<TEntity>(Dictionary<string, string> filter)
        {
            string wherestr = "";
            List<object> objlist = new List<object>();

            foreach (string filterKey in filter.Keys.ToList())
            {
                string value = filter[filterKey];
                if (value.Length == 0) continue;

                string[] keys = filterKey.ToLower().Split('^');
                if (keys.Count() > 2) continue;

                string keyEx = null;
                if (keys.Count() == 2)
                {
                    keyEx = keys[1];
                    if (!keyEx.Equals("lower") && !keyEx.Equals("upper")) continue;
                }

                string key = keys[0];
                string[] subKeys = key.Split('.');
                PropertyInfo[] propertys = typeof(TEntity).GetProperties();
                PropertyInfo propertyInfo = null;
                int i = 0;
                while (i < subKeys.Count())
                {
                    string subKey = subKeys[i++];
                    propertyInfo = propertys.Where(m => m.Name.ToLower().Equals(subKey)).FirstOrDefault();
                    if (propertyInfo == null) break;
                    propertys = propertyInfo.PropertyType.GetProperties();

                }
                if (propertyInfo == null) continue;
                string whereClause = "";
                int index = 0;
                if (wherestr.IsNotNullAndEmpty()) {
                    if (wherestr.IndexOf("&&") == -1)
                    {
                        index = 1;
                    }
                    else {
                        index = wherestr.Split("&&").Length; 
                    }
                }
                string propertyType = propertyInfo.PropertyType.Name;
                if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    propertyType = Nullable.GetUnderlyingType(propertyInfo.PropertyType).Name;
                switch (propertyType)
                {
                    case "Int32":
                    case "Decimal":
                    case "Boolean":
                    case "DateTime":
                        if (!BuildWhereClause_Generic(key, keyEx, ref whereClause, index)) continue;
                        break;
                    case "String":
                        if (!BuildWhereClause_String(key, keyEx, ref value, ref whereClause, index)) continue;
                        break;
                    default:
                        if (!BuildWhereClause_Default(key, keyEx, ref whereClause, index)) continue;
                        break;
                }

                object obj = null;

                if (!propertyInfo.PropertyType.IsGenericType)
                    obj = string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, propertyInfo.PropertyType);
                else if (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    obj = string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(propertyInfo.PropertyType));
                if (wherestr.IsNotNullAndEmpty())
                    wherestr += "&&" + whereClause;
                else
                    wherestr += whereClause;

                objlist.Add(obj);
            }

            return new Tuple<string, object[]>(wherestr, objlist.ToArray());
        }
        private static bool BuildWhereClause_String(string key, string keyEx, ref string value, ref string whereClause,int index)
        {

            int nF = value.IndexOf('%');
            int nL = value.LastIndexOf('%');
            if (nF == 0 && nL == value.Length - 1)
            {
                if (nL - nF < 2) return false;
                value = value.Substring(1, value.Length - 2);

                whereClause = string.Format("{0}.Contains(@"+ index + ")", key);
            }
            else if (nF == 0)
            {
                value = value.Substring(1);
                whereClause = string.Format("{0}.EndsWith(@"+index + ")" , key);
            }
            else if (nL == value.Length - 1)
            {
                value = value.Substring(0, value.Length - 1);
                whereClause = string.Format("{0}.StartsWith(@" + index + ")", key);
            }
            else
                whereClause = string.Format("{0}.Equals(@" + index + ")", key);

            return true;
        }

        private static bool BuildWhereClause_Generic(string key, string keyEx, ref string whereClause,int index)
        {
            if (string.IsNullOrEmpty(keyEx))
                whereClause = string.Format("{0} = @" + index , key);
            else if (keyEx.Equals("lower"))
                whereClause = string.Format("{0} >= @" + index , key);
            else if (keyEx.Equals("upper"))
                whereClause = string.Format("{0} <= @" + index , key);
            else
                return false;

            return true;
        }

        private static bool BuildWhereClause_Default(string key, string keyEx, ref string whereClause,int index)
        {
            whereClause = string.Format("{0} = @"+index, key);
            return false;
        }
    }
}
