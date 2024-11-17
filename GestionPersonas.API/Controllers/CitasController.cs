using GestionCitas.Application.CaracteristicasCita.Commands.ComandoCita;
using GestionCitas.Application.CaracteristicasCita.Commands.ComandoPatchCita;
using GestionCitas.Application.CaracteristicasCita.Consultas.ConsultaAllCitas;
using GestionCitas.Application.CaracteristicasCita.Consultas.ConsultaCitaMedico;
using GestionCitas.Application.CaracteristicasCita.Consultas.ConsultasCitasPaciente;
using GestionCitas.Application.Comunes;
using GestionCitas.Domain.Enums;
using GestionPersonas.Domain.ExcepcionesGenerales;
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
            try
            {
                var result = await _mediator.Send(cita);
                return result;
            }
            catch (NoHayDatosException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (ExcepcionAccesoDatos ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error inesperado." });
            }
        }


        [HttpGet("GetCitaPaciente")]
        public async Task<ActionResult<CitaVM>> GetCitasPaciente(int pacienteId)
        {
            try
            {
                var query = new CitaPacienteId(pacienteId);
                var result = await _mediator.Send(query);
                return result;
            }
            catch (NoHayDatosException ex)
            {
                return NotFound(new
                {
                    Message = ex.Message
                });
            }
            catch (ExcepcionAccesoDatos ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error inesperado." });
            }
        }

        [HttpGet("GetCitaMedico")]
        public async Task<ActionResult<CitaVM>> GetCitasMedico(int medicoId)
        {
            try
            {
                var query = new CitaMedicoId(medicoId);
                var result = await _mediator.Send(query);
                return result;
            }
            catch (NoHayDatosException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (ExcepcionAccesoDatos ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error inesperado." });
            }
        }

        [HttpPatch("PatchEstadoCita")]
        public async Task<ActionResult> PatchEstadoCita(int IdCita, EstadoCita estadoCita)
        {
            try
            {
                var query = new PatchCitaCommand(IdCita, estadoCita);
                await _mediator.Send(query);
                return Ok();
            }
            catch (NoHayDatosException ex)
            {
                return NotFound(new
                {
                    Message = ex.Message
                });
            }
            catch (ExcepcionAccesoDatos ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error inesperado." });
            }
        }

        [HttpGet("GetAllCitas")]
        public async Task<ActionResult<List<CitaVM>>> GetAllCitas()
        {
            try
            {
                var query = new GetAllCitas();
                var respPaciente = await _mediator.Send(query);
                return respPaciente;
            }
            catch (NoHayDatosException ex)
            {
                return NotFound(new
                {
                    Message = ex.Message
                });
            }
            catch (ExcepcionAccesoDatos ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ha ocurrido un error inesperado." });
            }
        }

    }
}
