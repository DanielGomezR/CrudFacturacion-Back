using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Dominio.Entidades
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string nombre { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string apellido { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime fecha_nacimiento { get; set; }

        public List<Factura> Facturas { get; set; }
    }
}
