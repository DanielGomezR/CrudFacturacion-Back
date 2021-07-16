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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServicios _iClienteServices;

        public ClienteController(IClienteServicios clienteServices)
        {
            _iClienteServices = clienteServices;
        }

        // GET: api/Cliente/Listar
        [HttpGet("[action]")]
        public ActionResult Listar()
        {
            return Ok(_iClienteServices.ListarClientes());
        }

    }
}
