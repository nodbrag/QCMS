using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qcms.Core.Utility
{
    public class FilterCondition
    {
        public string FieldName { get; set; }
        public string Value { get; set; }
        public List<string> ListValue { get; set; }
        public FilterOperator Operator { get; set; }
    }

    public enum FilterOperator
    {
        Equals,
        DoesNotEqual,
        IsGreaterThan,
        IsGreaterThanOrEqaulTo,
        IsLessThan,
        IsLessThanOrEqaulTo,
        Contains,
        Or
    }
}
