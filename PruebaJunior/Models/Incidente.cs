using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace PruebaJunior.Models
{
    public class Incidente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]  
        public string Descripcion { get; set; } 

        public EnumEstado Estado { get; set; } 
        public EnumPrioridad Prioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int UsuarioId { get; set; }
        public int TecnicoId { get; set; } 

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("TecnicoId")]
        public Tecnico Tecnico { get; set; }

        public List<Comentario> Comentarios { get; set; }
    }
}
