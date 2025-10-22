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

namespace PROJETO.views.consultas
{
    public partial class PaisesFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        PaisesController paisesController;
        PaisesFrmCadastro paisesFrmCadastro;
        Paises oPais;
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }

        public PaisesFrmConsulta()
        {
            InitializeComponent();
            paisesController = new PaisesController();
        }

        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                paisesFrmCadastro = (PaisesFrmCadastro)obj;
            }
        }

        public override void ConhecaObj(object obj)
        {
            oPais = (Paises)obj;
        }

        protected override void Incluir()
        {
            base.Incluir();
            paisesController.Incluir(); // Alteração de aCTLprodutoss para aCTLProdutos
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idPais = ObterIdSelecionado(); // Alteração de idprodutos para idProduto
            if (idPais > 0)
            {
                Paises pais = paisesController.BuscarPaisPorId(idPais); // Alteração de produtos para Produto, aCTLprodutoss para aCTLProdutos
                if (pais != null)
                {
                    paisesController.Alterar(pais); // Alteração de produtos para Produto, aCTLprodutoss para aCTLProdutos
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idPais = ObterIdSelecionado(); // Alteração de idprodutos para idProduto
            if (idPais > 0)
            {
                Paises pais = paisesController.BuscarPaisPorId(idPais); // Alteração de produtos para Produto, aCTLprodutoss para aCTLProdutos
                if (pais != null)
                {
                    paisesController.Excluir(pais); // Alteração de produtos para Produto, aCTLprodutoss para aCTLProdutos
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
                Paises pais = selectedItem.Tag as Paises; 
                if (pais != null)
                {
                    paisesController.Visualizar(pais); 
                    CarregaLV();
                }
            }
        }
        public override void CarregaLV()
        {
            base.CarregaLV();
            List<Paises> dados = paisesController.ListarPaises(oStatus);
            PreencherListView(dados);
        }
        private void PreencherListView(IEnumerable<Paises> dados)
        {
            listView1.Items.Clear();

            foreach (var pais in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(pais.ID));
                item.SubItems.Add(pais.Pais);
                item.SubItems.Add(pais.Sigla);
                item.SubItems.Add(pais.Ddi);
                item.SubItems.Add(pais.DataCriacao.ToString());
                item.SubItems.Add(pais.DataUltimaAlteracao.ToString());
                item.SubItems.Add(pais.StatusPais == "I" ? "Inativo" : pais.StatusPais == "A" ? "Ativo" : pais.StatusPais);
                item.Tag = pais;
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


        protected override void Pesquisar()
        {
            List<Paises> dados = paisesController.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(dados);
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
    }
}
