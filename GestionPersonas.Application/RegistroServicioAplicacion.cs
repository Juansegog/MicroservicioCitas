using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GestionPersonas.Application
{
    public static class RegistroServicioAplicacion
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
