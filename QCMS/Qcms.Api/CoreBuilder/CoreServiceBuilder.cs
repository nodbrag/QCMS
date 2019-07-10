using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Qcms.Core.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Qcms.Model.DataModel;
using Qcms.Core.Route;
using Qcms.Core.Dtos;
using FluentValidation;
using FluentValidation.AspNetCore;
using Qcms.Core.IocHelper;


namespace Qcms.Api.CoreBuilder
{
    public class CoreServiceBuilder : ICoreServiceBuilder
    {
        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _provider;
        public CoreServiceBuilder(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
            _provider = services.BuildServiceProvider();//get an instance of IServiceProvider
           
        }
       
        public void AddAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.IgnoreUnmapped();
            });
        }

        public void AddCache()
        {
            throw new NotImplementedException();
        }

        public void AddCors()
        {
            _services.AddCors(options => {
               
                options.AddPolicy("AllRequests", policy =>
                {
                    policy
                        .AllowAnyOrigin()//允许任何源
                        .AllowAnyMethod()//允许任何方式
                        .AllowAnyHeader()//允许任何头
                        .AllowCredentials();//允许cookie
                });
             
                //一般采用这种方法
                options.AddPolicy("LimitRequests", policy =>
                {
                    policy
                        .WithOrigins(_configuration["AppSettings:Audience"])//支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                        .AllowAnyHeader()//Ensures that the policy allows any header.
                        .AllowAnyMethod();
                });
            });
        }

        public void AddDbcontext()
        {
            _services.AddDbContext<ModelBaseContext>(options => options.UseSqlServer(_configuration["AppSettings:SQLServerConnectionString"]));
        }

        public void AddHttpContext()
        {
            throw new NotImplementedException();
        }

        public void AddJwtAuth()
        {
            //添加jwt验证：
            _services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie()
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = _configuration["AppSettings:Audience"],//Audience
                        ValidIssuer = _configuration["AppSettings:Issuer"],//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["AppSettings:SecurityKey"]))//拿到SecurityKey
                    };
            });
        }

        public void AddLog()
        {
            throw new NotImplementedException();
        }

        public void AddMvcExtensions()
        {
            _services.AddMvc(options =>
            {
               
                options.UseCentralRoutePrefix(new RouteAttribute("api/v1/[controller]/[action]"));
                options.Filters.Add<Qcms.Core.Filter.ExceptionFilter>();
                options.Filters.Add<Qcms.Core.Filter.ModelValidaionFilter>();
                

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddFluentValidation().AddJsonOptions(options =>
            {
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";//设置时间格式

            });
        }

        public void AddSwaggerGenerator()
        {
            _services.AddScoped<SwaggerGenerator>();
            //注册Swagger生成器，定义一个和多个Swagger 文档
            _services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "EMS API", Version = "v1", Description = "新能源接口文档 (查看访问接口路径,参数条件,模块字段)", });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "请输入带有Bearer的Token",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                //Json Token认证方式，此方式为全局添加
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", Enumerable.Empty<string>() }
                });
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "WebApi.xml");
                var xmlPathByModel = Path.Combine(basePath, "WebApi.xml");
                c.IncludeXmlComments(xmlPathByModel);
                //true表示生成控制器描述，包含true的IncludeXmlComments重载应放在最后，或者两句都使用true
                c.IncludeXmlComments(xmlPath, true);
                c.OperationFilter<Qcms.Core.Swagger.SwaggerOperationFilter>(); // 新增swagger过滤
            });
        }

        public void AddMiniProfiler()
        {
            //注入MiniProfiler性能监测
            _services.AddMiniProfiler(options =>
                options.RouteBasePath = "/profiler"
            ).AddEntityFramework();
        }

        public void AddAppService()
        {
            _services.AddScoped<Qcms.Repository.Uow.EFUnitOfWork, Qcms.Repository.Uow.EFUnitOfWork>();
            _services.RegisterAssembly("Qcms.IRepository", "Qcms.Repository");
            _services.RegisterAssembly("Qcms.IService", "Qcms.Service");
           

        }
        public void AddFluentValidationService()
        {
            //注册所有验证类 单个添加例如：services.AddSingleton<IValidator<EMSApi.Dots.UserDots.UserModification>, Validators.UserValidator>();
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(p => p.BaseType != null && p.BaseType.GetInterfaces().Any(x => x == typeof(IValidator)));
            foreach (var type in types)
            {
                var baseType = type.BaseType;
                if (baseType.GenericTypeArguments.Count() > 0)
                {
                    var genericType = typeof(IValidator<>).MakeGenericType(baseType.GenericTypeArguments[0]);
                    _services.AddSingleton(genericType, type);
                }
            }
        }

    }
}
