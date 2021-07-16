using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaFacturacion.Dominio.Entidades;
using System.IO; 

namespace SistemaFacturacion.Dominio.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:ConnectionStringNombre"])
                .EnableSensitiveDataLogging(true);
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; } 
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }

    }
}
