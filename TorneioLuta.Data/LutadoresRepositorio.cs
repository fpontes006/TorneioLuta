using TorneioLuta.Dominio.Entidades;
using TorneioLuta.Dominio.Interfaces.Repositorios;

namespace TorneioLuta.Data
{
    public class LutadoresRepositorio : ILutadoresRepositorio
    {
        private const string PATH = "https://apidev-mbb.t-systems.com.br:8443/edgemicro_tsdev/torneioluta/api/competidores";

        public async Task<List<Lutadores>> BuscaTodosLutadoresAsync() => await GetLutadoresAsync();

        private async Task<List<Lutadores>?> GetLutadoresAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-key", "29452a07-5ff9-4ad3-b472-c7243f548a33");

                var response = client.GetAsync(PATH).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Lutadores>>().Result.ToList();
            }

            return null;
        }
    }
}