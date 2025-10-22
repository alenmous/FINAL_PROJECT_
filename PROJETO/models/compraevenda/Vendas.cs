using PROJETO.models.bases;
using System;
using System.Collections.Generic;

namespace PROJETO.models.compraevenda
{
    public class Venda : Pai
    {
        public int NumNfv { get; set; }
        public int ModeloNfv { get; set; }
        public int SerieNfv { get; set; }
        public Clientes Cliente { get; set; }
        public CondicaoPagamento CondicaoPagamento { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorSeguro { get; set; }
        public decimal ValorOutrasDespesas { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public List<ItemVenda> ItensVenda { get; set; }
        public List<ContasReceber> ContasReceber { get; set; }

        public Venda() : base()
        {
            Cliente = new Clientes();
            CondicaoPagamento = new CondicaoPagamento();
            NumNfv = 0;
            ModeloNfv = 0;
            SerieNfv = 0;
            ValorTotal = 0.0m;
            ValorFrete = 0.0m;
            ValorSeguro = 0.0m;
            ValorOutrasDespesas = 0.0m;
            DataSaida = DateTime.MinValue;
            DataEmissao = DateTime.MinValue;
            DataCancelamento = null;
            ItensVenda = new List<ItemVenda>();
        }

        public Venda(List<ItemVenda> itensVenda, int numNfv, int modeloNfv, int serieNfv, Clientes cliente, CondicaoPagamento condicaoPagamento,
                     decimal valorTotal, decimal valorFrete, decimal valorSeguro, decimal valorOutrasDespesas,
                     DateTime dataSaida, DateTime dataEmissao, DateTime? dataCancelamento, DateTime dataCriacao, DateTime dataUltAlteracao)
            : base(0, dataCriacao, dataUltAlteracao)
        {
            NumNfv = numNfv;
            ModeloNfv = modeloNfv;
            SerieNfv = serieNfv;
            Cliente = cliente;
            CondicaoPagamento = condicaoPagamento;
            ValorTotal = valorTotal;
            ValorFrete = valorFrete;
            ValorSeguro = valorSeguro;
            ValorOutrasDespesas = valorOutrasDespesas;
            DataSaida = dataSaida;
            DataEmissao = dataEmissao;
            DataCancelamento = dataCancelamento;
            ItensVenda = itensVenda;
        }
    }
}
