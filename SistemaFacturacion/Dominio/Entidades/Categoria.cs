using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Dominio.Entidades
{
    public class Categoria
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string nombre { get; set; }

        public List<Producto> Productos { get; set; }
    }
}
