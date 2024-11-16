using GestionCitas.Application.Comunes;
using MediatR;

namespace GestionCitas.Application.CaracteristicasCita.Consultas.ConsultasCitasPaciente
{
    public class CitaPacienteId : IRequest<CitaVM>
    {
        public int PacienteId { get; set; }

        public CitaPacienteId(int pacienteId)
        {
            PacienteId = pacienteId;
        }
    }
}
