using PROJETO.models.bases;
using System;

namespace PROJETO.models
{
    public class Cidades : Pai
    {
        public string Cidade { get; set; } = "";
        public string DDD { get; set; } = "";
        public Estados OEstado { get; set; } = new Estados();
        public string StatusCidade { get; set; } = "";

        public Cidades() : base() { }

        public Cidades(int id, string cidade, string ddd, Estados oEstado, DateTime dataUltAlteracao, DateTime dataCriacao, string status)
            : base(id, dataCriacao, dataUltAlteracao)
        {
            Cidade = cidade;
            DDD = ddd;
            OEstado = oEstado;
            StatusCidade = status;
        }
    }
}
