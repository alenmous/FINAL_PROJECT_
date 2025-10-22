using PROJETO.controller;
using PROJETO.models;
using PROJETO.models.bases;
using PROJETO.Models;
using PROJETO.views.consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJETO.views.cadastros
{
    public partial class ProdutosFornecedoresFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        ProdutosFornecedor oProdForne;
        FornecedoresFrmConsulta fornecedoresFrmConsulta;
        ProdutosFrmConsulta produtosFrmConsulta;
        ProdutoFornecedorController produtosFornController = new ProdutoFornecedorController();
        public ProdutosFornecedoresFrmCadastro()
        {
            InitializeComponent();
            oProdForne = new ProdutosFornecedor();
            Operacao.DisableCopyPaste(this);
        }


        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is ProdutosFornecedor cidade)
            {
                oProdForne = cidade;
                CarregarCampos();
            }
        }
        public void SetConsultaFornecedores(object obj)
        {
            fornecedoresFrmConsulta = (FornecedoresFrmConsulta)obj;
        }
        public void SetConsultaProdutos(object obj)
        {
            produtosFrmConsulta = (ProdutosFrmConsulta)obj;
        }
        protected override void LimparCampos()
        {
            txtCodFornecedor.Clear();
            txtFornecedor.Clear();
            txtCodProduto.Clear();
            txtProduto.Clear();
            cmbStatus.SelectedIndex = 0;
        }
        public override void BloquearCampos()
        {
            base.BloquearCampos();
            txtCodFornecedor.Enabled = false;
            txtFornecedor.Enabled = false;
            txtCodProduto.Enabled = false;
            txtProduto.Enabled = false;
            btnBuscarFornecedor.Enabled = false;
            btnBuscarProduto.Enabled = false;   
            cmbStatus.Enabled = false;
        }
        public override void DesbloquearCampos()
        {
            base.DesbloquearCampos();
            txtCodFornecedor.Enabled = true;
            txtFornecedor.Enabled = true;
            txtCodProduto.Enabled = true;
            txtProduto.Enabled = true;
            btnBuscarFornecedor.Enabled = true;
            btnBuscarProduto.Enabled = true;
            cmbStatus.Enabled = true;
        }
        public override void CarregarCampos()
        {
            base.CarregarCampos();
            txtCodigo.Text = oProdForne.ID.ToString();
            txtCodProduto.Text = Convert.ToString(oProdForne.oProduto.ID);
            txtProduto.Text = oProdForne.oProduto.Nome;
            txtCodFornecedor.Text = Convert.ToString(oProdForne.oFornecedor.ID);
            txtFornecedor.Text = oProdForne.oFornecedor.NomeFantasia;
            cmbStatus.Text = oProdForne.Status == "I" ? "Inativo" : oProdForne.Status == "A" ? "Ativo" : oProdForne.Status;
        }

        public override void Verificar()
        {
            if (btnSalvar.Text == "Salvar" || btnSalvar.Text == "Alterar")
                Salvar();
            else if (btnSalvar.Text == "Excluir")
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este produto?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ExcluirCidade();
                }
            }
        }
        private void ExcluirCidade()
        {
            if (oProdForne != null)
            {
                try
                {
                    var result = produtosFornController.ExcluirProdutoFornecedor(oProdForne.ID);
                    if (result)
                        Close();
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o produto. Detalhes: " + result);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Verifica o número de erro 547, que corresponde a violação de chave estrangeira
                    {
                        MessageBox.Show("Não é possível excluir o produto devido a outros registros estarem vinculados a este estado.");
                    }
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o produto. Detalhes: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    // Trate outras exceções gerais, se necessário
                    MessageBox.Show("Ocorreu um erro inesperado. Detalhes: " + ex.Message);
                }
            }
        }

        private bool VerificarCamposVazios()
        {
            List<string> camposFaltantes = new List<string>();

            if (string.IsNullOrWhiteSpace(txtCodFornecedor.Text))
            {
                camposFaltantes.Add("Código do Fornecedor");
            }
            if (string.IsNullOrWhiteSpace(txtCodProduto.Text))
            {
                camposFaltantes.Add("Código do Produto");
            }
            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                camposFaltantes.Add("Status");
            }

            if (camposFaltantes.Count > 0)
            {
                string camposFaltantesStr = string.Join(", ", camposFaltantes);
                MessageBox.Show("Os seguintes campos são obrigatórios e não foram preenchidos: " + camposFaltantesStr, "Campos em Falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        protected override void Salvar()
        {
            if (VerificarCamposVazios())
            {
                oProdForne.oFornecedor.ID = Convert.ToInt32(txtCodFornecedor.Text);
                oProdForne.oProduto.ID = Convert.ToInt32(txtCodProduto.Text);
                oProdForne.Status = cmbStatus.Text[0].ToString();
                if (oProdForne.ID == 0)
                {
                    oProdForne.DataCriacao = DateTime.Now;
                    var result = produtosFornController.AdicionarProdutoFornecedor(oProdForne);
                    if (result == "OK")
                        Close();
                    else
                        MessageBox.Show("Erro inesperado.");
                }
                else
                {
                    oProdForne.DataUltimaAlteracao = DateTime.Now;
                    var result = produtosFornController.AtualizarProdutoFornecedor(oProdForne);
                    if (result == "OK")
                        Close();
                    else
                        MessageBox.Show("Erro inesperado.");
                }
            }
        }

        private void btnBuscarFornecedor_Click(object sender, EventArgs e)
        {
            using (FornecedoresFrmConsulta frm = new FornecedoresFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                frm.ShowDialog();
                int IdSelecionado = frm.IdSelecionado;
                string NomeSelecionado = frm.NomeSelecionado;
                txtCodFornecedor.Text = IdSelecionado.ToString();
                txtFornecedor.Text = NomeSelecionado;
                txtCodFornecedor_Leave(txtCodFornecedor, EventArgs.Empty);

            }
        }

        private void txtCodFornecedor_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodFornecedor.Text))
            {
                txtCodFornecedor.Clear();
                txtFornecedor.Clear();
            }
            else if (int.TryParse(txtCodFornecedor.Text, out int cod) && cod > 0)
            {
                FornecedoresController fornecedoresController = new FornecedoresController();
                Fornecedores fornecedor = fornecedoresController.BuscarFornecedorPorId(cod);

                if (fornecedor == null)
                {
                    MessageBox.Show("Código inexistente.");
                    LimparFornecedor();
                }
                else if (fornecedor.StatusFornecedor == "I")
                {
                    MessageBox.Show("O fornecedor associado a este código está inativo.");
                    LimparFornecedor();
                }
                else
                {
                    txtFornecedor.Text = fornecedor.NomeFantasia;
                }
            }
            else
            {
                // Se o código não for um número inteiro válido ou não for maior que zero, limpe ambos os campos
                MessageBox.Show("Código inválido. Certifique-se de inserir um número inteiro válido maior que zero.");
                LimparFornecedor();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }

        private void LimparFornecedor()
        {
            txtCodFornecedor.Clear();
            txtFornecedor.Clear();
            txtCodFornecedor.Focus();
        }
        private void txtCodFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarValorKeyPress((System.Windows.Forms.TextBox)sender, e);
        }

        private void txtCodFornecedor_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null; // Remove o botão "SALVAR" como botão padrão
        }

        private void btnBuscarProduto_Click(object sender, EventArgs e)
        {
            using (ProdutosFrmConsulta frm = new ProdutosFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                frm.ShowDialog();
                int IdSelecionado = frm.IdSelecionado;
                string NomeSelecionado = frm.NomeSelecionado;
                txtCodProduto.Text = IdSelecionado.ToString();
                txtProduto.Text = NomeSelecionado;
                txtCodProduto_Leave(txtProduto, EventArgs.Empty);
            }
        }

        private void txtCodProduto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodProduto.Text))
            {
                txtCodProduto.Clear();
                txtProduto.Clear();
            }
            else if (int.TryParse(txtCodProduto.Text, out int cod) && cod > 0)
            {
                ProdutosController produtosController = new ProdutosController();
                Produto produto = produtosController.BuscarProdutoPorId(cod);

                if (produto == null)
                {
                    MessageBox.Show("Código inexistente.");
                    LimparProduto();
                }
                else if (produto.Status == "I")
                {
                    MessageBox.Show("O produto associado a este código está inativo.");
                    LimparProduto();
                }
                else
                {
                    txtProduto.Text = produto.Nome;
                }
            }
            else
            {
                // Se o código não for um número inteiro válido ou não for maior que zero, limpe ambos os campos
                MessageBox.Show("Código inválido. Certifique-se de inserir um número inteiro válido maior que zero.");
                LimparProduto();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }


        private void LimparProduto()
        {
            txtCodProduto.Clear();
            txtProduto.Clear();
            txtCodProduto.Focus();
        }
    }
}
