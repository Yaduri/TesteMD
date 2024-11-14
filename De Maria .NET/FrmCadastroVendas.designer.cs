using System.Windows.Forms;

namespace De_Maria.NET
{
    partial class FrmCadastroVendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtClienteId = new System.Windows.Forms.TextBox();
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPesquisarCliente = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.DateTimePicker();
            this.listaProdutos = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdicionarProduto = new System.Windows.Forms.Button();
            this.btnRemoverProduto = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.Label();
            this.btnIncluirVenda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtClienteId
            // 
            this.txtClienteId.Location = new System.Drawing.Point(23, 39);
            this.txtClienteId.Name = "txtClienteId";
            this.txtClienteId.ReadOnly = true;
            this.txtClienteId.Size = new System.Drawing.Size(26, 23);
            this.txtClienteId.TabIndex = 0;
            // 
            // txtClienteNome
            // 
            this.txtClienteNome.Location = new System.Drawing.Point(55, 39);
            this.txtClienteNome.Name = "txtClienteNome";
            this.txtClienteNome.ReadOnly = true;
            this.txtClienteNome.Size = new System.Drawing.Size(133, 23);
            this.txtClienteNome.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Cliente";
            // 
            // btnPesquisarCliente
            // 
            this.btnPesquisarCliente.Location = new System.Drawing.Point(194, 39);
            this.btnPesquisarCliente.Name = "btnPesquisarCliente";
            this.btnPesquisarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisarCliente.TabIndex = 2;
            this.btnPesquisarCliente.Text = "Pesquisar";
            this.btnPesquisarCliente.UseVisualStyleBackColor = true;
            this.btnPesquisarCliente.Click += new System.EventHandler(this.btnPesquisarCliente_Click);
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(23, 68);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(246, 23);
            this.txtData.TabIndex = 3;
            // 
            // listaProdutos
            // 
            this.listaProdutos.FormattingEnabled = true;
            this.listaProdutos.ItemHeight = 15;
            this.listaProdutos.Location = new System.Drawing.Point(23, 150);
            this.listaProdutos.Name = "listaProdutos";
            this.listaProdutos.Size = new System.Drawing.Size(246, 109);
            this.listaProdutos.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 62;
            this.label2.Text = "Produtos";
            // 
            // btnAdicionarProduto
            // 
            this.btnAdicionarProduto.Location = new System.Drawing.Point(113, 121);
            this.btnAdicionarProduto.Name = "btnAdicionarProduto";
            this.btnAdicionarProduto.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarProduto.TabIndex = 5;
            this.btnAdicionarProduto.Text = "Adicionar";
            this.btnAdicionarProduto.UseVisualStyleBackColor = true;
            this.btnAdicionarProduto.Click += new System.EventHandler(this.btnAdicionarProduto_Click);
            // 
            // btnRemoverProduto
            // 
            this.btnRemoverProduto.Location = new System.Drawing.Point(194, 121);
            this.btnRemoverProduto.Name = "btnRemoverProduto";
            this.btnRemoverProduto.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverProduto.TabIndex = 6;
            this.btnRemoverProduto.Text = "Remover";
            this.btnRemoverProduto.UseVisualStyleBackColor = true;
            this.btnRemoverProduto.Click += new System.EventHandler(this.btnRemoverProduto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 92;
            this.label3.Text = "Valor Total: R$";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.AutoSize = true;
            this.txtValorTotal.Location = new System.Drawing.Point(113, 286);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(28, 15);
            this.txtValorTotal.TabIndex = 102;
            this.txtValorTotal.Text = "0,00";
            // 
            // btnIncluirVenda
            // 
            this.btnIncluirVenda.Location = new System.Drawing.Point(31, 327);
            this.btnIncluirVenda.Name = "btnIncluirVenda";
            this.btnIncluirVenda.Size = new System.Drawing.Size(75, 23);
            this.btnIncluirVenda.TabIndex = 7;
            this.btnIncluirVenda.Text = "Incluir";
            this.btnIncluirVenda.UseVisualStyleBackColor = true;
            this.btnIncluirVenda.Click += new System.EventHandler(this.btnIncluirVenda_Click);
            // 
            // FrmCadastroVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 362);
            this.Controls.Add(this.btnIncluirVenda);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRemoverProduto);
            this.Controls.Add(this.btnAdicionarProduto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listaProdutos);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.btnPesquisarCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClienteNome);
            this.Controls.Add(this.txtClienteId);
            this.Name = "FrmCadastroVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtClienteId;
        private TextBox txtClienteNome;
        private Label label1;
        private Button btnPesquisarCliente;
        private DateTimePicker txtData;
        private ListBox listaProdutos;
        private Label label2;
        private Button btnAdicionarProduto;
        private Button btnRemoverProduto;
        private Label label3;
        private Label txtValorTotal;
        private Button btnIncluirVenda;
    }
}