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
    public partial class CidadesFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        CidadesController cidadesController;
        CidadesFrmCadastro cidadesFrmCadastro;
        Cidades aCidade;
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }

        public CidadesFrmConsulta()
        {
            InitializeComponent();
            cidadesController = new CidadesController();
        }

        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                cidadesFrmCadastro = (CidadesFrmCadastro)obj;
            }
        }

        public override void ConhecaObj(object obj)
        {
            aCidade = (Cidades)obj;
        }

        protected override void Incluir()
        {
            base.Incluir();
            cidadesController.Incluir();
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idCidade = ObterIdSelecionado();
            if (idCidade > 0)
            {
                Cidades cidade = cidadesController.BuscarCidadePorId(idCidade);
                if (cidade != null)
                {
                    cidadesController.Alterar(cidade);
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idCidade = ObterIdSelecionado();
            if (idCidade > 0)
            {
                Cidades cidade = cidadesController.BuscarCidadePorId(idCidade);
                if (cidade != null)
                {
                    cidadesController.Excluir(cidade);
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
                Cidades cidade = selectedItem.Tag as Cidades;
                if (cidade != null)
                {
                    cidadesController.Visualizar(cidade);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            List<Cidades> dados = cidadesController.ListarCidades(oStatus);
            PreencherListView(dados);
        }

        private void PreencherListView(IEnumerable<Cidades> dados)
        {
            listView1.Items.Clear();

            foreach (var cidade in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(cidade.ID));
                item.SubItems.Add(cidade.Cidade);
                item.SubItems.Add(cidade.DDD);
                item.SubItems.Add(cidade.OEstado.Estado); // Verificar se isso é o que realmente deseja mostrar
                item.SubItems.Add(cidade.DataCriacao.ToString());
                item.SubItems.Add(cidade.DataUltimaAlteracao.ToString());
                item.SubItems.Add(cidade.StatusCidade == "I" ? "Inativo" : cidade.StatusCidade == "A" ? "Ativo" : cidade.StatusCidade);
                item.Tag = cidade;
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
            var resultados = cidadesController.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(resultados);        
        }
    }
}
