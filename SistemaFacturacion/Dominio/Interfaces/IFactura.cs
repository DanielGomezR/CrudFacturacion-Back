using SistemaFacturacion.Dominio.Data;
using SistemaFacturacion.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaFacturacion.Dominio.Interfaces
{
    public interface IFactura
    {
        public List<Factura> ListarFacturas();

        public Factura BuscarFactura(int idfactura);

        public int RegistrarFactura(DataContext contextTransaccion, Factura factura);

        public void ActualizarFactura(DataContext contextTransaccion, Factura factura);

        public void EliminarFactura(DataContext contextTransaccion, Factura factura);
    }
}
