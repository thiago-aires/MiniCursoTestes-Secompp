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
            if (!ListaDeCompras.Any())
                return "erro";
            else
                return "";
        }
    }
}
