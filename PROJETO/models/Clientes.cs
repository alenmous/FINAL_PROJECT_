using PROJETO.models.bases;
using System;
using System.Collections.Generic;

namespace PROJETO.models
{
    public class Clientes : Pessoa
    {
        public string StatusCliente { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public Cidades Cidade { get; set; } = new Cidades();
        public CondicaoPagamento CondicaoPagamento { get; set; } = new CondicaoPagamento();
        public DateTime DataNasc { get; set; } = DateTime.Now;
        public string TipoCliente { get; set; }
        public string Outros { get; set; }
        public string Sexo { get; set; }

        public Clientes() : base() { }

        public Clientes(int id, string outros, string sexo, string statusCliente, string cep, string endereco, int numero,
                        CondicaoPagamento condicao, string complemento, string bairro, Cidades cidade,
                        DateTime dataNasc, DateTime dataUltAlteracao, DateTime dataCriacao)
            : base(id, outros, null, null, null, null, null, null, null, null, dataNasc, dataUltAlteracao, dataCriacao)
        {
            StatusCliente = statusCliente;
            CEP = cep;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            DataNasc = dataNasc;
            CondicaoPagamento = condicao;
            Outros = outros;
            Sexo = sexo;
        }
    }
}
