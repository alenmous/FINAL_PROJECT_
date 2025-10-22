using PROJETO.models.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.models
{
    public class Parcela : Pai
    {
        public CondicaoPagamento Condicao { get; set; } = new CondicaoPagamento();
        public FormaPagamento Forma { get; set; } = new FormaPagamento();
        public int NumParcela { get; set; } = 0;
        public int DiasTotais { get; set; } = 0;
        public decimal Porcentagem { get; set; } = 0.0m;

        public Parcela() : base() { }

        public Parcela(CondicaoPagamento condicao, int numParcela, FormaPagamento forma, int diasTotais, decimal porcentagem,
            DateTime dataCriacao, DateTime dataUltAlteracao)
            : base(0, dataCriacao, dataUltAlteracao)
        {
            Condicao = condicao;
            NumParcela = numParcela;
            Forma = forma;
            DiasTotais = diasTotais;
            Porcentagem = porcentagem;
        }
    }
}
