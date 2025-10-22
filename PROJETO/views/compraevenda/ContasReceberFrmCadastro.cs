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
    public partial class ContasReceberFrmCadastro : PROJETO.views.compraevenda.ContasPagarFrmCadastro
    {
        ContasReceber aConta;
        ContasReceberController contasReceberController;
        CultureInfo cultura = CultureInfo.InvariantCulture;
        public ContasReceberFrmCadastro()
        {
            InitializeComponent();
            aConta = new ContasReceber();
            contasReceberController = new ContasReceberController();
        }

        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);
            if (obj is ContasReceber conta)
            {
                aConta = conta;
                CarregarCampos();
            }
        }
        public override void CarregarCampos()
        {
            base.CarregarCampos();

            txtCodigo.Text = aConta.NumNFC.ToString();
            txtModelo.Text = aConta.ModeloNFC.ToString();
            txtSerie.Text = aConta.SerieNFC.ToString();
            txtParcela.Text = aConta.NumParcela.ToString();
            txtCodForn.Text = aConta.Cliente.ID.ToString();
            txtCodCondPg.Text = aConta.Condicao.ID.ToString();
            txtCodForma.Text = aConta.FormaPagamento.ID.ToString();
            txtForma.Text = aConta.FormaPagamento.Forma;
            txtFornecedor.Text = aConta.Cliente.Nome;
            txtStatus.Text = aConta.Situacao;
            txtTaxa.Text = aConta.Taxa.ToString("0.00", cultura);
            txtMulta.Text = aConta.Multa.ToString("0.00", cultura);
            txtDesconto.Text = aConta.Desconto.ToString("0.00", cultura);
            txtValorParcela.Text = aConta.Valor.ToString("0.00", cultura);
            dtVencimento.Value = aConta.DataVencimento;

            // Verifica se DataBaixa é nulo ou default (DateTime.MinValue) e atribui DateTime.Now se for o caso
            dtBaixa.Value = aConta.DataBaixa != DateTime.MinValue ? aConta.DataBaixa : DateTime.Now;

            txtTotalPago.Text = aConta.Pagamento.ToString("0.00", cultura);
            if (txtStatus.Text == "PAGO")
                BloquearCampos();
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
                    var result = contasReceberController.Quitar(aConta);
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
                    var result = contasReceberController.AtualizarContaReceber(aConta);
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
