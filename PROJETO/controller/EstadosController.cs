using PROJETO.dao;
using PROJETO.models;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PROJETO.controller.EstadosController;

namespace PROJETO.controller
{
    public class EstadosController
    {
        private EstadosDAO estadosDAO = new EstadosDAO();

        public string AdicionarEstado(Estados estado)
        {
            return estadosDAO.AdicionarEstado(estado);
        }

        public string AtualizarEstado(Estados estado)
        {
            return estadosDAO.AtualizarEstado(estado);
        }

        public bool ExcluirEstado(int estadoId)
        {
            return estadosDAO.ExcluirEstado(estadoId);
        }

        public Estados BuscarEstadoPorId(int id)
        {
            return estadosDAO.BuscarEstadoPorId(id);
        }

        public List<Estados> ListarEstados(string status)
        {
            return estadosDAO.ListarEstados(status);
        }

        public List<Estados> Pesquisar(string filtro, string status)
        {
            return estadosDAO.Pesquisar(filtro, status);
        }


        public void Incluir()
        {
            EstadosFrmCadastro frm = new EstadosFrmCadastro();
            frm.Text = "Incluir Estado";
            frm.cmbStatus.Text = "ATIVO";
            frm.cmbStatus.Enabled = false;
            frm.ShowDialog();
        }
        public void Alterar(Estados estado)
        {
            if (estado != null)
            {
                EstadosFrmCadastro frm = new EstadosFrmCadastro();
                frm.ConhecaObj(estado);
                frm.Text = "Alterar Estado";
                frm.CarregarCampos();
                frm.ShowDialog();
            }
        }

        public void Excluir(Estados estado)
        {
            if (estado != null)
            {
                EstadosFrmCadastro frm = new EstadosFrmCadastro();
                frm.ConhecaObj(estado);
                frm.Text = "Excluir Estado";
                frm.btnSalvar.Text = "Excluir";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }

        public void Visualizar(Estados estado)
        {
            if (estado != null)
            {
                EstadosFrmCadastro frm = new EstadosFrmCadastro();
                frm.ConhecaObj(estado);
                frm.Text = "Consultar Estado";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.ShowDialog();
            }
        }

    }
}