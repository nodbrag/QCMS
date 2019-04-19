using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qcms.Core.CodeGenerator;
using Qcms.Core.CodeGenerator.Models;
using Qcms.Core.CodeGenerator.Options;

namespace Qcms.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("代码生成中....");
            var serviceProvider = BuildServiceForSqlServer();
            var codeGenerator = serviceProvider.GetRequiredService<CodeGenerator>();
            codeGenerator.GenerateTemplateCodesFromDatabase(true);
            Console.WriteLine("代码生成已ok");
            Console.ReadKey();
        }
        /// <summary>
        /// 构造依赖注入容器，然后传入参数
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider BuildServiceForSqlServer()
        {
            var services = new ServiceCollection();
            services.Configure<CodeGenerateOption>(options =>
            {
                options.ConnectionString = "Data Source=.;Initial Catalog=EnergyV2;User ID=sa;Password=Password01!;Persist Security Info=True;Max Pool Size=50;Min Pool Size=0;Connection Lifetime=300;";
                options.DbType = DatabaseType.SqlServer.ToString();//数据库类型是SqlServer,其他数据类型参照枚举DatabaseType
                options.Author = "CodeGeneratorTool";//作者名称
                options.OutputPath = "C:\\CodeGenerator";//模板代码生成的路径
                options.UseGenerateModels("Qcms.Model");//实体命名空间
                options.UseGenerateIRepository("Qcms.IRepository");//仓储接口命名空间
                options.UseGenerateRepository("Qcms.Repository");//仓储命名空间
                options.UseGenerateIServices("Qcms.IService");//服务接口命名空间
                options.UseGenerateServices("Qcms.Service");//服务命名空间
                options.UseGenerateController("Qcms.Api.Controllers");
                options.UseGenerateDtos("Qcms.Model.DtoModel");

            });
            services.Configure<DbOption>("db", GetConfiguration().GetSection("DbOpion"));
            services.AddScoped<CodeGenerator>();
            return services.BuildServiceProvider(); //构建服务提供程序
        }

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
