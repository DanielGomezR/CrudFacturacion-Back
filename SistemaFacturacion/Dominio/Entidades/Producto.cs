using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Dominio.Entidades
{
    public class Producto
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string descripcion { get; set; }

        [Required]
        public double precio { get; set; }

        [ForeignKey("Categoria")]
        public int idcategoria { get; set; }
        public Categoria Categoria { get; set; }

        [Required]
        public int cantidadActual { get; set; }

        public List<DetalleFactura> DetalleFacturas { get; set; }
    }
}
