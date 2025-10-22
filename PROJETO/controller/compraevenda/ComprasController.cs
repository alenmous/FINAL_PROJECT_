using PROJETO.dao.compraevenda;
using PROJETO.models.compraevenda;
using PROJETO.views.compraevenda;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETO.controller.compraevenda
{
    public class ComprasController
    {
        private ComprasDAO comprasDAO = new ComprasDAO();


        public bool AdicionarCompra(Compra compra)
        {
            return comprasDAO.AdicionarCompra(compra);
        }
        public bool CancelarCompra(Compra aCompra)
        {
            return comprasDAO.CancelarCompra(aCompra);
        }
        public string BaixaCompra(Compra aCompra)
        {
            return comprasDAO.BaixaCompra(aCompra);
        }
        public Compra BuscarCompraPorChave(int numNFC, int modeloNFC, int serieNFC, int idFornecedor)
        {
            return comprasDAO.BuscarCompraPorChave(numNFC, modeloNFC, serieNFC, idFornecedor);
        }
        public bool VerificarSeCompraExiste(int numNFC, int modeloNFC, int serieNFC, int idFornecedor)
        {
            try
            {
                return comprasDAO.ExisteCompraPorChave(numNFC, modeloNFC, serieNFC, idFornecedor);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public List<Compra> BuscarListaCompraPorChave(int numNFC, int modeloNFC, int serieNFC, int idFornecedor)
        {
            return comprasDAO.BuscarListaComprasPorChave(numNFC, modeloNFC, serieNFC, idFornecedor);
        }
        public List<Compra> ListarCompras(string statusCancelada)
        {
            bool cancelada = false;
            if (statusCancelada == "I")
                cancelada = true;
            return comprasDAO.ListarCompras(cancelada);
        }

        public List<Compra> ListarComprasPorFornecedor(int codFornecedor)
        {
            // filtrar, se a compra vier com status_compra = FINALIZADO então não entra no escopo de retorno .
            return comprasDAO.ListarComprasPorFornecedor(codFornecedor);
        }

        public List<Compra> Pesquisar(string pesquisa, string status)
        {
            // filtrar, se a compra vier com status_compra = FINALIZADO então não entra no escopo de retorno .
            return comprasDAO.Pesquisar(pesquisa, status);
        }

        public List<Compra> ListarCompras(DateTime? dataInicio, DateTime? dataFim, bool? Cancelada, string Fornecedor, string cbDatas)
        {
            return comprasDAO.ListarCompras(dataInicio, dataFim, Cancelada, Fornecedor, cbDatas);
        }

        public void Incluir()
        {
            ComprasFrmCadastro frm = new ComprasFrmCadastro();
            frm.Text = "Incluir Compra";
            frm.txtNumNFC.Focus();
            frm.txtNumNFC.Select();
            frm.ShowDialog();
        }

        public void Visualizar(Compra compra)
        {
            if (compra != null)
            {
                ComprasFrmCadastro frm = new ComprasFrmCadastro();
                frm.ConhecaObj(compra);
                frm.Text = "Consultar Compra";
                
                frm.Popular(compra);
                frm.BloquearCampos();
                frm.btnSalvar.Enabled = false;
                frm.ShowDialog();
            }
        }
        public void CancelarNota(Compra compra)
        {
            if (compra != null)
            {
                ComprasFrmCadastro frm = new ComprasFrmCadastro();
                frm.ConhecaObj(compra);
                frm.Text = "Cancelar Nota Nº "+ compra.NumNFC+compra.ModeloNFC+compra.SerieNFC+compra.Fornecedor.ID;

                if (compra.DataCancelamento != null)
                {
                    frm.btnSalvar.Text = "Cancelar";
                    frm.btnSalvar.BackColor = Color.Red;
                    frm.btnSalvar.Enabled = true;
                }
                   
                frm.Popular(compra);
                frm.BloquearCampos();
                frm.ShowDialog();
            }
        }

    }
}
