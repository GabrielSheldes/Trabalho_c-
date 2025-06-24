using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Trabalho_Jef
{
    public partial class Form1 : Form
    {
        private Carrinho _carrinho = new Carrinho();
        private ProdutoService _produtoService;

        public Form1()
        {
            InitializeComponent();
            _produtoService = new ProdutoService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AtualizarTotal();
        }

        private void btnAdicionarCarrinho_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textCodigoProduto.Text, out int codigo))
                {
                    MessageBox.Show("Código inválido");
                    return;
                }

                if (!int.TryParse(txt.Text, out int quantidade) || quantidade <= 0)
                {
                    MessageBox.Show("Quantidade inválida");
                    return;
                }

                var produto = _produtoService.BuscarPorCodigo(codigo);
                if (produto == null)
                {
                    MessageBox.Show("Produto não encontrado");
                    return;
                }

                _carrinho.AdicionarItem(produto, quantidade);
                AtualizarCarrinhoGrid();
                AtualizarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void AtualizarCarrinhoGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in _carrinho.Itens)
            {
                dataGridView1.Rows.Add(
                    item.Produto.Nome,
                    item.Quantidade,
                    item.Produto.Preco.ToString("C2"),
                    item.Subtotal.ToString("C2")
                );
            }
        }

        private void AtualizarTotal()
        {
            Total.Text = _carrinho.Total.ToString("C2");
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtValorPago.Text, out decimal valorPago))
                {
                    MessageBox.Show("Valor pago inválido");
                    return;
                }

                var venda = new Venda
                {
                    Data = DateTime.Now,
                    Itens = new List<Carrinho.ItemCarrinho>(_carrinho.Itens),
                    Total = _carrinho.Total,
                    ValorPago = valorPago,
                    Troco = valorPago - _carrinho.Total
                };

                if (venda.Troco < 0)
                {
                    MessageBox.Show("Valor pago é insuficiente");
                    return;
                }

                using (var vendaService = new VendaService())
                {
                    vendaService.Salvar(venda);
                }

                MessageBox.Show($"Venda finalizada! Troco: {venda.Troco:C2}");
                _carrinho.Limpar();
                AtualizarCarrinhoGrid();
                AtualizarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao finalizar venda: {ex.Message}");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _carrinho.Limpar();
            AtualizarCarrinhoGrid();
            AtualizarTotal();
            textCodigoProduto.Clear();
            txt.Clear();
            txtValorPago.Clear();
        }
    }
}