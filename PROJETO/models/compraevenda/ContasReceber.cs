using PROJETO.models.bases;
using System;

namespace PROJETO.models.compraevenda
{
    public class ContasReceber : Pai
    {
        public int NumNFC { get; set; }
        public int ModeloNFC { get; set; }
        public int SerieNFC { get; set; }
        public int NumParcela { get; set; }
        public Clientes Cliente { get; set; }
        public CondicaoPagamento Condicao { get; set; }
        public decimal Valor { get; set; }
        public string Situacao { get; set; }
        public DateTime DataBaixa { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltAlteracao { get; set; }
        public decimal Pagamento { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public decimal Taxa { get; set; }
        public decimal Multa { get; set; }
        public decimal Desconto { get; set; }

        public ContasReceber()
        {
            NumNFC = 0;
            ModeloNFC = 0;
            SerieNFC = 0;
            NumParcela = 0;
            Cliente = new Clientes();
            Condicao = new CondicaoPagamento();
            Valor = 0m;
            Situacao = "";
            DataBaixa = DateTime.Now;
            DataVencimento = DateTime.Now;
            DataCriacao = DateTime.Now;
            DataUltAlteracao = DateTime.Now;
            Pagamento = 0m;
            FormaPagamento = new FormaPagamento();
        }

        public ContasReceber(FormaPagamento forma, decimal pagamento, int numNFC, int modeloNFC, int serieNFC, int numParcela, Clientes cliente, CondicaoPagamento condicao,
                             decimal valor, string situacao, DateTime dataBaixa, DateTime dataVencimento, DateTime dataCriacao, DateTime dataUltAlteracao,
                             decimal taxa, decimal multa, decimal desconto)
        {
            NumNFC = numNFC;
            ModeloNFC = modeloNFC;
            SerieNFC = serieNFC;
            NumParcela = numParcela;
            Cliente = cliente;
            Condicao = condicao;
            Valor = valor;
            Situacao = situacao;
            DataBaixa = dataBaixa;
            DataVencimento = dataVencimento;
            DataCriacao = dataCriacao;
            DataUltAlteracao = dataUltAlteracao;
            Pagamento = pagamento;
            FormaPagamento = forma;
            Taxa = taxa;
            Multa = multa;
            Desconto = desconto;
        }
    }
}
