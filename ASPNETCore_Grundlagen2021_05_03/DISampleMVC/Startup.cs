using DependencyInjectionIntroSample.GoodSample;
using DISampleMVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DISampleMVC
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
            services.AddControllersWithViews(); // MVC ->Konvetion -> Model/View/Controller - Verzeichnis werden benötigt

            //Registrieren das Objekt MockCar in unseren IOC-Container
            services.AddSingleton(typeof(ICar), typeof(MockCar)); 

            services.AddTransient(typeof(ICar), typeof(MockCar));
            services.AddScoped(typeof(ICar), typeof(MockCar));
            //services.AddSingleton(typeof(ICar), typeof(Car)); -> Bei doppelten ICar, wird die letzte Definition genommen

            services.Configure<SampleWebSettings>(Configuration);

            //services.AddRazorPages(); //Koventionen -> Pages-Verzeichnis würde benötigt.//
            //services.AddControllers(); //WebAPI -> Controller-Verzeichnis oder Controller/api - Verzeichnnis
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
