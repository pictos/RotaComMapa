using Newtonsoft.Json;
using RouteMap.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RouteMap.Services
{
    public class DirecaoServico
    {
        private readonly string baseUrl = "https://maps.googleapis.com/maps/api/directions/";
        private HttpClient _httpClient;
        private readonly string _key;
        public DirecaoServico(string key) => _key = key;

        public async Task<DirecaoResposta> ObterRota(string origem, string destino)
        {

            _httpClient = new HttpClient();
            string url = string.Format(baseUrl + $"json?origin={origem}&destination={destino}&key={_key}");
            var resposta = await _httpClient.GetAsync(url);
            var json = await resposta.Content.ReadAsStringAsync();
            if (resposta.IsSuccessStatusCode)
            {
                var resultado = JsonConvert.DeserializeObject<DirecaoResposta>(json);
                return resultado;
            }
            return null;
        }
    }
}
