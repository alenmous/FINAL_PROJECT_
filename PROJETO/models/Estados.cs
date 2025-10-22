using PROJETO.models.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.models
{
    public class Estados : Pai
    {
        public string Estado { get; set; } = "";
        public string UF { get; set; } = "";
        public Paises OPais { get; set; } = new Paises();
        public string StatusEstado { get; set; } = "";

        public Estados() : base() { }

        public Estados(int id, string estado, string uf, Paises oPais, DateTime dataUltAlteracao, DateTime dataCriacao, string status)
            : base(id, dataCriacao, dataUltAlteracao)
        {
            Estado = estado;
            UF = uf;
            OPais = oPais;
            StatusEstado = status;
        }
    }
}