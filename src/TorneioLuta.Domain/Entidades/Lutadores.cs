using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneioLuta.Dominio.Entidades
{
    public class Lutadores : InfoResultado
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string? Nome { get; set; }

        [JsonProperty("idade")]
        public int Idade { get; set; }

        [JsonProperty("artesMarciais")]
        public List<string>? ArtesMarciais { get; set; }

        [JsonProperty("lutas")]
        public int Lutas { get; set; }

        [JsonProperty("derrotas")]
        public int Derrotas { get; set; }

        [JsonProperty("vitorias")]
        public int Vitorias { get; set; }

        
    }
}