using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Dominio.Entidades
{
    public class Factura
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime fecha { get; set; }

        [Required]
        public double subtotal { get; set; }

        [Required]
        public double iva { get; set; }

        [Required]
        public double total { get; set; }

        [ForeignKey("Cliente")]
        public int idcliente { get; set; }

        [Required]
        public DateTime createdday { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        [DefaultValue(0)]
        public bool anulada { get; set; }

        public Cliente Cliente { get; set; }
        public List<DetalleFactura> DetalleFacturas { get; set; }
    }
}
