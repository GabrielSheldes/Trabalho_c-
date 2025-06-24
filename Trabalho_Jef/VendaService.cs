using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Trabalho_Jef
{
    public class VendaService : IDisposable
    {
        private readonly MySqlConnection _connection;

        public VendaService()
        {
            _connection = DbHelper.GetConnection();
        }

        public void Salvar(Venda venda)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    // Inserir venda
                    var cmdVenda = new MySqlCommand(
                        @"INSERT INTO vendas (data, total, valor_pago, troco) 
                          VALUES (@Data, @Total, @ValorPago, @Troco);
                          SELECT LAST_INSERT_ID();", _connection);

                    cmdVenda.Parameters.AddWithValue("@Data", venda.Data);
                    cmdVenda.Parameters.AddWithValue("@Total", venda.Total);
                    cmdVenda.Parameters.AddWithValue("@ValorPago", venda.ValorPago);
                    cmdVenda.Parameters.AddWithValue("@Troco", venda.Troco);

                    var vendaId = Convert.ToInt32(cmdVenda.ExecuteScalar());

                    // Inserir itens da venda
                    foreach (var item in venda.Itens)
                    {
                        var cmdItem = new MySqlCommand(
                            @"INSERT INTO itens_venda 
                              (venda_id, produto_codigo, quantidade, preco_unitario) 
                              VALUES (@VendaId, @ProdutoCodigo, @Quantidade, @PrecoUnitario)", _connection);

                        cmdItem.Parameters.AddWithValue("@VendaId", vendaId);
                        cmdItem.Parameters.AddWithValue("@ProdutoCodigo", item.Produto.Codigo);
                        cmdItem.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                        cmdItem.Parameters.AddWithValue("@PrecoUnitario", item.Produto.Preco);

                        cmdItem.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao salvar venda: " + ex.Message);
                }
            }
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}