using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PruebaJunior.Models.DTO
{
    public class IncidenteDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public EnumEstado Estado { get; set; }
        public EnumPrioridad Prioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }
        public List<ComentarioDTO> Comentarios { get; set; }

    }
}
