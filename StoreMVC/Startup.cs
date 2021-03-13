using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreController;
using StoreData;
using StoreMVC.Controllers;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using StoreModel;
using Microsoft.AspNetCore.Http;

namespace StoreMVC
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
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<StoreDBContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("StoreDB")));

            //identityuser services stuff
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<StoreDBContext>()
                .AddDefaultTokenProviders();



            //add google authentication for customer login
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");

                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];
                });

            //WHENEVER WE ADD NEW BL AND DL DEPENDENCIES, WE MUST DO THIS TOO
            services.AddScoped<ICustomerRepoDB, CustomerRepoDB>();

            services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddTransient<CustomerBL>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductBL, ProductBL>();

            services.AddScoped<ILocationRepository, LocationRepoDB>();
            services.AddScoped<ILocationBL, LocationBL>();


            services.AddScoped<ICartBL, CartBL>();
            services.AddScoped<ICartRepoDB, CartRepoDB>();


            services.AddScoped<ILocationProductBL, LocationProductBL>();
            services.AddScoped<ILocationProductRepoDB, LocationProductRepoDB>();

            services.AddScoped<ICartProductsBL, CartProductsBL>();
            services.AddScoped<ICartProductsRepoDB, CartProductsRepoDB>();
            /*
            services.AddScoped<ILocationBL, LocationBL>();
            services.AddScoped<ILocationProductBL, LocationProductBL>();
            services.AddScoped<IOrderBL, OrderBL>();
            services.AddScoped<IOrderProductsBL, OrderProductsBL>();

            services.AddScoped<ICartBL, CartBL>();
            services.AddScoped<ICartProductsBL, CartProductsBL>();
            */
            services.AddScoped<IMapper, Mapper>();


            //these are the things your application is dependent on

            //in order to access the identity users user id, we must include this:
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                  name: "Cart",
                  pattern: "{area:exists}/{controller=Cart}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "Products",
                    pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "LocationProducts",
                    pattern: "{area:exists}/{controller=LocationProducts}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Products",
                    pattern: "{area:exists}/{controller=Product}/{action=Details}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });






        }
    }
}
