using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Trabalho_Jef.Carrinho;

namespace Trabalho_Jef
{
    internal class Venda
    {
        
    public int Id { get; set; } 
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public decimal ValorPago { get; set; }
        public decimal Troco { get; set; }
        public List<ItemCarrinho> Itens { get; set; }
    }
}

