using GestionCitas.Application.Contratos;
using GestionCitas.Domain.Entities;
using GestionPersonas.Infraestructura.Persistencia;
using GestionPersonas.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace GestionCitas.Infraestructura.Repositorios
{
    public class RepositorioCita : RepositorioGenerico<Cita>, ICitaRepositorio
    {
        public RepositorioCita(AplicacionDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Cita> GetCitaByPaciente(int paciente)
        {
            return await _dbContext.Cita
            .FirstOrDefaultAsync(p => p.Paciente == paciente) ?? throw new ApplicationException("No Se encontro una cita para este paciente");
        }
        public async Task<Cita> GetCitaByMedico(int medico)
        {
            return await _dbContext.Cita
            .FirstOrDefaultAsync(p => p.Medico == medico) ?? throw new ApplicationException("El medico no tiene una cita asignada");
        }
    }
}
