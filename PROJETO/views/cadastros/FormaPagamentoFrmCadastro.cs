using PROJETO.controller;
using PROJETO.models;
using PROJETO.models.bases;
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
    public partial class FormaPagamentoFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        FormaPagamento aForma;
        FormaPagamentoController formaPagamentoController;
        public FormaPagamentoFrmCadastro()
        {
            InitializeComponent();
            formaPagamentoController = new FormaPagamentoController();
            aForma = new FormaPagamento();
            Operacao.DisableCopyPaste(this);
        }
        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is FormaPagamento forma)
            {
                aForma = forma;
                CarregarCampos();
            }
        }

        protected override void LimparCampos()
        {
            txtCodigo.Clear();
            txtForma.Clear();
            cmbStatus.SelectedIndex = 0;
        }
        public override void BloquearCampos()
        {
            base.BloquearCampos();
            txtForma.Enabled = false;
            cmbStatus.Enabled = false;
        }
        public override void DesbloquearCampos()
        {
            base.DesbloquearCampos();
            txtForma.Enabled = true;
            cmbStatus.Enabled = true;
        }
        public override void CarregarCampos()
        {
            base.CarregarCampos();
            txtCodigo.Text = aForma.ID.ToString();
            txtForma.Text = aForma.Forma;
            cmbStatus.Text = aForma.StatusForma == "I" ? "Inativo" : aForma.StatusForma == "A" ? "Ativo" : aForma.StatusForma;
        }
        public override void Verificar()
        {
            if (btnSalvar.Text == "Salvar" || btnSalvar.Text == "Salvar")
                Salvar();
            else if (btnSalvar.Text == "Excluir")
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este estado?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ExcluirForma();
                }
            }
        }
        private void ExcluirForma()
        {
            if (aForma != null)
            {
                try
                {
                    var result = formaPagamentoController.ExcluirFormaPagamento(aForma.ID);
                    if (result)
                        Close();
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o Forma de pagamento. Detalhes: " + result);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Verifica o número de erro 547, que corresponde a violação de chave estrangeira
                    {
                        MessageBox.Show("Não é possível excluir Forma devido a outros registros estarem vinculados a este Forma de pagamento.");
                    }
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o Forma de pagamento. Detalhes: " + ex.Message);
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

            if (string.IsNullOrWhiteSpace(txtForma.Text))
            {
                camposFaltantes.Add("Forma");
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
                aForma.Forma = txtForma.Text;
                aForma.StatusForma = cmbStatus.Text[0].ToString();
                if (aForma.ID == 0)
                {
                    aForma.DataCriacao = DateTime.Now;
                    var result = formaPagamentoController.AdicionarFormaPagamento(aForma);
                    if (result == "OK")
                        Close();
                    else
                        MessageBox.Show("Erro inesperado.");
                }
                else
                {
                    aForma.DataUltimaAlteracao = DateTime.Now;
                    var result = formaPagamentoController.AtualizarFormaPagamento(aForma);
                    if (result == "OK")
                        Close();
                    else
                        MessageBox.Show("Erro inesperado.");
                }
            }
        }

        private void txtForma_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarNomes(sender, e);
        }
    }
}
