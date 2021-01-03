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

            ///����mvc·��
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
            //���Ĭ���ļ�֧��(Ĭ��Ѱ��˳�� index.html---default.html)
            //������usestaticfile֮ǰע��
            //app.UseDefaultFiles();
            //ʹ���Զ���Ĭ���ļ�
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("wswj.html");
            app.UseDefaultFiles(options);

            //����Զ��徲̬�ļ�
            StaticFileOptions staticFileOptions = new StaticFileOptions();
            //�Զ����ַ
            staticFileOptions.FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"MyStaticFile"));
            //����·��
            staticFileOptions.RequestPath = new PathString("/Static");
            app.UseStaticFiles(staticFileOptions);
            //��Ӿ�̬�ļ�֧��
            //app.UseStaticFiles();'
            //app.run(async (context) =>
            //{
            //    �����������
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
