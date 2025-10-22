using PROJETO.dao;
using PROJETO.models;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETO.controller
{
    public class PaisesController
    {

        private PaisesDAO paisesDAO = new PaisesDAO();

        public string AdicionarPais(Paises pais)
        {
            return paisesDAO.AdicionarPais(pais);
        }

        public string AtualizarPais(Paises pais)
        {
            if (pais.ID == 1)
            {
                var msg = "NOT";
                return msg;
            }
            return paisesDAO.AtualizarPais(pais);
        }

        public bool ExcluirPais(int paisId)
        {
            if (paisId == 1)
            {
                MessageBox.Show("Brasil não pode ser excluido!!");
                return false;
            }
            else
            {
                return paisesDAO.ExcluirPais(paisId);
            }
        }

        public Paises BuscarPaisPorId(int id)
        {
            return paisesDAO.BuscarPaisPorId(id);
        }

        public List<Paises> ListarPaises(string status)
        {
            return paisesDAO.ListarPaises(status);
        }

        public List<Paises> Pesquisar(string pesquisa, string status)
        {
            return paisesDAO.Pesquisar(pesquisa, status);
        }
        public void Incluir()
        {
            PaisesFrmCadastro frm = new PaisesFrmCadastro();
            frm.Text = "Incluir País";
            frm.cmbStatus.Text = "ATIVO";
            frm.cmbStatus.Enabled = false;
            frm.ShowDialog();
        }
        public void Alterar(Paises pais)
        {
            if (pais != null)
            {
                PaisesFrmCadastro frm = new PaisesFrmCadastro();
                frm.ConhecaObj(pais);
                frm.Text = "Alterar País";
                frm.CarregarCampos();
                frm.ShowDialog();
            }
        }
        public void Excluir(Paises pais)
        {
            if (pais != null)
            {
                PaisesFrmCadastro frm = new PaisesFrmCadastro();
                frm.ConhecaObj(pais);
                frm.Text = "Excluir País";
                frm.btnSalvar.Text = "Excluir";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }
        public void Visualizar(Paises pais)
        {
            if (pais != null)
            {
                PaisesFrmCadastro frm = new PaisesFrmCadastro();
                frm.ConhecaObj(pais);
                frm.Text = "Consultar País";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.ShowDialog();
            }
        }
    }
}
