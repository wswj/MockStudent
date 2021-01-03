using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace MockStudentManager
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            ///开启mvc路由
            services.AddMvc(e => e.EnableEndpointRouting = false);
        }
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                ///
            }
            //添加默认文件支持(默认寻找顺序 index.html---default.html)
            //必须再usestaticfile之前注册
            //app.UseDefaultFiles();
            //使用自定义默认文件
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("wswj.html");
            app.UseDefaultFiles(options);

            //添加自定义静态文件
            StaticFileOptions staticFileOptions = new StaticFileOptions();
            //自定义地址
            staticFileOptions.FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"MyStaticFile"));
            //请求路径
            staticFileOptions.RequestPath = new PathString("/Static");
            app.UseStaticFiles(staticFileOptions);
            //添加静态文件支持
            //app.UseStaticFiles();'
            //app.run(async (context) =>
            //{
            //    解决中文乱码
            //    context.response.contenttype = "text/plain;charset=utf-8";
            //    await context.response.writeasync(_configuration["mykey"]);

            //});
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=index}/{id?}");
            });
        }
    }
}
