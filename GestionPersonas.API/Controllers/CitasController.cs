using GestionCitas.Application.CaracteristicasCita.Commands.ComandoCita;
using GestionCitas.Application.CaracteristicasCita.Commands.ComandoPatchCita;
using GestionCitas.Application.CaracteristicasCita.Consultas.ConsultaAllCitas;
using GestionCitas.Application.CaracteristicasCita.Consultas.ConsultaCitaMedico;
using GestionCitas.Application.CaracteristicasCita.Consultas.ConsultasCitasPaciente;
using GestionCitas.Application.Comunes;
using GestionCitas.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionCitas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostCrearCita")]
        public async Task<ActionResult<CitaVM>> PostCrearCita([FromBody] ComandoCita cita)
        {
            var result = await _mediator.Send(cita);
            return result;
        }


        [HttpGet("GetCitaPaciente")]
        public async Task<ActionResult<CitaVM>> GetCitasPaciente(int pacienteId)
        {
            var query = new CitaPacienteId(pacienteId);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("GetCitaMedico")]
        public async Task<ActionResult<CitaVM>> GetCitasMedico(int medicoId)
        {
            var query = new CitaMedicoId(medicoId);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPatch("PatchEstadoCita")]
        public async Task<ActionResult> PatchEstadoCita(int IdCita, EstadoCita estadoCita)
        {
            var query = new PatchCitaCommand(IdCita, estadoCita);
            await _mediator.Send(query);
            return Ok();
        }

        [HttpGet("GetAllCitas")]
        public async Task<ActionResult<List<CitaVM>>> GetAllCitas()
        {
            var query = new GetAllCitas();
            var respPaciente = await _mediator.Send(query);
            return respPaciente;
        }

    }
}
