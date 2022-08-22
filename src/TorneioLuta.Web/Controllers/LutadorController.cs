using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TorneioLuta.Dominio.Entidades;
using TorneioLuta.Dominio.Interfaces.Servicos;
using TorneioLuta.Web.Models;

namespace TorneioLuta.Web.Controllers
{
    public class LutadorController : Controller
    {
        private readonly ILogger<LutadorController> _logger;
        private readonly ILutadoresServico _servico;

        public LutadorController(ILogger<LutadorController> logger,
            ILutadoresServico servico)
        {
            _logger = logger;
            _servico = servico;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var requestLutadores = await _servico.BuscaTodosLutadoresAsync();

            return View(requestLutadores);
        }

        [HttpPost]
        public async Task<IActionResult> Luta([FromBody] LutadoresRequest lutadoresRequest)
        {
            var requestLutadores = await _servico.BuscaTodosLutadoresAsync();
            int i = 0;

            IEnumerable<Lutadores> lutadoresSelecionados = requestLutadores
                .Where(x => lutadoresRequest.lutadores!.Contains(x.Id))
                .OrderBy(x => x.Idade)
                .ToList();

            foreach (var item in lutadoresSelecionados)
            {
                item.Resultado = calculaVitoria(item.Vitorias, item.Lutas);
                item.Sequencial = i++;
            }

            var resultadoOitavas = classificatoria(lutadoresSelecionados);
            var resultadoQuartas = classificatoria(resultadoOitavas);
            var resultadoSemi = classificatoria(resultadoQuartas);
            var resultadoFinal = classificatoria(resultadoSemi);

            var campeao = resultadoFinal.Select(x => x.Nome).FirstOrDefault();

            
            return Json(new { success = true, responseText = "Campeão: " + campeao });
        }

        private double calculaVitoria(int vitorias, int totalLutas)
        {
            return ((double)vitorias / (double)totalLutas) * 100;
        }

        private List<Lutadores> classificatoria(IEnumerable<Lutadores> lutadoresSelecionados)
        {
            List<Lutadores> lutadores = new();

            for (int i = 0; i < lutadoresSelecionados.Count(); i++)
            {
                if (i % 2 != 0) continue;

                var lutador1 = lutadoresSelecionados.ElementAt(i);
                var lutador2 = lutadoresSelecionados.ElementAt(i + 1);

                if (lutador1.Resultado > lutador2.Resultado)
                    lutadores.Add(lutador1);
                else if (lutador1.Resultado < lutador2.Resultado)
                    lutadores.Add(lutador2);
                else if (lutador1.ArtesMarciais!.Count > lutador2.ArtesMarciais!.Count)
                    lutadores.Add(lutador1);
                else if (lutador1.ArtesMarciais.Count < lutador2.ArtesMarciais.Count)
                    lutadores.Add(lutador2);
                else if (lutador1.Lutas > lutador2.Lutas)
                    lutadores.Add(lutador1);
                else
                    lutadores.Add(lutador2);
            }

            return lutadores;
        }
    }
}