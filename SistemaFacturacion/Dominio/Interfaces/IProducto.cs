using SistemaFacturacion.Dominio.Data;
using SistemaFacturacion.Dominio.Entidades; 
using System.Collections.Generic; 

namespace SistemaFacturacion.Dominio.Interfaces
{
    public interface IProducto
    {
        public Producto BuscarProducto(int cod);

        public List<Producto> ListarProductos();

        public void RestarCantidadProducto(DataContext contextTransaccion, int idproducto, int cantidad);

        public void SumarCantidadProducto(DataContext contextTransaccion, int idproducto, int cantidad);
    }
}
