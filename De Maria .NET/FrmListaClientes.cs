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
    public partial class FrmListaClientes : Form
    {
        public int Id;
        public string Nome;
        public FrmListaClientes()
        {
            InitializeComponent();
        }

        private void FrmListaClientes_Load(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.CarregarGrid(ref grdClientes);
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (grdClientes.SelectedCells.Count > 0)
            {
                SelecionaCliente();
            }
        }

        private void grdClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelecionaCliente();
        }

        private void SelecionaCliente()
        {
            if (grdClientes.SelectedCells.Count > 0)
            {
                int index = grdClientes.SelectedCells[0].RowIndex;
                DataGridViewRow row = grdClientes.Rows[index];
                Id = int.Parse(row.Cells["Id"].Value.ToString());
                Nome = row.Cells["Nome"].Value.ToString();
                Close();
            }
        }
    }
}
