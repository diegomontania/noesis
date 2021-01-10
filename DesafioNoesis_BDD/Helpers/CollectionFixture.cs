using Xunit;

namespace DesafioNoesis_BDD.Helpers
{
    //IClassFixture indica que a classe 'Fixtures' é uma classe de configuração 
    //para TODOS OS TESTES DA MESMA CLASSE

    //ICollectionFixture indica que a classe 'Fixtures' é uma classe 
    //de configuração compartilhada para TODOS OS TESTES DE CLASSES DIFERENTES

    [CollectionDefinition("Chrome Driver")]
    public class CollectionFixture : ICollectionFixture<Fixtures>
    {

    }
}
