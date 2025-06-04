using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Jef
{
    internal class Carrinho
    {
        public class ItemCarrinho
        {
            public Produto Produto { get; set; }
            public int Quantidade { get; set; }

            public decimal Subtotal => Produto.Preco * Quantidade;
        }
    }
}
