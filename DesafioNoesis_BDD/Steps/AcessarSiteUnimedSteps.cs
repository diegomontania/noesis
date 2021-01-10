using DesafioNoesis_BDD.PageObjects;
using TechTalk.SpecFlow;
using Xunit;

namespace DesafioNoesis_BDD.Steps
{
    [Collection("Chrome Driver")]
    [Binding]
    public class AcessarSiteUnimedSteps
    {
        private WebSiteUnimed _webSiteUnimed;

        public AcessarSiteUnimedSteps(WebSiteUnimed acessaWebSite)
        {
            //instancia contexto
            this._webSiteUnimed = acessaWebSite;
        }

        [Given(@"a url '(.*)'")]
        public void DadoAUrl(string url)
        {
            var pageSource = this._webSiteUnimed.AcessaSite(url);
            Assert.Contains("Portal Nacional de Saúde - Unimed - Institucional", pageSource);
        }

        [Given(@"acessar guia medico")]
        public void DadoAcessarGuiaMedico()
        {
            this._webSiteUnimed.AcessaGuiaMedica();
        }

        [When(@"realizar uma pesquisa de '(.*)' no Rio de Janeiro")]
        public void QuandoRealizarUmaPesquisaDeNoRioDeJaneiro(string busca)
        {
            this._webSiteUnimed.RealizaBuscaPor(busca);
        }

        [Then(@"devo ser capaz de visualizar os resultados com especialidade e cidade")]
        public void EntaoDevoSerCapazDeVisualizarOsResultadosComEspecialidadeECidade()
        {
            var elementoEncontrado = this._webSiteUnimed.VisualizoResultados();
            Assert.True(elementoEncontrado.Count > 0);
        }

        [Then(@"devo ser capaz de navegar nas paginas (.*), (.*) e (.*) não visualizar nenhum resultado com cidade '(.*)'")]
        public void EntaoDevoSerCapazDeNavegarNasPaginasENaoVisualizarNenhumResultadoComCidade(int pag1, int pag2, int pag3, string cidade)
        {
            int[] totalDePaginas = { pag1, pag2, pag3 };

            var resultado = this._webSiteUnimed.VerApenasResultadosDaCidadeAtual(totalDePaginas, cidade);
            Assert.True(resultado);
        }
    }
}
