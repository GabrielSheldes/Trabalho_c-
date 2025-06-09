using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Jef
{
    internal class ProdutoService
    {
        public Produto BuscarPorCodigo(int codigo)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT Codigo, Nome, Preco FROM Produtos WHERE Codigo = @Codigo", conn);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Produto
                        {
                            Codigo = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Preco = reader.GetDecimal(2)
                        };
                    }
                }
            }
            return null;
        }
    }
}
