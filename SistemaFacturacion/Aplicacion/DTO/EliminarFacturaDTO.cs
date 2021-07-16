using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacion.Aplicacion.DTO
{
    public class EliminarFacturaDTO
    {
        [Required(ErrorMessage = "Es requerido")]
        public int id { get; set; }
    }
}
