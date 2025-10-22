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
    public partial class EstadosFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        EstadosController estadosController;
        EstadosFrmCadastro estadosFrmCadastro;
        Estados oEstado;
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }

        public EstadosFrmConsulta()
        {
            InitializeComponent();
            estadosController = new EstadosController();
        }

        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                estadosFrmCadastro = (EstadosFrmCadastro)obj;
            }
        }
        protected override void Incluir()
        {
            base.Incluir();
            estadosController.Incluir();
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idEstado = ObterIdSelecionado();
            if (idEstado > 0)
            {
                Estados estado = estadosController.BuscarEstadoPorId(idEstado);
                if (estado != null)
                {
                    estadosController.Alterar(estado);
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idEstado = ObterIdSelecionado();
            if (idEstado > 0)
            {
                Estados estado = estadosController.BuscarEstadoPorId(idEstado);
                if (estado != null)
                {
                    estadosController.Excluir(estado);
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
                Estados estado = selectedItem.Tag as Estados;
                if (estado != null)
                {
                    estadosController.Visualizar(estado);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            List<Estados> dados = estadosController.ListarEstados(oStatus);
            PreencherListView(dados);
        }

        private void PreencherListView(IEnumerable<Estados> dados)
        {
            listView1.Items.Clear();

            foreach (var estado in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(estado.ID));
                item.SubItems.Add(estado.Estado);
                item.SubItems.Add(estado.UF);
                item.SubItems.Add(estado.OPais.Pais); // Verificar se isso é o que realmente deseja mostrar
                item.SubItems.Add(estado.DataCriacao.ToString());
                item.SubItems.Add(estado.DataUltimaAlteracao.ToString());
                item.SubItems.Add(estado.StatusEstado == "I" ? "Inativo" : estado.StatusEstado == "A" ? "Ativo" : estado.StatusEstado);
                item.Tag = estado;
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

        public override void ConhecaObj(object obj)
        {
            oEstado = (Estados)obj;
        }
        protected override void Pesquisar()
        {
            List<Estados> dados = estadosController.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(dados);
        }
    }
}
