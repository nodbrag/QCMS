using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Qcms.Core.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        /// <summary>
                /// 发生异常时进入
                /// </summary>
                /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled == false)
            {
                string errorMsg = string.Empty;
                if (context.Exception != null)
                {
                    errorMsg = context.Exception.Message;
                    if (context.Exception.InnerException != null)
                    {
                        errorMsg = context.Exception.InnerException.Message;
                    }
                }
                context.Result = new ObjectResult(new Dtos.BadOpResult(errorMsg));

            }
            context.ExceptionHandled = true;
        }

        /// <summary>
                /// 异步发生异常时进入
                /// </summary>
                /// <param name="context"></param>
                /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }


    }
}
