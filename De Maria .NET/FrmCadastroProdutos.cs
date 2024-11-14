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
    public partial class FrmCadastroProdutos : Form
    {
        public int ProdutoId = 0;
        public FrmCadastroProdutos()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Banco banco = new Banco();
            
            if (VerificaCampos())
            {
                float valor = float.Parse(txtValor.Text);
                int estoque = int.Parse(txtEstoque.Text);
                
                Produtos produto = new Produtos();
                produto.Nome = txtNome.Text;
                produto.Descricao = txtDescricao.Text;
                produto.Estoque = estoque;
                produto.Preco = valor;
                if (btnCadastrar.Text == "Editar")
                {
                    produto.Id = ProdutoId;
                    produto.Editar(produto);
                }
                else
                {
                    produto.Cadastrar(produto);
                    LimpaCampos();
                }

            }
        }
        private void LimpaCampos()
        {
            txtValor.Text = "";
            txtDescricao.Text = "";
            txtNome.Text = "";
            txtEstoque.Text = "";
            txtNome.Focus();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && txtValor.Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }

            int index = txtValor.Text.IndexOf(',');
            if (index > -1 && txtValor.Text.Length - index > 2)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
        }

        private void txtEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool VerificaCampos()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Digite um nome");
                txtNome.Focus();
                return false;
            }
            else if (txtDescricao.Text == "")
            {
                MessageBox.Show("Digite uma descrição");
                txtDescricao.Focus();
                return false;
            }
            else if (txtValor.Text == "")
            {
                MessageBox.Show("Digite um valor");
                txtValor.Focus();
                return false;
            }
            else if (txtEstoque.Text == "")
            {
                MessageBox.Show("Digite um valor de estoque");
                txtEstoque.Focus();
                return false;
            }
            return true;
        }
    }
}
