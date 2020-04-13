using HttpHandler.BL.Services;
using HttpHandler.DAL.Context;
using HttpHandler.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using HttpHandler.WebApp.Formatters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace HttpHandler.WebApp
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
            services.AddDbContext<NorthwindEFContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("Northwind")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderService, OrderService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers(options =>
                {
                    options.RespectBrowserAcceptHeader = true;
                    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                    options.OutputFormatters.Add(new ExcelOutputFormatter());
                    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", 
                        new MediaTypeHeaderValue("application/xml"));
                    options.FormatterMappings.SetMediaTypeMappingForFormat("excel", 
                        new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
