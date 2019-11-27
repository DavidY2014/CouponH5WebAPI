using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BangBangFuli.H5.API.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BangBangFuli.H5.API.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            #region CodeFirst 用

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    try
            //    {
            //        var context = services.GetRequiredService<CouponSystemDBContext>();
            //        DbIniializer.Initialize(context);
            //    }
            //    catch (Exception e)
            //    {
            //        //初始化系统测试数据的时候报错，请联系管理员。
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(e, "初始化系统测试数据的时候报错，请联系管理员。");

            //    }
            //}


            #endregion


            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
           //.UseKestrel()
            //.UseUrls("http://localhost:5000", "http://10.10.21.253:9009")
            //.UseIISIntegration()
            //.UseUrls("http://*:5000")
                .UseStartup<Startup>();
    }
}
