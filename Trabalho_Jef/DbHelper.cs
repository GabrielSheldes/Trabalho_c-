using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Trabalho_Jef
{
    public static class DbHelper
    {
        private const string BaseConnectionString = "Server=localhost;Uid=root;Pwd=root;";
        private const string DatabaseName = "vendas_db";
        private static string ConnectionString => $"{BaseConnectionString};Database={DatabaseName}";

        public static MySqlConnection GetConnection()
        {
            
            CriarBancoSeNaoExistir();

           
            var connection = new MySqlConnection(ConnectionString);

            try
            {
                connection.Open();
                VerificarTabelas(connection);
                return connection;
            }
            catch (Exception ex)
            {
                connection.Dispose();
                MessageBox.Show($"Erro de conexão: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private static void CriarBancoSeNaoExistir()
        {
            using (var conn = new MySqlConnection(BaseConnectionString))
            {
                try
                {
                    conn.Open();

                    // Verifica se o banco já existe
                    var cmdCheck = new MySqlCommand(
                        $"SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '{DatabaseName}'",
                        conn);

                    var exists = cmdCheck.ExecuteScalar() != null;

                    if (!exists)
                    {
                        // Cria o banco de dados se não existir
                        var cmdCreate = new MySqlCommand($"CREATE DATABASE {DatabaseName}", conn);
                        cmdCreate.ExecuteNonQuery();

                        // Adiciona permissões (opcional)
                        var cmdGrant = new MySqlCommand(
                            $"GRANT ALL PRIVILEGES ON {DatabaseName}.* TO 'root'@'localhost'", conn);
                        cmdGrant.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao verificar/criar banco: {ex.Message}", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private static void VerificarTabelas(MySqlConnection conn)
        {
            try
            {
                // Garante que estamos usando o banco correto
                var cmdUseDb = new MySqlCommand($"USE {DatabaseName}", conn);
                cmdUseDb.ExecuteNonQuery();

                // Verifica e cria tabelas
                if (!TabelaExiste(conn, "produtos"))
                {
                    var cmdProdutos = new MySqlCommand(
                        @"CREATE TABLE produtos (
                            codigo INT PRIMARY KEY,
                            nome VARCHAR(100) NOT NULL,
                            preco DECIMAL(10,2) NOT NULL
                        )", conn);
                    cmdProdutos.ExecuteNonQuery();

                    // Insere dados iniciais
                    var cmdInsert = new MySqlCommand(
                        @"INSERT INTO produtos (codigo, nome, preco) VALUES 
                        (1, 'Produto A', 10.50),
                        (2, 'Produto B', 25.00),
                        (3, 'Produto C', 7.80)", conn);
                    cmdInsert.ExecuteNonQuery();
                }

                // Continuação para outras tabelas...
                // [Adicione aqui a criação das outras tabelas como no seu código original]
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar tabelas: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private static bool TabelaExiste(MySqlConnection conn, string tabelaNome)
        {
            try
            {
                var cmd = new MySqlCommand(
                    $"SELECT COUNT(*) FROM information_schema.tables " +
                    $"WHERE table_schema = '{DatabaseName}' AND table_name = '{tabelaNome}'",
                    conn);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}