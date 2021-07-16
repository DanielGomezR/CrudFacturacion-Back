﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace SistemaFacturacion.Aplicacion.DTO
{
    public class CrearFacturaDTO
    {
        [Required(ErrorMessage = "Es requerido")]
        [Column(TypeName = "Date")]
        public DateTime fecha { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        public double subtotal { get; set; }

        public double iva { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        public double total { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        public int idcliente { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        public List<DetalleFacturaDTO> detalle { get; set; }
    }
}
