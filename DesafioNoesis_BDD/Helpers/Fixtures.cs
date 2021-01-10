using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DesafioNoesis_BDD.Helpers
{
    //classe responsavel pelo setup antes da execução e limpeza de recursos (teardown) dos testes
    public class Fixtures : IDisposable
    {
        public IWebDriver Driver { get; set; }
        private ChromeOptions _chromeOptions;

        //setup - antes de iniciar o teste
        public Fixtures()
        {
            //desabilita localizacao (localizacao estava preenchendo automaticamente alguns campos de cidade estado)
            _chromeOptions = new ChromeOptions();
            _chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 2);

            //cria instancia do webdriver pegando o caminho do chromedriver da pasta raiz da dependencia do projeto
            //passando as opções e maximiza janela para evitar problemas nos seletores
            Driver = new ChromeDriver(".", _chromeOptions);
            Driver.Manage().Window.Maximize();
        }

        //teardown - após executar teste, descartando os recursos utilizando IDisposable
        public void Dispose() => Driver.Quit();
    }
}