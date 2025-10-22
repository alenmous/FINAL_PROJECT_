
using PROJETO.data;
using PROJETO.models.bases;
using PROJETO.models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using System.Linq;
using PROJETO.dao;
using PROJETO.views.cadastros;

namespace PROJETO.controller
{

    public class CategoriasController
    {
        private CategoriasDAO categoriaDAO = new CategoriasDAO();

        public void AdicionarCategoria(Categoria Categoria)
        {
            categoriaDAO.AdicionarCategoria(Categoria);
        }

        public void AtualizarCategoria(Categoria Categoria)
        {
            categoriaDAO.AtualizarCategoria(Categoria);
        }

        public void ExcluirCategoria(int CategoriaId)
        {
            categoriaDAO.ExcluirCategoria(CategoriaId);
        }

        public Categoria BuscarCategoriaPorId(int id)
        {
            return categoriaDAO.BuscarCategoriaPorId(id);
        }
        public List<Categoria> ListarCategoria()
        {
            return categoriaDAO.ListarCategoria();
        }
        public List<Categoria> Pesquisar(string filtro)
        {
            return categoriaDAO.Pesquisar(filtro);
        }

        public void Incluir()
        {
            CategoriasFrmCadastro frmCadastroCategoria = new CategoriasFrmCadastro();
            frmCadastroCategoria.Text = "Incluir Categoria";
            frmCadastroCategoria.ShowDialog();
        }

        public void Alterar(Categoria Categoria)
        {
            if (Categoria != null)
            {
                CategoriasFrmCadastro frmCadastroCategoria = new CategoriasFrmCadastro();
                frmCadastroCategoria.ConhecaObj(Categoria);
                frmCadastroCategoria.Text = "Alterar Categoria";
                frmCadastroCategoria.btnSalvar.Text = "Alterar";
                frmCadastroCategoria.CarregarCampos();
                frmCadastroCategoria.ShowDialog();
            }
        }

        public void Excluir(Categoria Categoria)
        {
            if (Categoria != null)
            {
                CategoriasFrmCadastro frmCadastroCategoria = new CategoriasFrmCadastro();
                frmCadastroCategoria.ConhecaObj(Categoria);
                frmCadastroCategoria.CarregarCampos();
                frmCadastroCategoria.BloquearCampos();
                frmCadastroCategoria.btnSalvar.Text = "Excluir";
                frmCadastroCategoria.ShowDialog();
            }
        }

        public void Visualizar(Categoria Categoria)
        {
            if (Categoria != null)
            {
                CategoriasFrmCadastro frmCadastroCategoria = new CategoriasFrmCadastro();
                frmCadastroCategoria.ConhecaObj(Categoria);
                frmCadastroCategoria.CarregarCampos();
                frmCadastroCategoria.BloquearCampos();
                frmCadastroCategoria.btnSalvar.Enabled = false;
                frmCadastroCategoria.Text = "Consultar Categoria";
                frmCadastroCategoria.ShowDialog();
            }
        }

    }
}
