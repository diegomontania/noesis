namespace DesafioNoesis_TDD.Src
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public double Preco { get; set; }

        public Filme(int id, string nome, string genero, double preco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Genero = genero;
            this.Preco = preco;
        }
    }

    public class Loja
    {
        private int[] _carrinho;
        private readonly Filme[] _filmes;

        public Loja()
        {
            _filmes = new Filme[]
            {
                new Filme(1, "Senhor dos anéis", "Fantasia", 45.00),
                new Filme(2, "As Branquelas", "Comédia", 55.00),
                new Filme(3, "Velozes e Furiosos 7", "Ação", 100.00),
                new Filme(4, "Velozes e Furiosos 6", "Ação", 55.00),
                new Filme(5, "The Scapegoat", "Drama", 100.00),
                new Filme(6, "Meu Malvado Favorito", "Animação", 200.00)
            };
        }

        public double CalculaValorCompraComDesconto(int[] filmesEscolhidos)
        {
            //recebe os filmes
            _carrinho = filmesEscolhidos;

            double valorTotalCompra = 0;
            bool existeFilmeAcao = false;

            //faz loop entre de filmes
            for (int filme = 0; filme < _filmes.Length; filme++)
            {
                var filmeAtual = _filmes[filme];

                //faz loop entre os filmes do _carrinho e compara
                for (int filmeCarrinho = 0; filmeCarrinho < _carrinho.Length; filmeCarrinho++)
                {
                    //verifica se o id do filme no carrinho é igual ao filme atual
                    if (_carrinho[filmeCarrinho] == filmeAtual.Id)
                    {
                        valorTotalCompra += filmeAtual.Preco;

                        if (filmeAtual.Genero == "Ação")
                            existeFilmeAcao = true;
                    }
                }
            }

            //funcao para checar a porcentagem de desconto utilizando regra dos filmes de ação
            return CalculaDesconto(valorTotalCompra, existeFilmeAcao);
        }

        private double CalculaDesconto(double valorTotalCompra, bool existeFilmeAcao)
        {
            double desconto = 0;
            double descontoExtra = 0;

            if (existeFilmeAcao)
                descontoExtra = 5;

            if (valorTotalCompra > 100 && valorTotalCompra <= 200)
                desconto = (valorTotalCompra * (10 + descontoExtra)) / 100;
            else if (valorTotalCompra > 200 && valorTotalCompra <= 300)
                desconto = (valorTotalCompra * (20 + descontoExtra)) / 100;
            else if (valorTotalCompra > 300 && valorTotalCompra <= 400)
                desconto = (valorTotalCompra * (25 + descontoExtra)) / 100;
            else if (valorTotalCompra > 400)
                desconto = (valorTotalCompra * (30 + descontoExtra)) / 100;

            return desconto;
        }
    }
}
