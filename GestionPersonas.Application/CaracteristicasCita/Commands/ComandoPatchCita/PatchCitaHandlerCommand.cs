using GestionCitas.Application.Contratos;
using MediatR;

namespace GestionCitas.Application.CaracteristicasCita.Commands.ComandoPatchCita
{
    public class PatchCitaHandlerCommand : IRequestHandler<PatchCitaCommand, Unit>
    {
        private readonly ICitaRepositorio _citaRepositorio;
        private readonly GenericMapperService _genericMapperService;
        public PatchCitaHandlerCommand(ICitaRepositorio citaRepositorio, GenericMapperService genericMapperService)
        {
            _citaRepositorio = citaRepositorio;
            _genericMapperService = genericMapperService;
        }

        public async Task<Unit> Handle(PatchCitaCommand request, CancellationToken cancellationToken)
        {
            var cita = await _citaRepositorio.GetByIdAsync(request.Id);
            cita.CambiarEstado(request.EstadoActualCita);
            await _citaRepositorio.UpdateAsync(cita);
            return Unit.Value;
        }
    }
}
