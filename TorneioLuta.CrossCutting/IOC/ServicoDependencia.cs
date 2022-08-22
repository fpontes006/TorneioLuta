using Microsoft.Extensions.DependencyInjection;
using TorneioLuta.Dominio.Interfaces.Servicos;
using TorneioLuta.Servico;

namespace TorneioLuta.CrossCutting.IOC
{
    public static class ServicoDependencia
    {
        public static void AdicionaDependenciaServico(this IServiceCollection services)
        {
            services.AddScoped<ILutadoresServico, LutadorServico>();
        }
    }
}