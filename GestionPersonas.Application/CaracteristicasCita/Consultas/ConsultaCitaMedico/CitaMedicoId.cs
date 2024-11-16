using GestionCitas.Application.Comunes;
using MediatR;

namespace GestionCitas.Application.CaracteristicasCita.Consultas.ConsultaCitaMedico
{
    public class CitaMedicoId : IRequest<CitaVM>
    {
        public int MedicoId { get; set; }

        public CitaMedicoId(int pacienteId)
        {
            MedicoId = pacienteId;
        }
    }
}
