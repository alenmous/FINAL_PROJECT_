using System;

namespace PROJETO.models.compraevenda
{
    public class ItemVenda
    {
        public int NumNfv { get; set; }
        public int ModeloNfv { get; set; }
        public int SerieNfv { get; set; }
        public Clientes Cliente { get; set; }
        public string Descricao { get; set; }
        public int IdItem { get; set; }
        public string TipoItem { get; set; }
        public int QtdItem { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal TotalItem { get; set; }
        public decimal? Desconto { get; set; }
        public DateTime DataCriacao { get; set; }

        public ItemVenda()
        {
            NumNfv = 0;
            ModeloNfv = 0;
            SerieNfv = 0;
            Cliente = new Clientes();
            IdItem = 0;
            TipoItem = "";
            QtdItem = 1; // Por padrão, considerando quantidade 1 para serviços
            PrecoUnitario = 0.0m;
            TotalItem = 0.0m;
            Desconto = null;
            DataCriacao = DateTime.MinValue;
            Descricao = "";
        }

        public ItemVenda(string descricao, int numNfv, int modeloNfv, int serieNfv, Clientes cliente, int idItem, string tipoItem,
                         int qtdItem, decimal precoUnitario, decimal totalItem, decimal? desconto, DateTime dataCriacao)
        {
            NumNfv = numNfv;
            ModeloNfv = modeloNfv;
            SerieNfv = serieNfv;
            Cliente = cliente;
            IdItem = idItem;
            TipoItem = tipoItem;
            QtdItem = qtdItem;
            PrecoUnitario = precoUnitario;
            TotalItem = totalItem;
            Desconto = desconto;
            DataCriacao = dataCriacao;
            Descricao = descricao;
        }
    }
}
