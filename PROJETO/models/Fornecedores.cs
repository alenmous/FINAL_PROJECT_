using PROJETO.models.bases;
using System;

namespace PROJETO.models
{
    public class Fornecedores : Pessoa
    {
        public string StatusFornecedor { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataFundacao { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoEstadual { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string TipoFornecedor { get; set; }
        public Cidades Cidade { get; set; } = new Cidades();
        public CondicaoPagamento CondicaoPagamento { get; set; } = new CondicaoPagamento();

        public Fornecedores() : base()
        {
            StatusFornecedor = string.Empty;
            NomeFantasia = string.Empty;
            RazaoSocial = string.Empty;
            DataFundacao = DateTime.Now;
            InscricaoMunicipal = string.Empty;
            InscricaoEstadual = string.Empty;
            CEP = string.Empty;
            Endereco = string.Empty;
            Numero = 0;
            Complemento = string.Empty;
            Bairro = string.Empty;
            TipoFornecedor = string.Empty;
        }

        public Fornecedores(int id, string statusFornecedor, string nomeFantasia, string razaoSocial, DateTime dataFundacao,
            string inscricaoMunicipal, string inscricaoEstadual, string cep, string endereco, int numero, string complemento,
            string bairro, Cidades cidade, DateTime dataCriacao, DateTime dataUltAlteracao, CondicaoPagamento condicaoPagamento,
            string outros, string tipoFornecedor)
            : base(id, outros, nomeFantasia, null, null, null, null, null, null, null, dataFundacao, dataUltAlteracao, dataCriacao)
        {
            StatusFornecedor = statusFornecedor;
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            DataFundacao = dataFundacao;
            InscricaoMunicipal = inscricaoMunicipal;
            InscricaoEstadual = inscricaoEstadual;
            CEP = cep;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            TipoFornecedor = tipoFornecedor;
            CondicaoPagamento = condicaoPagamento;
        }
    }
}
