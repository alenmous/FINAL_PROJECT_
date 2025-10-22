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
    public partial class PaisesFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        Paises oPais;
        PaisesController paisesController;

        public PaisesFrmCadastro()
        {
            InitializeComponent();
            paisesController = new PaisesController();
            oPais = new Paises();
            Operacao.DisableCopyPaste(this);
        }



        private void txtDDI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifique se o caractere digitado não é um dígito numérico (0-9) e não é Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Impede a entrada do caractere não numérico
            }
        }

        private void txtPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarNomes(sender, e);
        }

        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is Paises pais)
            {
                oPais = pais;
                CarregarCampos();
            }
        }
        protected override void LimparCampos()
        {
            txtCodigo.Clear();
            txtDDI.Clear();
            txtPais.Clear();
            txtSigla.Clear();
            cmbStatus.SelectedIndex = 0;
        }
        public override void BloquearCampos()
        {
            base.BloquearCampos();
            txtPais.Enabled = false;
            txtDDI.Enabled = false;
            txtSigla.Enabled = false;
            cmbStatus.Enabled = false;
        }
        public override void DesbloquearCampos()
        {
            base.DesbloquearCampos();
            txtPais.Enabled = true;
            txtDDI.Enabled = true;
            txtSigla.Enabled = true;
            cmbStatus.Enabled = true;
        }
        public override void CarregarCampos()
        {
            base.CarregarCampos();
            txtCodigo.Text = oPais.ID.ToString();
            txtDDI.Text = oPais.Ddi.ToString();
            txtPais.Text = oPais.Pais.ToString();
            txtSigla.Text = oPais.Sigla.ToString();
            cmbStatus.Text = oPais.StatusPais == "I" ? "Inativo" : oPais.StatusPais == "A" ? "Ativo" : oPais.StatusPais;
        }


        public override void Verificar()
        {
            if (btnSalvar.Text == "Salvar" || btnSalvar.Text == "Alterar")
                Salvar();
            else if (btnSalvar.Text == "Excluir")
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este cliente?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ExcluirPais();
                }
            }
        }

        private void ExcluirPais()
        {
            if (oPais != null)
            {
                try
                {
                    var result = paisesController.ExcluirPais(oPais.ID);
                    if (result)
                        Close();
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o cliente. Detalhes: " + result);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Verifica o número de erro 547, que corresponde a violação de chave estrangeira
                    {
                        MessageBox.Show("Não é possível excluir o cliente devido a outros registros estarem vinclulados a este cliente.");
                    }
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o cliente. Detalhes: " + ex.Message);
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

            if (string.IsNullOrWhiteSpace(txtPais.Text))
            {
                camposFaltantes.Add("Pais");
            }
            if (string.IsNullOrWhiteSpace(txtDDI.Text))
            {
                camposFaltantes.Add("DDI");
            }
            if (string.IsNullOrWhiteSpace(txtSigla.Text))
            {
                camposFaltantes.Add("SIGLA");
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
                oPais.Ddi = txtDDI.Text;
                oPais.Pais = txtPais.Text;
                oPais.Sigla = txtSigla.Text;
                oPais.StatusPais = cmbStatus.Text[0].ToString();

                if (oPais.ID == 0)
                {
                    oPais.DataCriacao = DateTime.Now;
                    var result = paisesController.AdicionarPais(oPais);
                    if (result == "OK")
                        Close();
                    else
                        MessageBox.Show("Erro inesperado.");
                }
                else
                {
                    oPais.DataUltimaAlteracao = DateTime.Now;
                    var result = paisesController.AtualizarPais(oPais);
                    if (result == "OK")
                        Close();

                    else if (result == "NOT")
                        MessageBox.Show("Brasil não pode ser Alterado.");
                    else
                        MessageBox.Show("Erro inesperado.");
                }

                return;
            }
        }
    }
}
