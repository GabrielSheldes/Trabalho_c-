using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Trabalho_Jef
{
    internal class VendaService
    {
        public void SalvarVenda(Venda venda)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Salvar a venda principal
                        var cmdVenda = new MySqlCommand("INSERT INTO Vendas (Data, Total, ValorPago, Troco) VALUES (@Data, @Total, @ValorPago, @Troco); SELECT LAST_INSERT_ID();", conn, transaction);
                        cmdVenda.Parameters.AddWithValue("@Data", venda.Data);
                        cmdVenda.Parameters.AddWithValue("@Total", venda.Total);
                        cmdVenda.Parameters.AddWithValue("@ValorPago", venda.ValorPago);
                        cmdVenda.Parameters.AddWithValue("@Troco", venda.Troco);

                        venda.Id = Convert.ToInt32(cmdVenda.ExecuteScalar());

                        // Salvar itens da venda
                        foreach (var item in venda.Itens)
                        {
                            var cmdItem = new MySqlCommand("INSERT INTO ItensVenda (VendaId, ProdutoId, Quantidade, Subtotal) VALUES (@VendaId, @ProdutoId, @Quantidade, @Subtotal)", conn, transaction);
                            cmdItem.Parameters.AddWithValue("@VendaId", venda.Id);
                            cmdItem.Parameters.AddWithValue("@ProdutoId", item.Produto.Codigo);
                            cmdItem.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                            cmdItem.Parameters.AddWithValue("@Subtotal", item.Subtotal);
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
        }
    }
}
