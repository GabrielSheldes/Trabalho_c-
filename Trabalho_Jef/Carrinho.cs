using System;
using System.Collections.Generic;

namespace Trabalho_Jef
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itens = new List<ItemCarrinho>();

        public IReadOnlyCollection<ItemCarrinho> Itens => _itens.AsReadOnly();
        public decimal Total => CalcularTotal();

        public void AdicionarItem(Produto produto, int quantidade)
        {
            var itemExistente = _itens.Find(i => i.Produto.Codigo == produto.Codigo);

            if (itemExistente != null)
            {
                itemExistente.Quantidade += quantidade;
            }
            else
            {
                _itens.Add(new ItemCarrinho { Produto = produto, Quantidade = quantidade });
            }
        }

        public void RemoverItem(int codigoProduto)
        {
            _itens.RemoveAll(i => i.Produto.Codigo == codigoProduto);
        }

        public void Limpar()
        {
            _itens.Clear();
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in _itens)
            {
                total += item.Subtotal;
            }
            return total;
        }

        public class ItemCarrinho
        {
            public Produto Produto { get; set; }
            private int _quantidade;

            public int Quantidade
            {
                get => _quantidade;
                set => _quantidade = value > 0 ? value : throw new ArgumentException("Quantidade deve ser maior que zero");
            }

            public decimal Subtotal => Produto.Preco * Quantidade;
        }
    }
}