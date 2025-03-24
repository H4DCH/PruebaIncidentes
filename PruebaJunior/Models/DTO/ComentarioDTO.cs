using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace PruebaJunior.Models.DTO
{
    public class ComentarioDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime FechaCreacion { get; set; }  

        public int IncidenteId { get; set; }
    }
}
