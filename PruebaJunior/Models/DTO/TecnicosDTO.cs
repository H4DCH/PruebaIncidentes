using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaJunior.Models.DTO
{
    public class TecnicosDTO
    {
        public int Id { get; set; }
        public string NombreTecnico { get; set; }
        public List<IncidenteDTO> Incidentes { get; set; }
    }
}
