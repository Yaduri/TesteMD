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
    internal class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public int Estoque { get; set; }

        /// <summary>
        /// Cadastra o produto no banco de dados
        /// </summary>
        public bool Cadastrar(Produtos produto)
        {
            try
            {
                Banco banco = new Banco();
                using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    string valor = produto.Preco.ToString().Replace(",", ".");
                    string sql = "INSERT INTO Produtos (nome, descricao, preco, estoque) " +
                        $"VALUES ('{produto.Nome}', '{produto.Descricao}', {valor}, {produto.Estoque})";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Produto cadastrado com sucesso");
                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro ao inserir produto: " + err.Message);
                return false;
            }

        }
        /// <summary>
        /// Editar o produto do banco de dados
        /// </summary>
        public bool Editar(Produtos produto)
        {
            try
            {
                Banco banco = new Banco();
                using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    string valor = produto.Preco.ToString().Replace(",", ".");
                    string sql = $"UPDATE Produtos set nome = '{produto.Nome}', descricao = '{produto.Descricao}', " +
                        $"preco = {valor}, estoque = {produto.Estoque} " +
                        $"WHERE id = {produto.Id}";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Produto alterado com sucesso");
                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro ao inserir produto: " + err.Message);
                return false;
            }
        }
        /// <summary>
        /// Remover o produto do banco de dados
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
                    string sql = "DELETE FROM Produtos " +
                        $"WHERE id = {id}";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Produto removido com sucesso");
                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro ao remover produto: " + err.Message);
                return false;
            }
        }
        /// <summary>
        /// Carrega os dados dos Produtos para o grid
        /// </summary>
        public void CarregarGrid(ref DataGridView grid)
        {
            Banco banco = new Banco();
            using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Produtos "+
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
                        grid.Columns["descricao"].HeaderText = "Descrição";
                        grid.Columns["preco"].HeaderText = "Preço";
                        //grid.Columns["preco"].DefaultCellStyle.Format = "00,00";
                        grid.Columns["estoque"].HeaderText = "Estoque";
                    }
                }
            }
        }

        public void GetProdutos(int id)
        {
            Banco banco = new Banco();
            using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Produtos " +
                    $"WHERE Id = {id}";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Nome = reader.GetValue(0).ToString();
                            Descricao = reader.GetValue(1).ToString();
                            Preco = float.Parse(reader.GetValue(2).ToString());
                            Estoque = int.Parse(reader.GetValue(3).ToString());
                        }
                    }
                }
            }

        }
    }
}
