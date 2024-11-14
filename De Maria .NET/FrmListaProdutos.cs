using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De_Maria.NET
{
    public partial class FrmListaProdutos : Form
    {
        public int Id;
        public string Nome;
        public float Valor;
        public float ValorTotal;
        public int Quantidade;

        public FrmListaProdutos()
        {
            InitializeComponent();
        }

        private void FrmListaProdutos_Load(object sender, EventArgs e)
        {
            Produtos produto = new Produtos();
            produto.CarregarGrid(ref grdProdutos);
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            SelecionarProduto();
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void grdProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelecionarProduto();
        }

        private void SelecionarProduto()
        {
            try
            {
                if (grdProdutos.SelectedCells.Count > 0)
                {
                    int index = grdProdutos.SelectedCells[0].RowIndex;
                    DataGridViewRow row = grdProdutos.Rows[index];
                    int estoque = int.Parse(row.Cells["Estoque"].Value.ToString());
                    Id = int.Parse(row.Cells["Id"].Value.ToString());
                    Nome = row.Cells["Nome"].Value.ToString();
                    Quantidade = int.Parse(txtQuantidade.Text);
                    if (Quantidade > estoque || estoque <= 0)
                    {
                        MessageBox.Show("Produto sem estoque");
                    }
                    else
                    {
                        Valor = float.Parse(row.Cells["preco"].Value.ToString());
                        ValorTotal = Valor * Quantidade;
                        Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao selecionar o produto");
            }
        }
    }
}
