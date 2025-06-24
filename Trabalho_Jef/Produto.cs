using System;

namespace Trabalho_Jef
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        private decimal _preco;

        public decimal Preco
        {
            get => _preco;
            set => _preco = value >= 0 ? value : throw new ArgumentException("Preço não pode ser negativo");
        }
    }
}