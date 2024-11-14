using Microsoft.VisualBasic;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace De_Maria.NET
{
    public partial class FrmCadastroClientes : Form
    {
        public int ClienteId = 0;
        public FrmCadastroClientes()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {
                Clientes cliente = new Clientes();
                cliente.Nome = txtNome.Text;
                cliente.Endereco = txtEndereco.Text;
                cliente.Telefone = txtTelefone.Text;
                cliente.Email = txtEmail.Text;
                if (btnCadastrar.Text == "Editar")
                {
                    cliente.Id = ClienteId;
                    cliente.Editar(cliente);
                }
                else
                {
                    cliente.Cadastrar(cliente);
                    LimpaCampos();
                }
                
            }
            
        }

        private void LimpaCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
            txtNome.Focus();
        }

        private bool VerificaCampos()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Digite um nome");
                txtNome.Focus();
                return false;
            } else if (txtEndereco.Text == "")
            {
                MessageBox.Show("Digite um endereço");
                txtEndereco.Focus();
                return false;
            } else if (txtTelefone.Text == "")
            {
                MessageBox.Show("Digite um telefone");
                txtTelefone.Focus();
                return false;
            } else if (txtEmail.Text == "")
            {
                MessageBox.Show("Digite um email");
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!EmailValido(txtEmail.Text) && txtEmail.Text != "")
            {
                MessageBox.Show("Por favor, digite um endereço de e-mail válido.");
                txtEmail.Focus();
            }
        }
        
        private bool EmailValido(string txtEmail)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(txtEmail, pattern);
        }

        private void FrmCadastroClientes_Load(object sender, EventArgs e)
        {
            if (ClienteId > 0)
            {
                Clientes cliente = new Clientes();
                cliente.GetClientes(ClienteId);
                txtNome.Text = cliente.Nome;
                txtEndereco.Text = cliente.Endereco;
                txtTelefone.Text = cliente.Telefone;
                txtEmail.Text = cliente.Email;
                btnCadastrar.Text = "Editar";
            }
        }
    }
}
