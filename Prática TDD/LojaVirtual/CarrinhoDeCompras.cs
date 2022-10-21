using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual
{
    public class CarrinhoDeCompras
    {
        public List<Produto> ListaDeCompras { get; set; }

        public CarrinhoDeCompras()
        {
            ListaDeCompras = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            ListaDeCompras.Add(produto);
        }

        public void RemoverProduto(Produto produto)
        {
            ListaDeCompras.Remove(produto);
        }
        public string FinalizarCompra()
        {
            var descontoVintePorcento = 0.8;
            var total = 0.0;
            if (!ListaDeCompras.Any())
                return "erro";
            else
            {
                ListaDeCompras.ForEach(x => total+= x.CalcularTotal());
            }
            if (total > 5000)
                total = total * descontoVintePorcento;
            return total.ToString();
        }
    }
}
