using AutoMapper;
using GestionCitas.Application.CaracteristicasCita.Commands.ComandoCita;
using GestionCitas.Application.Comunes;
using GestionCitas.Domain.Entities;

namespace GestionPersonas.Application.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Cita
            CreateMap<ComandoCita, Cita>();
            CreateMap<Cita, ComandoCita>().ReverseMap();
            CreateMap<Cita, CitaVM>();
            CreateMap<CitaVM, Cita>().ReverseMap();
            #endregion
        }
    }
}
