using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.Aplicacion.DTO;
using SistemaFacturacion.Aplicacion.Interface;
using SistemaFacturacion.Dominio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {

        private DataContext _contextTransaccion;
        private readonly IFacturaServicios _IFacturaServicios;

        public FacturaController(IFacturaServicios facturaServicios)
        {
            _IFacturaServicios = facturaServicios;
        }

        // GET: api/Factura/Listar
        [HttpGet("[action]")]
        public ActionResult Listar()
        {
            return Ok(_IFacturaServicios.ListarFacturas());
        }

        // GET: api/Factura/Buscar/5
        [HttpGet("[action]/{codfactura}")]
        public ActionResult Buscar(int codfactura)
        {
            return Ok(_IFacturaServicios.BuscarFactura(codfactura));
        }

        // POST: api/Factura/Crear
        [HttpPost("[action]")]
        public ActionResult Crear([FromBody] CrearFacturaDTO crearFactura)
        {
            // Instancia DataContext
            _contextTransaccion = new DataContext();
            // Iniciamos la transaccion
            var contextTransaccion = _contextTransaccion.Database.BeginTransaction();

            try
            {
                _IFacturaServicios.IngresarFactura(_contextTransaccion, crearFactura);
                //Hacemos commit de todos los datos
                contextTransaccion.Commit();
                return new OkResult();
            }
            catch (Exception ex)
            {
                //Hacemos rollback si hay excepción
                contextTransaccion.Rollback();
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // PUT: api/Factura/Actualizar
        [HttpPut("[action]")]
        public ActionResult Actualizar([FromBody] ActualizarFacturaDTO actualizarFactura)
        {
            // Instancia DataContext
            _contextTransaccion = new DataContext();
            // Iniciamos la transaccion
            var contextTransaccion = _contextTransaccion.Database.BeginTransaction();
            try
            {
                if (_IFacturaServicios.EditarFactura(_contextTransaccion, actualizarFactura))
                {
                    //Hacemos commit de todos los datos
                    contextTransaccion.Commit();
                    return new OkResult();
                }
                else
                { 
                    //No se encontró la factura
                    return new BadRequestObjectResult("No se encontró la factura");
                }
            }
            catch (Exception ex)
            {
                //Hacemos rollback si hay excepción
                contextTransaccion.Rollback();
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // Anular: api/Factura/Anular
        [HttpPut("[action]")]
        public ActionResult Anular([FromBody] EliminarFacturaDTO eliminarFactura)
        {
            // Instancia DataContext
            _contextTransaccion = new DataContext();
            // Iniciamos la transaccion
            var contextTransaccion = _contextTransaccion.Database.BeginTransaction();

            try
            {
                if (_IFacturaServicios.EliminarFactura(_contextTransaccion, eliminarFactura.id))
                {
                    //Hacemos commit de todos los datos
                    contextTransaccion.Commit();
                    return new OkResult();
                }
                else
                {
                    return new BadRequestObjectResult("No se pudo encontrar la factura, por favor actualizce y vuelva a intentar");
                }
            }
            catch (Exception ex)
            {
                //Hacemos rollback si hay excepción
                contextTransaccion.Rollback(); 
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
