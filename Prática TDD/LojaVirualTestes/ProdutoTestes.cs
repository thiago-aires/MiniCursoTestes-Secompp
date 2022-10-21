using FluentAssertions;
using LojaVirtual;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirualTestes
{
    public class ProdutoTestes
    {
        [Test]
        public void CalcularTotal_QuandoOValorUnitarioForMaiorQuem100_DeveCalcularTotalCom10PorCentoDeDesconto()
        {
            // arrange
            Produto cerveja = new Produto("cerveja", 1, 110);
            var totalEsperado = 1 * 110 * 0.9;

            //act
            var resultado = cerveja.CalcularTotal();

            //assert
            resultado.Should().Be(totalEsperado);
        }

        [TestCase(1, 100)]
        [TestCase(1, 99)]
        public void CalcularTotal_QuandoOValorUnitarioForMenorOuIgualA100_NaoDeveCalcularTotalCom10PorCentoDeDesconto(int quantidade, double valor)
        {
            // arrange
            Produto produto = new Produto("produto", quantidade, valor);
            var totalEsperado = quantidade * valor;

            //act
            var resultado = produto.CalcularTotal();

            //assert
            resultado.Should().Be(totalEsperado);
        }

        [Test]
        public void CalcularTotal_QuandoAQuantidadeForMaiorQue10_DeveCalcularTotalCom10PorCentoDeDesconto()
        {
            // arrange
            Produto cerveja = new Produto("cerveja", 15, 10);
            var totalEsperado = 15 * 10 * 0.9;

            //act
            var resultado = cerveja.CalcularTotal();

            //assert
            resultado.Should().Be(totalEsperado);
        }

        [TestCase(10, 100)]
        [TestCase(9, 99)]
        public void CalcularTotal_QuandoAQuantidadeForMenorOuIgualA10_NaoDeveCalcularTotalCom10PorCentoDeDesconto(int quantidade, double valor)
        {
            // arrange
            Produto produto = new Produto("produto", quantidade, valor);
            var totalEsperado = quantidade * valor;

            //act
            var resultado = produto.CalcularTotal();

            //assert
            resultado.Should().Be(totalEsperado);
        }

    }
}
