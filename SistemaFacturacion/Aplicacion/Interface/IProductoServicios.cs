using SistemaFacturacion.Aplicacion.ViewModels; 
using System.Collections.Generic; 

namespace SistemaFacturacion.Aplicacion.Interface
{
    public interface IProductoServicios
    {
        public ProductoViewModel BuscarProducto(int id);

        public List<ProductoViewModel> ListarProductos();
    }
}
