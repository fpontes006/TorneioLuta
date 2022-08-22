using TorneioLuta.Dominio.Entidades;

namespace TorneioLuta.Dominio.Interfaces.Repositorios
{
    public interface ILutadoresRepositorio
    {
        Task<List<Lutadores>> BuscaTodosLutadoresAsync();
    }
}