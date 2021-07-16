using SistemaFacturacion.Dominio.Entidades; 
using System.Collections.Generic; 
namespace SistemaFacturacion.Dominio.Interfaces
{
    public interface ICliente
    {
        public List<Cliente> ListarClientes();

    }
}
