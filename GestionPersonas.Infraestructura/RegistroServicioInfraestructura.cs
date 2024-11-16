using GestionCitas.Application.Contratos;
using GestionCitas.Infraestructura.Repositorios;
using GestionPersonas.Application.Contratos;
using GestionPersonas.Infraestructura.Persistencia;
using GestionPersonas.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestionPersonas.Infraestructura
{
    public static class RegistroServicioInfraestructura
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AplicacionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UsuariosConnectionString")));

            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
            services.AddScoped<ICitaRepositorio, RepositorioCita>();

            return services;
        }
    }
}
