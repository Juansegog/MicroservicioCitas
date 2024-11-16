using GestionCitas.Domain.Entities;
using GestionPersonas.Application.Contratos;
using GestionPersonas.Domain.ExcepcionesGenerales;
using GestionPersonas.Infraestructura.Persistencia;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GestionPersonas.Infraestructura.Repositorios
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : Cita
    {
        public readonly AplicacionDbContext _dbContext;
        public RepositorioGenerico(AplicacionDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex) when (ex is SqlException || ex is DbUpdateException)
            {
                throw new ExcepcionAccesoDatos("Ha ocurrido un error accediendo a la base de datos", ex);
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            try
            {
                var lstResp = await _dbContext.Set<T>().ToListAsync();
                if (lstResp.Count == 0)
                    throw new NoHayDatosException("No se contraro datos para la busqueda");
                return lstResp;
            }
            catch (Exception ex) when (ex is SqlException || ex is DbUpdateException)
            {
                throw new ExcepcionAccesoDatos("Ha ocurrido un error mientra ingresaba a la base de datos.", ex);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var resp = await _dbContext.Set<T>().FindAsync(id);
                if (resp == null)
                    throw new NoHayDatosException($"No se encontro el registro con el identificador: {id}");
                return resp;
            }
            catch (Exception ex) when (ex is SqlException || ex is DbUpdateException)
            {
                throw new ExcepcionAccesoDatos("Ha ocurrido un error mientra ingresaba a la base de datos.", ex);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is SqlException || ex is DbUpdateException)
            {
                throw new ExcepcionAccesoDatos("Ha ocurrido un error mientra modificaba los datos en la base de datos.", ex);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
