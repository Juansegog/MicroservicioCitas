using GestionCitas.Domain.Enums;
using MediatR;

namespace GestionCitas.Application.CaracteristicasCita.Commands.ComandoPatchCita
{
    public class PatchCitaCommand : IRequest<Unit>
    {
        public int Id { get; init; }
        public EstadoCita EstadoActualCita { get; init; }
        public PatchCitaCommand(int id, EstadoCita estadoActualCita)
        {
            Id = id;
            EstadoActualCita = estadoActualCita;
        }
    }
}
