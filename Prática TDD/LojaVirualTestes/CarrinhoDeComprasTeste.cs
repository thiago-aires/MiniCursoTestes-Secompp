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
    }
}