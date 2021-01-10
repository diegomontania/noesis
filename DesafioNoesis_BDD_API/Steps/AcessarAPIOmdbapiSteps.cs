using DesafioNoesis_BDD_API.Helpers.RequestAPI;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

namespace DesafioNoesis_BDD_API.Steps
{
    [Binding]
    public class AcessarAPIOmdbapiSteps
    {
        private RequestAPI _requestAPI;
        private ITestOutputHelper _outPutHelper;

        public AcessarAPIOmdbapiSteps(RequestAPI requestAPI, ITestOutputHelper testOutputHelper)
        {
            //contexto
            this._requestAPI = requestAPI;
            this._outPutHelper = testOutputHelper;
        }

        [Given(@"a url '(.*)' com id '(.*)' e apikey '(.*)'")]
        public void DadoAUrlComIdEApikey(string url, string id, string apiKey)
        {
            id = RemoveCaraceteres(id);
            apiKey = RemoveCaraceteres(apiKey);

            this._requestAPI.ChamaAPI(url, id, apiKey);

            Assert.NotNull(_requestAPI.RespostaRequest);
        }

        [Given(@"se a resposta for (.*)")]
        public void DadoSeARespostaFor(int resposta)
        {
            var statusCode = (int)_requestAPI.RespostaRequest.StatusCode;
            Assert.Equal(statusCode, resposta);
        }

        [Then(@"devo ser capaz de receber o '(.*)', '(.*)' e '(.*)' do filme")]
        public void EntaoDevoSerCapazDeReceberOEDoFilme(string titulo, string ano, string idioma)
        {
            _requestAPI.DeserializeResposta();

            titulo = this._requestAPI.RespostaFilme.Titulo;
            ano = this._requestAPI.RespostaFilme.Ano;
            idioma = this._requestAPI.RespostaFilme.Idioma;

            _outPutHelper.WriteLine($"Titulo: {titulo} Ano: {ano} Idioma: {idioma}");
        }

        [Given(@"o filme não existir")]
        public void DadoOFilmeNaoExistir()
        {
            var resposta = _requestAPI.RespostaRequest.Content.Contains("False");
            Assert.True(resposta);
        }

        [Then(@"devo receber uma resposta que não existe o filme catalogado")]
        public void EntaoDevoReceberUmaRespostaQueNaoExisteOFilmeCatalogado()
        {
            var resposta = this._requestAPI.RespostaRequest.Content;
            _outPutHelper.WriteLine(resposta);
        }

        private string RemoveCaraceteres(string valor)
            => valor.Replace("\"", "");
    }
}
