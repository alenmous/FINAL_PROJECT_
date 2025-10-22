using PROJETO.controller.compraevenda;
using PROJETO.models.bases;
using PROJETO.models.compraevenda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJETO.views.compraevenda
{
    public partial class ContasReceberFrmConsulta : PROJETO.views.compraevenda.ContasPagarFrmConsulta
    {
        ContasReceberFrmCadastro contasReceberFrmCadastro;
        ContasReceber aContaReceber;
        ContasReceberController contasReceberController;
        public ContasReceberFrmConsulta()
        {
            InitializeComponent();
            contasReceberController = new ContasReceberController();
            Operacao.DisableCopyPaste(this);
        }
        public override void ConhecaObj(object obj)
        {
            aContaReceber = (ContasReceber)obj;
        }
        protected override void Incluir()
        {
            int Numero = ObterIdSelecionado(0); // Obtém o número
            int Modelo = ObterIdSelecionado(1); // Obtém o modelo
            int Serie = ObterIdSelecionado(2); // Obtém a série
            int parcela = ObterIdSelecionado(3); // Obtém o ID da parcela
            string status = ObterNomeSelecionado(15); // Obtém a Situacao
            if (status != "CANCELADA")
            {
                ContasReceber conta = contasReceberController.BuscarContasReceber(Numero, Modelo, Serie, parcela);
                if (conta != null)
                {
                    contasReceberController.Alterar(conta);
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
            string status = ObterNomeSelecionado(15); // Obtém a Situacao
            if (status != "CANCELADA")
            {
                ContasReceber conta = contasReceberController.BuscarContasReceber(Numero, Modelo, Serie, parcela);
                if (conta != null)
                {
                    contasReceberController.AlterarDados(conta);
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
        protected override string ObterNomeSelecionado(int posicao)
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
                ContasReceber conta = selectedItem.Tag as ContasReceber;
                if (conta != null)
                {
                    contasReceberController.Visualizar(conta);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            List<ContasReceber> dados = contasReceberController.ListarContasReceber(oStatus);
            PreencherListView(dados);
        }

        private void PreencherListView(IEnumerable<ContasReceber> dados)
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();

            listView1.Columns.Add("Número");
            listView1.Columns.Add("Modelo");
            listView1.Columns.Add("Série");
            listView1.Columns.Add("Parcela");
            listView1.Columns.Add("ID Cliente");
            listView1.Columns.Add("Nome Cliente");
            listView1.Columns.Add("Forma de Pagamento");
            listView1.Columns.Add("Data de Criação");
            listView1.Columns.Add("Data de Vencimento");
            listView1.Columns.Add("Valor");
            listView1.Columns.Add("Data de Baixa");
            listView1.Columns.Add("Pagamento");
            listView1.Columns.Add("Taxa");
            listView1.Columns.Add("Multa");
            listView1.Columns.Add("Desconto");
            listView1.Columns.Add("Situação");

            foreach (var conta in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(conta.NumNFC));
                item.SubItems.Add(conta.ModeloNFC.ToString());
                item.SubItems.Add(conta.SerieNFC.ToString());
                item.SubItems.Add(conta.NumParcela.ToString());
                item.SubItems.Add(conta.Cliente.ID.ToString());
                item.SubItems.Add(conta.Cliente.Nome);
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
            //  List<ContasReceber> dados = contasReceberController.Pesquisar(txtPesquisar.Text, oStatus);
            //   PreencherListView(dados);
        }

        private void rbAtivos_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtons();
        }

        private void rbPago_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtons();
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtons();
        }

        private void rbInativos_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtons();
        }
    }
}
