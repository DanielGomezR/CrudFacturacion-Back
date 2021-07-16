using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Dominio.Entidades
{
    public class DetalleFactura
    {
        [Key]
        public int id { get; set; }

        [Required]
        public double subtotal { get; set; }

        [Required]
        public int cantidad { get; set; }

        [ForeignKey("Factura")]
        public int idfactura { get; set; }

        [ForeignKey("Producto")]
        public int idproducto { get; set; }

        public Factura Factura { get; set; }
        public Producto Producto { get; set; }
    }
}
