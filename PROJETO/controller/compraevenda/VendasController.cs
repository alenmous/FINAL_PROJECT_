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
    public class VendasController
    {
        private VendasDAO vendasDAO = new VendasDAO();

        public bool AdicionarVenda(Venda venda)
        {
            return vendasDAO.AdicionarVenda(venda);
        }

        public bool CancelarVenda(Venda venda)
        {
            return vendasDAO.CancelarVenda(venda);
        }

        public Venda BuscarVendaPorChave(int numNF, int modeloNF, int serieNF, int idCliente)
        {
            return vendasDAO.BuscarVendaPorChave(numNF, modeloNF, serieNF, idCliente);
        }

        public bool VerificarSeVendaExiste(int numNF, int modeloNF, int serieNF, int idCliente)
        {
            try
            {
                return vendasDAO.ExisteVendaPorChave(numNF, modeloNF, serieNF, idCliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public List<Venda> BuscarListaVendaPorChave(int numNF, int modeloNF, int serieNF)
        {
            return vendasDAO.BuscarListaVendasPorChave(numNF, modeloNF, serieNF);
        }

        public List<Venda> ListarVendas(string statusCancelada)
        {
            bool cancelada = false;
            if (statusCancelada == "I")
                cancelada = true;
            return vendasDAO.ListarVendas(cancelada);
        }

        public List<Venda> ListarVendas(DateTime? dataInicio, DateTime? dataFim, bool? cancelada, string nomeCliente, string tipoData)
        {
            return vendasDAO.ListarVendas(dataInicio, dataFim, cancelada, nomeCliente, tipoData);
        }

        public int BuscarNFE(string tipo)
        {
            return vendasDAO.BuscarNFe(tipo);
        }
        public void Incluir()
        {
            VendaFrmCadastro frm = new VendaFrmCadastro();
            frm.Text = "Realizar nova venda";
            frm.BuscarNFE();
            frm.ShowDialog();
        }

        public void Visualizar(Venda venda)
        {
            if (venda != null)
            {
                VendaFrmCadastro frm = new VendaFrmCadastro();
                frm.Text = "Consultar uma Venda";
                frm.pnCliente.Enabled = false;
                frm.btnSair.Text = "Sair";
                frm.btnFinalizaCondicao.Enabled = false;
                frm.Popular(venda);
                frm.DesabilitarBotoes();
                frm.ShowDialog();
            }
        }

        public void CancelarNota(Venda venda)
        {
            if (venda != null)
            {
                VendaFrmCadastro frm = new VendaFrmCadastro();
                frm.Text = "Cancelar Nota";
                if (venda.DataCancelamento != null)
                    frm.btnSalvar.Text = "Cancelar";
                frm.btnFinalizaCondicao.Enabled = false;
                frm.Popular(venda);
                frm.ShowDialog();
            }
        }
    }
}
