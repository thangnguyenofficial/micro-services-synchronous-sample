using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThangNguyen.GlobalTicket.Client.Code;
using ThangNguyen.GlobalTicket.Client.Config;
using ThangNguyen.GlobalTicket.Client.Services;

namespace ThangNguyen.GlobalTicket.Client
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
            services.AddHttpClient<IEventCatalogService, EventCatalogService>(c =>
                c.BaseAddress = new Uri(Configuration["ApiConfigs:EventCatalog:Uri"]));
            services.AddHttpClient<IShoppingBasketService, ShoppingBasketService>(c =>
                c.BaseAddress = new Uri(Configuration["ApiConfigs:ShoppingBasket:Uri"]));

            services.AddSingleton<Settings>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
            services.AddCustomAutoMapper()
                .AddCustomApplicationDbContext(Configuration)
                .AddControllersWithViews();
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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
