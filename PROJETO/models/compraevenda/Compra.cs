using PROJETO.models.bases;
using System;
using System.Collections.Generic;

namespace PROJETO.models.compraevenda
{
    public class Compra : Pai
    {
        public int NumNFC { get; set; }
        public int ModeloNFC { get; set; }
        public int SerieNFC { get; set; }
        public Fornecedores Fornecedor { get; set; } = new Fornecedores();
        public CondicaoPagamento Condicao { get; set; } = new CondicaoPagamento();
        public decimal ValorTotal { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorSeguro { get; set; }
        public decimal ValorOutrasDespesas { get; set; }
        public DateTime DataChegada { get; set; } = DateTime.Now;
        public DateTime DataEmissao { get; set; } = DateTime.Now;
        public DateTime DataCancelamento { get; set; } = DateTime.Now;
        public List<ItemCompra> ItensCompra { get; set; } = new List<ItemCompra>();
        public List<ContasPagar> ContasPagar { get; set; } = new List<ContasPagar>();
        public string StatusCompra { get; set; } = string.Empty;
        public int EstoqueAnterior { get; set; }
        public decimal PrecoAnterior { get; set; }

        public Compra() : base() { }

        public Compra(int estoqueAnterior, decimal precoAnterior, string statusCompra, int numNFC, int modeloNFC, int serieNFC,
                      List<ItemCompra> itensCompra, Fornecedores fornecedor, CondicaoPagamento condicao, decimal valorTotal,
                      decimal valorFrete, decimal valorSeguro, decimal valorOutrasDespesas, DateTime dataChegada,
                      DateTime dataEmissao, DateTime dataCancelamento, DateTime dataCriacao)
            : base(dataCriacao)
        {
            EstoqueAnterior = estoqueAnterior;
            PrecoAnterior = precoAnterior;
            StatusCompra = statusCompra;
            NumNFC = numNFC;
            ModeloNFC = modeloNFC;
            SerieNFC = serieNFC;
            ItensCompra = itensCompra ?? new List<ItemCompra>();
            Fornecedor = fornecedor ?? new Fornecedores();
            Condicao = condicao ?? new CondicaoPagamento();
            ValorTotal = valorTotal;
            ValorFrete = valorFrete;
            ValorSeguro = valorSeguro;
            ValorOutrasDespesas = valorOutrasDespesas;
            DataChegada = dataChegada;
            DataEmissao = dataEmissao;
            DataCancelamento = dataCancelamento;
        }
    }
}