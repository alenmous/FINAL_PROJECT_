using PROJETO.models.bases;
using System;

namespace PROJETO.models
{
    public class Marca : Pai
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataUltAlteracao { get; set; }

        public Marca() : base()
        {
            Nome = string.Empty;
            Descricao = string.Empty;
            DataCriacao = DateTime.Now;
            DataUltAlteracao = DateTime.Now;
        }

        public Marca(int id, string nome, string descricao, DateTime dataCriacao, DateTime dataUltAlteracao)
            : base(id, dataCriacao, dataUltAlteracao)
        {
            Nome = nome;
            Descricao = descricao;
            DataCriacao = dataCriacao;
            DataUltAlteracao = dataUltAlteracao;
        }
    }
}
