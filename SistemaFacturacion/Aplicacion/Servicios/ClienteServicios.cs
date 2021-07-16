using SistemaFacturacion.Aplicacion.Interface;
using SistemaFacturacion.Aplicacion.ViewModels;
using SistemaFacturacion.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SistemaFacturacion.Aplicacion.Servicios
{

    public class ClienteServicios : IClienteServicios
    {
        private readonly ICliente _ICliente;

        public ClienteServicios(ICliente cliente)
        {
            _ICliente = cliente;
        }

        public List<ClienteViewModel> ListarClientes()
        {
            var datosClientes = _ICliente.ListarClientes();
            return datosClientes
                .Select(cliente => new ClienteViewModel(cliente))
                .ToList();
        }

    }
}
