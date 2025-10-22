using PROJETO.dao.compraevenda;
using PROJETO.models.compraevenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.controller.compraevenda
{
    public class ItensVendaController
    {
        private ItensVendaDAO ItensVendaDAO = new ItensVendaDAO();

        public bool AdicionarItemVenda(ItemVenda itemVenda)
        {
            return ItensVendaDAO.AdicionarItemVenda(itemVenda);
        }
        public ItemVenda BuscarItemVendaPorChave(int numNF, int modeloNF, int serieNF, int idCliente, int idProduto, string tipoItem)
        {
            return ItensVendaDAO.BuscarItemVendaPorChave(numNF, modeloNF, serieNF, idCliente, idProduto, tipoItem);
        }
        public List<ItemVenda> BuscarItensVendaPorChave2(int numNF, int modeloNF, int serieNF)
        {
            return ItensVendaDAO.BuscarItensVendaPorChave2(numNF, modeloNF, serieNF);
        }
        public List<ItemVenda> ListarItensVenda()
        {
            return ItensVendaDAO.ListarItensVenda();
        }
    }
}
