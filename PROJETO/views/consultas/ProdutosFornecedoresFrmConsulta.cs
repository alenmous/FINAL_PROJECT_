using PROJETO.controller;
using PROJETO.models;
using PROJETO.Models;
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
    public partial class ProdutosFornecedoresFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        ProdutoFornecedorController produtoFornecedorController;
        ProdutosFornecedoresFrmCadastro prodForneFrmCadastro;
        ProdutosFornecedor oProdutoForn;

        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }
        public string ValorVenda { get; private set; }
        public string Und { get; private set; }
        public string fornecedor_selecionado = "";
        public ProdutosFornecedoresFrmConsulta()
        {
            InitializeComponent();
            produtoFornecedorController = new ProdutoFornecedorController();
        }

        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                prodForneFrmCadastro = (ProdutosFornecedoresFrmCadastro)obj;
            }
        }

        public override void ConhecaObj(object obj)
        {
            oProdutoForn = (ProdutosFornecedor)obj;
        }

        protected override void Incluir()
        {
            base.Incluir();
            produtoFornecedorController.Incluir();
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idProdutoFornecedor = ObterIdSelecionado();
            if (idProdutoFornecedor > 0)
            {
                ProdutosFornecedor produtoFornecedor = produtoFornecedorController.BuscarProdutoFornecedorPorId(idProdutoFornecedor);
                if (produtoFornecedor != null)
                {
                    produtoFornecedorController.Alterar(produtoFornecedor);
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idProdutoFornecedor = ObterIdSelecionado();
            if (idProdutoFornecedor > 0)
            {
                ProdutosFornecedor produtoFornecedor = produtoFornecedorController.BuscarProdutoFornecedorPorId(idProdutoFornecedor);
                if (produtoFornecedor != null)
                {
                    produtoFornecedorController.Excluir(produtoFornecedor);
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
                ProdutosFornecedor produtoFornecedor = selectedItem.Tag as ProdutosFornecedor;
                if (produtoFornecedor != null)
                {
                    produtoFornecedorController.Visualizar(produtoFornecedor);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
           
            if(fornecedor_selecionado != "")
            {
                List<ProdutosFornecedor> dados = produtoFornecedorController.ListarProdutosFornecedoresPorFornecedor(oStatus,fornecedor_selecionado);
                PreencherListView(dados);
            }
            else
            {
                List<ProdutosFornecedor> dados = produtoFornecedorController.ListarProdutosFornecedores(oStatus);
                PreencherListView(dados);
            }

        }

        private void PreencherListView(IEnumerable<ProdutosFornecedor> dados)
        {
            listView1.Items.Clear();

            foreach (var produtoFornecedor in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(produtoFornecedor.ID));
                item.SubItems.Add(produtoFornecedor.oProduto.Nome);
                item.SubItems.Add(produtoFornecedor.oFornecedor.NomeFantasia);
                item.SubItems.Add(produtoFornecedor.DataCriacao.ToString());
                item.SubItems.Add(produtoFornecedor.DataUltimaAlteracao.ToString());
                item.SubItems.Add(produtoFornecedor.Status == "I" ? "Inativo" : produtoFornecedor.Status == "A" ? "Ativo" : produtoFornecedor.Status);
                item.SubItems.Add(produtoFornecedor.oProduto.UnidadeMedida.ToString());
                item.SubItems.Add(produtoFornecedor.oProduto.PrecoVenda.ToString());
                item.Tag = produtoFornecedor;
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
                    Und = listView1.SelectedItems[0].SubItems[6].Text;
                    ValorVenda = listView1.SelectedItems[0].SubItems[7].Text;
                }
                this.Close();
            }
        }

        protected override void Pesquisar()
        {
            if (fornecedor_selecionado != "")
            {
                var resultados = produtoFornecedorController.PesquisarPorFornecedor(txtPesquisar.Text, oStatus,fornecedor_selecionado);
                PreencherListView(resultados);
            }
            else
            {
                var resultados = produtoFornecedorController.Pesquisar(txtPesquisar.Text, oStatus);
                PreencherListView(resultados);
            }
        }
    }
}
