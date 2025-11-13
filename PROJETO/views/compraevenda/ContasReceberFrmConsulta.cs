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
            listView1.Columns[0].Text = "Numero";

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
            foreach (var conta in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(conta.NumNFC));
                item.SubItems.Add(conta.ModeloNFC.ToString());
                item.SubItems.Add(conta.SerieNFC.ToString());
                item.SubItems.Add(conta.NumParcela.ToString());
                item.SubItems.Add(conta.Cliente.ID.ToString());
                item.SubItems.Add(conta.Cliente.Nome);
                item.SubItems.Add(conta.FormaPagamento.Forma);

                // --- MUDANÇA 1: Emissão e Vencimento (Apenas Data) ---
                // O formato "dd/MM/yyyy" remove a hora.
                item.SubItems.Add(conta.DataCriacao.ToString("dd/MM/yyyy"));
                item.SubItems.Add(conta.DataVencimento.ToString("dd/MM/yyyy"));

                // Formatação de valores (Mantendo o 0.00 como no ajuste anterior)
                item.SubItems.Add(conta.Valor.ToString("0.00"));

                // --- MUDANÇA 2: Data da Baixa (Data e Hora SE PAGO, N/A se não pago) ---
                // Se Pagamento for nulo (decimal?) ou 0, exibe "N/A".
                // Caso contrário, exibe a data e hora completa.
                string dataBaixaFormatada = (conta.Pagamento == null || conta.Pagamento == 0)
                                            ? "N/A"
                                            : conta.DataBaixa.ToString("dd/MM/yyyy HH:mm:ss");
                item.SubItems.Add(dataBaixaFormatada);

                // Adiciona o valor do Pagamento
                // ATENÇÃO: Se conta.Pagamento for 'decimal' (não-nulo), remova GetValueOrDefault(0).
                item.SubItems.Add(conta.Pagamento.ToString("0.00"));

                // Demais campos formatados
                item.SubItems.Add(conta.Taxa.ToString("0.00"));
                item.SubItems.Add(conta.Multa.ToString("0.00"));
                item.SubItems.Add(conta.Desconto.ToString("0.00"));

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
