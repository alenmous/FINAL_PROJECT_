using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO.models.bases
{
    public class Pessoa : Pai
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        public Pessoa() : base() { }

        public Pessoa(int id, string outros, string nome, string apelido, string rg, string cpf, string cnpj,
                        string email, string telefone, string celular,
                        DateTime dataNasc, DateTime dataUltAlteracao,
                        DateTime dataCriacao) : base(id, dataCriacao, dataUltAlteracao)
        {
            Nome = nome;
            Apelido = apelido;
            RG = rg;
            CPF = cpf;
            CNPJ = cnpj;
            Email = email;
            Telefone = telefone;
            Celular = celular;

        }
    }

}
