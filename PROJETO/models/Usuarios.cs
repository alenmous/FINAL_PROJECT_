using PROJETO.models.bases;
using System;

namespace PROJETO.models
{
    public class Usuarios : Pessoa
    {
        public string StatusUsuario { get; set; } = "";
        public string Sexo { get; set; } = "";
        public string Senha { get; set; } = "";
        public string CEP { get; set; } = "";
        public string Endereco { get; set; } = "";
        public int Numero { get; set; } = 0;
        public string Complemento { get; set; } = "";
        public string Bairro { get; set; } = "";
        public DateTime DataNascimento { get; set; } = DateTime.Now;
        public Cidades Cidade { get; set; } = new Cidades();
        public Cargos Cargo { get; set; } = new Cargos();
        public DateTime? Demissao { get; set; } = DateTime.Now;

        public Usuarios() : base() { }

        public Usuarios(int id, string statusUsuario, string sexo, string senha, string cep, string endereco, int numero,
           string complemento, string bairro, DateTime dataNasc, Cidades cidade, Cargos cargo, string nome, string apelido,
           string rg, string cpf, string cnpj, string email, string telefone, string celular, string outros,
           DateTime dataCriacao, DateTime dataUltAlteracao,DateTime demissao)
           : base(id, outros, nome, apelido, rg, cpf, cnpj, email, telefone, celular, dataNasc, dataUltAlteracao, dataCriacao)
        {
            StatusUsuario = statusUsuario;
            Sexo = sexo;
            Senha = senha;
            CEP = cep;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            DataNascimento = dataNasc;
            Cidade = cidade;
            Cargo = cargo;
            Demissao = demissao;
        }
    }
}
