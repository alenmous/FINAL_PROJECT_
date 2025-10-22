using PROJETO.controller;
using PROJETO.models;
using PROJETO.models.bases;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETO.views.consultas
{
    public partial class CategoriasFrmConsulta : consultaFrm
    {
        CategoriasFrmCadastro frmCadastro;
        CategoriasController categoriasController;
        Categoria aCategoria;
        public int IdSelecionado { get; private set; }
        public string NomeSelecionado { get; private set; }

        public CategoriasFrmConsulta()
        {
            InitializeComponent();
            Operacao.DisableCopyPaste(this);
            categoriasController = new CategoriasController();
        }
        public override void SetFrmCadastro(object obj)
        {
            if (obj is CategoriasFrmCadastro)
            {
                frmCadastro = (CategoriasFrmCadastro)obj;
            }
        }

        public override void ConhecaObj(object obj)
        {
            base.ConhecaObj(obj);

            if (obj is Categoria) // Alteração de Categorias para Categoria
            {
                aCategoria = (Categoria)obj; // Alteração de Categorias para Categoria
            }
        }

        protected override void Incluir()
        {
            base.Incluir();
            categoriasController.Incluir(); // Alteração de categoriasControllers para categoriasController
            CarregaLV();
        }

        protected override void Alterar()
        {
            base.Alterar();
            int idCategoria = ObterIdSelecionado(); // Alteração de idCategorias para idCategoria
            if (idCategoria > 0)
            {
                Categoria Categoria = categoriasController.BuscarCategoriaPorId(idCategoria); // Alteração de Categorias para Categoria, categoriasControllers para categoriasController
                if (Categoria != null)
                {
                    categoriasController.Alterar(Categoria); // Alteração de Categorias para Categoria, categoriasControllers para categoriasController
                    CarregaLV();
                }
            }
        }

        protected override void Excluir()
        {
            base.Excluir();
            int idCategoria = ObterIdSelecionado(); // Alteração de idCategorias para idCategoria
            if (idCategoria > 0)
            {
                Categoria Categoria = categoriasController.BuscarCategoriaPorId(idCategoria); // Alteração de Categorias para Categoria, categoriasControllers para categoriasController
                if (Categoria != null)
                {
                    categoriasController.Excluir(Categoria); // Alteração de Categorias para Categoria, categoriasControllers para categoriasController
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
                Categoria Categoria = selectedItem.Tag as Categoria; // Alteração de Categorias para Categoria

                if (Categoria != null)
                {
                    categoriasController.Visualizar(Categoria); // Alteração de Categorias para Categoria, categoriasControllers para categoriasController
                }
            }
        }
        private void PreencherFichasListView(IEnumerable<Categoria> Categorias) // Alteração de Categorias para Categoria
        {
            listView1.Items.Clear();

            foreach (var Categoria in Categorias) // Alteração de Categorias para Categoria
            {
                ListViewItem item = new ListViewItem(Convert.ToString(Categoria.ID)); // Alteração de Categorias para Categoria
                item.SubItems.Add(Categoria.Nome); // Alteração de Categorias para Categoria
                item.Tag = Categoria; // Alteração de Categorias para Categoria
                listView1.Items.Add(item);
            }
        }
        public override void CarregaLV()
        {
            base.CarregaLV();
            List<Categoria> Categorias = categoriasController.ListarCategoria(); // Alteração de Categorias para Categoria, categoriasControllers para categoriasController
            PreencherFichasListView(Categorias); // Alteração de Categorias para Categoria
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
            var resultados = categoriasController.Pesquisar(txtPesquisar.Text);
            PreencherFichasListView(resultados); 
        }

    }
}
