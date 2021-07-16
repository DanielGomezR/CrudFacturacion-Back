using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using SistemaFacturacion.Aplicacion.DTO;
using SistemaFacturacion.Aplicacion.Interface;
using SistemaFacturacion.Aplicacion.Servicios;
using SistemaFacturacion.Dominio.DAO;
using SistemaFacturacion.Dominio.Entidades;
using SistemaFacturacion.Dominio.Interfaces; 

namespace SistemaFacturacion
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
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularLocal", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build());
            }); 
            // Inicializar AutoMapper
            services.AddAutoMapper(configuracion =>
            {
                configuracion.CreateMap<DetalleFacturaDTO, DetalleFactura>().ReverseMap();
                configuracion.CreateMap<CrearFacturaDTO, Factura>().ReverseMap();
                configuracion.CreateMap<ActualizarFacturaDTO, Factura>().ReverseMap();
            });

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // PRODUCTOS
            services.AddScoped<IProducto, ProductoDAO>();
            services.AddScoped<IProductoServicios, ProductoServicios>();

            // CLIENTES
            services.AddScoped<ICliente, ClienteDAO>();
            services.AddScoped<IClienteServicios, ClienteServicios>(); 

            // DETALLEFACTURA
            services.AddScoped<IDetalleFactura, DetalleFacturaDAO>();

            // FACTURA
            services.AddScoped<IFactura, FacturaDAO>();
            services.AddScoped<IFacturaServicios, FacturaServicios>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAngularLocal");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
