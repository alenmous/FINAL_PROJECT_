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
    public class CondicaoPagamentoController
    {
        private CondicaoPagamento CondicaoPagamento = new CondicaoPagamento();

        private CondicaoPagamentoDAO condicaoPagamentoDAO = new CondicaoPagamentoDAO();

        public bool AdicionarCondicaoPagamento(CondicaoPagamento condicao)
        {
            CondicaoPagamento = condicao;
            return condicaoPagamentoDAO.AdicionarCondicaoPagamento(CondicaoPagamento);
        }
        public bool AtualizarCondicaoPagamento(CondicaoPagamento condicao)
        {
            CondicaoPagamento = condicao;
            return condicaoPagamentoDAO.AtualizarCondicaoPagamento(CondicaoPagamento);
        }
        public bool AtivarOuDesativarCondicaoPagamento(CondicaoPagamento condicao)
        {
            return condicaoPagamentoDAO.AtivarOuDesativarCondicaoPagamento(condicao);
        }

        public int ObterProximoIdCondicaoPagamento()
        {
            return condicaoPagamentoDAO.ObterProximoIdCondicaoPagamento();
        }
        public bool ExcluirCondicaoPagamento(int condicaoPagamentoId)
        {
            return condicaoPagamentoDAO.ExcluirCondicaoPagamento(condicaoPagamentoId);
        }
        public CondicaoPagamento BuscarCondicaoPagamentoPorId(int id)
        {
            return condicaoPagamentoDAO.BuscarCondicaoPagamentoPorId(id);
        }
        public List<CondicaoPagamento> ListarCondicoesPagamento(string status)
        {
            return condicaoPagamentoDAO.ListarCondicoesPagamento(status);
        }

        public List<CondicaoPagamento> Pesquisar(string filtro, string status)
        {
            return condicaoPagamentoDAO.Pesquisar(filtro, status);
        }
        
        public void Incluir()
        {
            CondicaoPagamentoFrmCadastro frm = new CondicaoPagamentoFrmCadastro();
            frm.Text = "Incluir Condição de Pagamento";
            frm.btnLimpar.Visible = true;
            frm.btnExcluir.Visible = true;
            frm.DefinirProximoIdCondicaoPagamento();
            frm.ShowDialog();
        }
        public void Alterar(CondicaoPagamento condicaoPagamento)
        {
            if (condicaoPagamento != null)
            {
                CondicaoPagamentoFrmCadastro frm = new CondicaoPagamentoFrmCadastro();
                frm.ConhecaObj(condicaoPagamento);
                frm.Text = "Alterar Condição de Pagamento";
                frm.btnSalvar.Text = "Alterar";
                if(condicaoPagamento.Status == "A")
                {
                    frm.btnDesativar.Text = "DESATIVAR";
                    frm.btnDesativar.Visible = true;
                }
                else
                {
                    frm.btnDesativar.Text = "ATIVAR";
                    frm.btnDesativar.Visible = false;
                }   
                frm.btnDesativar.Visible = true;
                frm.btnLimpar.Visible = true;
                frm.btnExcluir.Visible = true;
                frm.Popular(condicaoPagamento);
                frm.ShowDialog();
            }
        }
        public void Excluir(CondicaoPagamento condicaoPagamento)
        {
            if (condicaoPagamento != null)
            {
                CondicaoPagamentoFrmCadastro frm = new CondicaoPagamentoFrmCadastro();
                frm.ConhecaObj(condicaoPagamento);
                frm.Text = "Excluir Condição de Pagamento";
                frm.btnSalvar.Text = "Excluir";
                frm.Popular(condicaoPagamento);
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }

        public void Visualizar(CondicaoPagamento condicaoPagamento)
        {
            if (condicaoPagamento != null)
            {
                CondicaoPagamentoFrmCadastro frm = new CondicaoPagamentoFrmCadastro();
                frm.ConhecaObj(condicaoPagamento);
                frm.Text = "Consultar Condição de Pagamento";
                frm.btnSalvar.Enabled = false;
                frm.Popular(condicaoPagamento);
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }     
    }
}
