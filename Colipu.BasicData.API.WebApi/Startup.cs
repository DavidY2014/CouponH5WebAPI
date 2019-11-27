using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using BangBangFuli.H5.API.Application;
using BangBangFuli.H5.API.Application.Services.BasicDatas;
using BangBangFuli.H5.API.Application.Services.Redis;
using BangBangFuli.H5.API.EntityFrameworkCore.BSystemDB;
using BangBangFuli.H5.API.EntityFrameworkCore.ECPubDB;
using BangBangFuli.H5.API.WebAPI.AOP;
using BangBangFuli.H5.API.WebAPI.Extensions;
using Colipu.Utils.Cache.Redis.Extension;
using Colipu.Utils.Log.Aliyun;
using Colipu.Utils.ORM.Imp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BangBangFuli.H5.API.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<BSystemDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BasicData")));
            //services.AddDbContext<ECPubDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ECPubDB")));

            services.AddScoped<IDbContextManager<BSystemDBContext>>(s =>
            {
                return new DbContextManager<BSystemDBContext>(new ConnectionOption()
                {
                    Master = Configuration.GetConnectionString("H5BasicData"),
                    SqlProvider = SqlProvider.SqlServer
                });
            });

            services.AddByAssembly("BangBangFuli.H5.API.EntityFrameworkCore", "IBaseRepository");
            services.AddByAssembly("BangBangFuli.H5.API.Application", "IAppService");

            //colipu 版本
            //services.Configure<RedisOptions>(Configuration.GetSection("Redis"));
            //services.AddRedisCache();
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                //options.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddVersionedApiExplorer(options =>
            {
                //The format of the version added to the route URL  
                options.GroupNameFormat = "'v'VVV";
                //Tells swagger to replace the version in the controller route  
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new Swashbuckle.AspNetCore.Swagger.Info
                    {
                        Title = $"棒棒福利网 H5 WebAPI {description.ApiVersion}",
                        Version = description.ApiVersion.ToString()
                    });
                }

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            });


            services.AddAliyunLog(options =>
            {
                Configuration.GetSection("AliyunLog").Bind(options);
            });

            services.AddHttpClient<ILogService, LogService>();

            services.AddAutoMapper(typeof(MapperProfile));


            
            //#region autofac 接管DI容器


            //var builder = new ContainerBuilder();

            //builder.RegisterType<CachingIntercept>(); // 注册AOP

            ////var assemblysServices = Assembly.Load("BangBangFuli.H5.API.Application");
            ////builder.RegisterAssemblyTypes(assemblysServices);


            ////只注入需要AOP的Types,继承ICanCacheService 即可
            //var filterTypes = builder.AddFilterTypes("BangBangFuli.H5.API.Application", "ICanCacheService");
            //builder.RegisterTypes(filterTypes)
            //    .AsImplementedInterfaces()
            //  .InstancePerLifetimeScope()
            //  .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
            //  .InterceptedBy(typeof(CachingIntercept));//可以直接替换拦截器

            //builder.Populate(services);

            //var ApplicationContainer = builder.Build();

            //#endregion

            //return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAliyunLog();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            app.UseMiddleware<ExceptionHandler>();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "api/{controller}/{action}/{id?}");
            });
        }
    }
}
