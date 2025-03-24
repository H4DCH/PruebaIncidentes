using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaJunior.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Nombre { get; set; }
        [Required]  
        public string Correo { get; set; }

        public List<Incidente> Incidentes { get; set; }
    }
}
