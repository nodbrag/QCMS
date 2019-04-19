using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qcms.Api.CoreBuilder;


namespace Qcms.Api
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            ICoreServiceBuilder coreServiceBuilder = new CoreServiceBuilder(services,_configuration);
            coreServiceBuilder.AddDbcontext();
            coreServiceBuilder.AddAppService();
            coreServiceBuilder.AddFluentValidationService();
            coreServiceBuilder.AddMvcExtensions();
            coreServiceBuilder.AddSwaggerGenerator();
            coreServiceBuilder.AddCors();
            coreServiceBuilder.AddAutoMapper();
            coreServiceBuilder.AddMiniProfiler();
            coreServiceBuilder.AddJwtAuth();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            var module = new ConfigurationModule(_configuration);
            builder.RegisterModule(module);
            Autofac.IContainer Container = builder.Build();
            return new AutofacServiceProvider(Container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {

            ICoreConfigurationBuilder coreConfigurationBuilder = new CoreConfigureBuilder(app, env, svp, _configuration);
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            coreConfigurationBuilder.UseCors(CorsPolicyType.AllRequests);
            coreConfigurationBuilder.UseSwagger();
            coreConfigurationBuilder.UseAuth();
            coreConfigurationBuilder.UseMiniProfiler();
            coreConfigurationBuilder.UseOther();
            app.UseHttpsRedirection();
            app.UseMvc();
          
        }
    }
}
