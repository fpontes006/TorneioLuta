using Microsoft.Extensions.DependencyInjection;
using TorneioLuta.Data;
using TorneioLuta.Dominio.Interfaces.Repositorios;

namespace TorneioLuta.CrossCutting.IOC
{
    public static class RepositorioDependencia
    {
        public static void AdicionaDependenciaRepositorio(this IServiceCollection services)
        {
            services.AddScoped<ILutadoresRepositorio, LutadoresRepositorio>();
        }
    }
}