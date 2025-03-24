using AutoMapper;
using PruebaJunior.Models;
using PruebaJunior.Models.DTO;

namespace PruebaJunior.AutoMapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Incidente, IncidenteDTO>().ReverseMap();
            CreateMap<ActualizarIncidenteDTO, Incidente>().ReverseMap();
            CreateMap<CrearIncidenteDTO, Incidente>();

            CreateMap<Tecnico, TecnicosDTO>().ReverseMap();

            CreateMap<Comentario, ComentarioDTO>().ReverseMap();
        }

    }
}
