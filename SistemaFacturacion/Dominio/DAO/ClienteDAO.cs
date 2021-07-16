using SistemaFacturacion.Dominio.Data;
using SistemaFacturacion.Dominio.Entidades;
using SistemaFacturacion.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Dominio.DAO
{
    public class ClienteDAO : ICliente
    {
        private readonly DataContext _context;

        public ClienteDAO()
        {
            _context = new DataContext();
        }

        public List<Cliente> ListarClientes()
        {
            return _context
                .Clientes
                .ToList();
        }

    }
}
