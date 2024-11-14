using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De_Maria.NET
{
    internal class Clientes
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Cadastra o cliente no banco de dados
        /// </summary>
        public bool Cadastrar(Clientes cliente)
        {
            try
            {
                Banco banco = new Banco();
                using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cliente.Telefone = ValidarTelefoneSQL(cliente.Telefone);
                    cmd.Connection = connection;
                    string sql = "INSERT INTO clientes (nome, endereco, telefone, email) " +
                        $"VALUES ('{cliente.Nome}', '{cliente.Endereco}', '{cliente.Telefone}', '{cliente.Email}')";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cliente cadastrado com sucesso");
                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro ao inserir cliente: " + err.Message);
                return false;
            }

        }
        /// <summary>
        /// Editar o cliente do banco de dados
        /// </summary>
        public bool Editar(Clientes cliente)
        {
            try
            {
                Banco banco = new Banco();
                using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cliente.Telefone = ValidarTelefoneSQL(cliente.Telefone);
                    cmd.Connection = connection;
                    string sql = $"UPDATE clientes set nome = '{cliente.Nome}', endereco = '{cliente.Endereco}', " +
                        $"telefone = '{cliente.Telefone}', email = '{cliente.Email}' " +
                        $"WHERE id = {cliente.Id}";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cliente alterado com sucesso");
                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro ao inserir cliente: " + err.Message);
                return false;
            }
        }
        /// <summary>
        /// Remover o cliente do banco de dados
        /// </summary>
        public bool Remover(int id)
        {
            try
            {
                Banco banco = new Banco();
                using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    string sql = "DELETE FROM clientes " +
                        $"WHERE id = {id}";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cliente removido com sucesso");
                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro ao remover cliente: " + err.Message);
                return false;
            }
        }
        /// <summary>
        /// Carrega os dados dos clientes para o grid
        /// </summary>
        public void CarregarGrid(ref DataGridView grid)
        {
            Banco banco = new Banco();
            using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM clientes "+
                    "ORDER BY id";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        grid.DataSource = dt;
                        grid.Columns["id"].HeaderText = "ID";
                        grid.Columns["nome"].HeaderText = "Nome";
                        grid.Columns["endereco"].HeaderText = "Endereço";
                        grid.Columns["telefone"].HeaderText = "Telefone";
                        grid.Columns["telefone"].DefaultCellStyle.Format = "(99)00000-0000";
                        grid.Columns["email"].HeaderText = "Email";
                    }
                }
            }
        }

        public void GetClientes(int id)
        {
            Banco banco = new Banco();
            using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM clientes " +
                    $"WHERE Id = {id} ";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Nome = reader.GetValue(1).ToString();
                            Endereco = reader.GetValue(2).ToString();
                            Telefone = reader.GetValue(3).ToString();
                            Email = reader.GetValue(4).ToString();
                        }
                    }
                }
            }

        }

        private string ValidarTelefoneSQL(string telefone)
        {
            telefone = telefone.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace(")", "-");
            return telefone;
        }
    }
}
