using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcms.Core.Utility
{
    public class LambdaProvider
    {

        /// <summary>
        /// 通过FilterCondition解析得到Lambda表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static System.Linq.Expressions.Expression<Func<T, bool>> GetLambdaByFilter<T>(FilterCondition filter)
        {
            System.Linq.Expressions.ParameterExpression mParameter = System.Linq.Expressions.Expression.Parameter(typeof(T), filter.FieldName);
            System.Linq.Expressions.MemberExpression member = System.Linq.Expressions.Expression.Property(mParameter, filter.FieldName);
            Type type = typeof(T).GetProperty(filter.FieldName).PropertyType;
            //构造单个参数值和多个参数值的常量表达式
            System.Linq.Expressions.ConstantExpression constant = System.Linq.Expressions.Expression.Constant(Convert.ChangeType(filter.Value, type), type);
            
            List<System.Linq.Expressions.ConstantExpression> lstConstant = null;
            if (filter.ListValue != null && filter.ListValue.Count() > 0)
            {
                lstConstant = new List<System.Linq.Expressions.ConstantExpression>();
                foreach (var item in filter.ListValue)
                {
                    lstConstant.Add(System.Linq.Expressions.Expression.Constant(Convert.ChangeType(item, type), type));
                }
            }
            System.Linq.Expressions.Expression operation = null;
            switch (filter.Operator)
            {
                case FilterOperator.Equals:
                    operation = System.Linq.Expressions.Expression.Equal(member, constant);
                    break;
                case FilterOperator.DoesNotEqual:
                    operation = System.Linq.Expressions.Expression.NotEqual(member, constant);
                    break;
                case FilterOperator.IsGreaterThan:
                    operation = System.Linq.Expressions.Expression.GreaterThan(member, constant);
                    break;
                case FilterOperator.IsGreaterThanOrEqaulTo:
                    operation = System.Linq.Expressions.Expression.GreaterThanOrEqual(member, constant);
                    break;
                case FilterOperator.IsLessThan:
                    operation = System.Linq.Expressions.Expression.LessThan(member, constant);
                    break;
                case FilterOperator.IsLessThanOrEqaulTo:
                    operation = System.Linq.Expressions.Expression.LessThanOrEqual(member, constant);
                    break;
                case FilterOperator.Contains:
                    System.Reflection.MethodInfo containsMethod = typeof(string).GetMethod("Contains");
                    operation = System.Linq.Expressions.Expression.Call(member, containsMethod, constant);
                    break;
                case FilterOperator.Or:
                    foreach (var item in lstConstant)
                    {
                        System.Linq.Expressions.Expression expression = System.Linq.Expressions.Expression.Equal(member, item);
                        if (operation == null)
                            operation = expression;
                        else
                            operation = System.Linq.Expressions.Expression.Or(operation, expression);
                    }
                    break;
                default:
                    break;
            }
            return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(operation, mParameter);
        }
    }
}
