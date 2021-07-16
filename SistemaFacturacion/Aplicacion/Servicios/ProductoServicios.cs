using SistemaFacturacion.Aplicacion.Interface;
using SistemaFacturacion.Aplicacion.ViewModels;
using SistemaFacturacion.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Aplicacion.Servicios
{
    public class ProductoServicios : IProductoServicios
    {
        private readonly IProducto _IProducto;

        public ProductoServicios(IProducto producto)
        {
            _IProducto = producto;
        }

        public ProductoViewModel BuscarProducto(int id)
        {
            var datoProducto = _IProducto.BuscarProducto(id);
            return new ProductoViewModel
            {
                id = datoProducto.id,
                idcategoria = datoProducto.idcategoria,
                descripcion = datoProducto.descripcion,
                precio = datoProducto.precio,
                cantidad = datoProducto.cantidadActual
            };
        }

        public List<ProductoViewModel> ListarProductos()
        {
            var datosProductos = _IProducto.ListarProductos();
            return datosProductos.Select(p => new ProductoViewModel
            {
                id = p.id,
                idcategoria = p.idcategoria,
                descripcion = p.descripcion,
                precio = p.precio,
                cantidad = p.cantidadActual

            }).ToList();
        }
    }
}
