using SistemaFacturacion.Aplicacion.DTO;
using SistemaFacturacion.Aplicacion.ViewModels;
using SistemaFacturacion.Dominio.Data; 
using System.Collections.Generic; 

namespace SistemaFacturacion.Aplicacion.Interface
{
    public interface IFacturaServicios
    {
        public FacturaViewModel BuscarFactura(int codfactura);

        public List<FacturaViewModel> ListarFacturas();

        public int IngresarFactura(DataContext contextTransaccion, CrearFacturaDTO ingresarFactura);

        public bool EditarFactura(DataContext contextTransaccion, ActualizarFacturaDTO editarFactura);

        public bool EliminarFactura(DataContext contextTransaccion, int idfactura);
    }
}
