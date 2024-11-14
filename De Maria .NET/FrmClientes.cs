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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FrmCadastroClientes frmCadastroClientes = new FrmCadastroClientes();
            frmCadastroClientes.ShowDialog();
            CarregaGrid();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarClientes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (grdClientes.SelectedCells.Count > 0)
                {
                    int index = grdClientes.SelectedCells[0].RowIndex;
                    DataGridViewRow row = grdClientes.Rows[index];
                    int id = int.Parse(row.Cells["Id"].Value.ToString());
                    DialogResult resultado = MessageBox.Show("Realmente deseja excluir?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        Clientes cliente = new Clientes();
                        cliente.Remover(id);
                        CarregaGrid();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Selecione um cliente");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Selecione um cliente válido");
            }
            
        }

        private void CarregaGrid()
        {
            Clientes cliente = new Clientes();
            cliente.CarregarGrid(ref grdClientes);
        }

        private void grdClientes_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("teste");
        }

        private void grdClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarClientes();
        }

        private void EditarClientes()
        {
            FrmCadastroClientes frmCadastroClientes = new FrmCadastroClientes();
            if (grdClientes.SelectedCells.Count > 0)
            {
                int index = grdClientes.SelectedCells[0].RowIndex;
                DataGridViewRow row = grdClientes.Rows[index];
                frmCadastroClientes.ClienteId = int.Parse(row.Cells["Id"].Value.ToString());
                frmCadastroClientes.ShowDialog();
            }
            CarregaGrid();
        }
    }
}
