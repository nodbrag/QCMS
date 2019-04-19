using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.HttpOverrides;

namespace Qcms.Api.CoreBuilder
{
    public class CoreConfigureBuilder : ICoreConfigurationBuilder
    {
        private readonly IApplicationBuilder _app;
        private readonly IHostingEnvironment _env;
        private readonly IServiceProvider _svp;
        private readonly IConfiguration _configuration;
        public CoreConfigureBuilder(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp, IConfiguration configuration)
        {
            _app = app;
            _env = env;
            _svp = svp;
            _configuration = configuration;
        }

        public void UseAuth()
        {
            _app.UseAuthentication();//启用验证
        }

        public void UseCors(CorsPolicyType corsPolicyType)
        {
            if (corsPolicyType == CorsPolicyType.AllRequests)
            {
                _app.UseCors("AllRequests");
            }
            else
            {
                _app.UseCors("LimitRequests");
            }
           
        }

        public void UseErrorHanle()
        {
            throw new NotImplementedException();
        }

        public void UseOther()
        {
            ///获取客户端ip地址
            _app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto });
        }

        public void UseRazorEngine()
        {
            throw new NotImplementedException();
        }

        public void UseSwagger()
        {
            //启用中间件服务生成Swagger作为JSON终结点
            _app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            _app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EMS API V1");
                c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("Qcms.Api.index.html");
                c.DefaultModelExpandDepth(2);//接口列表折叠配置
                c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1);//不显示model
                //c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.None);
                //c.EnableDeepLinking();
                //c.EnableFilter();
                c.ShowExtensions();

            });
        }

        public void UseMiniProfiler()
        {
            // 启用MiniProfiler 性能监测
            _app.UseMiniProfiler();
        }
    }
}
