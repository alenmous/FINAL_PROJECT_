using PROJETO.controller;
using PROJETO.models;
using PROJETO.models.bases;
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
    public partial class ProdutosFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        ProdutosFrmCadastro frmcadProduto;
        Produto oProduto;
        ProdutosController aCTLProduto; // Alteração de CTLProduto para CTLProduto
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }
        public string ValorVenda { get; private set; }
        public string Und { get; private set; }
        public ProdutosFrmConsulta()
        {
            InitializeComponent();
            Operacao.DisableCopyPaste(this);
            aCTLProduto = new ProdutosController();
        }
        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                frmcadProduto = (ProdutosFrmCadastro)obj;
            }
        }
        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);

            if (obj is Produto)
            {
                oProduto = (Produto)obj;
            }
        }
        protected override void Incluir()
        {
            base.Incluir();
            aCTLProduto.Incluir(); // Alteração de CTLProduto para CTLProduto
            CarregaLV();
        }
        protected override void Alterar()
        {
            base.Alterar();
            int idProduto = ObterIdSelecionado(); // Alteração de idProduto para idProduto
            if (idProduto > 0)
            {
                Produto Produto = aCTLProduto.BuscarProdutoPorId(idProduto); // Alteração de Produto para Produto, CTLProduto para CTLProduto
                if (Produto != null)
                {
                    aCTLProduto.Alterar(Produto); // Alteração de Produto para Produto, CTLProduto para CTLProduto
                    CarregaLV();
                }
            }
        }
        protected override void Excluir()
        {
            base.Excluir();
            int idProduto = ObterIdSelecionado(); // Alteração de idProduto para idProduto
            if (idProduto > 0)
            {
                Produto Produto = aCTLProduto.BuscarProdutoPorId(idProduto); // Alteração de Produto para Produto, CTLProduto para CTLProduto
                if (Produto != null)
                {
                    aCTLProduto.Excluir(Produto); // Alteração de Produto para Produto, CTLProduto para CTLProduto
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
                Produto Produto = selectedItem.Tag as Produto; // Alteração de Produto para Produto

                if (Produto != null)
                {
                    aCTLProduto.Visualizar(Produto); // Alteração de Produto para Produto, CTLProduto para CTLProduto
                }
            }
        }
        private void PreencherListView(IEnumerable<Produto> Produtos) // Alteração de IEnumerable<Produto> para IEnumerable<Produto>
        {
            listView1.Items.Clear();

            foreach (var Produto in Produtos) // Alteração de var Produto em Produtos para var Produto em Produtos
            {
                ListViewItem item = new ListViewItem(Convert.ToString(Produto.ID));
                item.SubItems.Add(Produto.Categoria.Nome);
                item.SubItems.Add(Produto.Nome);
                item.SubItems.Add(Produto.DescricaoProduto);
                item.SubItems.Add(Produto.Marca.Nome);
                item.SubItems.Add(Produto.PrecoCusto.ToString("C"));
                item.SubItems.Add(Produto.PrecoVenda.ToString("C"));
                item.SubItems.Add(Produto.UnidadeMedida);
                item.SubItems.Add(Produto.QtdEstoque.ToString());
                item.SubItems.Add(Produto.DataCriacao.ToString());
                item.SubItems.Add(Produto.DataUltimaAlteracao.ToString());
                item.SubItems.Add(Produto.Status == "I" ? "Inativo" : Produto.Status == "A" ? "Ativo" : Produto.Status);
                item.SubItems.Add(Produto.Referencia);
                item.Tag = Produto;
                listView1.Items.Add(item);
            }
        }
        public override void CarregaLV()
        {

            base.CarregaLV();
            List<Produto> Produtos = aCTLProduto.ListarProdutos(oStatus); // Alteração de List<Produto> para List<Produto>, CTLProduto para CTLProduto
            PreencherListView(Produtos); // Alteração de IEnumerable<Produto> para IEnumerable<Produto>

        }
        protected override void Pesquisar()
        {
            var resultados = aCTLProduto.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(resultados);
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
                    Und = listView1.SelectedItems[0].SubItems[8].Text;
                    ValorVenda = listView1.SelectedItems[0].SubItems[6].Text;
                }
                this.Close();
            }
        }


    }
}
