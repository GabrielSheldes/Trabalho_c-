using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Trabalho_Jef
{
    public class ProdutoService : IDisposable
    {
        private readonly MySqlConnection _connection;

        public ProdutoService()
        {
            _connection = DbHelper.GetConnection();
        }

        public Produto BuscarPorCodigo(int codigo)
        {
            const string query = "SELECT codigo, nome, preco FROM produtos WHERE codigo = @Codigo";

            using (var cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Codigo", codigo);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Produto
                        {
                            Codigo = reader.GetInt32("codigo"),
                            Nome = reader.GetString("nome"),
                            Preco = reader.GetDecimal("preco")
                        };
                    }
                }
            }
            return null;
        }
        public List<Produto> ListarTodos()
        {
            var produtos = new List<Produto>();

            const string query = "SELECT codigo, nome, preco FROM produtos ORDER BY nome";

            using (var cmd = new MySqlCommand(query, _connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    produtos.Add(new Produto
                    {
                        Codigo = reader.GetInt32("codigo"),
                        Nome = reader.GetString("nome"),
                        Preco = reader.GetDecimal("preco")
                    });
                }
            }

            return produtos;
        }
        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}