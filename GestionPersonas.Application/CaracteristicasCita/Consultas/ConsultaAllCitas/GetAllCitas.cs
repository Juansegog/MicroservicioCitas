using GestionCitas.Application.Comunes;
using MediatR;

namespace GestionCitas.Application.CaracteristicasCita.Consultas.ConsultaAllCitas
{
    public class GetAllCitas : IRequest<List<CitaVM>>
    {
    }
}
