using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ThangNguyen.GlobalTicket.ShoppingBasket.Code;
using ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure;
using ThangNguyen.GlobalTicket.ShoppingBasket.Infrastructure.Repositories;
using ThangNguyen.GlobalTicket.ShoppingBasket.Services;

namespace ThangNguyen.GlobalTicket.ShoppingBasket
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
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<ShoppingBasketDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IBasketLineRepository, BasketLineRepository>();

            services.AddHttpClient<IEventCatalogService, EventCatalogService>(c =>
                c.BaseAddress = new Uri(Configuration["ApiConfigs:EventCatalog:Uri"]));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopping Basket API V1", Version = "v1" });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping Basket API V1");

            });
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
