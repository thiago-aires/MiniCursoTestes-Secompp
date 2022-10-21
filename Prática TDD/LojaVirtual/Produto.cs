using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual
{
    public class Produto
    {
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public Double valor { get; set; }
        public Produto(string descricao, int quantidade, double valor)
        {
            Descricao = descricao;
            Quantidade = quantidade;
            this.valor = valor;
        }

        public Double CalcularTotal()
        {
            var descontoDesPorcento = 0.9;

            if(valor > 100)
                return valor * Quantidade * descontoDesPorcento;

            if (Quantidade > 10)
                return valor * Quantidade * descontoDesPorcento;



            return valor * Quantidade;
        }
    }
}
