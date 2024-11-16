using GestionCitas.Application.Comunes;
using GestionCitas.Application.Contratos;
using GestionCitas.Domain.Entities;
using MediatR;

namespace GestionCitas.Application.CaracteristicasCita.Consultas.ConsultaCitaMedico
{
    public class ConsultarCitaMedicoHandler : IRequestHandler<CitaMedicoId, CitaVM>
    {
        private readonly ICitaRepositorio _citaRepositorio;
        private readonly GenericMapperService _genericMapperService;
        public ConsultarCitaMedicoHandler(ICitaRepositorio citaRepositorio, GenericMapperService genericMapperService)
        {
            _citaRepositorio = citaRepositorio;
            _genericMapperService = genericMapperService;
        }
        public async Task<CitaVM> Handle(CitaMedicoId request, CancellationToken cancellationToken)
        {
            var paciente = await _citaRepositorio.GetByIdAsync(request.MedicoId);
            CitaVM resultadoMedico = _genericMapperService.Map<Cita, CitaVM>(paciente);
            return resultadoMedico;
        }
    }
}
