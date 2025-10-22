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
    public partial class VendaFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        VendaFrmCadastro vendaFrmCadastro;
        VendasController vendasController;
        Venda aVenda;
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }
        public VendaFrmConsulta()
        {
            InitializeComponent();
            vendasController = new VendasController();
            Operacao.DisableCopyPaste(this);

        }
        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                vendaFrmCadastro = (VendaFrmCadastro)obj;
            }
        }
        public override void ConhecaObj(object obj)
        {
            aVenda = (Venda)obj;
        }
        protected override void Incluir()
        {
            base.Incluir();
            vendasController.Incluir();
            CarregaLV();
        }
        protected override void Excluir()
        {
            int Numero = ObterIdSelecionado(0); // Obtém o número
            int Modelo = ObterIdSelecionado(1); // Obtém o modelo
            int Serie = ObterIdSelecionado(2); // Obtém a série
            int Cliente = ObterIdSelecionado(3); // Obtém o ID do cliente

            // Verifica se o ID do cliente é maior que 0
            if (Cliente > 0)
            {
                // Busca a venda com base nos IDs obtidos
                Venda venda = vendasController.BuscarVendaPorChave(Numero, Modelo, Serie, Cliente);

                // Verifica se a venda foi encontrada
                if (venda != null)
                {
                    // Cancela a nota da venda encontrada
                    vendasController.CancelarNota(venda);
                    CarregaLV();
                }
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
        public override void Visualizar()
        {
            if (btnSair.Text == "Selecionar")
            {
                btnSair.PerformClick();
            }
            else if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                Venda venda = selectedItem.Tag as Venda;
                if (venda != null)
                {
                    vendasController.Visualizar(venda);
                    CarregaLV();
                }
            }
        }
        public override void CarregaLV()
        {
            List<Venda> dados = vendasController.ListarVendas(oStatus);
            PreencherListView(dados);
        }
        private void PreencherListView(IEnumerable<Venda> dados)
        {
            listView1.Items.Clear();

            foreach (var venda in dados)
            {
                ListViewItem item = new ListViewItem(venda.NumNfv.ToString());
                item.SubItems.Add(venda.ModeloNfv.ToString());
                item.SubItems.Add(venda.SerieNfv.ToString());
                item.SubItems.Add(venda.Cliente.ID.ToString());
                item.SubItems.Add(venda.Cliente.Nome);
                item.SubItems.Add(venda.CondicaoPagamento.Condicao);
                item.SubItems.Add(venda.ValorTotal.ToString("C"));
                item.SubItems.Add(venda.ValorFrete.ToString("C"));
                item.SubItems.Add(venda.ValorSeguro.ToString("C"));
                item.SubItems.Add(venda.ValorOutrasDespesas.ToString("C"));
                item.SubItems.Add(venda.DataSaida.ToString());
                item.SubItems.Add(venda.DataEmissao.ToString());
                item.SubItems.Add(venda.DataCancelamento == DateTime.MinValue ? "Não Cancelada" : venda.DataCancelamento.ToString()); // Verifica se a data de cancelamento é MinValue
                item.SubItems.Add(venda.DataCriacao.ToString());

                item.Tag = venda;
                listView1.Items.Add(item);
            }
        }
        protected override void Sair()
        {
            if (btnSair.Text == "Sair")
            {
                base.Sair();
            }
            else if (btnSair.Text == "Selecionar")
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    IdSelecionado = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                    NomeSelecionado = listView1.SelectedItems[0].SubItems[1].Text;
                }
                this.Close();
            }
        }
        protected override void RadioButtons()
        {
            if (rbAtivos.Checked)
            {
                btnExcluir.Enabled = true;
                oStatus = "A";
            }
                
            else if (rbInativos.Checked)
            {
                oStatus = "I";
                btnExcluir.Enabled = false;
            }
               
        }
    }
}
