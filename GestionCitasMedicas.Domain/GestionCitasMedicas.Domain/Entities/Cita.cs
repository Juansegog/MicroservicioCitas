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


        // Método de fábrica para crear una nueva cita
        public static Cita CrearCita(int paciente, int medico, DateTime fecha, EstadoCita estadoCita, Lugar lugar)
        {
            if (lugar == null)
                throw new ArgumentNullException(nameof(lugar));
            return new Cita()
            {
                Paciente = paciente,
                Medico = medico,
                Fecha = fecha,
                EstadoActualCita = estadoCita,
                Lugar = lugar
            };
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
