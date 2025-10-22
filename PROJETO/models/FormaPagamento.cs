using PROJETO.models.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.models
{
    public class FormaPagamento : Pai
    {
        public string StatusForma { get; set; } = "";
        public string Forma { get; set; } = "";

        public FormaPagamento() : base() { }

        public FormaPagamento(int id, string statusForma, string forma, DateTime dataCriacao, DateTime dataUltAlteracao)
            : base(id, dataCriacao, dataUltAlteracao)
        {
            StatusForma = statusForma;
            Forma = forma;
        }
    }
}