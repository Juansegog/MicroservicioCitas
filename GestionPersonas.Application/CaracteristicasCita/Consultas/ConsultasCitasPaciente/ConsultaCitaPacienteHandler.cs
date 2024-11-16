using GestionCitas.Application.Comunes;
using GestionCitas.Application.Contratos;
using GestionCitas.Domain.Entities;
using MediatR;

namespace GestionCitas.Application.CaracteristicasCita.Consultas.ConsultasCitasPaciente
{
    public class ConsultaCitaPacienteHandler : IRequestHandler<CitaPacienteId, CitaVM>
    {
        private readonly ICitaRepositorio _citaRepositorio;
        private readonly GenericMapperService _genericMapperService;
        public ConsultaCitaPacienteHandler(ICitaRepositorio citaRepositorio, GenericMapperService genericMapperService)
        {
            _citaRepositorio = citaRepositorio;
            _genericMapperService = genericMapperService;
        }

        public async Task<CitaVM> Handle(CitaPacienteId request, CancellationToken cancellationToken)
        {
            var paciente = await _citaRepositorio.GetByIdAsync(request.PacienteId);
            CitaVM resultadoPaciente = _genericMapperService.Map<Cita, CitaVM>(paciente);
            return resultadoPaciente;
        }
    }
}
