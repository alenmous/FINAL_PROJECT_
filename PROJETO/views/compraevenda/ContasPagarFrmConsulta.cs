using PROJETO.controller;
using PROJETO.controller.compraevenda;
using PROJETO.models;
using PROJETO.models.bases;
using PROJETO.models.compraevenda;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJETO.views.compraevenda
{
    public partial class ContasPagarFrmConsulta : PROJETO.views.consultas.consultaFrm
    {/// <summary>
    /// /////////////////////////////////////////////CONTAS A PAGAR
    /// </summary>
        ContasPagarFrmCadastro contasPagarFrmCadastro;
        ContasPagar aContaPagar;
        ContasPagarController contasPagarController;
        public ContasPagarFrmConsulta()
        {
            InitializeComponent();
            contasPagarController = new ContasPagarController();
            Operacao.DisableCopyPaste(this);
        }
        public override void ConhecaObj(object obj)
        {
            aContaPagar = (ContasPagar)obj;
        }
        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                contasPagarFrmCadastro = (ContasPagarFrmCadastro)obj;
            }
        }
        protected override void Incluir()
        {
            int Numero = ObterIdSelecionado(0); // Obtém o número
            int Modelo = ObterIdSelecionado(1); // Obtém o modelo
            int Serie = ObterIdSelecionado(2); // Obtém a série
            int parcela = ObterIdSelecionado(3); // Obtém o ID da parcela
            int Fornecedor = ObterIdSelecionado(4); // Obtém o ID do fornecedor
            string status = ObterNomeSelecionado(15); // Obtém a Situacao
            if (status != "CANCELADA")
            {
                ContasPagar conta = contasPagarController.BuscarContaPagar(Numero, Modelo, Serie, Fornecedor, parcela);
                if (conta != null)
                {
                    contasPagarController.Alterar(conta);
                    CarregaLV();
                }
            }
            else
            {
                MessageBox.Show(
                    "A operação não pode ser realizada porque a nota fiscal selecionada foi cancelada.",
                    "Ação não permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        protected override void Alterar()
        {
            int Numero = ObterIdSelecionado(0); // Obtém o número
            int Modelo = ObterIdSelecionado(1); // Obtém o modelo
            int Serie = ObterIdSelecionado(2); // Obtém a série
            int parcela = ObterIdSelecionado(3); // Obtém o ID da parcela
            int Fornecedor = ObterIdSelecionado(4); // Obtém o ID do fornecedor
            string status = ObterNomeSelecionado(15); // Obtém a Situacao
            if (status != "CANCELADA")
            {
                ContasPagar conta = contasPagarController.BuscarContaPagar(Numero, Modelo, Serie, Fornecedor, parcela);
                if (conta != null)
                {
                    contasPagarController.AlterarDados(conta);
                    CarregaLV();
                }
            }
            else
            {
                MessageBox.Show(
                    "A operação não pode ser realizada porque a nota fiscal selecionada foi cancelada.",
                    "Ação não permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
        protected virtual string ObterNomeSelecionado(int posicao)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                return listView1.SelectedItems[0].SubItems[posicao].Text;
            }

            return string.Empty; // Retorna uma string vazia como valor padrão caso não haja linha selecionada
        }

        public override void Visualizar()
        {
            if (btnSair.Text == "Selecionar")
            {
                btnSair.PerformClick();
            }
            else if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                ContasPagar conta = selectedItem.Tag as ContasPagar;
                if (conta != null)
                {
                    contasPagarController.Visualizar(conta);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            List<ContasPagar> dados = contasPagarController.ListarContasPagar(oStatus);
            PreencherListView(dados);
        }

        private void PreencherListView(IEnumerable<ContasPagar> dados)
        {
            listView1.Items.Clear();

            foreach (var conta in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(conta.NumNFC));
                item.SubItems.Add(conta.ModeloNFC.ToString());
                item.SubItems.Add(conta.SerieNFC.ToString());
                item.SubItems.Add(conta.NumParcela.ToString());
                item.SubItems.Add(conta.Fornecedor.ID.ToString());
                item.SubItems.Add(conta.Fornecedor.NomeFantasia);
                item.SubItems.Add(conta.FormaPagamento.Forma);
                item.SubItems.Add(conta.DataCriacao.ToString());
                item.SubItems.Add(conta.DataVencimento.ToString());
                item.SubItems.Add(conta.Valor.ToString());
                item.SubItems.Add(conta.DataBaixa.ToString());
                item.SubItems.Add(conta.Pagamento.ToString());
                item.SubItems.Add(conta.Taxa.ToString());
                item.SubItems.Add(conta.Multa.ToString());
                item.SubItems.Add(conta.Desconto.ToString());
                item.SubItems.Add(conta.Situacao.ToString());
                item.Tag = conta;
                listView1.Items.Add(item);
            }
        }

        private int ObterIdSelecionado(int posicao)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                return int.Parse(listView1.SelectedItems[0].SubItems[posicao].Text);
            }
            return 0;
        }

        protected override void Pesquisar()
        {
            List<ContasPagar> dados = contasPagarController.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(dados);
        }

        private void rbPago_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtons();
        }
        protected override void RadioButtons()
        {
            if (rbAtivos.Checked)
                oStatus = "A"; // A PAGAR
            else if (rbInativos.Checked)
                oStatus = "I"; // CANCELADAS
            else if (rbPago.Checked)
                oStatus = "P"; // PAGO
            else if (rbTodos.Checked)
                oStatus = "T"; // TODOS

        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtons();
        }

        private void rbPago_CheckedChanged_1(object sender, EventArgs e)
        {
            RadioButtons();
        }

        private void rbAtivos_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtons();
        }

        private void rbInativos_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtons();
        }
    }
}
