using GestionCitas.Application.Comunes;
using GestionCitas.Application.Contratos;
using GestionCitas.Domain.Entities;
using MediatR;

namespace GestionCitas.Application.CaracteristicasCita.Commands.ComandoCita
{

    public class CrearComandoHandlerCita : IRequestHandler<ComandoCita, CitaVM>
    {

        private readonly ICitaRepositorio _citaRepositorio;
        private readonly GenericMapperService _genericMapperService;

        public CrearComandoHandlerCita(ICitaRepositorio citaRepositorio, GenericMapperService genericMapperService)
        {
            _citaRepositorio = citaRepositorio;
            _genericMapperService = genericMapperService;
        }
        public async Task<CitaVM> Handle(ComandoCita request, CancellationToken cancellationToken)
        {
            var MapCita = _genericMapperService.Map<ComandoCita, Cita>(request);
            var citaInsertada = await _citaRepositorio.AddAsync(MapCita);
            var resultado = _genericMapperService.Map<Cita, CitaVM>(citaInsertada);
            return resultado;
        }
    }
}
