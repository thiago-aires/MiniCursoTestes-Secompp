using FluentAssertions;
using LojaVirtual;
using NUnit.Framework;
using System.Linq;


namespace LojaVirualTestes
{
    public class CarrinhoDecomprasTeste
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AdicionarProduto_AoEscolherProduto_DeveAdicionarNoCarrinho()
        {
            //Arrange
            Produto produto = new Produto("cerveja", 1, 3.5);
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();


            // Act
            carrinho.AdicionarProduto(produto);

            var resultado = carrinho.ListaDeCompras;

            //Assert
            resultado.Should().Contain(produto);
        }

        [Test]
        public void RemoverProduto_AoEscolherProduto_DeveRemoverDoCarrinho()
        {
            // Arrange
            Produto produto = new Produto("cerveja", 1, 3.5);
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            carrinho.AdicionarProduto(produto);

            //Act
            carrinho.RemoverProduto(produto);


            var resultado = carrinho.ListaDeCompras;

            //Assert
            resultado.Should().NotContain(produto);

        }

        [Test]
        public void FinalizarCompra_CasoNaoExistaProdutosAdicionados_DeveGerarUmErro()
        {
            //arrange
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            string erro = "erro";

            //act
            var resultado = carrinho.FinalizarCompra();

            //assert
            resultado.Should().Be(erro);
        }

        [Test]
        public void FinalizarCompra_CasoExistaProdutosAdicionados_DeveCalcularValorTotal()
        {
            //arrange
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            Produto cerveja = new Produto("cerveja", 2, 3.5);
            carrinho.AdicionarProduto(cerveja);
            string erro = "erro";

            //act
            var resultado = carrinho.FinalizarCompra();

            //assert
            resultado.Should().NotBe(erro);
        }

        [Test]
        public void FinalizarCompra_AoSerChamado_DeveCalcularCorretamenteOValorFinal()
        {
            // Arrange
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            Produto cerveja = new Produto("cerveja", 4, 3.5);
            var totalEsperado = 3.5 * 4;
            carrinho.AdicionarProduto(cerveja);


            // Act
            var resultado = carrinho.FinalizarCompra();

            // Assert
            resultado.Should().Be(totalEsperado.ToString());
        }

        [Test]
        public void FinalizarCompra_QuandoOTotalForMaiorQue5000_DeveAplicarUmDescontoDeVintePorcento()
        {
            // Arrange
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            Produto geladeira = new Produto("geladeira", 1, 5005);
            Produto cerveja = new Produto("cerveja", 50, 50.0);
            var totalEsperadoDaGeladeira = (5005 * 1 * 0.9);
            var totalEsperadoDaCerveja = 50 * 50.0 * 0.9;
            var totalEsperado = (totalEsperadoDaCerveja + totalEsperadoDaGeladeira) * 0.8;
            carrinho.AdicionarProduto(geladeira);
            carrinho.AdicionarProduto(cerveja);


            // Act
            var resultado = carrinho.FinalizarCompra();

            // Assert
            resultado.Should().Be(totalEsperado.ToString());
        }
    }
}