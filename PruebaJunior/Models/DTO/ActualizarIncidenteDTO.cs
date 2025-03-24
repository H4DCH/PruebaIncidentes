﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace PruebaJunior.Models.DTO
{
    public class ActualizarIncidenteDTO
    {
        public int Id { get; set; } 
        [Required(ErrorMessage ="El titulo es obligatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage ="La descripcion es obligatoria")]
        public string Descripcion { get; set; }

        public EnumEstado Estado { get; set; }
        public EnumPrioridad Prioridad { get; set; }
        public DateTime FechaActualizacion { get;private set; } = DateTime.Now;
        public int UsuarioId { get; set; }
        public int TecnicoId { get; set; }

    }
}
