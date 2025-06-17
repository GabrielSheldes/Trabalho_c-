using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Trabalho_Jef
{
    internal class ProdutoService
    {
        public Produto BuscarPorCodigo(int codigo)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT Codigo, Nome, Preco FROM Produtos WHERE Codigo = @Codigo", conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Produto
                        {
                            Codigo = reader.GetInt32("Codigo"),
                            Nome = reader.GetString("Nome"),
                            Preco = reader.GetDecimal("Preco")
                        };
                    }
                }
            }
            return null;
        }
    }
}
