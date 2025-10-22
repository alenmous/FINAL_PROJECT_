using PROJETO.models.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.models
{
    public class CondicaoPagamento : Pai
    {
        public string Condicao { get; set; } = "";
        public int Parcelas { get; set; } = 0;
        public decimal Taxa { get; set; } = 0;
        public decimal Multa { get; set; } = 0;
        public decimal Desconto { get; set; } = 0;
        public string Status { get; set; } = "";
        public List<Parcela> uParcelas { get; set; } = new List<Parcela>();

        public CondicaoPagamento() : base() { }

        public CondicaoPagamento(int id, string condicao, int parcelas, decimal taxa, decimal multa, decimal desconto,
            string status, DateTime dataCriacao, DateTime dataUltAlteracao)
            : base(id, dataCriacao, dataUltAlteracao)
        {
            Condicao = condicao;
            Parcelas = parcelas;
            Taxa = taxa;
            Multa = multa;
            Desconto = desconto;
            Status = status;
        }
    }
}

