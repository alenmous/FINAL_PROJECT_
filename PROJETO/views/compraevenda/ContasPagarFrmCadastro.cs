using PROJETO.controller.compraevenda;
using PROJETO.models.compraevenda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace PROJETO.views.compraevenda
{
    public partial class ContasPagarFrmCadastro : PROJETO.views.cadastros.cadastroFrm
    {
        ContasPagar aConta;
        ContasPagarController contaPagarController;
        CultureInfo cultura = CultureInfo.InvariantCulture;
        public ContasPagarFrmCadastro()
        {
            InitializeComponent();
            aConta = new ContasPagar();
            contaPagarController = new ContasPagarController();
        }
        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is ContasPagar conta)
            {
                aConta = conta;
                CarregarCampos();
            }
        }
        protected override void LimparCampos()
        {
            txtCodigo.Clear();
            txtModelo.Clear();
            txtSerie.Clear();
            txtParcela.Clear();
            txtCodForn.Clear();
            txtCodCondPg.Clear();
            txtCodForma.Clear();
            txtForma.Clear();
            txtFornecedor.Clear();
            txtStatus.Clear();
            txtTaxa.Clear();
            txtMulta.Clear();
            txtDesconto.Clear();
            txtParcela.Clear();
            txtTotalPago.Clear();
            dtVencimento.Value = DateTime.Now;
            dtEmissao.Value = DateTime.Now;
            dtBaixa.Value = DateTime.Now;
        }
        public override void BloquearCampos()
        {
            base.BloquearCampos();
            txtCodigo.Enabled = false;
            txtModelo.Enabled = false;
            txtSerie.Enabled = false;
            txtParcela.Enabled = false;
            txtCodForn.Enabled = false;
            txtCodCondPg.Enabled = false;
            txtCodForma.Enabled = false;
            txtForma.Enabled = false;
            txtFornecedor.Enabled = false;
            txtStatus.Enabled = false;
            txtTaxa.Enabled = false;
            txtMulta.Enabled = false;
            txtDesconto.Enabled = false;
            txtTotalPago.Enabled = false;
            dtVencimento.Enabled = false;
            dtBaixa.Enabled = false;
            dtEmissao.Enabled = false;
            btnSalvar.Enabled = false;
        }
        public override void DesbloquearCampos()
        {
            base.DesbloquearCampos();
            txtCodigo.Enabled = true;
            txtModelo.Enabled = true;
            txtSerie.Enabled = true;
            txtParcela.Enabled = true;
            txtCodForn.Enabled = true;
            txtCodCondPg.Enabled = true;
            dtEmissao.Enabled = true;
            txtCodForma.Enabled = true;
            txtForma.Enabled = true;
            txtFornecedor.Enabled = true;
            txtStatus.Enabled = true;
            txtTaxa.Enabled = true;
            txtMulta.Enabled = true;
            txtDesconto.Enabled = true;
            txtTotalPago.Enabled = true;
            dtVencimento.Enabled = true;
            dtBaixa.Enabled = true;
            btnSalvar.Enabled = true;
        }
        public override void CarregarCampos()
        {
            base.CarregarCampos();

            txtCodigo.Text = aConta.NumNFC.ToString();
            txtModelo.Text = aConta.ModeloNFC.ToString();
            txtSerie.Text = aConta.SerieNFC.ToString();
            txtParcela.Text = aConta.NumParcela.ToString();
            txtCodForn.Text = aConta.Fornecedor.ID.ToString();
            txtCodCondPg.Text = aConta.Condicao.ID.ToString();
            txtCodForma.Text = aConta.FormaPagamento.ID.ToString();
            txtForma.Text = aConta.FormaPagamento.Forma;
            txtFornecedor.Text = aConta.Fornecedor.NomeFantasia;
            txtStatus.Text = aConta.Situacao;
            txtTaxa.Text = aConta.Taxa.ToString("0.00", cultura);
            txtMulta.Text = aConta.Multa.ToString("0.00", cultura);
            txtDesconto.Text = aConta.Desconto.ToString("0.00", cultura);
            txtValorParcela.Text = aConta.Valor.ToString("0.00", cultura);
            dtEmissao.Value = aConta.DataCriacao;
            dtVencimento.Value = aConta.DataVencimento;

            // Verifica se DataBaixa é nulo ou default (DateTime.MinValue) e atribui DateTime.Now se for o caso
            dtBaixa.Value = aConta.DataBaixa != DateTime.MinValue ? aConta.DataBaixa : DateTime.Now;

            txtTotalPago.Text = aConta.Pagamento.ToString("0.00", cultura);
            if (txtStatus.Text == "PAGO")
                BloquearCampos();
        }

        protected bool VerificarCamposVazios()
        {
            List<string> camposFaltantes = new List<string>();

            // Verifica se o campo txtTotalPago está vazio ou é zero
            if (string.IsNullOrWhiteSpace(txtTotalPago.Text) || !decimal.TryParse(txtTotalPago.Text.Replace('.', ','), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal totalPago) || totalPago <= 0)
            {
                if (btnSalvar.Text != "Alterar")// se for SALVAR então precsa do valor para pagar, alteração não vai salvar o valor da parcela. pois não da baixa na mesma.
                    camposFaltantes.Add("Valor total pago deve ser um número maior que zero.");
            }
            else
            {
                // Verifica se txtValorParcela não está vazio e tenta converter
                if (string.IsNullOrWhiteSpace(txtValorParcela.Text) || !decimal.TryParse(txtValorParcela.Text.Replace('.', ','), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valorParcela) || valorParcela <= 0)
                {
                    camposFaltantes.Add("Valor da parcela deve ser um número maior que zero.");
                }
                else
                {
                    // Arredonda os valores para duas casas decimais
                    decimal valorParcelaArredondado = Math.Round(valorParcela, 2);
                    decimal totalPagoArredondado = Math.Round(totalPago, 2);

                    // Verifica se o valor pago é menor que o valor da parcela
                    if (totalPagoArredondado < valorParcelaArredondado)
                    {
                        DialogResult result = MessageBox.Show(
                            "O valor pago é menor que o valor da parcela. Tem certeza que deseja prosseguir?",
                            "Valor Inferior",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            return false; // O usuário escolheu não prosseguir
                        }
                    }

                }


            }

            // Verifica se a data de baixa é maior que a data atual
            if (dtBaixa.Value.Date > DateTime.Now.Date)
            {
                camposFaltantes.Add("Data de baixa não pode ser uma data futura.");
            }

            // Verifica se o desconto é válido (não vazio)
            if (!decimal.TryParse(txtDesconto.Text, out decimal desconto))
            {
                camposFaltantes.Add("Desconto");
            }

            // Verifica se a taxa é válida (não vazia)
            if (!decimal.TryParse(txtTaxa.Text, out decimal taxa))
            {
                camposFaltantes.Add("Taxa");
            }

            // Verifica se a multa é válida (não vazia)
            if (!decimal.TryParse(txtMulta.Text, out decimal multa))
            {
                camposFaltantes.Add("Multa");
            }

            // Se houver campos faltantes, mostra mensagem de erro
            if (camposFaltantes.Count > 0)
            {
                string camposFaltantesStr = string.Join(", ", camposFaltantes);
                MessageBox.Show("Os seguintes campos são obrigatórios e não foram preenchidos ou contêm valores inválidos: " + camposFaltantesStr, "Campos em Falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }




        protected override void Salvar()
        {
            if (VerificarCamposVazios())
            {

                aConta.DataUltAlteracao = DateTime.Now;
                aConta.DataVencimento = dtVencimento.Value;
                aConta.Taxa = decimal.Parse(txtTaxa.Text, cultura);
                aConta.Multa = decimal.Parse(txtMulta.Text, cultura);
                aConta.Desconto = decimal.Parse(txtDesconto.Text, cultura);

                if (btnSalvar.Text == "Salvar")
                {
                    aConta.Situacao = "PAGO";
                    aConta.DataBaixa = dtBaixa.Value;
                    aConta.Pagamento = decimal.Parse(txtTotalPago.Text, cultura);
                    var result = contaPagarController.Quitar(aConta);
                    if (result == "OK")
                    {
                        MessageBox.Show("Operação realizada com sucesso ");
                        Close();
                    }
                    else
                        MessageBox.Show("Erro inesperado.");
                }
                else if (btnSalvar.Text == "Alterar")
                {
                    var result = contaPagarController.AtualizarContaPagar(aConta);
                    if (result == "OK")
                    {
                        MessageBox.Show("Operação realizada com sucesso ");
                        Close();
                    }
                    else
                        MessageBox.Show("Erro inesperado.");
                }

            }
        }

    }
}
