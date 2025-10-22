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
    public partial class CidadesFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        Cidades aCidade;
        private EstadosFrmConsulta estadosFrmConsulta;
        CidadesController cidadesController;

        public CidadesFrmCadastro()
        {
            InitializeComponent();
            aCidade = new Cidades();
            cidadesController = new CidadesController();
            Operacao.DisableCopyPaste(this);
        }

        private void btnBuscarEstado_Click(object sender, EventArgs e)
        {
            using (EstadosFrmConsulta frm = new EstadosFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                frm.ShowDialog();

                // Após o retorno do diálogo, você pode acessar os valores do cliente selecionado
                int IdSelecionado = frm.IdSelecionado;
                string NomeSelecionado = frm.NomeSelecionado;

                // Agora, defina os valores nos campos do seu formulário de cadastro
                txtCodEstado.Text = IdSelecionado.ToString();
                txtEstado.Text = NomeSelecionado;
                // Chamando explicitamente o evento Leave de txtCodPais
                txtCodEstado_Leave(txtCodEstado, EventArgs.Empty);

            }
        }


        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is Cidades cidade)
            {
                aCidade = cidade;
                CarregarCampos();
            }
        }
        public void SetConsultaEstados(object obj)
        {
            estadosFrmConsulta = (EstadosFrmConsulta)obj;
        }
        protected override void LimparCampos()
        {
            txtCidade.Clear();
            txtDDD.Clear();
            txtCodigo.Clear();
            txtEstado.Clear();
            cmbStatus.SelectedIndex = 0;
        }
        public override void BloquearCampos()
        {
            base.BloquearCampos();
            txtCidade.Enabled = false;
            txtDDD.Enabled = false;
            txtCodEstado.Enabled = false;
            txtEstado.Enabled = false;
            btnBuscarEstado.Enabled = false;
            cmbStatus.Enabled = false;
        }
        public override void DesbloquearCampos()
        {
            base.DesbloquearCampos();
            txtCidade.Enabled = true;
            txtDDD.Enabled = true;
            txtCodEstado.Enabled = true;
            txtEstado.Enabled = true;
            btnBuscarEstado.Enabled = true;
            cmbStatus.Enabled = true;
        }
        public override void CarregarCampos()
        {
            base.CarregarCampos();
            txtCodigo.Text = aCidade.ID.ToString();
            txtCidade.Text = aCidade.Cidade;
            txtDDD.Text = aCidade.DDD;
            txtCodEstado.Text = Convert.ToString(aCidade.OEstado.ID);
            txtEstado.Text = aCidade.OEstado.Estado;
            cmbStatus.Text = aCidade.StatusCidade == "I" ? "Inativo" : aCidade.StatusCidade == "A" ? "Ativo" : aCidade.StatusCidade;
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
                    ExcluirCidade();
                }
            }
        }
        private void ExcluirCidade()
        {
            if (aCidade != null)
            {
                try
                {
                    var result = cidadesController.ExcluirCidade(aCidade.ID);
                    if (result)
                        Close();
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir a cidade. Detalhes: " + result);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Verifica o número de erro 547, que corresponde a violação de chave estrangeira
                    {
                        MessageBox.Show("Não é possível excluir a cidade devido a outros registros estarem vinculados a este estado.");
                    }
                    else
                    {
                        // Trate outras exceções SQL, se necessário
                        MessageBox.Show("Ocorreu um erro ao excluir a cidade. Detalhes: " + ex.Message);
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

            if (string.IsNullOrWhiteSpace(txtCodEstado.Text))
            {
                camposFaltantes.Add("Codigo do Estado");
            }
            if (string.IsNullOrWhiteSpace(txtCidade.Text))
            {
                camposFaltantes.Add("Cidade");
            }
            if (string.IsNullOrWhiteSpace(txtDDD.Text))
            {
                camposFaltantes.Add("DDD");
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
                aCidade.Cidade = txtCidade.Text;
                aCidade.DDD = txtDDD.Text;
                aCidade.OEstado.ID = Convert.ToInt32(txtCodEstado.Text);
                aCidade.StatusCidade = cmbStatus.Text[0].ToString();
                if (aCidade.ID == 0)
                {
                    aCidade.DataCriacao = DateTime.Now;
                    var result = cidadesController.AdicionarCidade(aCidade);
                    if (result == "OK")
                        Close();
                    else
                        MessageBox.Show("Erro inesperado.");
                }
                else
                {
                    aCidade.DataUltimaAlteracao = DateTime.Now;
                    var result = cidadesController.AtualizarCidade(aCidade);
                    if (result == "OK")
                        Close();
                    else
                        MessageBox.Show("Erro inesperado.");
                }
            }
        }

        private void Limpar()
        {
            txtCodEstado.Clear();
            txtEstado.Clear();
            txtCodEstado.Focus();
        }

        private void txtCidade_KeyDown(object sender, KeyEventArgs e)
        {
            Operacao.BloquearKeyDowControlC(sender, e);
        }

        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarNomes(sender, e);
        }

        private void txtCodEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarValorKeyPress((System.Windows.Forms.TextBox)sender, e);
        }

        private void txtCodEstado_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null; // Remove o botão "SALVAR" como botão padrão
        }

        private void txtCodEstado_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodEstado.Text))
            {
                // Se o campo txtCodEstado estiver vazio, limpe também o campo txtEstado
                txtCodEstado.Clear();
                txtEstado.Clear();
            }
            else if (int.TryParse(txtCodEstado.Text, out int cod) && cod > 0)
            {
                // Se o código for um número inteiro válido e maior que zero, verifique o estado correspondente
                EstadosController estadosController = new EstadosController();
                Estados estado = estadosController.BuscarEstadoPorId(cod);

                if (estado == null)
                {
                    MessageBox.Show("Código inexistente.");
                    Limpar();
                }
                else if (estado.StatusEstado == "I")
                {
                    MessageBox.Show("O estado associado a este código está inativo.");
                    Limpar();
                }
                else
                {
                    txtEstado.Text = estado.Estado;
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
    }

}
