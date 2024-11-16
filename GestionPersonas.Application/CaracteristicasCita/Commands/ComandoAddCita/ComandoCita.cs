using GestionCitas.Application.Comunes;
using GestionCitas.Domain.Enums;
using GestionCitas.Domain.ValueObjects;
using MediatR;

namespace GestionCitas.Application.CaracteristicasCita.Commands.ComandoCita
{
    public class ComandoCita : IRequest<CitaVM>
    {
        public int Paciente { get; init; }
        public int Medico { get; init; }
        public DateTime Fecha { get; init; }
        public EstadoCita EstadoActualCita { get; init; }
        public Lugar Lugar { get; init; }
    }
}
