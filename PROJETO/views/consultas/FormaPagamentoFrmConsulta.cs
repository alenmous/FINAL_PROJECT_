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
    public partial class FormaPagamentoFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        FormaPagamentoFrmCadastro formaPagamentoFrmCadastro;
        FormaPagamento aForma;
        FormaPagamentoController formaPagamentoController;
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }

        public FormaPagamentoFrmConsulta()
        {
            InitializeComponent();
            formaPagamentoController = new FormaPagamentoController();
        }
        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                formaPagamentoFrmCadastro = (FormaPagamentoFrmCadastro)obj;
            }
        }
        public override void ConhecaObj(object obj)
        {
            aForma = (FormaPagamento)obj;
        }
        protected override void Incluir()
        {
            base.Incluir();
            formaPagamentoController.Incluir();
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idforma = ObterIdSelecionado();
            if (idforma > 0)
            {
                FormaPagamento forma = formaPagamentoController.BuscarFormaPagamentoPorId(idforma);
                if (forma != null)
                {
                    formaPagamentoController.Alterar(forma);
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idforma = ObterIdSelecionado();
            if (idforma > 0)
            {
                FormaPagamento forma = formaPagamentoController.BuscarFormaPagamentoPorId(idforma);
                if (forma != null)
                {
                    formaPagamentoController.Excluir(forma);
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
                FormaPagamento forma = selectedItem.Tag as FormaPagamento;
                if (forma != null)
                {
                    formaPagamentoController.Visualizar(forma);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            List<FormaPagamento> dados = formaPagamentoController.ListarFormasPagamento(oStatus);
            PreencherListView(dados);
        }
        private void PreencherListView(IEnumerable<FormaPagamento> dados)
        {
            listView1.Items.Clear();

            foreach (var forma in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(forma.ID));
                item.SubItems.Add(forma.Forma);
                item.SubItems.Add(forma.DataCriacao.ToString());
                item.SubItems.Add(forma.DataUltimaAlteracao.ToString());
                item.SubItems.Add(forma.StatusForma == "I" ? "Inativo" : forma.StatusForma == "A" ? "Ativo" : forma.StatusForma);
                item.Tag = forma;
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
            var resultados = formaPagamentoController.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(resultados);
        }

    }
}
