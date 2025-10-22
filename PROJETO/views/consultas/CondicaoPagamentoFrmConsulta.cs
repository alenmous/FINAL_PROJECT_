using PROJETO.controller;
using PROJETO.models;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJETO.views.consultas
{
    public partial class CondicaoPagamentoFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        CondicaoPagamentoFrmCadastro condicaoPagamentoFrmCadastro;
        CondicaoPagamento aCondicaoPG;
        CondicaoPagamentoController condicaoPagamentoControllerG;
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }
        public CondicaoPagamentoFrmConsulta()
        {
            InitializeComponent();
            condicaoPagamentoControllerG = new CondicaoPagamentoController();
        }
        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                condicaoPagamentoFrmCadastro = (CondicaoPagamentoFrmCadastro)obj;
            }
        }

        public override void ConhecaObj(object obj)
        {
            aCondicaoPG = (CondicaoPagamento)obj;
        }
        protected override void Incluir()
        {
            base.Incluir();
            condicaoPagamentoControllerG.Incluir();
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idCondicao = ObterIdSelecionado();
            if (idCondicao > 0)
            {
                CondicaoPagamento condicao = condicaoPagamentoControllerG.BuscarCondicaoPagamentoPorId(idCondicao);
                if (condicao != null)
                {
                    condicaoPagamentoControllerG.Alterar(condicao);
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idCondicao = ObterIdSelecionado();
            if (idCondicao > 0)
            {
                CondicaoPagamento condicao = condicaoPagamentoControllerG.BuscarCondicaoPagamentoPorId(idCondicao);
                if (condicao != null)
                {
                    condicaoPagamentoControllerG.Excluir(condicao);
                    CarregaLV();
                }
            }
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
                CondicaoPagamento condicao = selectedItem.Tag as CondicaoPagamento;
                if (condicao != null)
                {
                    condicaoPagamentoControllerG.Visualizar(condicao);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            List<CondicaoPagamento> dados = condicaoPagamentoControllerG.ListarCondicoesPagamento(oStatus);
            PreencherListView(dados);
        }
        private void PreencherListView(IEnumerable<CondicaoPagamento> dados)
        {
            listView1.Items.Clear();

            foreach (var Condicao in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(Condicao.ID));
                item.SubItems.Add(Condicao.Condicao);
                item.SubItems.Add(Condicao.Parcelas.ToString());
                item.SubItems.Add(Condicao.Taxa.ToString());
                item.SubItems.Add(Condicao.Multa.ToString());
                item.SubItems.Add(Condicao.Desconto.ToString());
                item.SubItems.Add(Condicao.DataCriacao.ToString());
                item.SubItems.Add(Condicao.DataUltimaAlteracao.ToString());
                item.SubItems.Add(Condicao.Status == "I" ? "Inativo" : Condicao.Status == "A" ? "Ativo" : Condicao.Status);
                item.Tag = Condicao;
                listView1.Items.Add(item);
            }
        }

        private int ObterIdSelecionado()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                return int.Parse(listView1.SelectedItems[0].Text);
            }
            return 0;
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
        protected override void Pesquisar()
        {
            var resultados = condicaoPagamentoControllerG.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(resultados);

        }
    }
}
