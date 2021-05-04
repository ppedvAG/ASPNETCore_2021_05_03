using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Westwind.AspNetCore.LiveReload;

namespace MiddlewareMVC
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddLiveReload(config =>
            {
                //config.LiveReloadEnabled = true;
                //config.FolderToMonitor = //  PfadangabePath.GetFullname
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseLiveReload();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            #region Customize Middleware (Use/Run)
            //Inline Middleware
            app.Use(async (context, next) =>
            {
                //await context.Response.WriteAsync("Before Invoke from 1st app.Use \n");
                await next(); //Ruft er die nächste Middleware auf
                //await context.Response.WriteAsync("After Invoke from 1st app.Use \n");
            });
            app.Use(async (context, next) =>
            {
                //await context.Response.WriteAsync("Before Invoke from 2nd app.Use \n");
                await next();//Ruft er die nächste Middleware auf
                //await context.Response.WriteAsync("After Invoke from 2nd app.Use \n");
            });

            //Mit Run kann man terminierte Middlewares erstellen
            //app.Run(async (context) =>
            //{
            //    //await context.Response.WriteAsync("Before Terminated \n");
            //    await context.Connection.GetClientCertificateAsync();
            //    //await context.Response.WriteAsync("After Terminated \n");
            //});



            //Zweite Run oder andere Middleware nach einem Run(), wird nicht ausgeführt
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Eigentlich darf man mich nicht ausgeben \n");
            //    await context.Connection.GetClientCertificateAsync();
            //    await context.Response.WriteAsync(" Eigentlich darf man mich nicht ausgeben \n");
            //});
            #endregion


            #region Customize Middleware (Map)
            //////Request                         Response
            //////https://localhost:44362/        Hello from app.Run()
            //////https://localhost:44362/m1      Hello from 1st app.Map()
            //////https://localhost:44362/m1/xyz  Hello from 1st app.Map()
            //////https://localhost:44362/m2      Hello from 2nd app.Map()
            //////https://localhost:44362/m500    Hello from app.Run()
            /////

            //app.Map("/m1", HandleMapOn);
            //app.Map("/m2", appMap =>
            //{
            //    appMap.Run(async context =>
            //    {
            //     await context.Response.WriteAsync("Hello from 2nd app.Mapp()");
            //    });
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from Run()");
            //});
            #endregion

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")),
                RequestPath = "/images"
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void HandleMapOn(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 1st app.Map()");
            });
        }
    }
}
