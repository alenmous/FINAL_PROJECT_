using System;

namespace PROJETO.models.compraevenda
{
    public class ContasPagar
    {
        public int NumNFC { get; set; } = 0;
        public int ModeloNFC { get; set; } = 0;
        public int SerieNFC { get; set; } = 0;
        public int NumParcela { get; set; } = 0;
        public Fornecedores Fornecedor { get; set; } = new Fornecedores();
        public CondicaoPagamento Condicao { get; set; } = new CondicaoPagamento();
        public decimal Valor { get; set; } = 0m;
        public string Situacao { get; set; } = string.Empty;
        public DateTime DataBaixa { get; set; } = DateTime.Now;
        public DateTime DataVencimento { get; set; } = DateTime.Now;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataUltAlteracao { get; set; } = DateTime.Now;
        public decimal Pagamento { get; set; } = 0m;
        public FormaPagamento FormaPagamento { get; set; } = new FormaPagamento();
        public decimal Taxa { get; set; } = 0m;
        public decimal Multa { get; set; } = 0m;
        public decimal Desconto { get; set; } = 0m;

        public ContasPagar() { }

        public ContasPagar(FormaPagamento forma, decimal pagamento, int numNFC, int modeloNFC, int serieNFC, int numParcela,
                            Fornecedores fornecedor, CondicaoPagamento condicao, decimal valor, string situacao,
                            DateTime dataBaixa, DateTime dataVencimento, DateTime dataCriacao, DateTime dataUltAlteracao,
                            decimal taxa, decimal multa, decimal desconto)
        {
            FormaPagamento = forma ?? new FormaPagamento();
            Pagamento = pagamento;
            NumNFC = numNFC;
            ModeloNFC = modeloNFC;
            SerieNFC = serieNFC;
            NumParcela = numParcela;
            Fornecedor = fornecedor ?? new Fornecedores();
            Condicao = condicao ?? new CondicaoPagamento();
            Valor = valor;
            Situacao = situacao ?? string.Empty;
            DataBaixa = dataBaixa;
            DataVencimento = dataVencimento;
            DataCriacao = dataCriacao;
            DataUltAlteracao = dataUltAlteracao;
            Taxa = taxa;
            Multa = multa;
            Desconto = desconto;
        }
    }
}