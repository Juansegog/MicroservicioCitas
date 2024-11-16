using GestionCitas.Domain.Enums;
using GestionCitas.Domain.ValueObjects;

namespace GestionCitas.Domain.Entities
{
    public class Cita
    {
        // Propiedades
        public int Id { get; private set; }
        public int Paciente { get; private set; }
        public int Medico { get; private set; }
        public DateTime Fecha { get; private set; }
        public EstadoCita EstadoActualCita { get; private set; }
        public Lugar Lugar { get; private set; }

        private Cita() { }

        // Constructor privado para uso interno
        private Cita(int id, int paciente, int medico, DateTime fecha, EstadoCita estadoCita, Lugar lugar)
        {
            if (fecha <= DateTime.Now)
                throw new ArgumentException("La fecha debe ser futura", nameof(fecha));

            Id = id;
            Paciente = paciente;
            Medico = medico;
            Fecha = fecha;
            EstadoActualCita = estadoCita;
            Lugar = lugar ?? throw new ArgumentNullException(nameof(lugar));
        }

        // Método de fábrica para crear una nueva cita
        public static Cita Crear(int id, int paciente, int medico, DateTime fecha, EstadoCita estadoCita, Lugar lugar)
        {
            return new Cita(id, paciente, medico, fecha, estadoCita, lugar);
        }

        // Método para cambiar el estado de la cita
        public void CambiarEstado(EstadoCita nuevoEstado)
        {
            if (nuevoEstado == null)
                throw new ArgumentException("El nuevo estado no puede ser nulo", nameof(nuevoEstado));

            EstadoActualCita = nuevoEstado;
        }
    }
}
