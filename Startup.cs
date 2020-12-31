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
using TheWayShop_2._0.DB;
using TheWayShop_2._0.Interfaces;
using TheWayShop_2._0.Models;
using TheWayShop_2._0.Repositories;

namespace TheWayShop_2._0
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllersWithViews();
             //services.AddTransient<IAllThings<Thing>, ThingRepository>();
            //services.AddSingleton(typeof(IAllThings<>), typeof(ThingRepository));
            //services.AddScoped(typeof(IAllThings<Thing>),typeof(ThingRepository));

            //services.AddScoped(typeof(IAllCategories<>), typeof(CategoryRepository));
            //services.AddScoped(typeof(IAllCategoryItems<>), typeof(CategoryItemRepository));

            services.AddMvc();

            services.AddMvcCore();

            services.AddMemoryCache();
            services.AddSession();
            services.AddRazorPages();


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
            //using (var scope = app.ApplicationServices.CreateScope())
            //{
            //    AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            //    AppDbInitializer.Initial(context);
            //}
        }

    }
}
