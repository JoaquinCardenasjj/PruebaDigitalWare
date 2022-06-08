using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PruebaDigitalWare.BL;
using PruebaDigitalWare.BL.Clientes;
using PruebaDigitalWare.BL.Compras;
using PruebaDigitalWare.BL.DetalleCompras;
using PruebaDigitalWare.BL.Productos;
using PruebaDigitalWare.DAL.Clientes;
using PruebaDigitalWare.DAL.Compras;
using PruebaDigitalWare.DAL.DetalleCompras;
using PruebaDigitalWare.DAL.ModelData;
using PruebaDigitalWare.DAL.Productos;
using PruebaDigitalWare.DTO;
using PruebaDigitalWare.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDigitalWare
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOriginis = "http://localhost:4200/";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());

            });
            services.AddCors((options =>
            {
                options.AddPolicy(name: MyAllowSpecificOriginis, builder =>
                {
                    builder
                        .WithOrigins("*")
                        .WithMethods("GET", "POST", "PUT")
                        .WithHeaders("Content-Type", "X-amz-Date", "Authorization", "X-Api-Key", "X-Amz-Security-Token", "X-Amz-User-Agent", "X-Category");

                });


            }));
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IGeneralMethodsBl<ProductoDto>, ProductoBl>();
            services.AddTransient<IGeneralMethodsBl<DetalleCompraDto>, DetalleCompraBl>();
            services.AddTransient<IGeneralMethodsBl<CompraDto>, CompraBl>();
            services.AddTransient<ICompraBl, CompraBl>();
            services.AddTransient<IGeneralMethodsBl<ClienteDto>, ClienteBl>();
            
            services.AddTransient<IGeneralMethodsDal<ProductoDto>, ProductoDal>();
            services.AddTransient<IGeneralMethodsDal<DetalleCompraDto>, DetalleCompraDal>();
            services.AddTransient<IGeneralMethodsDal<CompraDto>, CompraDal>();
            services.AddTransient<IGeneralMethodsDal<ClienteDto>, ClienteDal>();

            services.AddDbContext<pruebaDigitalWareContext>(options => options.UseSqlServer("Server=DESKTOP-TKCRCIL\\DEVELOP; database=pruebaDigitalWare;user id=develop; password=123"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebaDigitalWare", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaDigitalWare v1"));
            }
            app.UseCors(MyAllowSpecificOriginis);
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
