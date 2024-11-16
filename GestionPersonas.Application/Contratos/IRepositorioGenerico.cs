using GestionCitas.Domain.Entities;

namespace GestionPersonas.Application.Contratos
{
    public interface IRepositorioGenerico<T> where T : Cita
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
