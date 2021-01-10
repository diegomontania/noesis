using Newtonsoft.Json;
using RestSharp;

namespace DesafioNoesis_BDD_API.Helpers.RequestAPI
{
    public class RequestAPI
    {
        private RestClient _cliente;
        private RestRequest _requisicao;
        public IRestResponse RespostaRequest;

        public RespostaFilme RespostaFilme;

        public void ChamaAPI(string url, string id, string apiKey)
        {
            _cliente = new RestClient(url);
            _requisicao = new RestRequest($"?i={id}&apikey={apiKey}", Method.GET);

            //executa a chamada
            RespostaRequest = _cliente.Execute(_requisicao);
        }

        //recebe a resposta da api na classe 'RespostaFilme'
        public void DeserializeResposta()
            => RespostaFilme = JsonConvert.DeserializeObject<RespostaFilme>(RespostaRequest.Content);
    }
}
