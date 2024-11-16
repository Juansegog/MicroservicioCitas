using GestionCitas.Domain.Enums;
using GestionPersonas.Domain.ValueObjects;

namespace GestionCitas.Application.Comunes
{
    public class CitaVM
    {
        public int Id { get; private set; }
        public int PacienteId { get; private set; }
        public string NombrePaciente { get; private set; }
        public int Medico { get; set; }
        public string NombreMedico { get; private set; }
        public string HistoriaClinica { get; private set; }
        public string Dosis { get; private set; }
        public string Duracion { get; private set; }
        public string Instrucciones { get; private set; }
        public string Medicamento { get; private set; }
        public ViaAdministracion ViaAdministracion { get; private set; }
        public string ObservacionesPlanTratamiento { get; private set; }
        public string Diagnostico { get; private set; }
        public DateTime? FechaReceta { get; private set; }
        public DateTime? FechaVencimiento { get; private set; }
        public Direccion DireccionReclamacion { get; private set; }
    }
}
