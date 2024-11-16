namespace GestionPersonas.Domain.ExcepcionesGenerales
{
    public class ExcepcionAccesoDatos : Exception
    {
        public ExcepcionAccesoDatos(string message, Exception innerException) : base(message, innerException) { }
    }
}
