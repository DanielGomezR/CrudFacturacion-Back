namespace SistemaFacturacion.Aplicacion.ViewModels
{
    public class DetalleFacturaViewModel
    {
        public int id { get; set; }

        public double subtotal { get; set; }

        public int cantidad { get; set; }

        public int idproducto { get; set; }

        public int idfactura { get; set; }

        public double precio { get; set; }

        public string producto { get; set; }
    }
}
