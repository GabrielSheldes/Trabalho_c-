using System;
using System.Collections.Generic;

namespace Trabalho_Jef
{
    public class Venda
    {
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public decimal ValorPago { get; set; }
        public decimal Troco { get; set; }
        public List<Carrinho.ItemCarrinho> Itens { get; set; } = new List<Carrinho.ItemCarrinho>();
    }
}