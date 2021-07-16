using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.Aplicacion.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicios _iProductoServices;

        public ProductoController(IProductoServicios productoServices)
        {
            _iProductoServices = productoServices;
        }

        // GET: api/Producto/Listar
        [HttpGet("[action]")]
        public ActionResult Listar()
        {
            return Ok(_iProductoServices.ListarProductos());
        }

        // GET: api/Producto/Buscar/codproducto
        [HttpGet("[action]/{codproducto}")]
        public ActionResult Buscar(int codproducto)
        {
            return Ok(_iProductoServices.BuscarProducto(codproducto));
        }
    }
}
