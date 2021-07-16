using SistemaFacturacion.Aplicacion.ViewModels;
using System.Collections.Generic;

namespace SistemaFacturacion.Aplicacion.Interface
{
    public interface IClienteServicios
    {
        public List<ClienteViewModel> ListarClientes();
    }
}
