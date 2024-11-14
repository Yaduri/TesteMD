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
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FrmCadastroProdutos frmCadastroProdutos = new FrmCadastroProdutos();
            frmCadastroProdutos.ShowDialog();
            CarregaGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            SelecionarProduto();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {

                if (grdProdutos.SelectedCells.Count > 0)
                {
                    int index = grdProdutos.SelectedCells[0].RowIndex;
                    DataGridViewRow row = grdProdutos.Rows[index];
                    int id = int.Parse(row.Cells["Id"].Value.ToString());
                    DialogResult resultado = MessageBox.Show("Realmente deseja excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        Produtos produto = new Produtos();
                        produto.Remover(id);
                        CarregaGrid();
                    }

                }
                else
                {
                    MessageBox.Show("Selecione um produto");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Selecione um produto válido");
            }
        }

        private void CarregaGrid()
        {
            Produtos produto = new Produtos();
            produto.CarregarGrid(ref grdProdutos);
        }

        private void grdProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelecionarProduto();
        }

        private void SelecionarProduto()
        {
            FrmCadastroProdutos frmCadastroProdutos = new FrmCadastroProdutos();
            if (grdProdutos.SelectedCells.Count > 0)
            {
                int index = grdProdutos.SelectedCells[0].RowIndex;
                DataGridViewRow row = grdProdutos.Rows[index];
                frmCadastroProdutos.ProdutoId = int.Parse(row.Cells["Id"].Value.ToString());
                frmCadastroProdutos.ShowDialog();
            }
            CarregaGrid();
        }
    }
}
