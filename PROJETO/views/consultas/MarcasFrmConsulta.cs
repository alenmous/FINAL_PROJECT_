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

namespace PROJETO.views.consultas
{
    public partial class MarcasFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        MarcasFrmCadastro marcasFrmCadastro;
        Marca aMarca;
        MarcaController marcasController;

        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }


        public MarcasFrmConsulta()
        {
            InitializeComponent();
            Operacao.DisableCopyPaste(this);
            marcasController = new MarcaController();
        }
        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                marcasFrmCadastro = (MarcasFrmCadastro)obj;
            }
        }

        public override void ConhecaObj(object obj)
        {
            aMarca = (Marca)obj;
        }
        protected override void Incluir()
        {
            base.Incluir();
            marcasController.Incluir();
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idMarca = ObterIdSelecionado();
            if (idMarca > 0)
            {
                Marca marca = marcasController.BuscarMarcaPorId(idMarca);
                if (marca != null)
                {
                    marcasController.Alterar(marca);
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idMarca = ObterIdSelecionado();
            if (idMarca > 0)
            {
                Marca marca = marcasController.BuscarMarcaPorId(idMarca);
                if (marca != null)
                {
                    marcasController.Excluir(marca);
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
                Marca marca = selectedItem.Tag as Marca;
                if (marca != null)
                {
                    marcasController.Visualizar(marca);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            List<Marca> dados = marcasController.ListarMarcas();
            PreencherListView(dados);
        }

        private void PreencherListView(IEnumerable<Marca> dados)
        {
            listView1.Items.Clear();

            foreach (var marca in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(marca.ID));
                item.SubItems.Add(marca.Nome);
                item.SubItems.Add(marca.Descricao);
                item.SubItems.Add(marca.DataCriacao.ToString());
                item.SubItems.Add(marca.DataUltimaAlteracao.ToString());
                item.Tag = marca;
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
            var resultados = marcasController.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(resultados);
        }

    }
}
