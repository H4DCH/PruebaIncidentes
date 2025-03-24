using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaJunior.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int IncidenteId { get; set; }
        [ForeignKey("IncidenteId")]
        public Incidente Incidente { get; set; }
    }
}
