using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Core.Extensions
{
    public static class IntExtension
    {
        #region int?
        public static int IsNullThenZero(this int? value)
        {
            return null == value ? 0 : (int)value;
        }

        public static bool IsNull(this int? value)
        {
            return null == value;
        }
        #endregion
    }
}
