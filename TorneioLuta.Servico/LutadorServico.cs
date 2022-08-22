using TorneioLuta.Dominio.Entidades;
using TorneioLuta.Dominio.Interfaces.Repositorios;
using TorneioLuta.Dominio.Interfaces.Servicos;

namespace TorneioLuta.Servico
{
    public class LutadorServico : ILutadoresServico
    {
        private readonly ILutadoresRepositorio _lutadoresRepositorio;

        public LutadorServico(ILutadoresRepositorio lutadoresRepositorio)
        {
            _lutadoresRepositorio = lutadoresRepositorio;
        }

        public async Task<List<Lutadores>> BuscaTodosLutadoresAsync()
        {
            return await _lutadoresRepositorio.BuscaTodosLutadoresAsync();
        }
    }
}