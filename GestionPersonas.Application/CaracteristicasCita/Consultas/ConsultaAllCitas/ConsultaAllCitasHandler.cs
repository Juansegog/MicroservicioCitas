using GestionCitas.Application.Comunes;
using GestionCitas.Application.Contratos;
using MediatR;

namespace GestionCitas.Application.CaracteristicasCita.Consultas.ConsultaAllCitas
{
    public class ConsultaAllCitasHandler : IRequestHandler<GetAllCitas, List<CitaVM>>
    {
        private readonly ICitaRepositorio _citaRepositorio;
        private readonly GenericMapperService _genericMapperService;
        public ConsultaAllCitasHandler(ICitaRepositorio citaRepositorio, GenericMapperService genericMapperService)
        {
            _citaRepositorio = citaRepositorio;
            _genericMapperService = genericMapperService;
        }
        public async Task<List<CitaVM>> Handle(GetAllCitas request, CancellationToken cancellationToken)
        {
            var lstCitas = await _citaRepositorio.GetAllAsync();
            var entityObjects = lstCitas.Cast<object>().ToList();
            return _genericMapperService.MapListFromObject<CitaVM>(entityObjects);
        }
    }
}
