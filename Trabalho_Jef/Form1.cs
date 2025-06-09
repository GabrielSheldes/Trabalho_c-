using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Trabalho_Jef.Carrinho;

namespace Trabalho_Jef
{
    public partial class Form1 : Form
    {
        private List<ItemCarrinho> carrinho = new List<ItemCarrinho>();
        private Produto produtoService = new Produto();

        public Form1()
        {
            InitializeComponent();
            AtualizarCarrinho();
        }

        private void AdicionarAoCarrinho(int codigoProduto, int quantidade)
        {
            var produto = produtoService.BuscarPorCodigo(codigoProduto);
            if (produto == null)
            {
                MessageBox.Show("Produto não encontrado.");
                return;
            }

            var existente = carrinho.FirstOrDefault(x => x.Produto.Codigo == codigoProduto);
            if (existente != null)
            {
                existente.Quantidade += quantidade;
            }
            else
            {
                carrinho.Add(new ItemCarrinho { Produto = produto, Quantidade = quantidade });
            }

            AtualizarCarrinho();
        }

        private void AtualizarCarrinho()
        {
            dgvCarrinho.Rows.Clear();
            decimal total = 0;

            foreach (var item in carrinho)
            {
                dgvCarrinho.Rows.Add(item.Produto.Nome, item.Quantidade, item.Produto.Preco.ToString("C"), item.Subtotal.ToString("C"));
                total += item.Subtotal;
            }

            lblTotal.Text = total.ToString("C");
        }

        private void CalcularTroco()
        {
            decimal total = carrinho.Sum(x => x.Subtotal);
            decimal pago = decimal.TryParse(txtValorPago.Text, out var valor) ? valor : 0;
            decimal troco = pago - total;
            lblTroco.Text = troco >= 0 ? troco.ToString("C") : "Valor insuficiente";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(txtCodigoProduto.Text);
            int quantidade = int.Parse(txtQuantidade.Text);
            AdicionarAoCarrinho(codigo, quantidade);
        }

        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            CalcularTroco();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
