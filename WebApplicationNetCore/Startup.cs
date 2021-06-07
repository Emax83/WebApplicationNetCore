using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNetCore.Interfaces;
using WebApplicationNetCore.Models;
using WebApplicationNetCore.Repositories;

namespace WebApplicationNetCore
{
    public class Startup
    {
        //appsettings.json configuration
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            //services.AddMvc();

            //adding entity framework service --> vedi 1) appsettings.json per la connection.
            //nuget packet manager add Microsoft.EntityFrameworkCore.SqlServer
            //nuget packet manager add Microsoft.EntityFrameworkCore.Tools
            //add using Microsoft.EntityFrameworkCore;
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //register our own services //dependency injections
            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //see static method public static ShoppingCart GetCart(IServiceProvider services)
            services.AddScoped<ShoppingCart>(sp=> ShoppingCart.GetCart(sp));

            //services.AddTransient();
            //services.AddSingleton();
            //default framework services
            services.AddControllersWithViews();

            services.AddHttpContextAccessor();

            //to use sessions.. the app.UseSession();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //add middleware components here
            //they will be executed sequentially by request and then response

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

            //to use sessions.. --> services.AddSession();
            app.UseSession();

            app.UseHttpsRedirection();

            app.UseStatusCodePages();

            app.UseStaticFiles();  //javascript files, css and others..

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
