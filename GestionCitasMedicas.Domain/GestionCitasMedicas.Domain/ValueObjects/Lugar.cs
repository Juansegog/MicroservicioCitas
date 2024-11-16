using GestionPersonas.Domain.ValueObjects;

namespace GestionCitas.Domain.ValueObjects
{
    public class Lugar
    {
        public string NombreIps { get; private set; }
        public Direccion Direccion { get; private set; }

        // Constructor privado
        private Lugar() { }

        // Constructor completo
        public Lugar(string nombreIps, Direccion direccion)
        {
            if (string.IsNullOrWhiteSpace(nombreIps)) throw new ArgumentException("El nombre de la IPS no puede ser vacío", nameof(nombreIps));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            NombreIps = nombreIps;
        }
    }
}