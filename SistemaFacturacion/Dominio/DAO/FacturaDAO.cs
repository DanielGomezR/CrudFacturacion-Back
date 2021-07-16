using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.Dominio.Data;
using SistemaFacturacion.Dominio.Entidades;
using SistemaFacturacion.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaFacturacion.Dominio.DAO
{
    public class FacturaDAO : IFactura
    {
        private readonly DataContext _context;

        public FacturaDAO()
        {
            _context = new DataContext();
        }

        public Factura BuscarFactura(int idfactura)
        {
            return _context
                .Facturas
                .Where(f => f.anulada == false)
                .Where(f => f.id == idfactura)
                .Include(f => f.Cliente)
                .Include(f => f.DetalleFacturas)
                .ThenInclude(d => d.Producto) 
                .FirstOrDefault();
        }

        public List<Factura> ListarFacturas()
        {
            return _context
                .Facturas
                .Where(f => f.anulada == false)
                .Include(f => f.Cliente)
                .Include(f => f.DetalleFacturas)
                .ThenInclude(d => d.Producto)
                .ToList();
        }

        public int RegistrarFactura(DataContext contextTransaccion, Factura factura)
        {
            factura.createdday = DateTime.Now;
            contextTransaccion.Facturas.Add(factura);
            contextTransaccion.SaveChanges();
            return factura.id;
        }

        public void ActualizarFactura(DataContext contextTransaccion, Factura factura)
        {
            _context.Facturas.Update(factura);
            _context.SaveChanges();
        }

        public void EliminarFactura(DataContext contextTransaccion, Factura factura)
        {
            factura.anulada = true;
            ActualizarFactura(contextTransaccion, factura);
        }
    }
}
