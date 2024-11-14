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
    internal class Vendas
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string DataVenda { get; set; }
        public List<Produtos> Itens { get; set; }
        public float? ValorTotal { get; set; }

        public DataTable GerarDadosRelatorio()
        {
            var dt = new DataTable();
            Banco banco = new Banco();
            using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
            {
                connection.Open();
                string sql = "SELECT vendas.id, vendas.data_venda, clientes.nome, vendas.valor_total FROM vendas " +
                    "INNER JOIN clientes ON vendas.cliente_id = clientes.id " +
                    "ORDER BY vendas.id";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }

        public void CarregarGrid(ref DataGridView grid)
        {

            Banco banco = new Banco();
            using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
            {
                connection.Open();
                string sql = "SELECT vendas.id, vendas.data_venda, clientes.nome, vendas.valor_total FROM vendas " +
                    "INNER JOIN clientes ON vendas.cliente_id = clientes.id " +
                    "ORDER BY vendas.id";
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        grid.DataSource = dt;
                        grid.Columns["id"].HeaderText = "Id";
                        grid.Columns["data_venda"].HeaderText = "Data da Venda";
                        grid.Columns["data_venda"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        grid.Columns["nome"].HeaderText = "Cliente";
                        grid.Columns["valor_total"].HeaderText = "Valor Total";
                    }
                }
            }
        }
        public bool Cadastrar()
        {
            try
            {
                Banco banco = new Banco();
                using (NpgsqlConnection connection = new NpgsqlConnection(banco.connectionString))
                {
                    connection.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = connection;
                    string valor = ValorTotal.ToString().Replace(",", ".");
                    string sql = "INSERT INTO Vendas (cliente_id, data_venda, valor_total) " +
                        $"VALUES ({ClienteId}, '{DataVenda}', {valor}); " +
                        "SELECT MAX(ID) as Id from vendas";



                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string venda_id = reader.GetValue(0).ToString();
                                Id = int.Parse(venda_id);


                            }
                        }
                    }

                    foreach (Produtos item in Itens)
                    {
                        string valor_total = item.Preco.ToString().Replace(",", ".");
                        sql = "INSERT INTO vendas_produtos (venda_id, produto_id, quantidade, valor_total) " +
                            $"VALUES ({Id}, {item.Id}, {item.Estoque}, {valor_total})";
                        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                        sql = $"UPDATE produtos set estoque = estoque - {item.Estoque} " +
                            $"WHERE id = {item.Id}";
                        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Venda cadastrada com sucesso");
                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro ao inserir venda: " + err.Message);
                return false;
            }
        }
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
                    string sql = "DELETE FROM vendas_produtos " +
                        $"WHERE venda_id = {id}";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    sql = "DELETE FROM Vendas " +
                        $"WHERE id = {id}";

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Venda removida com sucesso");
                    return true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro ao remover venda: " + err.Message);
                return false;
            }
        }
    }
}
