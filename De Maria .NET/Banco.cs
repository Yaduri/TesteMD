using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De_Maria.NET
{
    internal class Banco
    {
        public string connectionString = "Server=localhost;Port=5432;Database=demaria;User Id=postgres;Password=@Y@g0190201;";

        /// <summary>
        /// Criação de tabelas do banco de dados
        /// </summary>
        public void CriarTabelas()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    string sql = "CREATE TABLE IF NOT EXISTS clientes ( " +
                        "id SERIAL PRIMARY KEY, " +
                        "nome VARCHAR(100), " +
                        "endereco TEXT, " +
                        "telefone VARCHAR(20), " +
                        "email VARCHAR(100) " +
                        ");";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    sql = "CREATE TABLE IF NOT EXISTS produtos ( " +
                        "id SERIAL PRIMARY KEY, " +
                        "nome VARCHAR(100), " +
                        "descricao TEXT, " +
                        "preco NUMERIC(10,2), " +
                        "estoque INTEGER " +
                        ");";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    sql = "CREATE TABLE IF NOT EXISTS vendas ( " +
                        "id SERIAL PRIMARY KEY, " +
                        "cliente_id INTEGER REFERENCES clientes(id), " +
                        "data_venda DATE, " +
                        "valor_total NUMERIC(10,2) " +
                        ");";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    sql = "CREATE TABLE IF NOT EXISTS vendas_produtos ( " +
                        "venda_id INTEGER REFERENCES vendas(id), " +
                        "produto_id INTEGER REFERENCES produtos(id), " +
                        "quantidade INTEGER, " +
                        "valor_total NUMERIC(10,2) " +
                        ");";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                }


            }
            catch (Exception err)
            {
                MessageBox.Show("Erro ao criar as tabelas: " + err.Message);
            }

        }
        /// <summary>
        /// Carrega todas as vendas no grid
        /// </summary>
    }
}
