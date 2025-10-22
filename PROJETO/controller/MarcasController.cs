using PROJETO.dao;
using PROJETO.models;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;


namespace PROJETO.controller
{
    public class MarcaController
    {
        private MarcasDAO marcaDAO = new MarcasDAO();

        public string AdicionarMarca(Marca marca)
        {
            try
            {
                marca.DataCriacao = DateTime.Now;
                marca.DataUltAlteracao = DateTime.Now;
                marcaDAO.AdicionarMarca(marca);
                return "Marca adicionada com sucesso.";
            }
            catch (Exception ex)
            {
                return "Erro ao adicionar marca: " + ex.Message;
            }
        }

        public string AtualizarMarca(Marca marca)
        {
            try
            {
                marca.DataUltAlteracao = DateTime.Now;
                marcaDAO.AtualizarMarca(marca);
                return "Marca atualizada com sucesso.";
            }
            catch (Exception ex)
            {
                return "Erro ao atualizar marca: " + ex.Message;
            }
        }

        public bool ExcluirMarca(int marcaId)
        {
            try
            {
                return marcaDAO.ExcluirMarca(marcaId);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Marca BuscarMarcaPorId(int id)
        {
            try
            {
                return marcaDAO.BuscarMarcaPorId(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Marca> ListarMarcas()
        {
            try
            {
                return marcaDAO.ListarMarcas();
            }
            catch (Exception)
            {
                return new List<Marca>();
            }
        }

        public List<Marca> Pesquisar(string filtro, string status)
        {
            return marcaDAO.Pesquisar(filtro, status);
        }
        public void Incluir()
        {
            MarcasFrmCadastro frm = new MarcasFrmCadastro();
            frm.Text = "Incluir Marca";
            frm.ShowDialog();
        }

        public void Alterar(Marca marca)
        {
            if (marca != null)
            {
               MarcasFrmCadastro frm = new MarcasFrmCadastro();
                frm.ConhecaObj(marca);
                frm.Text = "Alterar Marca";
                frm.btnSalvar.Text = "Alterar";
                frm.CarregarCampos();
                frm.ShowDialog();
            }
        }

        public void Excluir(Marca marca)
        {
            if (marca != null)
            {
                MarcasFrmCadastro frm = new MarcasFrmCadastro();
                frm.ConhecaObj(marca);
                frm.Text = "Excluir Marca";
                frm.btnSalvar.Text = "Excluir";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }

        public void Visualizar(Marca marca)
        {
            if (marca != null)
            {
                MarcasFrmCadastro frm = new MarcasFrmCadastro();
                frm.ConhecaObj(marca);
                frm.Text = "Consultar Marca";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.ShowDialog();
            }
        }
    }
}


