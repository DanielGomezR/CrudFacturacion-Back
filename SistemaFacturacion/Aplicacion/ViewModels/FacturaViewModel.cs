using System.Collections.Generic;

namespace SistemaFacturacion.Aplicacion.ViewModels
{
    public class FacturaViewModel
    {
        public int id { get; set; }

        public string fecha { get; set; }

        public double subtotal { get; set; }

        public double iva { get; set; }

        public double total { get; set; }

        public int idcliente { get; set; }

        public string createdday { get; set; }

        public ClienteViewModel cliente { get; set; }

        public List<DetalleFacturaViewModel> detalle { get; set; }
    }
}
