using PROJETO.dao;
using PROJETO.models;
using PROJETO.views.cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.controller
{
    public class FormaPagamentoController
    {
        private FormaPagamentoDAO formaPagamentoDAO = new FormaPagamentoDAO();

        public string AdicionarFormaPagamento(FormaPagamento formaPagamento)
        {
            return formaPagamentoDAO.AdicionarFormaPagamento(formaPagamento);
        }

        public string AtualizarFormaPagamento(FormaPagamento formaPagamento)
        {
            return formaPagamentoDAO.AtualizarFormaPagamento(formaPagamento);
        }

        public bool ExcluirFormaPagamento(int formaPagamentoId)
        {
            return formaPagamentoDAO.ExcluirFormaPagamento(formaPagamentoId);
        }

        public FormaPagamento BuscarFormaPagamentoPorId(int id)
        {
            return formaPagamentoDAO.BuscarFormaPagamentoPorId(id);
        }

        public List<FormaPagamento> ListarFormasPagamento(string status)
        {
            return formaPagamentoDAO.ListarFormasPagamento(status);
        }

        public List<FormaPagamento> Pesquisar(string filtro, string status)
        {
            return formaPagamentoDAO.Pesquisar(filtro, status);
        }

        
        
        public void Incluir()
        {
            FormaPagamentoFrmCadastro frm = new FormaPagamentoFrmCadastro();
            frm.Text = "Incluir Forma de Pagamento";
            frm.cmbStatus.Text = "ATIVO";
            frm.cmbStatus.Enabled = false;
            frm.ShowDialog();
        }

        public void Alterar(FormaPagamento formaPagamento)
        {
            if (formaPagamento != null)
            {
                FormaPagamentoFrmCadastro frm = new FormaPagamentoFrmCadastro();
                frm.ConhecaObj(formaPagamento);
                frm.Text = "Alterar Forma de Pagamento";
                frm.CarregarCampos();
                frm.ShowDialog();
            }
        }

        public void Excluir(FormaPagamento formaPagamento)
        {
            if (formaPagamento != null)
            {
                FormaPagamentoFrmCadastro frm = new FormaPagamentoFrmCadastro();
                frm.ConhecaObj(formaPagamento);
                frm.Text = "Excluir Forma de Pagamento";
                frm.btnSalvar.Text = "Excluir";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }

        public void Visualizar(FormaPagamento formaPagamento)
        {
            if (formaPagamento != null)
            {
                FormaPagamentoFrmCadastro frm = new FormaPagamentoFrmCadastro();
                frm.ConhecaObj(formaPagamento);
                frm.Text = "Consultar Forma de Pagamento";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.ShowDialog();
            }
        }
        
    }
}
