using PROJETO.models.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.models
{
    public class Paises : Pai
    {
        public string Pais { get; set; } = "";
        public string Sigla { get; set; } = "";
        public string Ddi { get; set; } = "";
        public string StatusPais { get; set; } = "";

        public Paises() : base() { }

        public Paises(int id, string ddi, string pais, string sigla, DateTime dataUltAlteracao, DateTime dataCriacao, string status)
            : base(id, dataCriacao, dataUltAlteracao)
        {
            Ddi = ddi;
            Pais = pais;
            Sigla = sigla;
            StatusPais = status;
        }
    }
}
