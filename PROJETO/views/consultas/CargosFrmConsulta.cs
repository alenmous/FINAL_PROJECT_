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
    public partial class CargosFrmConsulta : PROJETO.views.consultas.consultaFrm
    {
        CargosController cargosController;
        CargosFrmCadastro cargosFrmCadastro;
        Cargos oCargo;
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }

        public CargosFrmConsulta()
        {
            InitializeComponent();
            cargosController = new CargosController();
        }

        public override void SetFrmCadastro(object obj)
        {
            if (obj != null)
            {
                cargosFrmCadastro = (CargosFrmCadastro)obj;
            }
        }

        public override void ConhecaObj(object obj)
        {
            oCargo = (Cargos)obj;
        }
        protected override void Incluir()
        {
            base.Incluir();
            cargosController.Incluir();
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idCargo = ObterIdSelecionado();
            if (idCargo > 0)
            {
                Cargos cargo = cargosController.BuscarCargoPorId(idCargo);
                if (cargo != null)
                {
                    cargosController.Alterar(cargo);
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idCargo = ObterIdSelecionado();
            if (idCargo > 0)
            {
                Cargos cargo = cargosController.BuscarCargoPorId(idCargo);
                if (cargo != null)
                {
                    cargosController.Excluir(cargo);
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
                Cargos cargo = selectedItem.Tag as Cargos;
                if (cargo != null)
                {
                    cargosController.Visualizar(cargo);
                    CarregaLV();
                }
            }
        }

        public override void CarregaLV()
        {
            base.CarregaLV();
            List<Cargos> dados = cargosController.ListarCargos(oStatus);
            PreencherListView(dados);
        }
        private void PreencherListView(IEnumerable<Cargos> dados)
        {
            listView1.Items.Clear();

            foreach (var cargo in dados)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(cargo.ID));
                item.SubItems.Add(cargo.Cargo);
                item.SubItems.Add(cargo.DataCriacao.ToString());
                item.SubItems.Add(cargo.DataUltimaAlteracao.ToString());
                item.SubItems.Add(cargo.StatusCargo == "I" ? "Inativo" : cargo.StatusCargo == "A" ? "Ativo" : cargo.StatusCargo);
                item.Tag = cargo;
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
            var resultados = cargosController.Pesquisar(txtPesquisar.Text, oStatus);
            PreencherListView(resultados);

        }
    }
}
