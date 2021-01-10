using DesafioNoesis_TDD.Src;
using Xunit;

namespace DesafioNoesis_TDD.Testes
{
    public class DescontoLoja
    {
        //Como lojista 
        //Quero saber quanto de desconto posso conceder no carrinho 
        //Para fidelizar um cliente

        //envia quantos filmes vão ser comprados
        [Theory]
        [InlineData(new int[] { 1, 1, 2, 3, 4, 6 })]
        public void ComoLogistaQueroSAberQuantoDeDescontoPossoConceder(int[] filmesNoCarrinho)
        {
            //Arrange
            var loja = new Loja();

            //Act
            var desconto = loja.CalculaValorCompraComDesconto(filmesNoCarrinho);

            //Assert
            Assert.Equal(175.0, desconto);
        }
    }
}
