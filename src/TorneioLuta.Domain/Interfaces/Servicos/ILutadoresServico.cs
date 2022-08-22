using TorneioLuta.Dominio.Entidades;

namespace TorneioLuta.Dominio.Interfaces.Servicos
{
    public interface ILutadoresServico
    {
        Task<List<Lutadores>> BuscaTodosLutadoresAsync();
    }
}