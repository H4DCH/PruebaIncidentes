using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace PruebaJunior.Models
{
    public class Tecnico
    {
        [Key]
        public int Id { get;set; }
        [Required]  
        public string NombreTecnico { get; set; }
        public List<Incidente> Incidentes { get; set; } 
    }
}
