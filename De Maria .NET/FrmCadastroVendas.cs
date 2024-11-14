using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace De_Maria.NET
{
    public partial class FrmCadastroVendas : Form
    {
        private float ValorTotal = 0;
        public FrmCadastroVendas()
        {
            InitializeComponent();
            txtData.Format = DateTimePickerFormat.Custom;
            txtData.CustomFormat = "yyyy-MM-dd";
        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            FrmListaClientes listaClientes = new FrmListaClientes();
            listaClientes.ShowDialog();
            txtClienteId.Text = listaClientes.Id.ToString();
            txtClienteNome.Text = listaClientes.Nome;
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            FrmListaProdutos prod = new FrmListaProdutos();
            prod.ShowDialog();
            //int index = listaProdutos.Items.Count + 1;
            string item = $"{prod.Id} | {prod.Nome} | {prod.Quantidade} | {prod.ValorTotal}";
            listaProdutos.Items.Add(item);
            ValorTotal += prod.ValorTotal;
            txtValorTotal.Text = ValorTotal.ToString();
        }

        private void btnRemoverProduto_Click(object sender, EventArgs e)
        {
            if (listaProdutos.SelectedItem != null)
            {
                string[] row = listaProdutos.SelectedItem.ToString().Split('|');
                ValorTotal -= float.Parse(row[3]);
                txtValorTotal.Text = ValorTotal.ToString();
                listaProdutos.Items.RemoveAt(listaProdutos.SelectedIndex);
            }
        }

        private void btnIncluirVenda_Click(object sender, EventArgs e)
        {
            LimparCampos();
            try
            {
                Vendas venda = new Vendas();
                venda.ClienteId = int.Parse(txtClienteId.Text);
                venda.DataVenda = txtData.Text;
                List<Produtos> itens = new List<Produtos>();

                foreach (var item in listaProdutos.Items)
                {
                    Produtos produto = new Produtos();
                    string[] row = item.ToString().Split('|');
                    produto.Id = int.Parse(row[0].Trim());
                    produto.Estoque = int.Parse(row[2].Trim());
                    //string valor = row[3].ToString().Replace(",", ".");
                    produto.Preco = float.Parse(row[3].Trim());
                    itens.Add(produto);
                    //itens += "{\"produto_id\": " + row[0] + $", \"quantidade\": {row[2]}, \"valor_somado\": {valor}" + "},";
                }
                venda.Itens = itens;
                venda.ValorTotal = ValorTotal;
                venda.Cadastrar();
                LimparCampos();
            }
            catch
            {
                MessageBox.Show("Erro ao incluir a venda");
                txtClienteId.Focus();
            }
        }

        private void LimparCampos()
        {
            txtClienteId.Text = string.Empty;
            txtClienteNome.Text = string.Empty;
            txtValorTotal.Text = "0,00";
            listaProdutos.Items.Clear();
        }
    }
}
