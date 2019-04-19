using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Core.Extensions
{
    public static class ExceptionExtension
    {
        /// <summary>
        /// 获取最里层异常信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetInnerEorror(this Exception ex)
        {
            string errorMsg = ex.Message;

            if (ex.InnerException != null)
            {
                errorMsg = ex.InnerException.Message;
            }

            return errorMsg;
        }
    }
}
