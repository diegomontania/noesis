using DesafioNoesis_BDD.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DesafioNoesis_BDD.PageObjects
{
    public class WebSiteUnimed
    {
        private IWebDriver _driver;

        private By _campoPesquisa, _guiaMedica, _btnAceitaCookies, _estadoSelecionado, _cidadeSelecionada,
            _resultadoBusca, _botaoConfirma, _campoEstado, _campoCidade, _elementoResultado;

        private IReadOnlyCollection<IWebElement> _elemento;

        //chama webdriver. E cria seletores, para facil manutenção futura
        public WebSiteUnimed(Fixtures fixtures)
        {
            this._driver = fixtures.Driver;

            _guiaMedica = By.LinkText("Guia Médico");
            _campoPesquisa = By.Id("campo_pesquisa");
            _btnAceitaCookies = By.Id("acceptCookie");

            _estadoSelecionado = By.Id("react-select-2-option-18");
            _cidadeSelecionada = By.Id("react-select-3-option-67");

            _campoEstado = By.XPath("//div[@id=\'app\']/div/div/div/div/div/form/div/div/div/div/div");
            _campoCidade = By.XPath("//div[@id=\'app\']/div/div/div/div/div/form/div/div[2]/div/div/div/div");

            _resultadoBusca = By.CssSelector(".margin-left:nth-child(2)");
            _botaoConfirma = By.XPath("//button[2]");

            _elementoResultado = By.CssSelector("#resultado0 > .resultado-resumido");
        }

        public string AcessaSite(string url)
        {
            this._driver.Navigate().GoToUrl(url);
            return this._driver.PageSource;
        }

        public void AcessaGuiaMedica()
            => this._driver.FindElement(_guiaMedica).Click();

        public void RealizaBuscaPor(string busca)
        {
            //faz a busca
            this._driver.FindElement(_campoPesquisa).SendKeys(busca);
            this._driver.FindElement(_campoPesquisa).SendKeys(Keys.Enter);

            //remove barra inferior de 'cookies'
            this._driver.FindElement(_btnAceitaCookies).Click();

            //estado - rio de janeiro
            this._driver.FindElement(_campoEstado).Click();
            AguardaSegundos(2);
            this._driver.FindElement(_estadoSelecionado).Click();

            //cidade - rio de janeiro
            this._driver.FindElement(_campoCidade).Click();
            AguardaSegundos(2);
            this._driver.FindElement(_cidadeSelecionada).Click();

            //clica no primeiro elemento e confirma
            AguardaSegundos(3);
            this._driver.FindElement(_resultadoBusca).Click();
            this._driver.FindElement(_botaoConfirma).Click();
        }

        public IReadOnlyCollection<IWebElement> VisualizoResultados()
        {
            AguardaSegundos(5);
            return _elemento = this._driver.FindElements(_elementoResultado);
        }

        public bool VerApenasResultadosDaCidadeAtual(int[] quantidadePags, string cidade)
        {
            //loop entre os resultados da página, atualmente cada página exibe apenas 20 resultados.
            var totalResultadosPorPagina = 20;

            AguardaSegundos(5);

            //a cada página 
            for (int i = 2; i < quantidadePags.Length + 1; i++) /*+1 para fazer loop corretamente nas 3 páginas.*/
            {
                //faça loop entre os elementos de resulado
                for (int j = 0; j < totalResultadosPorPagina; j++)
                {
                    //entre os resultados exibidos
                    var seletor = $"#resultado{j} p:nth-child(1)";
                    var texto = this._driver.FindElement(By.CssSelector(seletor)).Text;

                    //não deve conter essa cidade
                    if (texto.Contains(cidade))
                        return false;
                }

                //vai para próxima pagina
                this._driver.FindElement(By.LinkText(i.ToString())).Click();
                AguardaSegundos(5);
            }

            //se não, teste concluído com sucesso
            return true;
        }

        private void AguardaSegundos(int segundos)
            => Thread.Sleep((int)TimeSpan.FromSeconds(segundos).TotalMilliseconds);
    }
}
