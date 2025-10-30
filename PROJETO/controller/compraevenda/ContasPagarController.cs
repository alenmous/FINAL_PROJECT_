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
    public class ContasPagarController
    {
        private ContasPagarDAO contasPagarDAO = new ContasPagarDAO();

        public string AdicionarContaPagar(ContasPagar contaPagar)
        {
            return contasPagarDAO.AdicionarContaPagar(contaPagar);
        }
        public string AtualizarContaPagar(ContasPagar contaPagar)
        {
            return contasPagarDAO.AtualizarContaPagar(contaPagar);
        }
        public string Quitar(ContasPagar contaPagar)
        {
            return contasPagarDAO.Quitar(contaPagar);
        }
        public bool CancelarParcela(ContasPagar contaPagar)
        {
            return contasPagarDAO.CancelarParcela(contaPagar);
        }
        public bool ExcluirContaPagar(int numNFC, int modeloNFC, int serieNFC, int numFornecedor, int numParcela)
        {
            return contasPagarDAO.ExcluirContaPagar(numNFC, modeloNFC, serieNFC, numFornecedor, numParcela);
        }
        public ContasPagar BuscarContaPagar(int numNFC, int modeloNFC, int serieNFC, int numFornecedor, int numParcela)
        {
            return contasPagarDAO.BuscarContaPagar(numNFC, modeloNFC, serieNFC, numFornecedor, numParcela);
        }
        public List<ContasPagar> BuscarContasPorNomeFornecedor(string nome)
        {
            return contasPagarDAO.BuscarContasPorNomeFornecedor(nome);
        }
        public List<ContasPagar> BuscarContas(int numNFC, int modeloNFC, int serieNFC, int numFornecedor, int ParcelaNFC)
        {
            return contasPagarDAO.BuscarContas(numNFC, modeloNFC, serieNFC, numFornecedor, ParcelaNFC);
        }
        public bool VerificarExistenciaDeCompra(int numNFC, int modeloNFC, int serieNFC, int numFornecedor)
        {
            return contasPagarDAO.VerificarExistenciaDeNota(numNFC, modeloNFC, serieNFC, numFornecedor);
        }
        public string VerificarContasAPagar(int numNFC, int modeloNFC, int serieNFC, int numFornecedor)
        {
            List<ContasPagar> contasVerificadas = contasPagarDAO.ListarContasAPagarPorNumero(numNFC, modeloNFC, serieNFC, numFornecedor);

            foreach (ContasPagar conta in contasVerificadas)
            {
                if (conta.Situacao != "PAGO")
                {
                    return "NOT";
                }
            }
            return "OK";
        }
        public List<ContasPagar> ListarContasPorNota(int numNFC, int modeloNFC, int serieNFC, int numFornecedor)
        {
            // Presumimos que ListarContasAPagarPorNumero (no DAO) busca TODAS as parcelas
            // com base apenas nos dados da nota (NFC, modelo, serie, fornecedor).
            return contasPagarDAO.ListarContasAPagarPorNumero(numNFC, modeloNFC, serieNFC, numFornecedor);
        }
        public List<ContasPagar> VerificarListaContasAPagar(int numNFC, int modeloNFC, int serieNFC, int numFornecedor)
        {
            // Chama o método DAL para listar as contas a pagar com base nos parâmetros fornecidos
            List<ContasPagar> contasVerificadas = contasPagarDAO.ListarContasAPagarPorNumero(numNFC, modeloNFC, serieNFC, numFornecedor);

            // Cria uma nova lista para armazenar as contas que não estão pagas
            List<ContasPagar> contasNaoPagas = new List<ContasPagar>();

            // Itera sobre a lista de contas verificadas
            foreach (ContasPagar conta in contasVerificadas)
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
        public List<ContasPagar> ListarContasPagar(string status)
        {
            string novoStatus = alterStatus(status);
            return contasPagarDAO.ListarContasPagar(novoStatus);
        }
        public List<ContasPagar> ListarContasPagarComData(string status, DateTime DataInicio, DateTime DataFim, string TipoData)
        {
            return contasPagarDAO.ListarContasPagarComData(status, DataInicio, DataFim, TipoData);
        }
        public List<ContasPagar> ListarTodasContasPagar()
        {
            return contasPagarDAO.ListarTodasContasPagar();
        }
        public List<ContasPagar> Pesquisar(string pesquisa, string status)
        {
            string novoStatus = alterStatus(status);
            return contasPagarDAO.Pesquisar(pesquisa, status);
        }
        private string alterStatus(string status)
        {
            string statusConvertido = "";
            if (status == "A")
                statusConvertido = "A PAGAR";
            else if (status == "P")
                statusConvertido = "PAGO";
            else if (status == "T")
                statusConvertido = "TODOS";
            else if (status == "I")
                statusConvertido = "CANCELADA";
            return statusConvertido;
        }
        public void Incluir()
        {
            ContasPagarFrmCadastro frm = new ContasPagarFrmCadastro();
            frm.Text = "Contas a Pagar";
            frm.ShowDialog();
        }
        public void Alterar(ContasPagar contaPagar)
        {
            if (contaPagar != null)
            {
                ContasPagarFrmCadastro frm = new ContasPagarFrmCadastro();
                frm.ConhecaObj(contaPagar);
                frm.Text = "Contas a Pagar";
                frm.CarregarCampos();
                frm.ShowDialog();
            }

        }
        public void AlterarDados(ContasPagar contaPagar)
        {
            if (contaPagar != null)
            {
                ContasPagarFrmCadastro frm = new ContasPagarFrmCadastro();
                frm.ConhecaObj(contaPagar);
                frm.Text = "Alteração de contas a pagar";
                frm.CarregarCampos();
                frm.btnSalvar.Text = "Alterar";
                frm.txtTotalPago.Enabled = false;
                frm.dtBaixa.Enabled = false;
                frm.ShowDialog();
            }

        }
        public void Excluir(ContasPagar contaPagar)
        {
           
        }
        public void Visualizar(ContasPagar contaPagar)
        {
            if (contaPagar != null)
            {
                ContasPagarFrmCadastro frm = new ContasPagarFrmCadastro();
                frm.ConhecaObj(contaPagar);
                frm.Text = "Contas a Pagar";
                frm.CarregarCampos();
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }
    }
}
