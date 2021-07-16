using SistemaFacturacion.Dominio.Data;
using SistemaFacturacion.Dominio.Entidades;
using SistemaFacturacion.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Dominio.DAO
{
    public class DetalleFacturaDAO : IDetalleFactura
    {

        private readonly DataContext _context;

        public DetalleFacturaDAO()
        {
            _context = new DataContext();
        }

        public DetalleFactura BuscarDetalleFactura(int id)
        {
            return _context
                .DetalleFacturas
                .Where(p => p.id == id)
                .FirstOrDefault();
        }

        public List<DetalleFactura> BuscarDetalleFacturaxFactura(int idFactura)
        {
            return _context
                .DetalleFacturas
                .Where(p => p.idfactura == idFactura)
                .ToList();
        }

        public void CrearDetalleFactura(DataContext contextTransaccion, DetalleFactura detalleFactura)
        {
            contextTransaccion.Add(detalleFactura);
            contextTransaccion.SaveChanges();
        }

        public void ActualizarDetalleFactura(DataContext contextTransaccion, DetalleFactura detalleFactura)
        {
            contextTransaccion.Update(detalleFactura);
            contextTransaccion.SaveChanges();
        }

        public void EliminarDetalleFactura(DataContext contextTransaccion, DetalleFactura detalleFactura)
        {
            contextTransaccion.DetalleFacturas.Remove(detalleFactura);
            contextTransaccion.SaveChanges();
        } 
    }
}
