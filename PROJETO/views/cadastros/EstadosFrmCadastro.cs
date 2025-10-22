using PROJETO.controller;
using PROJETO.models;
using PROJETO.models.bases;
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
    public partial class EstadosFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        Estados oEstado;
        EstadosController estadosController;
        private PaisesFrmConsulta paisesFrmConsulta;

        public EstadosFrmCadastro()
        {
            InitializeComponent();
            oEstado = new Estados();
            estadosController = new EstadosController();
            Operacao.DisableCopyPaste(this);
        }
        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is Estados estado)
            {
                oEstado = estado;
                CarregarCampos();
            }
        }
        public void SetConsultaPaises(object obj)
        {
            paisesFrmConsulta = (PaisesFrmConsulta)obj;
        }

        protected override void LimparCampos()
        {
            txtUF.Clear();
            txtEstado.Clear();
            txtPais.Clear();
            txtCodigo.Clear();
            cmbStatus.SelectedIndex = 0;
        }
        public override void BloquearCampos()
        {
            base.BloquearCampos();
            txtEstado.Enabled = false;
            txtUF.Enabled = false;
            txtCodPais.Enabled = false;
            txtPais.Enabled = false;
            btnBuscarPaises.Enabled = false;
            cmbStatus.Enabled = false;
        }
        public override void DesbloquearCampos()
        {
            base.BloquearCampos();
            txtEstado.Enabled = true;
            txtUF.Enabled = true;
            txtCodPais.Enabled = true;
            txtPais.Enabled = true;
            btnBuscarPaises.Enabled = true;
        }
        public override void CarregarCampos()
        {
            base.CarregarCampos();
            txtCodigo.Text = oEstado.ID.ToString();
            this.txtUF.Text = oEstado.UF.ToString();
            this.txtPais.Text = oEstado.OPais.Pais.ToString();
            this.txtEstado.Text = oEstado.Estado.ToString();
            this.txtCodPais.Text = oEstado.OPais.ID.ToString();
            this.txtPais.Text = oEstado.OPais.Pais;
            cmbStatus.Text = oEstado.StatusEstado == "I" ? "Inativo" : oEstado.StatusEstado == "A" ? "Ativo" : oEstado.StatusEstado;

        }
        public override void Verificar()
        {
            if (btnSalvar.Text == "Salvar" || btnSalvar.Text == "Alterar")
                Salvar();
            else if (btnSalvar.Text == "Excluir")
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este estado?", "Confirmação de Exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ExcluirEstado();
                }
            }
        }
        private void ExcluirEstado()
        {
            if (oEstado != null)
            {
                try
                {
                    var result = estadosController.ExcluirEstado(oEstado.ID);
                    if (result)
                        Close();
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o estado. Detalhes: " + result);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Verifica o número de erro 547, que corresponde a violação de chave estrangeira
                    {
                        MessageBox.Show("Não é possível excluir o estado devido a outros registros estarem vinculados a este estado.");
                    }
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir o estado. Detalhes: " + ex.Message);
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

            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                camposFaltantes.Add("Estado");
            }
            if (string.IsNullOrWhiteSpace(txtUF.Text))
            {
                camposFaltantes.Add("UF");
            }
            if (string.IsNullOrWhiteSpace(txtCodPais.Text))
            {
                camposFaltantes.Add("Código do País");
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
                oEstado.Estado = txtEstado.Text;
                oEstado.UF = txtUF.Text;
                oEstado.OPais.ID = Convert.ToInt32(txtCodPais.Text);
                oEstado.StatusEstado = cmbStatus.Text[0].ToString();

                if (oEstado.ID == 0)
                {
                    oEstado.DataCriacao = DateTime.Now;
                    var result = estadosController.AdicionarEstado(oEstado);
                    if (result == "OK")
                        Close();
                    else
                        MessageBox.Show("Erro inesperado.");
                }
                else
                {
                    oEstado.DataUltimaAlteracao = DateTime.Now;
                    var result = estadosController.AtualizarEstado(oEstado);
                    if (result == "OK")
                        Close();
                    else
                        MessageBox.Show("Erro inesperado.");
                }
            }
        }
        private void Limpar()
        {
            txtCodPais.Clear();
            txtPais.Clear();
            txtCodPais.Focus();
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarNomes(sender, e);
        }

        private void txtCodPais_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null; // Remove o botão "SALVAR" como botão padrão
        }

        private void txtCodPais_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarValorKeyPress((System.Windows.Forms.TextBox)sender, e);
        }

        private void txtCodPais_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodPais.Text))
            {
                // Se o campo txtCodPais estiver vazio, limpe também o campo txtPais
                txtCodPais.Clear();
                txtPais.Clear();
            }
            else if (int.TryParse(txtCodPais.Text, out int cod) && cod > 0)
            {
                // Se o código for um número inteiro válido e maior que zero, verifique o status do país
                PaisesController aCTLPais = new PaisesController();
                Paises pais = aCTLPais.BuscarPaisPorId(cod);

                if (pais == null)
                {
                    MessageBox.Show("Código inexistente.");
                    Limpar();
                }
                else if (pais.StatusPais == "I")
                {
                    MessageBox.Show("O país associado a este código está inativo.");
                    Limpar();
                }
                else
                {
                    txtPais.Text = pais.Pais;
                }
            }
            else
            {
                // Se o código não for um número inteiro válido ou não for maior que zero, limpe ambos os campos
                MessageBox.Show("Código inválido. Certifique-se de inserir um número inteiro válido maior que zero.");
                Limpar();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }

        private void btnBuscarPaises_Click(object sender, EventArgs e)
        {
            using (PaisesFrmConsulta frm = new PaisesFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                frm.ShowDialog();

                // Após o retorno do diálogo, você pode acessar os valores do cliente selecionado
                int IdSelecionado = frm.IdSelecionado;
                string NomeSelecionado = frm.NomeSelecionado;

                // Agora, defina os valores nos campos do seu formulário de cadastro
                txtCodPais.Text = IdSelecionado.ToString();
                txtPais.Text = NomeSelecionado;
                txtCodPais_Leave(txtCodPais, EventArgs.Empty);
            }
        }
    }
}
