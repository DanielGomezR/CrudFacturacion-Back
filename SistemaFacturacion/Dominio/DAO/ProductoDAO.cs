using SistemaFacturacion.Dominio.Data;
using SistemaFacturacion.Dominio.Entidades;
using SistemaFacturacion.Dominio.Interfaces; 
using System.Collections.Generic;
using System.Linq; 

namespace SistemaFacturacion.Dominio.DAO
{
    public class ProductoDAO : IProducto
    {
        private readonly DataContext _context;

        public ProductoDAO()
        {
            _context = new DataContext();
        }

        public Producto BuscarProducto(int id)
        {
            return _context
                .Productos
                .Where(p => p.id == id) 
                .FirstOrDefault();
        }

        public List<Producto> ListarProductos()
        {
            return _context
                .Productos 
                .ToList();
        }

        public void RestarCantidadProducto(DataContext contextTransaccion, int idproducto, int cantidad)
        {
            var producto = contextTransaccion
                .Productos
                .Where(p => p.id == idproducto)
                .FirstOrDefault();
            producto.cantidadActual -= cantidad;
            contextTransaccion.Update(producto);
            contextTransaccion.SaveChanges();
        }
        public void SumarCantidadProducto(DataContext contextTransaccion, int idproducto, int cantidad)
        {
            var producto = contextTransaccion
                .Productos
                .Where(p => p.id == idproducto)
                .FirstOrDefault();
            producto.cantidadActual += cantidad;
            contextTransaccion.Update(producto);
            contextTransaccion.SaveChanges();
        }
    }
}
