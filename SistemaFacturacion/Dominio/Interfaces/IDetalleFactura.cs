using SistemaFacturacion.Dominio.Data;
using SistemaFacturacion.Dominio.Entidades;
using System.Collections.Generic;

namespace SistemaFacturacion.Dominio.Interfaces
{
    public interface IDetalleFactura
    {
        public DetalleFactura BuscarDetalleFactura(int id);
        public List<DetalleFactura> BuscarDetalleFacturaxFactura(int idFactura);

        public void CrearDetalleFactura(DataContext contextTransaccion, DetalleFactura detalleFactura);

        public void ActualizarDetalleFactura(DataContext contextTransaccion, DetalleFactura detalleFactura);

        public void EliminarDetalleFactura(DataContext contextTransaccion, DetalleFactura detalleFactura);
    }
}
