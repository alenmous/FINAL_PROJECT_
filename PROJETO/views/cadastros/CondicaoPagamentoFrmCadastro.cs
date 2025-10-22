using PROJETO.controller;
using PROJETO.models;
using PROJETO.models.bases;
using PROJETO.views.consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PROJETO.views.cadastros
{
    public partial class CondicaoPagamentoFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        CondicaoPagamentoController condicaoPagamentoController;
        private int ultimoDias = 30; // Variável para armazenar o último valor de dias utilizado
        private CondicaoPagamento aCondicao;
        ParcelasController parcelasController;
        List<Parcela> parcelasAtual;


        public CondicaoPagamentoFrmCadastro()
        {
            InitializeComponent();
            aCondicao = new CondicaoPagamento();
            condicaoPagamentoController = new CondicaoPagamentoController();
            parcelasController = new ParcelasController();
            parcelasAtual = new List<Parcela>();
            Operacao.DisableCopyPaste(this);
        }
        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is CondicaoPagamento condicao)
            {
                aCondicao = condicao;
            }
        }
        protected override void LimparCampos()
        {
            txtCondicao.Clear();
            txtParcelas.Clear();
            txtDias.Clear();
            txtPercentualTotal.Clear();
            txtTaxa.Clear();
            txtMulta.Clear();
            txtDesconto.Clear();
            txtCodForma.Clear();
            txtForma.Clear();
        }
        public override void BloquearCampos()
        {
            base.BloquearCampos();
            txtCondicao.Enabled = false;
            txtParcelas.Enabled = false;
            txtDias.Enabled = false;
            txtPercentualTotal.Enabled = false;
            txtTaxa.Enabled = false;
            txtMulta.Enabled = false;
            txtDesconto.Enabled = false;
            txtCodForma.Enabled = false;
            txtForma.Enabled = false;
            btnAdicionar.Enabled = false;
            btnBuscarForma.Enabled = false;
            txtPercentual.Enabled = false;

        }
        public override void DesbloquearCampos()
        {
            base.DesbloquearCampos();
            txtCondicao.Enabled = true;
            txtParcelas.Enabled = true;
            txtDias.Enabled = true;
            txtPercentualTotal.Enabled = true;
            txtTaxa.Enabled = true;
            txtMulta.Enabled = true;
            txtDesconto.Enabled = true;
            txtCodForma.Enabled = true;
            txtForma.Enabled = true;
            btnAdicionar.Enabled = true;
            btnBuscarForma.Enabled = true;
            txtPercentual.Enabled = true;
        }
        private bool VerificarCamposVazios()
        {
            List<string> camposFaltantes = new List<string>();

            if (string.IsNullOrWhiteSpace(txtParcelas.Text))
            {
                camposFaltantes.Add("Parcelas");
            }
            if (string.IsNullOrWhiteSpace(txtTaxa.Text))
            {
                camposFaltantes.Add("Taxa");
            }
            if (string.IsNullOrWhiteSpace(txtMulta.Text))
            {
                camposFaltantes.Add("Multa");
            }
            if (string.IsNullOrWhiteSpace(txtDesconto.Text))
            {
                camposFaltantes.Add("Desconto");
            }
            if (string.IsNullOrWhiteSpace(txtCondicao.Text))
            {
                camposFaltantes.Add("Condição de pagamento");
            }
            if (string.IsNullOrWhiteSpace(txtCodForma.Text))
            {
                camposFaltantes.Add("Codigo de Forma de pagamento");
            }
            if (string.IsNullOrWhiteSpace(txtPercentualTotal.Text))
            {
                camposFaltantes.Add("Parcelas");
            }
            if (string.IsNullOrWhiteSpace(txtDias.Text))
            {
                camposFaltantes.Add("DiasTotais");
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
            if (txtPercentualTotal.Text == "100.00" || txtPercentualTotal.Text == "100.0000")
            {
                if (btnSalvar.Text == "Salvar")
                {
                    aCondicao.DataCriacao = DateTime.Now;
                    aCondicao.Status = "A";
                    var result = condicaoPagamentoController.AdicionarCondicaoPagamento(AdicionarGrid());
                    if (result == true)
                        Close();
                    else
                        MessageBox.Show("Erro inesperado.");
                }
                else
                {
                    //
                    aCondicao.ID = Convert.ToInt32(txtCodigo.Text);
                    var result = condicaoPagamentoController.AtualizarCondicaoPagamento(AdicionarGrid());
                    if (result == true)
                        Close();
                    else
                        MessageBox.Show("Erro inesperado.");
                }
            }
            else
            {
                MessageBox.Show("Impossivel salvar, o percentual não bate com 100%");
            }

        }
        public void Add()
        {
            try
            {
                int totalParcelas = DgCondicao.Rows.Count + 1;
                int dias = Convert.ToInt32(txtDias.Text);
                decimal percentualTotal = 0;

                // Soma os percentuais já existentes no DataGridView
                foreach (DataGridViewRow row in DgCondicao.Rows)
                {
                    if (row.Cells["percentual"].Value != null)
                    {
                        string valorCelula = row.Cells["percentual"].Value.ToString().Replace(',', '.');
                        if (decimal.TryParse(valorCelula, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal percentualLinha))
                        {
                            percentualTotal += Math.Round(percentualLinha, 4);
                        }
                        else
                        {
                            MessageBox.Show("Há um percentual inválido em uma das parcelas.");
                            return;
                        }
                    }
                }

                // Trata o valor do campo txtPercentual
                string percentualTexto = txtPercentual.Text.Replace(',', '.');
                if (!decimal.TryParse(percentualTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal percentualAtual))
                {
                    MessageBox.Show("Formato de percentual inválido. Por favor, insira um número válido.");
                    return;
                }

                percentualAtual = Math.Round(percentualAtual, 4); // Garante 4 casas decimais

                if (percentualAtual <= 0)
                {
                    MessageBox.Show("O percentual deve ser maior que 0.");
                    return;
                }

                if (percentualTotal + percentualAtual > 100.0000m)
                {
                    MessageBox.Show("A soma do percentual atual com o percentual total ultrapassa 100%.");
                    return;
                }

                // Adiciona a nova linha ao DataGridView
                AddDg(totalParcelas, dias, percentualAtual);

                // Atualiza campos
                txtParcelas.Text = totalParcelas.ToString();

                decimal novoPercentualTotal = Math.Round(percentualTotal + percentualAtual, 4);
                txtPercentualTotal.Text = novoPercentualTotal.ToString("F4", CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato inválido. Certifique-se de inserir apenas números no percentual e nos dias.");
            }
        }

        private void RecalcularPercentualTotal()
        {
            decimal percentualTotal = 0;

            // Itera pelas linhas do DataGridView e soma os percentuais
            foreach (DataGridViewRow row in DgCondicao.Rows)
            {
                decimal percentual;
                if (decimal.TryParse(row.Cells["percentual"].Value?.ToString(), out percentual))
                {
                    percentualTotal += percentual;
                }
            }

            // Atualiza o valor de txtPercentualTotal.Text com o novo valor calculado
            txtPercentualTotal.Text = percentualTotal.ToString("0.00", CultureInfo.InvariantCulture);
        }



        public void AddDg(int vLinha, int dias, decimal percentual)
        {
            DgCondicao.Rows.Add(
                vLinha,
                dias,
                txtCodForma.Text,
                txtForma.Text,
                percentual.ToString());
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DgCondicao.Rows.Clear();
            txtPercentualTotal.Text = "0";
            txtParcelas.Text = "1";
            txtDias.Text = "";
            ultimoDias = 0; // Reinicia o último valor de dias para 0
        }

        public CondicaoPagamento AdicionarGrid()
        {
            FormaPagamentoController ControllerForma = new FormaPagamentoController();
            var pagamento = new CondicaoPagamento();
            List<Parcela> Lista = new List<Parcela>();
            Parcela Parcelas = null;
            pagamento.ID = Convert.ToInt32(txtCodigo.Text);
            CultureInfo cultura = CultureInfo.InvariantCulture;

            pagamento.Status = "A";
            pagamento.Condicao = Convert.ToString(txtCondicao.Text);
            pagamento.Multa = decimal.Parse(txtMulta.Text, cultura);
            pagamento.Taxa = decimal.Parse(txtTaxa.Text, cultura);
            pagamento.Desconto = decimal.Parse(txtDesconto.Text, cultura);
            pagamento.DataCriacao = DateTime.Now;
            pagamento.DataUltimaAlteracao = DateTime.Now;
            foreach (DataGridViewRow vLinha in DgCondicao.Rows)
            {
                Parcelas = new Parcela();
                Parcelas.ID = pagamento.ID;
                Parcelas.NumParcela = Convert.ToInt32(vLinha.Cells["num_parcela"].Value);
                Parcelas.DiasTotais = Convert.ToInt32(vLinha.Cells["dias_totais"].Value);
                Parcelas.Porcentagem = Convert.ToDecimal(vLinha.Cells["percentual"].Value);
                Parcelas.Forma = new FormaPagamento();
                Parcelas.Forma.ID = Convert.ToInt32(vLinha.Cells["idForma"].Value);
                Parcelas.DataCriacao = DateTime.Now;
                Parcelas.DataUltimaAlteracao = DateTime.Now;
                Lista.Add(Parcelas);
            }
            pagamento.uParcelas = Lista;
            pagamento.Parcelas = pagamento.uParcelas.Count();
            return pagamento;
        }
        public void Popular(CondicaoPagamento CondicaoPagamento)
        {
            // Formata os valores de preço para exibição correta
            CultureInfo cultura = CultureInfo.InvariantCulture;
            txtCodigo.Text = CondicaoPagamento.ID.ToString();
            txtCondicao.Text = CondicaoPagamento.Condicao.ToString();
            txtMulta.Text = CondicaoPagamento.Multa.ToString("0.00", cultura);
            txtDesconto.Text = CondicaoPagamento.Desconto.ToString("0.00", cultura);
            txtTaxa.Text = CondicaoPagamento.Taxa.ToString("0.00", cultura);
            txtDatCad.Text = CondicaoPagamento.DataCriacao.ToShortDateString();
            txtDatUltAlt.Text = CondicaoPagamento.DataUltimaAlteracao.ToShortDateString();
            int idCondicao = Convert.ToInt32(txtCodigo.Text);
            List<Parcela> parcelas = parcelasController.BuscarParcelasPorIDCondicao(idCondicao);

            foreach (var Parc in parcelas)
            {
                DgCondicao.Rows.Add(
                    Parc.NumParcela,
                    Parc.DiasTotais,
                    Parc.Forma.ID,
                    Parc.Forma.Forma,
                    Parc.Porcentagem
                );

                // Adiciona a parcela à lista parcelasAtual
                txtCodForma.Text = Parc.Forma.ID.ToString();
                txtForma.Text = Parc.Forma.Forma;
                parcelasAtual.Add(Parc);
            }
            txtPercentualTotal.Text = "100.00";
        }

        public void DefinirProximoIdCondicaoPagamento()
        {
            try
            {
                int proximoId = condicaoPagamentoController.ObterProximoIdCondicaoPagamento();
                txtCodigo.Text = proximoId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao definir o próximo ID: {ex.Message}");
            }
        }
        private void tbIdForma_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null; // Remove o botão "SALVAR" como botão padrão
        }


        private void tbIdForma_Leave(object sender, EventArgs e)
        {

        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (VerificarCamposVazios())
            {
                Add();
            }

        }


        public override void Verificar()
        {
            if (btnSalvar.Text == "Salvar" || btnSalvar.Text == "Alterar")
            {
                if (DgCondicao.Rows.Count > 0)
                    Salvar();
                else
                {
                    MessageBox.Show("Não existem parcelas cadastradas, por favor insira as parcelas.");
                }
            }
            else if (btnSalvar.Text == "Excluir")
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir a condição de pagamento?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        aCondicao.ID = Convert.ToInt32(txtCodigo.Text);
                        condicaoPagamentoController.ExcluirCondicaoPagamento(aCondicao.ID);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao excluir a condição de pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
          
        }
        private void LimparForma()
        {
            txtForma.Clear();
            txtCodForma.Clear();
            //txtParcelas.
        }

        private void txtParcelas_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarValorKeyPress((System.Windows.Forms.TextBox)sender, e);
        }

        private void txtDias_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDias.Text))
            {
                ultimoDias = Convert.ToInt32(txtDias.Text);
            }
        }

        private void txtPercentual_KeyPress(object sender, KeyPressEventArgs e)
        {
            Operacao.ValidarDecimais((System.Windows.Forms.TextBox)sender, e);
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            if (VerificarCamposVazios())
            {
                Add();
            }
        }

        private void btnBuscarForma_Click(object sender, EventArgs e)
        {
            using (FormaPagamentoFrmConsulta frm = new FormaPagamentoFrmConsulta())
            {
                frm.btnSair.Text = "Selecionar";
                frm.ShowDialog();

                int IdSelecionado = frm.IdSelecionado;
                string NomeSelecionado = frm.NomeSelecionado;

                // Agora, defina os valores nos campos do seu formulário de cadastro
                txtCodForma.Text = IdSelecionado.ToString();
                txtForma.Text = NomeSelecionado;
                // Chamando explicitamente o evento Leave de txtCodPais
                txtCodigo_Leave(txtCodForma, EventArgs.Empty);

            }
        }
        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodForma.Text))
                LimparForma();
            else if (int.TryParse(txtCodForma.Text, out int cod) && cod > 0)
            {
                // Se o código for um número inteiro válido e maior que zero, verifique o estado correspondente
                FormaPagamentoController aCTLF = new FormaPagamentoController();
                FormaPagamento forma = aCTLF.BuscarFormaPagamentoPorId(cod);

                if (forma == null)
                {
                    MessageBox.Show("Código inexistente.");
                    LimparForma();
                }
                else
                {
                    txtForma.Text = forma.Forma;
                }
            }
            else
            {
                // Se o código não for um número inteiro válido ou não for maior que zero, limpe ambos os campos
                MessageBox.Show("Código inválido. Certifique-se de inserir um número inteiro válido maior que zero.");
                LimparForma();
            }
            this.AcceptButton = btnSalvar; // Restaura o botão "SALVAR" como botão padrão
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            DgCondicao.Rows.Clear();
            txtPercentualTotal.Text = "0";
            txtParcelas.Text = "1";
            txtDias.Text = "30";
            ultimoDias = 30; // Reinicia o último valor de dias para 30
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifique se há uma linha selecionada
            if (DgCondicao.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow selectedRow = DgCondicao.SelectedRows[0];

                // Remove a linha selecionada do DataGridView
                DgCondicao.Rows.Remove(selectedRow);

                // Recalcular o percentual total
                RecalcularPercentualTotal();
            }
            else
            {
                MessageBox.Show("Nenhuma linha selecionada. Selecione uma linha para excluir.");
            }
        }

        private void btnDesativar_Click(object sender, EventArgs e)
        {
            int idCondicao = Convert.ToInt32(txtCodigo.Text);
            if (idCondicao > 0)
            {
                bool desativando = btnDesativar.Text == "DESATIVAR";
                string acao = desativando ? "desativar" : "ativar";
                string mensagem = $"Tem certeza que deseja {acao} a condição de pagamento?";

                DialogResult resultado = MessageBox.Show(mensagem, $"Confirmação de {acao}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        aCondicao.ID = idCondicao;
                        bool sucesso = condicaoPagamentoController.AtivarOuDesativarCondicaoPagamento(aCondicao);
                        if (sucesso)
                        {
                            string status = desativando ? "desativada" : "ativada";
                            MessageBox.Show($"A condição de pagamento foi {status}.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();  // Fecha o formulário se a operação for bem-sucedida
                        }
                        else
                        {
                            MessageBox.Show("Ocorreu um erro ao tentar alterar o status da condição de pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro ao {acao} a condição de pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

}
