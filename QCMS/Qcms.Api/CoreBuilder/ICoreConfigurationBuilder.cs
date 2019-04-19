using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Api.CoreBuilder
{
    public interface ICoreConfigurationBuilder
    {
        /// <summary>
        /// MVC模板引擎配置
        /// </summary>
        void UseRazorEngine();

        /// <summary>
        /// 全局错误拦截器配置
        /// </summary>
        void UseErrorHanle();
        /// <summary>
        /// Swagger配置
        /// </summary>
        void UseSwagger();
        /// <summary>
        /// MiniProfiler 配置
        /// </summary>
        void UseMiniProfiler();
        /// <summary>
        /// 认证配置
        /// </summary>
        void UseAuth();

        /// <summary>
        /// 跨域配置
        /// </summary>
        void UseCors(CorsPolicyType corsPolicyType);

        /// <summary>
        /// 其他配置
        /// </summary>
        void UseOther();
       
    }
}
