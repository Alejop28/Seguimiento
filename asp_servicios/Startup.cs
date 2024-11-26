﻿using asp_servicios.Controllers;
//using lib_aplicaciones.Implementaciones;
//using lib_aplicaciones.Interfaces;
using lib_repositorios;
//using lib_repositorios.Implementaciones;
//using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<Conexion, Conexion>();

            /*
             // Repositorios
            services.AddScoped<IMascotasRepositorio, MascotasRepositorio>();
            services.AddScoped<IMascotas_ClientesRepositorio, Mascotas_ClientesRepositorio>();



            // Aplicaciones
            services.AddScoped<IMascotasAplicacion, MascotasAplicacion>();
             services.AddScoped<IMascotas_ClientesAplicacion, Mascotas_ClientesAplicacion>();
             */


            // Controladores
            services.AddScoped<TokenController, TokenController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}