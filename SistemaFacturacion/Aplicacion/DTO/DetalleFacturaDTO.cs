using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Aplicacion.DTO
{
    public class DetalleFacturaDTO
    {
        public int? id { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        public double subtotal { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        public int cantidad { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        public int idfactura { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        public int idproducto { get; set; }
    }
}
