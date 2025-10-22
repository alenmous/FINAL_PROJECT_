using PROJETO.dao.compraevenda;
using PROJETO.models.compraevenda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.controller.compraevenda
{
    public class ItensCompraController
    {
        private ItensCompraDAO itensCompraDAO = new ItensCompraDAO();
        private ItemCompra item = new ItemCompra();


        public bool AdicionarItemCompra(ItemCompra itemCompra)
        {
            return itensCompraDAO.AdicionarItemCompra(itemCompra);
        }

        public ItemCompra BuscarItemCompraPorChave(int numNFC, int modeloNFC, int serieNFC, int idFornecedor, int idProduto)
        {
            return itensCompraDAO.BuscarItemCompraPorChave(numNFC, modeloNFC, serieNFC, idFornecedor, idProduto);
        }

        public List<ItemCompra> BuscarItemCompraPorChave2(int numNFC, int modeloNFC, int serieNFC, int idFornecedor)
        {
            return itensCompraDAO.BuscarItemCompraPorChave2(numNFC, modeloNFC, serieNFC, idFornecedor);
        }

        public List<ItemCompra> ListarItensCompra()
        {
            return itensCompraDAO.ListarItensCompra();
        }

    }
}
