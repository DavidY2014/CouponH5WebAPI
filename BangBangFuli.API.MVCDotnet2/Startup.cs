using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.API.MVCDotnet2.Extensions;
using BangBangFuli.H5.API.Core;
using BangBangFuli.H5.API.Core.Entities;
using BangBangFuli.H5.API.EntityFrameworkCore;
using BangBangFuli.Utils.ORM.Imp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BangBangFuli.API.MVCDotnet2
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
            //services.AddScoped<IDbContextManager<CouponSystemDBContext>>(s =>
            //{
            //    return new DbContextManager<CouponSystemDBContext>(new ConnectionOption()
            //    {
            //        Master = Configuration.GetConnectionString("H5BasicData"),
            //        SqlProvider = SqlProvider.SqlServer
            //    });
            //});

            services.AddDbContext<CouponSystemDBContext>(d => d.UseSqlServer(Configuration.GetConnectionString("H5BasicData")));
            services.AddScoped<IUnitOfWork, H5.API.EntityFrameworkCore.UnitOfWork<CouponSystemDBContext>>();//注入UOW依赖，确保每次请求都是同一个对象
            //权限关联
            services.AddIdentity<User, IdentityRole>()
                 .AddEntityFrameworkStores<CouponSystemDBContext>();

            //services.AddControllersWithViews();
            services.AddByAssembly("BangBangFuli.H5.API.EntityFrameworkCore", "IBaseRepository");
            services.AddByAssembly("BangBangFuli.H5.API.Application", "IAppService");

            services.AddCors(options =>
            {
                options.AddPolicy("allow_all", builder =>
                {
                    builder.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
                });
            });
            services.AddMvc();


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            //启用认证
            app.UseAuthentication();

            app.UseCors("allow_all");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
