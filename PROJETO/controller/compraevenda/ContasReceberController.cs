using PROJETO.dao.compraevenda;
using PROJETO.models.compraevenda;
using PROJETO.views.compraevenda;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.controller.compraevenda
{
    public class ContasReceberController
    {
        private ContasReceberDAO ContasReceberDAO = new ContasReceberDAO();

        public string AdicionarContaReceber(ContasReceber contaReceber)
        {
            return ContasReceberDAO.AdicionarContaReceber(contaReceber);
        }

        public string AtualizarContaReceber(ContasReceber contaReceber)
        {
            return ContasReceberDAO.AtualizarContaReceber(contaReceber);
        }

        public string Quitar(ContasReceber contaReceber)
        {
            return ContasReceberDAO.Quitar(contaReceber);
        }

        public bool CancelarParcela(ContasReceber contaReceber)
        {
            return ContasReceberDAO.CancelarParcela(contaReceber);
        }
        public List<ContasReceber> ListarContasReceber(string status)
        {
            string novoStatus = alterStatus(status);
            return ContasReceberDAO.ListarContasReceber(novoStatus);
        }
        public List<ContasReceber> BuscarContas(int numNFC, int modeloNFC, int serieNFC, int ParcelaNFC)
        {
            return ContasReceberDAO.BuscarContas(numNFC, modeloNFC, serieNFC, ParcelaNFC);
        }
        public ContasReceber BuscarContasReceber(int numNFC, int modeloNFC, int serieNFC, int ParcelaNFC)
        {
            return ContasReceberDAO.BuscarContaReceber(numNFC, modeloNFC, serieNFC, ParcelaNFC);
        }
        public List<ContasReceber> ListarContasReceberComData(string status, DateTime DataInicio, DateTime DataFim, string TipoData)
        {
            return ContasReceberDAO.ListarContasReceberComData(status, DataInicio, DataFim, TipoData);
        }
        private string alterStatus(string status)
        {
            string statusConvertido = "";
            if (status == "A")
                statusConvertido = "A RECEBER";
            else if (status == "P")
                statusConvertido = "PAGO";
            else if (status == "T")
                statusConvertido = "TODOS";
            else if (status == "I")
                statusConvertido = "CANCELADA";
            return statusConvertido;
        }

        public List<ContasReceber> VerificarListaContasAReceber(int numNFC, int modeloNFC, int serieNFC, int numFornecedor)
        {
            List<ContasReceber> contasVerificadas = ContasReceberDAO.ListarContasAReceberPorNumero(numNFC, modeloNFC, serieNFC, numFornecedor);

            List<ContasReceber> contasNaoPagas = new List<ContasReceber>();

            // Itera sobre a lista de contas verificadas
            foreach (ContasReceber conta in contasVerificadas)
            {
                // Se a conta não estiver paga, adiciona à lista de contas não pagas
                if (conta.Situacao != "PAGO")
                {
                    contasNaoPagas.Add(conta);
                }
            }

            // Retorna a lista de contas não pagas
            return contasNaoPagas;
        }
        public void Incluir()
        {
            ContasReceberFrmCadastro frm = new ContasReceberFrmCadastro();
            frm.Text = "Contas a Receber";
            frm.ShowDialog();
        }

        public void Alterar(ContasReceber contaReceber)
        {
            if (contaReceber != null)
            {
                ContasReceberFrmCadastro frm = new ContasReceberFrmCadastro();
                frm.ConhecaObj(contaReceber);
                frm.Text = "Contas a Receber";
                frm.CarregarCampos();
                frm.ShowDialog();
            }
        }
        public void AlterarDados(ContasReceber contaReceber)
        {
            if (contaReceber != null)
            {
                ContasReceberFrmCadastro frm = new ContasReceberFrmCadastro();
                frm.ConhecaObj(contaReceber);
                frm.CarregarCampos();
                frm.Text = "Alteração de contas a receber";
                frm.btnSalvar.BackColor = Color.BurlyWood;
                frm.btnSalvar.Text = "Alterar";
                frm.txtTotalPago.Enabled = false;
                frm.dtBaixa.Enabled = false;
                frm.ShowDialog();
            }
        }

        public void Excluir(ContasReceber contaReceber)
        {
            // Implemente a lógica para abrir o formulário de exclusão de contas a receber
        }

        public void Visualizar(ContasReceber contaReceber)
        {
            if (contaReceber != null)
            {
                ContasReceberFrmCadastro frm = new ContasReceberFrmCadastro();
                frm.ConhecaObj(contaReceber);
                frm.Text = "Contas a Receber";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }
        
    }
}
