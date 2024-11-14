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
    public partial class FrmInicial : Form
    {
        Banco banco = new Banco();
        public FrmInicial()
        {
            InitializeComponent();
            banco.CriarTabelas();
        }
        private void FrmInicial_Load_1(object sender, EventArgs e)
        {
            CarregarGrid();
        }
        private void CarregarGrid()
        {
            Vendas venda = new Vendas();
            venda.CarregarGrid(ref grdVendas);
        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Abrir a tela de clientes
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrir a tela de produtos
            FrmProdutos frmProdutos = new FrmProdutos();
            frmProdutos.ShowDialog();
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Infelizmente não consegui fazer o relatório funcionar
            Vendas vendas = new Vendas();
            var dt = vendas.GerarDadosRelatorio();
            Relatorios.FrmRelVendas frmRelVendas = new Relatorios.FrmRelVendas(dt);
            frmRelVendas.Show();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnVenda_Click(object sender, EventArgs e)
        {
            // Colocar a tela de venda aqui
            FrmCadastroVendas frmCadastroVendas = new FrmCadastroVendas();
            frmCadastroVendas.ShowDialog();
            CarregarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {

                if (grdVendas.SelectedCells.Count > 0)
                {
                    int index = grdVendas.SelectedCells[0].RowIndex;
                    DataGridViewRow row = grdVendas.Rows[index];
                    int id = int.Parse(row.Cells["Id"].Value.ToString());
                    DialogResult resultado = MessageBox.Show("Realmente deseja excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        Vendas venda = new Vendas();
                        venda.Remover(id);
                        CarregarGrid();
                    }

                }
                else
                {
                    MessageBox.Show("Selecione uma venda");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Selecione uma venda válida");
            }
        }
    }
}
