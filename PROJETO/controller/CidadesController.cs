using PROJETO.dao;
using PROJETO.models;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.controller
{
    internal class CidadesController
    {

        private CidadesDAO cidadesDAO = new CidadesDAO();

        public string AdicionarCidade(Cidades cidade)
        {
            return cidadesDAO.AdicionarCidade(cidade);
        }

        public string AtualizarCidade(Cidades cidade)
        {
            return cidadesDAO.AtualizarCidade(cidade);
        }

        public bool ExcluirCidade(int cidadeId)
        {
            return cidadesDAO.ExcluirCidade(cidadeId);
        }

        public Cidades BuscarCidadePorId(int id)
        {
            return cidadesDAO.BuscarCidadePorId(id);
        }

        public List<Cidades> ListarCidades(string status)
        {
            return cidadesDAO.ListarCidades(status);
        }

        public List<Cidades> Pesquisar(string filtro, string status)
        {
            return cidadesDAO.Pesquisar(filtro, status);
        }

        public Cidades Carregar(int Id)
        {
            Cidades Cidade = cidadesDAO.BuscarCidadePorId(Id);
            return Cidade;
        }

        public void Incluir()
        {
            CidadesFrmCadastro frm = new CidadesFrmCadastro();
            frm.Text = "Incluir Cidade";
            frm.cmbStatus.Text = "ATIVO";
            frm.cmbStatus.Enabled = false;
            frm.ShowDialog();
        }
        public void Alterar(Cidades cidade)
        {
            if (cidade != null)
            {
                CidadesFrmCadastro frm = new CidadesFrmCadastro();
                frm.ConhecaObj(cidade);
                frm.Text = "Alterar Cidade";
                frm.CarregarCampos();
                frm.ShowDialog();
            }
        }

        public void Excluir(Cidades cidade)
        {
            if (cidade != null)
            {
                CidadesFrmCadastro frm = new CidadesFrmCadastro();
                frm.ConhecaObj(cidade);
                frm.Text = "Excluir Cidade";
                frm.btnSalvar.Text = "Excluir";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }

        public void Visualizar(Cidades cidade)
        {
            if (cidade != null)
            {
                CidadesFrmCadastro frm = new CidadesFrmCadastro();
                frm.ConhecaObj(cidade);
                frm.Text = "Consultar Cidade";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.ShowDialog();
            }
        }

    }
}
